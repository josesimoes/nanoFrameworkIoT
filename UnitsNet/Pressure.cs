﻿using System;
using UnitsNet.Units;

namespace UnitsNet
{
    public struct Pressure
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly PressureUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public PressureUnit Unit => _unit;

        /// <summary>
        ///     The base unit of Pressure, which is Pascal. All conversions go via this value.
        /// </summary>
        public static PressureUnit BaseUnit { get; } = PressureUnit.Pascal;

        /// <summary>
        /// Represents the largest possible value of Pressure
        /// </summary>
        public static Pressure MaxValue { get; } = new Pressure(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Pressure
        /// </summary>
        public static Pressure MinValue { get; } = new Pressure(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Pascal.
        /// </summary>
        public static Pressure Zero { get; } = new Pressure(0, BaseUnit);

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public Pressure(double value, PressureUnit unit)
        {
            if (unit == PressureUnit.Undefined)
                throw new ArgumentException("The quantity can not be created with an undefined unit.", nameof(unit));

            _value = value;
            _unit = unit;

        }

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public double As(PressureUnit unit) => GetValueAs(unit);

        /// <summary>
        ///     Converts the current value + unit to the base unit.
        ///     This is typically the first step in converting from one unit to another.
        /// </summary>
        /// <returns>The value in the base unit representation.</returns>
        private double GetValueInBaseUnit()
        {
            switch (Unit)
            {
                case PressureUnit.Atmosphere: return _value * 1.01325 * 1e5;
                case PressureUnit.Bar: return _value * 1e5;
                case PressureUnit.Centibar: return (_value * 1e5) * 1e-2d;
                case PressureUnit.Decapascal: return (_value) * 1e1d;
                case PressureUnit.Decibar: return (_value * 1e5) * 1e-1d;
                case PressureUnit.DynePerSquareCentimeter: return _value * 1.0e-1;
                case PressureUnit.FootOfHead: return _value * 2989.0669;
                case PressureUnit.Gigapascal: return (_value) * 1e9d;
                case PressureUnit.Hectopascal: return (_value) * 1e2d;
                case PressureUnit.InchOfMercury: return _value / 2.95299830714159e-4;
                case PressureUnit.InchOfWaterColumn: return _value * 249.08890833333;
                case PressureUnit.Kilobar: return (_value * 1e5) * 1e3d;
                case PressureUnit.KilogramForcePerSquareCentimeter: return _value * 9.80665e4;
                case PressureUnit.KilogramForcePerSquareMeter: return _value * 9.80665019960652;
                case PressureUnit.KilogramForcePerSquareMillimeter: return _value * 9.80665e6;
                case PressureUnit.KilonewtonPerSquareCentimeter: return (_value * 1e4) * 1e3d;
                case PressureUnit.KilonewtonPerSquareMeter: return (_value) * 1e3d;
                case PressureUnit.KilonewtonPerSquareMillimeter: return (_value * 1e6) * 1e3d;
                case PressureUnit.Kilopascal: return (_value) * 1e3d;
                case PressureUnit.KilopoundForcePerSquareFoot: return (_value * 4.788025898033584e1) * 1e3d;
                case PressureUnit.KilopoundForcePerSquareInch: return (_value * 6.894757293168361e3) * 1e3d;
                case PressureUnit.Megabar: return (_value * 1e5) * 1e6d;
                case PressureUnit.MeganewtonPerSquareMeter: return (_value) * 1e6d;
                case PressureUnit.Megapascal: return (_value) * 1e6d;
                case PressureUnit.MeterOfHead: return _value * 9804.139432;
                case PressureUnit.Microbar: return (_value * 1e5) * 1e-6d;
                case PressureUnit.Micropascal: return (_value) * 1e-6d;
                case PressureUnit.Millibar: return (_value * 1e5) * 1e-3d;
                case PressureUnit.MillimeterOfMercury: return _value / 7.50061561302643e-3;
                case PressureUnit.Millipascal: return (_value) * 1e-3d;
                case PressureUnit.NewtonPerSquareCentimeter: return _value * 1e4;
                case PressureUnit.NewtonPerSquareMeter: return _value;
                case PressureUnit.NewtonPerSquareMillimeter: return _value * 1e6;
                case PressureUnit.Pascal: return _value;
                case PressureUnit.PoundForcePerSquareFoot: return _value * 4.788025898033584e1;
                case PressureUnit.PoundForcePerSquareInch: return _value * 6.894757293168361e3;
                case PressureUnit.PoundPerInchSecondSquared: return _value * 1.785796732283465e1;
                case PressureUnit.TechnicalAtmosphere: return _value * 9.80680592331 * 1e4;
                case PressureUnit.TonneForcePerSquareCentimeter: return _value * 9.80665e7;
                case PressureUnit.TonneForcePerSquareMeter: return _value * 9.80665e3;
                case PressureUnit.TonneForcePerSquareMillimeter: return _value * 9.80665e9;
                case PressureUnit.Torr: return _value * 1.3332266752 * 1e2;
                default:
                    throw new NotImplementedException($"Can not convert {Unit} to base units.");
            }
        }

        private double GetValueAs(PressureUnit unit)
        {
            if (Unit == unit)
                return _value;

            var baseUnitValue = GetValueInBaseUnit();

            switch (unit)
            {
                case PressureUnit.Atmosphere: return baseUnitValue / (1.01325 * 1e5);
                case PressureUnit.Bar: return baseUnitValue / 1e5;
                case PressureUnit.Centibar: return (baseUnitValue / 1e5) / 1e-2d;
                case PressureUnit.Decapascal: return (baseUnitValue) / 1e1d;
                case PressureUnit.Decibar: return (baseUnitValue / 1e5) / 1e-1d;
                case PressureUnit.DynePerSquareCentimeter: return baseUnitValue / 1.0e-1;
                case PressureUnit.FootOfHead: return baseUnitValue * 0.000334552565551;
                case PressureUnit.Gigapascal: return (baseUnitValue) / 1e9d;
                case PressureUnit.Hectopascal: return (baseUnitValue) / 1e2d;
                case PressureUnit.InchOfMercury: return baseUnitValue * 2.95299830714159e-4;
                case PressureUnit.InchOfWaterColumn: return baseUnitValue / 249.08890833333;
                case PressureUnit.Kilobar: return (baseUnitValue / 1e5) / 1e3d;
                case PressureUnit.KilogramForcePerSquareCentimeter: return baseUnitValue / 9.80665e4;
                case PressureUnit.KilogramForcePerSquareMeter: return baseUnitValue * 0.101971619222242;
                case PressureUnit.KilogramForcePerSquareMillimeter: return baseUnitValue / 9.80665e6;
                case PressureUnit.KilonewtonPerSquareCentimeter: return (baseUnitValue / 1e4) / 1e3d;
                case PressureUnit.KilonewtonPerSquareMeter: return (baseUnitValue) / 1e3d;
                case PressureUnit.KilonewtonPerSquareMillimeter: return (baseUnitValue / 1e6) / 1e3d;
                case PressureUnit.Kilopascal: return (baseUnitValue) / 1e3d;
                case PressureUnit.KilopoundForcePerSquareFoot: return (baseUnitValue / 4.788025898033584e1) / 1e3d;
                case PressureUnit.KilopoundForcePerSquareInch: return (baseUnitValue / 6.894757293168361e3) / 1e3d;
                case PressureUnit.Megabar: return (baseUnitValue / 1e5) / 1e6d;
                case PressureUnit.MeganewtonPerSquareMeter: return (baseUnitValue) / 1e6d;
                case PressureUnit.Megapascal: return (baseUnitValue) / 1e6d;
                case PressureUnit.MeterOfHead: return baseUnitValue * 0.0001019977334;
                case PressureUnit.Microbar: return (baseUnitValue / 1e5) / 1e-6d;
                case PressureUnit.Micropascal: return (baseUnitValue) / 1e-6d;
                case PressureUnit.Millibar: return (baseUnitValue / 1e5) / 1e-3d;
                case PressureUnit.MillimeterOfMercury: return baseUnitValue * 7.50061561302643e-3;
                case PressureUnit.Millipascal: return (baseUnitValue) / 1e-3d;
                case PressureUnit.NewtonPerSquareCentimeter: return baseUnitValue / 1e4;
                case PressureUnit.NewtonPerSquareMeter: return baseUnitValue;
                case PressureUnit.NewtonPerSquareMillimeter: return baseUnitValue / 1e6;
                case PressureUnit.Pascal: return baseUnitValue;
                case PressureUnit.PoundForcePerSquareFoot: return baseUnitValue / 4.788025898033584e1;
                case PressureUnit.PoundForcePerSquareInch: return baseUnitValue / 6.894757293168361e3;
                case PressureUnit.PoundPerInchSecondSquared: return baseUnitValue / 1.785796732283465e1;
                case PressureUnit.TechnicalAtmosphere: return baseUnitValue / (9.80680592331 * 1e4);
                case PressureUnit.TonneForcePerSquareCentimeter: return baseUnitValue / 9.80665e7;
                case PressureUnit.TonneForcePerSquareMeter: return baseUnitValue / 9.80665e3;
                case PressureUnit.TonneForcePerSquareMillimeter: return baseUnitValue / 9.80665e9;
                case PressureUnit.Torr: return baseUnitValue / (1.3332266752 * 1e2);
                default:
                    throw new NotImplementedException($"Can not convert {Unit} to {unit}.");
            }
        }

        #region Static Factory Methods

        /// <summary>
        ///     Get Pressure from Atmospheres.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromAtmospheres(double atmospheres)
        {
            double value = (double)atmospheres;
            return new Pressure(value, PressureUnit.Atmosphere);
        }
        /// <summary>
        ///     Get Pressure from Bars.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromBars(double bars)
        {
            double value = (double)bars;
            return new Pressure(value, PressureUnit.Bar);
        }
        /// <summary>
        ///     Get Pressure from Centibars.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromCentibars(double centibars)
        {
            double value = (double)centibars;
            return new Pressure(value, PressureUnit.Centibar);
        }
        /// <summary>
        ///     Get Pressure from Decapascals.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromDecapascals(double decapascals)
        {
            double value = (double)decapascals;
            return new Pressure(value, PressureUnit.Decapascal);
        }
        /// <summary>
        ///     Get Pressure from Decibars.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromDecibars(double decibars)
        {
            double value = (double)decibars;
            return new Pressure(value, PressureUnit.Decibar);
        }
        /// <summary>
        ///     Get Pressure from DynesPerSquareCentimeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromDynesPerSquareCentimeter(double dynespersquarecentimeter)
        {
            double value = (double)dynespersquarecentimeter;
            return new Pressure(value, PressureUnit.DynePerSquareCentimeter);
        }
        /// <summary>
        ///     Get Pressure from FeetOfHead.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromFeetOfHead(double feetofhead)
        {
            double value = (double)feetofhead;
            return new Pressure(value, PressureUnit.FootOfHead);
        }
        /// <summary>
        ///     Get Pressure from Gigapascals.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromGigapascals(double gigapascals)
        {
            double value = (double)gigapascals;
            return new Pressure(value, PressureUnit.Gigapascal);
        }
        /// <summary>
        ///     Get Pressure from Hectopascals.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromHectopascals(double hectopascals)
        {
            double value = (double)hectopascals;
            return new Pressure(value, PressureUnit.Hectopascal);
        }
        /// <summary>
        ///     Get Pressure from InchesOfMercury.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromInchesOfMercury(double inchesofmercury)
        {
            double value = (double)inchesofmercury;
            return new Pressure(value, PressureUnit.InchOfMercury);
        }
        /// <summary>
        ///     Get Pressure from InchesOfWaterColumn.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromInchesOfWaterColumn(double inchesofwatercolumn)
        {
            double value = (double)inchesofwatercolumn;
            return new Pressure(value, PressureUnit.InchOfWaterColumn);
        }
        /// <summary>
        ///     Get Pressure from Kilobars.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromKilobars(double kilobars)
        {
            double value = (double)kilobars;
            return new Pressure(value, PressureUnit.Kilobar);
        }
        /// <summary>
        ///     Get Pressure from KilogramsForcePerSquareCentimeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromKilogramsForcePerSquareCentimeter(double kilogramsforcepersquarecentimeter)
        {
            double value = (double)kilogramsforcepersquarecentimeter;
            return new Pressure(value, PressureUnit.KilogramForcePerSquareCentimeter);
        }
        /// <summary>
        ///     Get Pressure from KilogramsForcePerSquareMeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromKilogramsForcePerSquareMeter(double kilogramsforcepersquaremeter)
        {
            double value = (double)kilogramsforcepersquaremeter;
            return new Pressure(value, PressureUnit.KilogramForcePerSquareMeter);
        }
        /// <summary>
        ///     Get Pressure from KilogramsForcePerSquareMillimeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromKilogramsForcePerSquareMillimeter(double kilogramsforcepersquaremillimeter)
        {
            double value = (double)kilogramsforcepersquaremillimeter;
            return new Pressure(value, PressureUnit.KilogramForcePerSquareMillimeter);
        }
        /// <summary>
        ///     Get Pressure from KilonewtonsPerSquareCentimeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromKilonewtonsPerSquareCentimeter(double kilonewtonspersquarecentimeter)
        {
            double value = (double)kilonewtonspersquarecentimeter;
            return new Pressure(value, PressureUnit.KilonewtonPerSquareCentimeter);
        }
        /// <summary>
        ///     Get Pressure from KilonewtonsPerSquareMeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromKilonewtonsPerSquareMeter(double kilonewtonspersquaremeter)
        {
            double value = (double)kilonewtonspersquaremeter;
            return new Pressure(value, PressureUnit.KilonewtonPerSquareMeter);
        }
        /// <summary>
        ///     Get Pressure from KilonewtonsPerSquareMillimeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromKilonewtonsPerSquareMillimeter(double kilonewtonspersquaremillimeter)
        {
            double value = (double)kilonewtonspersquaremillimeter;
            return new Pressure(value, PressureUnit.KilonewtonPerSquareMillimeter);
        }
        /// <summary>
        ///     Get Pressure from Kilopascals.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromKilopascals(double kilopascals)
        {
            double value = (double)kilopascals;
            return new Pressure(value, PressureUnit.Kilopascal);
        }
        /// <summary>
        ///     Get Pressure from KilopoundsForcePerSquareFoot.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromKilopoundsForcePerSquareFoot(double kilopoundsforcepersquarefoot)
        {
            double value = (double)kilopoundsforcepersquarefoot;
            return new Pressure(value, PressureUnit.KilopoundForcePerSquareFoot);
        }
        /// <summary>
        ///     Get Pressure from KilopoundsForcePerSquareInch.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromKilopoundsForcePerSquareInch(double kilopoundsforcepersquareinch)
        {
            double value = (double)kilopoundsforcepersquareinch;
            return new Pressure(value, PressureUnit.KilopoundForcePerSquareInch);
        }
        /// <summary>
        ///     Get Pressure from Megabars.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromMegabars(double megabars)
        {
            double value = (double)megabars;
            return new Pressure(value, PressureUnit.Megabar);
        }
        /// <summary>
        ///     Get Pressure from MeganewtonsPerSquareMeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromMeganewtonsPerSquareMeter(double meganewtonspersquaremeter)
        {
            double value = (double)meganewtonspersquaremeter;
            return new Pressure(value, PressureUnit.MeganewtonPerSquareMeter);
        }
        /// <summary>
        ///     Get Pressure from Megapascals.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromMegapascals(double megapascals)
        {
            double value = (double)megapascals;
            return new Pressure(value, PressureUnit.Megapascal);
        }
        /// <summary>
        ///     Get Pressure from MetersOfHead.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromMetersOfHead(double metersofhead)
        {
            double value = (double)metersofhead;
            return new Pressure(value, PressureUnit.MeterOfHead);
        }
        /// <summary>
        ///     Get Pressure from Microbars.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromMicrobars(double microbars)
        {
            double value = (double)microbars;
            return new Pressure(value, PressureUnit.Microbar);
        }
        /// <summary>
        ///     Get Pressure from Micropascals.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromMicropascals(double micropascals)
        {
            double value = (double)micropascals;
            return new Pressure(value, PressureUnit.Micropascal);
        }
        /// <summary>
        ///     Get Pressure from Millibars.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromMillibars(double millibars)
        {
            double value = (double)millibars;
            return new Pressure(value, PressureUnit.Millibar);
        }
        /// <summary>
        ///     Get Pressure from MillimetersOfMercury.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromMillimetersOfMercury(double millimetersofmercury)
        {
            double value = (double)millimetersofmercury;
            return new Pressure(value, PressureUnit.MillimeterOfMercury);
        }
        /// <summary>
        ///     Get Pressure from Millipascals.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromMillipascals(double millipascals)
        {
            double value = (double)millipascals;
            return new Pressure(value, PressureUnit.Millipascal);
        }
        /// <summary>
        ///     Get Pressure from NewtonsPerSquareCentimeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromNewtonsPerSquareCentimeter(double newtonspersquarecentimeter)
        {
            double value = (double)newtonspersquarecentimeter;
            return new Pressure(value, PressureUnit.NewtonPerSquareCentimeter);
        }
        /// <summary>
        ///     Get Pressure from NewtonsPerSquareMeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromNewtonsPerSquareMeter(double newtonspersquaremeter)
        {
            double value = (double)newtonspersquaremeter;
            return new Pressure(value, PressureUnit.NewtonPerSquareMeter);
        }
        /// <summary>
        ///     Get Pressure from NewtonsPerSquareMillimeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromNewtonsPerSquareMillimeter(double newtonspersquaremillimeter)
        {
            double value = (double)newtonspersquaremillimeter;
            return new Pressure(value, PressureUnit.NewtonPerSquareMillimeter);
        }
        /// <summary>
        ///     Get Pressure from Pascals.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromPascals(double pascals)
        {
            double value = (double)pascals;
            return new Pressure(value, PressureUnit.Pascal);
        }
        /// <summary>
        ///     Get Pressure from PoundsForcePerSquareFoot.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromPoundsForcePerSquareFoot(double poundsforcepersquarefoot)
        {
            double value = (double)poundsforcepersquarefoot;
            return new Pressure(value, PressureUnit.PoundForcePerSquareFoot);
        }
        /// <summary>
        ///     Get Pressure from PoundsForcePerSquareInch.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromPoundsForcePerSquareInch(double poundsforcepersquareinch)
        {
            double value = (double)poundsforcepersquareinch;
            return new Pressure(value, PressureUnit.PoundForcePerSquareInch);
        }
        /// <summary>
        ///     Get Pressure from PoundsPerInchSecondSquared.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromPoundsPerInchSecondSquared(double poundsperinchsecondsquared)
        {
            double value = (double)poundsperinchsecondsquared;
            return new Pressure(value, PressureUnit.PoundPerInchSecondSquared);
        }
        /// <summary>
        ///     Get Pressure from TechnicalAtmospheres.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromTechnicalAtmospheres(double technicalatmospheres)
        {
            double value = (double)technicalatmospheres;
            return new Pressure(value, PressureUnit.TechnicalAtmosphere);
        }
        /// <summary>
        ///     Get Pressure from TonnesForcePerSquareCentimeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromTonnesForcePerSquareCentimeter(double tonnesforcepersquarecentimeter)
        {
            double value = (double)tonnesforcepersquarecentimeter;
            return new Pressure(value, PressureUnit.TonneForcePerSquareCentimeter);
        }
        /// <summary>
        ///     Get Pressure from TonnesForcePerSquareMeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromTonnesForcePerSquareMeter(double tonnesforcepersquaremeter)
        {
            double value = (double)tonnesforcepersquaremeter;
            return new Pressure(value, PressureUnit.TonneForcePerSquareMeter);
        }
        /// <summary>
        ///     Get Pressure from TonnesForcePerSquareMillimeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromTonnesForcePerSquareMillimeter(double tonnesforcepersquaremillimeter)
        {
            double value = (double)tonnesforcepersquaremillimeter;
            return new Pressure(value, PressureUnit.TonneForcePerSquareMillimeter);
        }
        /// <summary>
        ///     Get Pressure from Torrs.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Pressure FromTorrs(double torrs)
        {
            double value = (double)torrs;
            return new Pressure(value, PressureUnit.Torr);
        }

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="PressureUnit" /> to <see cref="Pressure" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Pressure unit value.</returns>
        public static Pressure From(double value, PressureUnit fromUnit)
        {
            return new Pressure((double)value, fromUnit);
        }

        #endregion

        #region Conversion Properties

        /// <summary>
        ///     Get Pressure in Atmospheres.
        /// </summary>
        public double Atmospheres => As(PressureUnit.Atmosphere);

        /// <summary>
        ///     Get Pressure in Bars.
        /// </summary>
        public double Bars => As(PressureUnit.Bar);

        /// <summary>
        ///     Get Pressure in Centibars.
        /// </summary>
        public double Centibars => As(PressureUnit.Centibar);

        /// <summary>
        ///     Get Pressure in Decapascals.
        /// </summary>
        public double Decapascals => As(PressureUnit.Decapascal);

        /// <summary>
        ///     Get Pressure in Decibars.
        /// </summary>
        public double Decibars => As(PressureUnit.Decibar);

        /// <summary>
        ///     Get Pressure in DynesPerSquareCentimeter.
        /// </summary>
        public double DynesPerSquareCentimeter => As(PressureUnit.DynePerSquareCentimeter);

        /// <summary>
        ///     Get Pressure in FeetOfHead.
        /// </summary>
        public double FeetOfHead => As(PressureUnit.FootOfHead);

        /// <summary>
        ///     Get Pressure in Gigapascals.
        /// </summary>
        public double Gigapascals => As(PressureUnit.Gigapascal);

        /// <summary>
        ///     Get Pressure in Hectopascals.
        /// </summary>
        public double Hectopascals => As(PressureUnit.Hectopascal);

        /// <summary>
        ///     Get Pressure in InchesOfMercury.
        /// </summary>
        public double InchesOfMercury => As(PressureUnit.InchOfMercury);

        /// <summary>
        ///     Get Pressure in InchesOfWaterColumn.
        /// </summary>
        public double InchesOfWaterColumn => As(PressureUnit.InchOfWaterColumn);

        /// <summary>
        ///     Get Pressure in Kilobars.
        /// </summary>
        public double Kilobars => As(PressureUnit.Kilobar);

        /// <summary>
        ///     Get Pressure in KilogramsForcePerSquareCentimeter.
        /// </summary>
        public double KilogramsForcePerSquareCentimeter => As(PressureUnit.KilogramForcePerSquareCentimeter);

        /// <summary>
        ///     Get Pressure in KilogramsForcePerSquareMeter.
        /// </summary>
        public double KilogramsForcePerSquareMeter => As(PressureUnit.KilogramForcePerSquareMeter);

        /// <summary>
        ///     Get Pressure in KilogramsForcePerSquareMillimeter.
        /// </summary>
        public double KilogramsForcePerSquareMillimeter => As(PressureUnit.KilogramForcePerSquareMillimeter);

        /// <summary>
        ///     Get Pressure in KilonewtonsPerSquareCentimeter.
        /// </summary>
        public double KilonewtonsPerSquareCentimeter => As(PressureUnit.KilonewtonPerSquareCentimeter);

        /// <summary>
        ///     Get Pressure in KilonewtonsPerSquareMeter.
        /// </summary>
        public double KilonewtonsPerSquareMeter => As(PressureUnit.KilonewtonPerSquareMeter);

        /// <summary>
        ///     Get Pressure in KilonewtonsPerSquareMillimeter.
        /// </summary>
        public double KilonewtonsPerSquareMillimeter => As(PressureUnit.KilonewtonPerSquareMillimeter);

        /// <summary>
        ///     Get Pressure in Kilopascals.
        /// </summary>
        public double Kilopascals => As(PressureUnit.Kilopascal);

        /// <summary>
        ///     Get Pressure in KilopoundsForcePerSquareFoot.
        /// </summary>
        public double KilopoundsForcePerSquareFoot => As(PressureUnit.KilopoundForcePerSquareFoot);

        /// <summary>
        ///     Get Pressure in KilopoundsForcePerSquareInch.
        /// </summary>
        public double KilopoundsForcePerSquareInch => As(PressureUnit.KilopoundForcePerSquareInch);

        /// <summary>
        ///     Get Pressure in Megabars.
        /// </summary>
        public double Megabars => As(PressureUnit.Megabar);

        /// <summary>
        ///     Get Pressure in MeganewtonsPerSquareMeter.
        /// </summary>
        public double MeganewtonsPerSquareMeter => As(PressureUnit.MeganewtonPerSquareMeter);

        /// <summary>
        ///     Get Pressure in Megapascals.
        /// </summary>
        public double Megapascals => As(PressureUnit.Megapascal);

        /// <summary>
        ///     Get Pressure in MetersOfHead.
        /// </summary>
        public double MetersOfHead => As(PressureUnit.MeterOfHead);

        /// <summary>
        ///     Get Pressure in Microbars.
        /// </summary>
        public double Microbars => As(PressureUnit.Microbar);

        /// <summary>
        ///     Get Pressure in Micropascals.
        /// </summary>
        public double Micropascals => As(PressureUnit.Micropascal);

        /// <summary>
        ///     Get Pressure in Millibars.
        /// </summary>
        public double Millibars => As(PressureUnit.Millibar);

        /// <summary>
        ///     Get Pressure in MillimetersOfMercury.
        /// </summary>
        public double MillimetersOfMercury => As(PressureUnit.MillimeterOfMercury);

        /// <summary>
        ///     Get Pressure in Millipascals.
        /// </summary>
        public double Millipascals => As(PressureUnit.Millipascal);

        /// <summary>
        ///     Get Pressure in NewtonsPerSquareCentimeter.
        /// </summary>
        public double NewtonsPerSquareCentimeter => As(PressureUnit.NewtonPerSquareCentimeter);

        /// <summary>
        ///     Get Pressure in NewtonsPerSquareMeter.
        /// </summary>
        public double NewtonsPerSquareMeter => As(PressureUnit.NewtonPerSquareMeter);

        /// <summary>
        ///     Get Pressure in NewtonsPerSquareMillimeter.
        /// </summary>
        public double NewtonsPerSquareMillimeter => As(PressureUnit.NewtonPerSquareMillimeter);

        /// <summary>
        ///     Get Pressure in Pascals.
        /// </summary>
        public double Pascals => As(PressureUnit.Pascal);

        /// <summary>
        ///     Get Pressure in PoundsForcePerSquareFoot.
        /// </summary>
        public double PoundsForcePerSquareFoot => As(PressureUnit.PoundForcePerSquareFoot);

        /// <summary>
        ///     Get Pressure in PoundsForcePerSquareInch.
        /// </summary>
        public double PoundsForcePerSquareInch => As(PressureUnit.PoundForcePerSquareInch);

        /// <summary>
        ///     Get Pressure in PoundsPerInchSecondSquared.
        /// </summary>
        public double PoundsPerInchSecondSquared => As(PressureUnit.PoundPerInchSecondSquared);

        /// <summary>
        ///     Get Pressure in TechnicalAtmospheres.
        /// </summary>
        public double TechnicalAtmospheres => As(PressureUnit.TechnicalAtmosphere);

        /// <summary>
        ///     Get Pressure in TonnesForcePerSquareCentimeter.
        /// </summary>
        public double TonnesForcePerSquareCentimeter => As(PressureUnit.TonneForcePerSquareCentimeter);

        /// <summary>
        ///     Get Pressure in TonnesForcePerSquareMeter.
        /// </summary>
        public double TonnesForcePerSquareMeter => As(PressureUnit.TonneForcePerSquareMeter);

        /// <summary>
        ///     Get Pressure in TonnesForcePerSquareMillimeter.
        /// </summary>
        public double TonnesForcePerSquareMillimeter => As(PressureUnit.TonneForcePerSquareMillimeter);

        /// <summary>
        ///     Get Pressure in Torrs.
        /// </summary>
        public double Torrs => As(PressureUnit.Torr);

        #endregion

    }
}
