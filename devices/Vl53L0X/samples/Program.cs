using Iot.Device.Vl53L0X;
using System;
using System.Device.I2c;
using System.Diagnostics;
using System.Threading;

namespace vl53l0x.sample
{
    public class Program
    {
        public static void Main()
        {
            Debug.WriteLine("Hello from nanoFramework!");

            //Thread.Sleep(Timeout.Infinite);

            // Browse our samples repository: https://github.com/nanoframework/samples
            // Check our documentation online: https://docs.nanoframework.net/
            // Join our lively Discord community: https://discord.gg/gCyBu8T

            Debug.WriteLine("Hello VL53L0X!");
            var i2cDevice = I2cDevice.Create(new I2cConnectionSettings(1, Vl53L0X.DefaultI2cAddress));
            Vl53L0X vL53L0X = new Vl53L0X(i2cDevice);
            Debug.WriteLine($"Rev: {vL53L0X.Information.Revision}, Prod: {vL53L0X.Information.ProductId}, Mod: {vL53L0X.Information.ModuleId}");
            Debug.WriteLine($"Offset in µm: {vL53L0X.Information.OffsetMicrometers}, Signal rate fixed 400 µm: {vL53L0X.Information.SignalRateMeasuementFixed400Micrometers}");
            vL53L0X.MeasurementMode = MeasurementMode.Continuous;
            for (; ;)
            {
                try
                {
                    var dist = vL53L0X.Distance;
                    if (dist != (ushort)OperationRange.OutOfRange)
                    {
                        Debug.WriteLine($"Distance: {dist}");
                    }
                    else
                    {
                        Debug.WriteLine("Invalid data");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Exception: {ex.Message}");
                }

                Thread.Sleep(500);
            }

        }
    }
}
