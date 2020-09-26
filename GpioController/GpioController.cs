using System.Collections;
using System.IO;
using Windows.Devices.Gpio;

namespace System.Device.Gpio
{
    /// <summary>
    /// Represents a general-purpose I/O (GPIO) controller.
    /// </summary>
    public sealed class GpioController : IDisposable
    {
        private Windows.Devices.Gpio.GpioController _controller;
        private static GpioPin[] _gpioPins;

        /// <summary>
        /// Initializes a new instance of the System.Device.Gpio.GpioController class that
        /// will use the logical pin numbering scheme as default.
        /// </summary>
        public GpioController()
        {
            GetController();
        }

        /// <summary>
        /// Initializes a new instance of the System.Device.Gpio.GpioController class that
        /// will use the specified numbering scheme. The controller will default to use the
        /// driver that best applies given the platform the program is executing on.
        /// </summary>
        /// <param name="numberingScheme">The numbering scheme used to represent pins provided by the controller.</param>
        public GpioController(PinNumberingScheme numberingScheme)
        {
            GetController();
            NumberingScheme = numberingScheme;
        }

        private void GetController()
        {
            _controller = Windows.Devices.Gpio.GpioController.GetDefault();
            if (_gpioPins == null)
            {
                _gpioPins = new GpioPin[_controller.PinCount];
            }
        }

        /// <summary>
        /// The numbering scheme used to represent pins provided by the controller.
        /// </summary>
        public PinNumberingScheme NumberingScheme { get; internal set; }

        /// <summary>
        /// The number of pins provided by the controller.
        /// </summary>
        public int PinCount => _controller.PinCount;

        /// <summary>
        /// Closes an open pin.
        /// </summary>
        /// <param name="pinNumber">The pin number in the controller's numbering scheme.</param>
        public void ClosePin(int pinNumber)
        {

            if (_gpioPins[pinNumber] != null)
            {
                _gpioPins[pinNumber].Dispose();
                _gpioPins[pinNumber] = null;
            }
            else
            {
                throw new IOException($"Port {pinNumber} is not open");
            }
        }

        /// <summary>
        /// Dispose the controller
        /// </summary>
        public void Dispose()
        {
            for (int i = 0; i < _gpioPins.Length; i++)
            {
                ClosePin(i);
            }
        }

        /// <summary>
        /// Gets the mode of a pin.
        /// </summary>
        /// <param name="pinNumber">The pin number in the controller's numbering scheme.</param>
        /// <returns>The mode of the pin.</returns>
        public PinMode GetPinMode(int pinNumber)
        {
            if (_gpioPins[pinNumber] == null)
            {
                throw new IOException($"Port {pinNumber} is not open");
            }

            var mode = _gpioPins[pinNumber].GetDriveMode();
            switch (mode)
            {
                case GpioPinDriveMode.Input:
                    return PinMode.Input;
                case GpioPinDriveMode.InputPullDown:
                    return PinMode.InputPullDown;
                case GpioPinDriveMode.InputPullUp:
                    return PinMode.InputPullUp;
                case GpioPinDriveMode.Output:
                case GpioPinDriveMode.OutputOpenDrain:
                case GpioPinDriveMode.OutputOpenDrainPullUp:
                case GpioPinDriveMode.OutputOpenSource:
                case GpioPinDriveMode.OutputOpenSourcePullDown:
                default:
                    return PinMode.Output;
            }
        }

        /// <summary>
        /// Checks if a pin supports a specific mode.
        /// </summary>
        /// <param name="pinNumber">The pin number in the controller's numbering scheme.</param>
        /// <param name="mode">The mode to check.</param>
        /// <returns>The status if the pin supports the mode.</returns>
        public bool IsPinModeSupported(int pinNumber, PinMode mode) => true;

        /// <summary>
        ///  Checks if a specific pin is open.
        /// </summary>
        /// <param name="pinNumber">The pin number in the controller's numbering scheme.</param>
        /// <returns>The status if the pin is open or closed.</returns>
        public bool IsPinOpen(int pinNumber) => _gpioPins[pinNumber] != null;

