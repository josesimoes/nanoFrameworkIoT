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
        private ArrayList _gpioPins = new ArrayList();
   
        /// <summary>
        /// Initializes a new instance of the System.Device.Gpio.GpioController class that
        /// will use the logical pin numbering scheme as default.
        /// </summary>
        public GpioController()
        {
            _controller = Windows.Devices.Gpio.GpioController.GetDefault();
        }
   
        /// <summary>
        /// Initializes a new instance of the System.Device.Gpio.GpioController class that
        /// will use the specified numbering scheme. The controller will default to use the
        /// driver that best applies given the platform the program is executing on.
        /// </summary>
        /// <param name="numberingScheme">The numbering scheme used to represent pins provided by the controller.</param>
        public GpioController(PinNumberingScheme numberingScheme)
        {
            _controller = Windows.Devices.Gpio.GpioController.GetDefault();
            NumberingScheme = numberingScheme;
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

            var pin = GetPin(pinNumber);
            if(pin != null)
            {
                pin.Dispose();
                _gpioPins.Remove(pin);
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
            foreach(var pin in _gpioPins)
            {
                ClosePin(((GpioPin)pin).PinNumber);
            }
        }
   
        /// <summary>
        /// Gets the mode of a pin.
        /// </summary>
        /// <param name="pinNumber">The pin number in the controller's numbering scheme.</param>
        /// <returns>The mode of the pin.</returns>
        public PinMode GetPinMode(int pinNumber)
        {
            var pin = GetPin(pinNumber);
            var mode = pin.GetDriveMode();
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
        public bool IsPinOpen(int pinNumber) => GetPin(pinNumber) != null;

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

            var pin = _controller.OpenPin(pinNumber);
            _gpioPins.Add(pin);
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

        private GpioPin GetPin(int pinNumber)
        {
            for (int i = 0; i < _gpioPins.Count; i++)
            {
                var pin = (GpioPin)_gpioPins[i];
                if ((int)pin.PinNumber == pinNumber)
                {
                    return pin;
                }
            }

            return null;
        }

        /// <summary>
        /// Reads the current value of a pin.
        /// </summary>
        /// <param name="pinNumber">The pin number in the controller's numbering scheme.</param>
        /// <returns>The value of the pin.</returns>
        public PinValue Read(int pinNumber) => GetPin(pinNumber).Read() == GpioPinValue.High ? PinValue.High : PinValue.Low;
   
        /// <summary>
        /// Read the given pins with the given pin numbers.
        /// </summary>
        /// <param name="pinValuePairs">The pin/value pairs to read.</param>
        public void Read(Span<PinValuePair> pinValuePairs)
        {
            for(int i=0; i<pinValuePairs.Length; i++)
            {
                pinValuePairs[i] = new PinValuePair(pinValuePairs[i].PinNumber, Read(pinValuePairs[i].PinNumber));
            }
        }

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
            var pin = GetPin(pinNumber);

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
            pin.SetDriveMode(modeNatif);
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
        /// Write the given pins with the given values.
        /// </summary>
        /// <param name="pinValuePairs">The pin/value pairs to write.</param>
        public void Write(ReadOnlySpan<PinValuePair> pinValuePairs)
        {
            for(int i=0;i<pinValuePairs.Length;i++)
            {
                Write(pinValuePairs[i].PinNumber, pinValuePairs[i].PinValue);
            }
        }
 
        /// <summary>
        /// Writes a value to a pin.
        /// </summary>
        /// <param name="pinNumber">The pin number in the controller's numbering scheme.</param>
        /// <param name="value">The value to be written to the pin.</param>
        public void Write(int pinNumber, PinValue value)
        {
            var pin = GetPin(pinNumber);
            pin.Write(value == PinValue.High ? GpioPinValue.High : GpioPinValue.Low);
        }
    }
}
