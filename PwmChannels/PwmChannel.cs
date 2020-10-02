// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Device.Pwm
{
    /// <summary>
    /// Represents a single PWM channel.
    /// </summary>
    public class PwmChannel : IDisposable
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private PwmPulsePolarity _polarity;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private double _dutyCyclePercentage;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private int _pinNumber;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private int _pwmTimer;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool _isStarted;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool _disposed = false;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private int _frequency;

        private Windows.Devices.Pwm.PwmPin _pwm;
        private Windows.Devices.Pwm.PwmController _controller;

        /// <summary>
        /// The frequency in hertz.
        /// </summary>
        /// <remarks>As not every frequency is supported, setting this property will set the Frequency to the closest possible one.
        /// As a consequence, you may red it first and see 1000 and decide to set to 1500 Hz and when reading it right after seeing 1200.
        /// This is the expected behavior as it will automatically be set to the closest supported frequency.</remarks>
        public int Frequency
        {
            get => _frequency;

            set
            {
                if(value<0)
                {
                    throw new ArgumentOutOfRangeException("Frequency can only be positive");
                }

                _frequency = value;
                _frequency = (int)_controller.SetDesiredFrequency(_frequency);
            }
        }

        /// <summary>
        /// The duty cycle represented as a value between 0.0 and 1.0.
        /// </summary>
        public double DutyCycle
        {
            get => _dutyCyclePercentage;

            set
            {
                if((value <0)||(value >1))
                {
                    throw new ArgumentOutOfRangeException("Duty cycle should be between 0.0 and 1.1"); 
                }

                _dutyCyclePercentage = value;
                _pwm.SetActiveDutyCyclePercentage(_dutyCyclePercentage);
            }
        }

        /// <summary>
        /// Starts the PWM channel.
        /// </summary>
        public void Start()
        {
            _isStarted = true;
            _pwm.Start();
        }

        /// <summary>
        /// Stops the PWM channel.
        /// </summary>
        public void Stop()
        {
            _pwm.Stop();
            _isStarted = false;
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if(_disposed)
            {
                return;
            }

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Gets the started state of the pin.
        /// </summary>
        /// <value>
        /// True if the PWM has started on this pin, otherwise false.
        /// </value>
        public bool IsStarted => _isStarted;

        /// <summary>
        /// Disposes this instance
        /// </summary>
        /// <param name="disposing"><see langword="true"/> if explicitly disposing, <see langword="false"/> if in finalizer</param>
        protected virtual void Dispose(bool disposing)
        {
            _disposed = true;
            // Nothing to do in base class.
        }

        /// <summary>
        /// Creates a new instance of the <see cref="PwmChannel"/> running on the current platform.
        /// </summary>
        /// <param name="chip">The PWM chip number which is PWMx where x is the chip number</param>
        /// <param name="channel">The PWM channel number which can be called as well the pin Number</param>
        /// <param name="frequency">The frequency in hertz.</param>
        /// <param name="dutyCyclePercentage">The duty cycle percentage represented as a value between 0.0 and 1.0.</param>
        /// <returns>A PWM channel running on Windows 10 IoT.</returns>
        public static PwmChannel Create(
            int chip,
            int channel,
            int frequency = 400,
            double dutyCyclePercentage = 0.5)
        {
            return new PwmChannel(chip, channel, frequency, dutyCyclePercentage);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="PwmChannel"/> running on the current platform.
        /// </summary>
        /// <param name="chip">The PWM chip number which is PWMx where x is the chip number</param>
        /// <param name="channel">The PWM channel number which can be called as well the pin Number</param>
        /// <param name="frequency">The frequency in hertz.</param>
        /// <param name="dutyCyclePercentage">The duty cycle percentage represented as a value between 0.0 and 1.0.</param>
        /// <param name="pulsePolarity">The pulse polarity</param>
        public PwmChannel(int chip,
            int channel,
            int frequency = 400,
            double dutyCyclePercentage = 0.5,
            PwmPulsePolarity pulsePolarity = PwmPulsePolarity.ActiveHigh)
        {
            _pinNumber = channel;
            _pwmTimer = chip;
            _controller = Windows.Devices.Pwm.PwmController.FromId($"PWM{chip}");
            _pwm = _controller.OpenPin(channel);
            _frequency = frequency;
            _dutyCyclePercentage = dutyCyclePercentage;
            _polarity = pulsePolarity;
        }
    }
}