        /// <summary>
        /// Opens a pin in order for it to be ready to use.
        /// </summary>
        /// <param name="pinNumber">The pin number in the controller's numbering scheme.</param>
        public void OpenPin(int pinNumber)
        {
            if (IsPinOpen(pinNumber))
            {
                throw new IOException($"Pin {pinNumber} already open");
            }

            _gpioPins[pinNumber] = _controller.OpenPin(pinNumber);
        }

        /// <summary>
        /// Opens a pin and sets it to a specific mode.
        /// </summary>
        /// <param name="pinNumber">The pin number in the controller's numbering scheme.</param>
        /// <param name="mode">The mode to be set.</param>
        public void OpenPin(int pinNumber, PinMode mode)
        {
            OpenPin(pinNumber);
            SetPinMode(pinNumber, mode);
        }

        /// <summary>
        /// Reads the current value of a pin.
        /// </summary>
        /// <param name="pinNumber">The pin number in the controller's numbering scheme.</param>
        /// <returns>The value of the pin.</returns>
        public PinValue Read(int pinNumber) => _gpioPins[pinNumber].Read() == GpioPinValue.High ? PinValue.High : PinValue.Low;

        /// <summary>
        /// Adds a callback that will be invoked when pinNumber has an event of type eventType.
        /// </summary>
        /// <param name="pinNumber">The pin number in the controller's numbering scheme.</param>
        /// <param name="eventTypes">The event types to wait for.</param>
        /// <param name="callback">The callback method that will be invoked.</param>
        public void RegisterCallbackForPinValueChangedEvent(int pinNumber, PinEventTypes eventTypes, PinChangeEventHandler callback)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the mode to a pin.
        /// </summary>
        /// <param name="pinNumber">The pin number in the controller's numbering scheme</param>
        /// <param name="mode">The mode to be set.</param>
        public void SetPinMode(int pinNumber, PinMode mode)
        {
            if (!IsPinOpen(pinNumber))
            {
                throw new IOException($"Pin {pinNumber} needs to be open");
            }

            GpioPinDriveMode modeNatif = GpioPinDriveMode.Output;
            switch (mode)
            {
                case PinMode.Input:
                    modeNatif = GpioPinDriveMode.Input;
                    break;
                case PinMode.InputPullDown:
                    modeNatif = GpioPinDriveMode.InputPullDown;
                    break;
                case PinMode.InputPullUp:
                    modeNatif = GpioPinDriveMode.InputPullUp;
                    break;
                case PinMode.Output:
                default:
                    modeNatif = GpioPinDriveMode.Output;
                    break;
            }
            _gpioPins[pinNumber].SetDriveMode(modeNatif);
        }

        /// <summary>
        /// Removes a callback that was being invoked for pin at pinNumber.
        /// </summary>
        /// <param name="pinNumber">The pin number in the controller's numbering scheme.</param>
        /// <param name="callback">The callback method that will be invoked.</param>
        public void UnregisterCallbackForPinValueChangedEvent(int pinNumber, PinChangeEventHandler callback)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Blocks execution until an event of type eventType is received or a period of
        /// time has expired.
        /// </summary>
        /// <param name="pinNumber">The pin number in the controller's numbering scheme.</param>
        /// <param name="eventTypes">The event types to wait for.</param>
        /// <param name="timeout">The time to wait for the event.</param>
        /// <returns>A structure that contains the result of the waiting operation.</returns>
        public WaitForEventResult WaitForEvent(int pinNumber, PinEventTypes eventTypes, TimeSpan timeout)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Writes a value to a pin.
        /// </summary>
        /// <param name="pinNumber">The pin number in the controller's numbering scheme.</param>
        /// <param name="value">The value to be written to the pin.</param>
        public void Write(int pinNumber, PinValue value)
        {
            _gpioPins[pinNumber].Write(value == PinValue.High ? GpioPinValue.High : GpioPinValue.Low);
        }
    }
}
