using System;
using UnitsNet.Units;

namespace UnitsNet
{
    public struct Length
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly LengthUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public LengthUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public Length(double value, LengthUnit unit)
        {
            if (unit == LengthUnit.Undefined)
                throw new ArgumentException("The quantity can not be created with an undefined unit.", nameof(unit));

            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of Length, which is Meter. All conversions go via this value.
        /// </summary>
        public static LengthUnit BaseUnit { get; } = LengthUnit.Meter;

        /// <summary>
        /// Represents the largest possible value of Length
        /// </summary>
        public static Length MaxValue { get; } = new Length(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Length
        /// </summary>
        public static Length MinValue { get; } = new Length(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Meter.
        /// </summary>
        public static Length Zero { get; } = new Length(0, BaseUnit);

        #region Conversion Properties

        /// <summary>
        ///     Get Length in AstronomicalUnits.
        /// </summary>
        public double AstronomicalUnits => As(LengthUnit.AstronomicalUnit);

        /// <summary>
        ///     Get Length in Centimeters.
        /// </summary>
        public double Centimeters => As(LengthUnit.Centimeter);

        /// <summary>
        ///     Get Length in Chains.
        /// </summary>
        public double Chains => As(LengthUnit.Chain);

        /// <summary>
        ///     Get Length in Decimeters.
        /// </summary>
        public double Decimeters => As(LengthUnit.Decimeter);

        /// <summary>
        ///     Get Length in DtpPicas.
        /// </summary>
        public double DtpPicas => As(LengthUnit.DtpPica);

        /// <summary>
        ///     Get Length in DtpPoints.
        /// </summary>
        public double DtpPoints => As(LengthUnit.DtpPoint);

        /// <summary>
        ///     Get Length in Fathoms.
        /// </summary>
        public double Fathoms => As(LengthUnit.Fathom);

        /// <summary>
        ///     Get Length in Feet.
        /// </summary>
        public double Feet => As(LengthUnit.Foot);

        /// <summary>
        ///     Get Length in Hands.
        /// </summary>
        public double Hands => As(LengthUnit.Hand);

        /// <summary>
        ///     Get Length in Hectometers.
        /// </summary>
        public double Hectometers => As(LengthUnit.Hectometer);

        /// <summary>
        ///     Get Length in Inches.
        /// </summary>
        public double Inches => As(LengthUnit.Inch);

        /// <summary>
        ///     Get Length in KilolightYears.
        /// </summary>
        public double KilolightYears => As(LengthUnit.KilolightYear);

        /// <summary>
        ///     Get Length in Kilometers.
        /// </summary>
        public double Kilometers => As(LengthUnit.Kilometer);

        /// <summary>
        ///     Get Length in Kiloparsecs.
        /// </summary>
        public double Kiloparsecs => As(LengthUnit.Kiloparsec);

        /// <summary>
        ///     Get Length in LightYears.
        /// </summary>
        public double LightYears => As(LengthUnit.LightYear);

        /// <summary>
        ///     Get Length in MegalightYears.
        /// </summary>
        public double MegalightYears => As(LengthUnit.MegalightYear);

        /// <summary>
        ///     Get Length in Megaparsecs.
        /// </summary>
        public double Megaparsecs => As(LengthUnit.Megaparsec);

        /// <summary>
        ///     Get Length in Meters.
        /// </summary>
        public double Meters => As(LengthUnit.Meter);

        /// <summary>
        ///     Get Length in Microinches.
        /// </summary>
        public double Microinches => As(LengthUnit.Microinch);

        /// <summary>
        ///     Get Length in Micrometers.
        /// </summary>
        public double Micrometers => As(LengthUnit.Micrometer);

        /// <summary>
        ///     Get Length in Mils.
        /// </summary>
        public double Mils => As(LengthUnit.Mil);

        /// <summary>
        ///     Get Length in Miles.
        /// </summary>
        public double Miles => As(LengthUnit.Mile);

        /// <summary>
        ///     Get Length in Millimeters.
        /// </summary>
        public double Millimeters => As(LengthUnit.Millimeter);

        /// <summary>
        ///     Get Length in Nanometers.
        /// </summary>
        public double Nanometers => As(LengthUnit.Nanometer);

        /// <summary>
        ///     Get Length in NauticalMiles.
        /// </summary>
        public double NauticalMiles => As(LengthUnit.NauticalMile);

        /// <summary>
        ///     Get Length in Parsecs.
        /// </summary>
        public double Parsecs => As(LengthUnit.Parsec);

        /// <summary>
        ///     Get Length in PrinterPicas.
        /// </summary>
        public double PrinterPicas => As(LengthUnit.PrinterPica);

        /// <summary>
        ///     Get Length in PrinterPoints.
        /// </summary>
        public double PrinterPoints => As(LengthUnit.PrinterPoint);

        /// <summary>
        ///     Get Length in Shackles.
        /// </summary>
        public double Shackles => As(LengthUnit.Shackle);

        /// <summary>
        ///     Get Length in SolarRadiuses.
        /// </summary>
        public double SolarRadiuses => As(LengthUnit.SolarRadius);

        /// <summary>
        ///     Get Length in Twips.
        /// </summary>
        public double Twips => As(LengthUnit.Twip);

        /// <summary>
        ///     Get Length in UsSurveyFeet.
        /// </summary>
        public double UsSurveyFeet => As(LengthUnit.UsSurveyFoot);

        /// <summary>
        ///     Get Length in Yards.
        /// </summary>
        public double Yards => As(LengthUnit.Yard);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Get Length from AstronomicalUnits.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromAstronomicalUnits(double astronomicalunits)
        {
            double value = (double)astronomicalunits;
            return new Length(value, LengthUnit.AstronomicalUnit);
        }
        /// <summary>
        ///     Get Length from Centimeters.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromCentimeters(double centimeters)
        {
            double value = (double)centimeters;
            return new Length(value, LengthUnit.Centimeter);
        }
        /// <summary>
        ///     Get Length from Chains.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromChains(double chains)
        {
            double value = (double)chains;
            return new Length(value, LengthUnit.Chain);
        }
        /// <summary>
        ///     Get Length from Decimeters.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromDecimeters(double decimeters)
        {
            double value = (double)decimeters;
            return new Length(value, LengthUnit.Decimeter);
        }
        /// <summary>
        ///     Get Length from DtpPicas.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromDtpPicas(double dtppicas)
        {
            double value = (double)dtppicas;
            return new Length(value, LengthUnit.DtpPica);
        }
        /// <summary>
        ///     Get Length from DtpPoints.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromDtpPoints(double dtppoints)
        {
            double value = (double)dtppoints;
            return new Length(value, LengthUnit.DtpPoint);
        }
        /// <summary>
        ///     Get Length from Fathoms.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromFathoms(double fathoms)
        {
            double value = (double)fathoms;
            return new Length(value, LengthUnit.Fathom);
        }
        /// <summary>
        ///     Get Length from Feet.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromFeet(double feet)
        {
            double value = (double)feet;
            return new Length(value, LengthUnit.Foot);
        }
        /// <summary>
        ///     Get Length from Hands.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromHands(double hands)
        {
            double value = (double)hands;
            return new Length(value, LengthUnit.Hand);
        }
        /// <summary>
        ///     Get Length from Hectometers.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromHectometers(double hectometers)
        {
            double value = (double)hectometers;
            return new Length(value, LengthUnit.Hectometer);
        }
        /// <summary>
        ///     Get Length from Inches.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromInches(double inches)
        {
            double value = (double)inches;
            return new Length(value, LengthUnit.Inch);
        }
        /// <summary>
        ///     Get Length from KilolightYears.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromKilolightYears(double kilolightyears)
        {
            double value = (double)kilolightyears;
            return new Length(value, LengthUnit.KilolightYear);
        }
        /// <summary>
        ///     Get Length from Kilometers.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromKilometers(double kilometers)
        {
            double value = (double)kilometers;
            return new Length(value, LengthUnit.Kilometer);
        }
        /// <summary>
        ///     Get Length from Kiloparsecs.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromKiloparsecs(double kiloparsecs)
        {
            double value = (double)kiloparsecs;
            return new Length(value, LengthUnit.Kiloparsec);
        }
        /// <summary>
        ///     Get Length from LightYears.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromLightYears(double lightyears)
        {
            double value = (double)lightyears;
            return new Length(value, LengthUnit.LightYear);
        }
        /// <summary>
        ///     Get Length from MegalightYears.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromMegalightYears(double megalightyears)
        {
            double value = (double)megalightyears;
            return new Length(value, LengthUnit.MegalightYear);
        }
        /// <summary>
        ///     Get Length from Megaparsecs.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromMegaparsecs(double megaparsecs)
        {
            double value = (double)megaparsecs;
            return new Length(value, LengthUnit.Megaparsec);
        }
        /// <summary>
        ///     Get Length from Meters.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromMeters(double meters)
        {
            double value = (double)meters;
            return new Length(value, LengthUnit.Meter);
        }
        /// <summary>
        ///     Get Length from Microinches.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromMicroinches(double microinches)
        {
            double value = (double)microinches;
            return new Length(value, LengthUnit.Microinch);
        }
        /// <summary>
        ///     Get Length from Micrometers.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromMicrometers(double micrometers)
        {
            double value = (double)micrometers;
            return new Length(value, LengthUnit.Micrometer);
        }
        /// <summary>
        ///     Get Length from Mils.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromMils(double mils)
        {
            double value = (double)mils;
            return new Length(value, LengthUnit.Mil);
        }
        /// <summary>
        ///     Get Length from Miles.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromMiles(double miles)
        {
            double value = (double)miles;
            return new Length(value, LengthUnit.Mile);
        }
        /// <summary>
        ///     Get Length from Millimeters.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromMillimeters(double millimeters)
        {
            double value = (double)millimeters;
            return new Length(value, LengthUnit.Millimeter);
        }
        /// <summary>
        ///     Get Length from Nanometers.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromNanometers(double nanometers)
        {
            double value = (double)nanometers;
            return new Length(value, LengthUnit.Nanometer);
        }
        /// <summary>
        ///     Get Length from NauticalMiles.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromNauticalMiles(double nauticalmiles)
        {
            double value = (double)nauticalmiles;
            return new Length(value, LengthUnit.NauticalMile);
        }
        /// <summary>
        ///     Get Length from Parsecs.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromParsecs(double parsecs)
        {
            double value = (double)parsecs;
            return new Length(value, LengthUnit.Parsec);
        }
        /// <summary>
        ///     Get Length from PrinterPicas.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromPrinterPicas(double printerpicas)
        {
            double value = (double)printerpicas;
            return new Length(value, LengthUnit.PrinterPica);
        }
        /// <summary>
        ///     Get Length from PrinterPoints.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromPrinterPoints(double printerpoints)
        {
            double value = (double)printerpoints;
            return new Length(value, LengthUnit.PrinterPoint);
        }
        /// <summary>
        ///     Get Length from Shackles.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromShackles(double shackles)
        {
            double value = (double)shackles;
            return new Length(value, LengthUnit.Shackle);
        }
        /// <summary>
        ///     Get Length from SolarRadiuses.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromSolarRadiuses(double solarradiuses)
        {
            double value = (double)solarradiuses;
            return new Length(value, LengthUnit.SolarRadius);
        }
        /// <summary>
        ///     Get Length from Twips.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromTwips(double twips)
        {
            double value = (double)twips;
            return new Length(value, LengthUnit.Twip);
        }
        /// <summary>
        ///     Get Length from UsSurveyFeet.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromUsSurveyFeet(double ussurveyfeet)
        {
            double value = (double)ussurveyfeet;
            return new Length(value, LengthUnit.UsSurveyFoot);
        }
        /// <summary>
        ///     Get Length from Yards.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Length FromYards(double yards)
        {
            double value = (double)yards;
            return new Length(value, LengthUnit.Yard);
        }

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="LengthUnit" /> to <see cref="Length" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Length unit value.</returns>
        public static Length From(double value, LengthUnit fromUnit)
        {
            return new Length((double)value, fromUnit);
        }

        #endregion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public double As(LengthUnit unit) => GetValueAs(unit);

            /// <summary>
            ///     Converts this Length to another Length with the unit representation <paramref name="unit" />.
            /// </summary>
            /// <returns>A Length with the specified unit.</returns>
        public Length ToUnit(LengthUnit unit)
        {
            var convertedValue = GetValueAs(unit);
            return new Length(convertedValue, unit);
        }

        /// <summary>
        ///     Converts the current value + unit to the base unit.
        ///     This is typically the first step in converting from one unit to another.
        /// </summary>
        /// <returns>The value in the base unit representation.</returns>
        private double GetValueInBaseUnit()
        {
            switch (Unit)
            {
                case LengthUnit.AstronomicalUnit: return _value * 1.4959787070e11;
                case LengthUnit.Centimeter: return (_value) * 1e-2d;
                case LengthUnit.Chain: return _value * 20.1168;
                case LengthUnit.Decimeter: return (_value) * 1e-1d;
                case LengthUnit.DtpPica: return _value / 236.220472441;
                case LengthUnit.DtpPoint: return (_value / 72) * 2.54e-2;
                case LengthUnit.Fathom: return _value * 1.8288;
                case LengthUnit.Foot: return _value * 0.3048;
                case LengthUnit.Hand: return _value * 1.016e-1;
                case LengthUnit.Hectometer: return (_value) * 1e2d;
                case LengthUnit.Inch: return _value * 2.54e-2;
                case LengthUnit.KilolightYear: return (_value * 9.46073047258e15) * 1e3d;
                case LengthUnit.Kilometer: return (_value) * 1e3d;
                case LengthUnit.Kiloparsec: return (_value * 3.08567758128e16) * 1e3d;
                case LengthUnit.LightYear: return _value * 9.46073047258e15;
                case LengthUnit.MegalightYear: return (_value * 9.46073047258e15) * 1e6d;
                case LengthUnit.Megaparsec: return (_value * 3.08567758128e16) * 1e6d;
                case LengthUnit.Meter: return _value;
                case LengthUnit.Microinch: return _value * 2.54e-8;
                case LengthUnit.Micrometer: return (_value) * 1e-6d;
                case LengthUnit.Mil: return _value * 2.54e-5;
                case LengthUnit.Mile: return _value * 1609.34;
                case LengthUnit.Millimeter: return (_value) * 1e-3d;
                case LengthUnit.Nanometer: return (_value) * 1e-9d;
                case LengthUnit.NauticalMile: return _value * 1852;
                case LengthUnit.Parsec: return _value * 3.08567758128e16;
                case LengthUnit.PrinterPica: return _value / 237.106301584;
                case LengthUnit.PrinterPoint: return (_value / 72.27) * 2.54e-2;
                case LengthUnit.Shackle: return _value * 27.432;
                case LengthUnit.SolarRadius: return _value * 6.95510000E+08;
                case LengthUnit.Twip: return _value / 56692.913385826;
                case LengthUnit.UsSurveyFoot: return _value * 1200 / 3937;
                case LengthUnit.Yard: return _value * 0.9144;
                default:
                    throw new NotImplementedException($"Can not convert {Unit} to base units.");
            }
        }

        private double GetValueAs(LengthUnit unit)
        {
            if (Unit == unit)
                return _value;

            var baseUnitValue = GetValueInBaseUnit();

            switch (unit)
            {
                case LengthUnit.AstronomicalUnit: return baseUnitValue / 1.4959787070e11;
                case LengthUnit.Centimeter: return (baseUnitValue) / 1e-2d;
                case LengthUnit.Chain: return baseUnitValue / 20.1168;
                case LengthUnit.Decimeter: return (baseUnitValue) / 1e-1d;
                case LengthUnit.DtpPica: return baseUnitValue * 236.220472441;
                case LengthUnit.DtpPoint: return (baseUnitValue / 2.54e-2) * 72;
                case LengthUnit.Fathom: return baseUnitValue / 1.8288;
                case LengthUnit.Foot: return baseUnitValue / 0.3048;
                case LengthUnit.Hand: return baseUnitValue / 1.016e-1;
                case LengthUnit.Hectometer: return (baseUnitValue) / 1e2d;
                case LengthUnit.Inch: return baseUnitValue / 2.54e-2;
                case LengthUnit.KilolightYear: return (baseUnitValue / 9.46073047258e15) / 1e3d;
                case LengthUnit.Kilometer: return (baseUnitValue) / 1e3d;
                case LengthUnit.Kiloparsec: return (baseUnitValue / 3.08567758128e16) / 1e3d;
                case LengthUnit.LightYear: return baseUnitValue / 9.46073047258e15;
                case LengthUnit.MegalightYear: return (baseUnitValue / 9.46073047258e15) / 1e6d;
                case LengthUnit.Megaparsec: return (baseUnitValue / 3.08567758128e16) / 1e6d;
                case LengthUnit.Meter: return baseUnitValue;
                case LengthUnit.Microinch: return baseUnitValue / 2.54e-8;
                case LengthUnit.Micrometer: return (baseUnitValue) / 1e-6d;
                case LengthUnit.Mil: return baseUnitValue / 2.54e-5;
                case LengthUnit.Mile: return baseUnitValue / 1609.34;
                case LengthUnit.Millimeter: return (baseUnitValue) / 1e-3d;
                case LengthUnit.Nanometer: return (baseUnitValue) / 1e-9d;
                case LengthUnit.NauticalMile: return baseUnitValue / 1852;
                case LengthUnit.Parsec: return baseUnitValue / 3.08567758128e16;
                case LengthUnit.PrinterPica: return baseUnitValue * 237.106301584;
                case LengthUnit.PrinterPoint: return (baseUnitValue / 2.54e-2) * 72.27;
                case LengthUnit.Shackle: return baseUnitValue / 27.432;
                case LengthUnit.SolarRadius: return baseUnitValue / 6.95510000E+08;
                case LengthUnit.Twip: return baseUnitValue * 56692.913385826;
                case LengthUnit.UsSurveyFoot: return baseUnitValue * 3937 / 1200;
                case LengthUnit.Yard: return baseUnitValue / 0.9144;
                default:
                    throw new NotImplementedException($"Can not convert {Unit} to {unit}.");
            }
        }
    }
}
