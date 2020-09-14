# nanoFrameworj <-> .NET IoT integration

This repo is a prototype repository to explore how to better integrate [nanoFramework](https://github.com/nanoframework/Home) and [.NET IoT](https://github.com/dotnet/iot).

In the repo:
- Span
  - Span<T> simple implementation to use as template for code generation (see later)
  - SpanByte which can be automatically generated from the Span<T> template
- BinaryPrimitives implementation with SpanByte and byte[]
- List<T> to be used as template to generate automatically List of anything
- Stopwatch
  - simple stopwatch non precise implementation using the DateTime object
- UnitsNet simple implementation for couple os units used in .NET IoT
- HSCR04 implementation
- BMXX80 with more specifically BMP280 implementation
- I2cDevice under System.Device.I2c allowing compatibility with System.Device.I2c from .NET IoT
- GpioController under System.Device.Gpio allowing compatibility with System.Device.Gpio from .NET IoT
- TestSpanRef a bug when using ref this

# Path to automate automatic creation of nanFramork compatible bindings from .NET IoT code

Let's start with the limitations:
- Linq is not supported, any binding using Linq won't be able to be generated
  - Mitigation buy not allowing usage of Linq. Most usage is about browsing collection to filter, can be done thru a basic function
  - For this prototype, I just removed those lines are not used in the sensor I was using.
- Enum.IsDefined doen't exist in nanoFramework
  - Mitigation by either removing it as used only to raise exception, should be able to be done autmatically
- Issues with Math.Pow, Exp, etc on the ESP32 I am using, should be fixable
- Generic are not supported => rathen than Span<byte> generate SpanByte, same for List<T> a specific class can be automatically generated from the template built.
- stackalloc not supported => replacing by new
- ArgumentOutOfRangeException is sometimes used with 3 arguments in .NET IoT, only 2 supported
  - Mitigation: can be adjusted on nanoFramework or byt code un .NET IoT
- Convert.ToByte(bool) doesn't exist
  - Mitigation, replace by bool ? 1 : 0
  - To implement in nanoFramework
- Convert.ToBoolean(byte) doesn't exist
  - Mitagation, replace by value == 0 ? false : true;
  - Add it to nanoFramework

Steps:
- Create a nanoFramework project and add all the files
- Add the reference on the System.Device needed, same for the Span and other needed classes either thru the nuget either tru source code
- Global replace for the project ReadOnlySpan<byte> by SpanByte, global replace Span<byte> by SpanByte
- Global replace for the project stackalloc by new
- Global replace Convert.ToByte(!value) by (byte)(!value ? 1 : 0), same for Convert.ToByte(value) by (byte)(value ? 1 : 0)
- replace every Convert.ToBoolean by value == 0 ? false : true;
- comment all Linq lines and all Enum.IsDefined lines

Notes for Bmxx80:
- All Enum.Isdefined code block removed
- All Linq lines removed => the sensor using this won't work but some code must be rewritten to replace Linq
- List<T> kept in the code => the sensor using this won't work but generating a List specific will fiw this issue
- Sensor used is a BPM280, all code using Math.XXX has been removed for the sample (altitude calculation)

# ToDo

[] Add the various Convert. missing in nanoFramework
[] Work on migratin of Windows.Devices to System.Device, see [issue](https://github.com/nanoframework/Home/issues/620)
[] Open issue on UnitsNet for autogeration of simple units nugets for nanoFramework based on the core units
[] Find a way o automatically replace Linq
[] Math.XXX [issues](https://github.com/nanoframework/Home/issues/642)