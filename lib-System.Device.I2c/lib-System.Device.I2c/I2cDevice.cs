using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace System.Device.I2c
{
    /// <summary>
    /// The communications channel to a device on an I2C bus.
    /// </summary>
    public class I2cDevice : IDisposable
    {

        // the device unique ID for the device is achieve by joining the I2C bus ID and the slave address
        // should be unique enough by encoding it as: (I2C bus number x 1000 + slave address)
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const int deviceUniqueIdMultiplier = 1000;

        // this is used as the lock object 
        // a lock is required because multiple threads can access the device
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private object _syncLock;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private readonly int _deviceId;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private readonly I2cConnectionSettings _connectionSettings;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool _disposed;

        private byte[] buff = new byte[1];

        /// <summary>
        /// The connection settings of a device on an I2C bus. The connection settings are immutable after the device is created
        /// so the object returned will be a clone of the settings object.
        /// </summary>
        public I2cConnectionSettings ConnectionSettings { get => new I2cConnectionSettings(_connectionSettings); }

        /// <summary>
        /// Reads a byte from the I2C device.
        /// </summary>
        /// <returns>A byte read from the I2C device.</returns>
        public byte ReadByte()
        {
            Read(buff);
            return buff[0];
        }

        /// <summary>
        /// Reads data from the I2C device.
        /// </summary>
        /// <param name="buffer">
        /// The buffer to read the data from the I2C device.
        /// The length of the buffer determines how much data to read from the I2C device.
        /// </param>
        public void Read(byte[] buffer)
        {
            NativeTransmit(null, buffer);
        }

        /// <summary>
        /// Writes a byte to the I2C device.
        /// </summary>
        /// <param name="value">The byte to be written to the I2C device.</param>
        public void WriteByte(byte value)
        {
            buff[0] = value;
            Write(buff);
        }

        /// <summary>
        /// Writes data to the I2C device.
        /// </summary>
        /// <param name="buffer">
        /// The buffer that contains the data to be written to the I2C device.
        /// The data should not include the I2C device address.
        /// </param>
        public void Write(byte[] buffer)
        {
            NativeTransmit(buffer, null);
        }

        /// <summary>
        /// Performs an atomic operation to write data to and then read data from the I2C bus on which the device is connected,
        /// and sends a restart condition between the write and read operations.
        /// </summary>
        /// <param name="writeBuffer">
        /// The buffer that contains the data to be written to the I2C device.
        /// The data should not include the I2C device address.</param>
        /// <param name="readBuffer">
        /// The buffer to read the data from the I2C device.
        /// The length of the buffer determines how much data to read from the I2C device.
        /// </param>
        public void WriteRead(byte[] writeBuffer, byte[] readBuffer)
        {
            NativeTransmit(writeBuffer, readBuffer);
        }

        /// <summary>
        /// Creates a communications channel to a device on an I2C bus running on the current platform
        /// </summary>
        /// <param name="settings">The connection settings of a device on an I2C bus.</param>
        /// <returns>A communications channel to a device on an I2C bus running on Windows 10 IoT.</returns>
        public static I2cDevice Create(I2cConnectionSettings settings)
        {
            return new I2cDevice(settings);
        }

        public I2cDevice(I2cConnectionSettings settings)
        {
            // generate a unique ID for the device by joining the I2C bus ID and the slave address, should be pretty unique
            // the encoding is (I2C bus number x 1000 + slave address)
            // i2cBus is an ASCII string with the bus name in format 'I2Cn'
            // need to grab 'n' from the string and convert that to the integer value from the ASCII code (do this by subtracting 48 from the char value)
            var controllerId = settings.BusId;
            var deviceId = (controllerId * deviceUniqueIdMultiplier) + settings.DeviceAddress;

            I2cController controller = I2cController.FindController(controllerId);

            if (controller == null)
            {
                // this controller doesn't exist yet, create it...
                controller = new I2cController(settings.BusId);
            }

            // check if this device ID already exists
            var device = FindDevice(controller, deviceId);

            if (device == null)
            {
                // device doesn't exist, create it...
                _connectionSettings = settings;             

                // save device ID
                _deviceId = deviceId;

                // call native init to allow HAL/PAL inits related with I2C hardware
                NativeInit();

                // ... and add this device
                controller.DeviceCollection.Add(this);

                _syncLock = new object();
            }
            else
            {
                // this device already exists, throw an exception
                throw new IOException($"I2C Device already in use");
            }

        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        /// <param name="disposing"><see langword="true"/> if explicitly disposing, <see langword="false"/> if in finalizer</param>
        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                bool disposeController = false;

                if (disposing)
                {
                    // get the controller
                    var controller = I2cController.FindController(_deviceId / deviceUniqueIdMultiplier);

                    if (controller != null)
                    {
                        // find device
                        var device = FindDevice(controller, _deviceId);

                        if (device != null)
                        {
                            // remove from device collection
                            controller.DeviceCollection.Remove(device);

                            // it's OK to also remove the controller, if there is no other device associated
                            if (controller.DeviceCollection.Count == 0)
                            {
                                I2cControllerManager.ControllersCollection.Remove(controller);

                                // flag this to native dispose
                                disposeController = true;
                            }
                        }
                    }
                }

                NativeDispose(disposeController);

                _disposed = true;
            }
        }

#pragma warning disable 1591
        ~I2cDevice()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            lock (_syncLock)
            {
                if (!_disposed)
                {
                    Dispose(true);

                    GC.SuppressFinalize(this);
                }
            }
        }

        internal static I2cDevice FindDevice(I2cController controller, int index)
        {
            for (int i = 0; i < controller.DeviceCollection.Count; i++)
            {
                if (((I2cDevice)controller.DeviceCollection[i])._deviceId == index)
                {
                    return (I2cDevice)controller.DeviceCollection[i];
                }
            }

            return null;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeInit();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeDispose(bool disposeController);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern I2cTransferResult NativeTransmit(byte[] writeBuffer, byte[] readBuffer);
    }
}