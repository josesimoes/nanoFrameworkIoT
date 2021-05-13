# nanoFramework <-> .NET IoT integration

This repo is a prototype repository to explore how to better integrate [nanoFramework](https://github.com/nanoframework/Home) and [.NET IoT](https://github.com/dotnet/iot).

In the repo:

- Span
  - SpanByte which has been [implemented in nanoFramework](https://github.com/nanoframework/lib-CoreLibrary/blob/develop/nanoFramework.CoreLibrary/System/SpanByte.cs) which will be used to automatically generate Span<T>to SpanT
- BinaryPrimitives implementation with SpanByte and byte[]. Note: the one which will be used it the SpanByte one. the byte[] was early work.
- List<T> to be used as template to generate automatically List of anything
  - ListByte is the one to be used as a template to generate List<T> to ListT.
- Stopwatch
  - simple stopwatch non precise implementation using the DateTime object
- UnitsNet simple implementation for couple os units used in .NET IoT.
- HSCR04 early implementation
- BMXX80 with more specifically BMP280 implementation. This has been manually adjusted. And will be regenarated.
- [System.Device.I2c](https://github.com/nanoframework/lib-System.Device.I2c) is now in nanoFramework and has been removed from this repo.
- [System.Device.Gpio](https://github.com/nanoframework/lib-System.Device.Gpio) is now in nanoFramework and has been removed from this repo.
- System.Device.Spi as a simple implementation in native code using the exisitng nanoFramework one. To be ported as well natively to nano
- System.Device.Pwm as a simple implementation in native code using the exisitng nanoFramework one. To be ported as well natively to nano
- TransforSpanList to transform automatically Span<T> and List<T> to SpanT and ListT

## Static code analyzer

A simple, brute force analyzer can help finding those elements:

- Presence of Generics
- UnitsNet and which units
- Async, Linq

so far the list of used Units is:

- ElectricPotential
- Temperature
- Ratio
- RelativeHumidity
- Illuminance
- Length
- Pressure
- Duration
- ElectricResistance
- ElectricCurrent
- VolumeConcentration
- Power
- Frequency
- ElectricPotentialDc

## Path to automate automatic creation of nanFramework compatible bindings from .NET IoT code

Let's start with the limitations:
- Linq is not supported, any binding using Linq won't be able to be generated
  - Mitigation buy not allowing usage of Linq. Most usage is about browsing collection to filter, can be done thru a basic function
  - For this prototype, I just removed those lines are not used in the sensor I was using.
- Issues with Math.Pow, Exp, etc on the ESP32 I am using, should be fixable
- Generic are not supported => rathen than Span<byte> generate SpanByte, same for List<T> a specific class can be automatically generated from the template built.
- stackalloc not supported => replacing by new
- Few things like ArgumentOutOfRangeException is sometimes used with 3 arguments in .NET IoT, only 2 supported
  - Mitigation: can be adjusted on nanoFramework or by code in .NET IoT to have a consistent usage of it
- Convert.ToByte(bool) doesn't exist
  - Mitigation, replace by bool ? 1 : 0
  - To implement in nanoFramework

Steps to automate:
- Create a nanoFramework project and add all the files
- Add the reference on the System.Device needed, same for the Span and other needed classes either thru the nuget either tru source code
- Global replace for the project ReadOnlySpan<byte> by SpanByte, global replace Span<byte> by SpanByte
- Global replace for the project stackalloc by new
- Find missing functions and implement them into nano

Notes for Bmxx80:
- It has been adjusted manually, recreated automatically some times, it's a great example using things like Linq as well which should be adjusted in .NET IoT 
- All Linq lines removed so far => the sensor using this won't work but some code must be rewritten to replace Linq
- List<T> kept in the code => the sensor using this won't work but generating a List specific will fiw this issue, will have to generate to check

## ToDo

- [x] Add the various Convert. missing in nanoFramework. More to come for sure but all very quick to do
- [x] Work on migratin of Windows.Devices to System.Device, see [issue](https://github.com/nanoframework/Home/issues/620). Spi and Pwm missing
- [X] Open issue on UnitsNet for autogeration of simple units nugets for nanoFramework based on the core units. See https://github.com/angularsen/UnitsNet/issues/836. A PR has been raised, closed and will reopen, so focus can be placed on the main units.
- [ ] Find a way o automatically replace Linq or change the policy and replace the few tens of lines in the current bindings => need to adjust the .NET IoT code to get rid of those lines
- [x] Math.XXX [issues](https://github.com/nanoframework/Home/issues/642), ~~solution will be found.~~ Fixed: API now in sync with the .NET API.
- [ ] Add more devices to check performance and migration path, discover new missing elements from System that may be used by other bindings
- [ ] Create specific policies to make a binding nanoFramework compatible => work started
- [ ] Work on automated code to transform original code and create specific nanoFramework compatible project + work on CI/CD => work started
- [x] Performance check on sensitive sensors like DHT => DHT won't work on some devices like ESP32. But there are ways to have those devices working but not with GpioController => out of scope for automatic generation
- [ ] Define the documentation and steps needed for manual adjustments
- [ ] Find a smart way to migrate samples
- [x] ILogger => now compatible and in place in [nano](https://github.com/nanoframework/nanoFramework.Logging)
