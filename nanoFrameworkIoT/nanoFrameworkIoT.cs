
using System.Threading;
using Iot.Device.Hcsr04;
using System.Diagnostics;
using System;
using Iot.Device.Samples;
using Iot.Device.DHTxx;
using UnitsNet;
using System.Device.Gpio;
using System.Device.I2c;

namespace NanoFrameworkIoT
{
    public class NanoFrameworkIoT
    {
        private static I2cDevice _device;
        private static byte[] buff = new byte[1];

        public static void Main()
        {
            try
            {
                // To use HCSR04:
                // Hsc();
                 HscGpioCore();
                // For the BMP280:
                // BmpExample.StartBmp(null);
                // For various low level I2C tests:
                // CheckDeviceIdWindowsDevicesI2c();
                // CheckDeviceIdSystemI2c();
                // Test the SpanByte:
                // TestSpanByte();
                // DTH12
                // Dth12Test();
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"Ups :-(: {ex}");
                Blink();
            }

        }

        private static void TestSpanByte()
        {
            SpanByte span = new byte[2];
            span[0] = 42;
            span[1] = 24;
            Debug.WriteLine($"{span.Length}, {span[0]}, {span[1]}");
        }

        private static void CheckWithDeviceSystemI2cInline()
        {
            _device = I2cDevice.Create(new I2cConnectionSettings(1,0x77, I2cBusSpeed.StandardMode));
            WriteByte(0xD0);
            var ret = ReadByte();
            Debug.WriteLine($"{ret}");
        }

        private static void CheckDeviceIdSystemI2c()
        {
            var device = System.Device.I2c.I2cDevice.Create(new System.Device.I2c.I2cConnectionSettings(1, 0x77));
            device.WriteByte(0xD0);
            var ret = device.ReadByte();
            Debug.WriteLine($"{ret}");

        }

        public static void WriteByte(byte value)
        {
            buff[0] = value;
            _device.Write(buff);
        }

        public static byte ReadByte()
        {
            _device.Read(buff);
            return buff[0];
        }

        private static void CheckDeviceIdWindowsDevicesI2c()
        {
            var device = I2cDevice.Create(new I2cConnectionSettings(1, 0x77, I2cBusSpeed.StandardMode));
            //var device = I2cController.GetDefault().GetDevice(new I2cConnectionSettings(0x77) { BusSpeed = I2cBusSpeed.StandardMode, SharingMode = I2cSharingMode.Shared });
            var toWrite = new byte[1];
            var toRead = new byte[1];
            toWrite[0] = 0xD0;
            var ret = device.WriteRead(toWrite, toRead);

            //device.Read(toWrite);
            Debug.WriteLine($"Ret: {ret.Status}, value :{toRead[0]}");
        }

        private static void Hsc()
        {
            Hcsr04 sonar = new Hcsr04(16, 17);

            while (true)
            {
                try
                {
                    Debug.WriteLine($"Distance: {sonar.Distance.Centimeters} cm");
                }
                catch (Exception)
                {
                    Debug.WriteLine($"Exception");
                }
                Thread.Sleep(1000);
            }
        }

        private static void HscGpioCore()
        {
            Hcsr04GpioCore sonar = new Hcsr04GpioCore(16, 17);
            GpioPin led = new GpioController().OpenPin(2);
            led.SetPinMode(PinMode.Output);
            led.Write(PinValue.High);
            double dist;

            while (true)
            {
                try
                {
                    dist = sonar.Distance.Centimeters;
                    Debug.WriteLine($"Distance: {dist} cm");
                    if(dist < 5)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Thread.Sleep(500);
                            led.Toggle();
                        }
                    }
                }
                catch (Exception)
                {
                    Debug.WriteLine($"Exception");
                }
                Thread.Sleep(1000);
            }
        }

        private static void Blink()
        {
            GpioPin led = new GpioController().OpenPin(2);
            led.SetPinMode(PinMode.Output);

            led.Write(PinValue.Low);
            while (true)
            {
                Thread.Sleep(500);
                led.Toggle();
            }
        }

        private static void Dth12Test()
        {
            Dht12 dht = new Dht12(19);
            Temperature temp;
            Ratio hum;
            GpioPin led = new GpioController().OpenPin(2);
            led.SetPinMode(PinMode.Output);
            led.Write(PinValue.High);

            while (true)
            {
                hum = dht.Humidity;
                temp = dht.Temperature;
                if (dht.IsLastReadSuccessful)
                {
                    Debug.WriteLine($"Hum: {hum.Percent} %, Temp: {temp.DegreesCelsius} °C");

                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(500);
                        led.Toggle();
                    }
                }
                else
                {
                    Debug.WriteLine("error reading dht");
                    led.Write(PinValue.High);
                }

                Thread.Sleep(1000);
            }
        }

    }
}
