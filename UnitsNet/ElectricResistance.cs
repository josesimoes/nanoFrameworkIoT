using System;
using UnitsNet.Units;

namespace UnitsNet
{
    public struct ElectricResistance
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly ElectricResistanceUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public ElectricResistanceUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public ElectricResistance(double value, ElectricResistanceUnit unit)
        {
            _value =value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of ElectricResistance, which is Ohm. All conversions go via this value.
        /// </summary>
        public static ElectricResistanceUnit BaseUnit { get; } = ElectricResistanceUnit.Ohm;

        /// <summary>
        /// Represents the largest possible value of ElectricResistance
        /// </summary>
        public static ElectricResistance MaxValue { get; } = new ElectricResistance(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of ElectricResistance
        /// </summary>
        public static ElectricResistance MinValue { get; } = new ElectricResistance(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Ohm.
        /// </summary>
        public static ElectricResistance Zero { get; } = new ElectricResistance(0, BaseUnit);

        #region Conversion Properties

        /// <summary>
        ///     Get ElectricResistance in Gigaohms.
        /// </summary>
        public double Gigaohms => As(ElectricResistanceUnit.Gigaohm);

        /// <summary>
        ///     Get ElectricResistance in Kiloohms.
        /// </summary>
        public double Kiloohms => As(ElectricResistanceUnit.Kiloohm);

        /// <summary>
        ///     Get ElectricResistance in Megaohms.
        /// </summary>
        public double Megaohms => As(ElectricResistanceUnit.Megaohm);

        /// <summary>
        ///     Get ElectricResistance in Microohms.
        /// </summary>
        public double Microohms => As(ElectricResistanceUnit.Microohm);

        /// <summary>
        ///     Get ElectricResistance in Milliohms.
        /// </summary>
        public double Milliohms => As(ElectricResistanceUnit.Milliohm);

        /// <summary>
        ///     Get ElectricResistance in Ohms.
        /// </summary>
        public double Ohms => As(ElectricResistanceUnit.Ohm);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Get ElectricResistance from Gigaohms.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ElectricResistance FromGigaohms(double gigaohms)
        {
            double value = (double)gigaohms;
            return new ElectricResistance(value, ElectricResistanceUnit.Gigaohm);
        }
        /// <summary>
        ///     Get ElectricResistance from Kiloohms.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ElectricResistance FromKiloohms(double kiloohms)
        {
            double value = (double)kiloohms;
            return new ElectricResistance(value, ElectricResistanceUnit.Kiloohm);
        }
        /// <summary>
        ///     Get ElectricResistance from Megaohms.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ElectricResistance FromMegaohms(double megaohms)
        {
            double value = (double)megaohms;
            return new ElectricResistance(value, ElectricResistanceUnit.Megaohm);
        }
        /// <summary>
        ///     Get ElectricResistance from Microohms.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ElectricResistance FromMicroohms(double microohms)
        {
            double value = (double)microohms;
            return new ElectricResistance(value, ElectricResistanceUnit.Microohm);
        }
        /// <summary>
        ///     Get ElectricResistance from Milliohms.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ElectricResistance FromMilliohms(double milliohms)
        {
            double value = (double)milliohms;
            return new ElectricResistance(value, ElectricResistanceUnit.Milliohm);
        }
        /// <summary>
        ///     Get ElectricResistance from Ohms.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ElectricResistance FromOhms(double ohms)
        {
            double value = (double)ohms;
            return new ElectricResistance(value, ElectricResistanceUnit.Ohm);
        }

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ElectricResistanceUnit" /> to <see cref="ElectricResistance" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>ElectricResistance unit value.</returns>
        public static ElectricResistance From(double value, ElectricResistanceUnit fromUnit)
        {
            return new ElectricResistance((double)value, fromUnit);
        }

        #endregion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public double As(ElectricResistanceUnit unit) => GetValueAs(unit);

        /// <summary>
        ///     Converts the current value + unit to the base unit.
        ///     This is typically the first step in converting from one unit to another.
        /// </summary>
        /// <returns>The value in the base unit representation.</returns>
        private double GetValueInBaseUnit()
        {
            switch (Unit)
            {
                case ElectricResistanceUnit.Gigaohm: return (_value) * 1e9d;
                case ElectricResistanceUnit.Kiloohm: return (_value) * 1e3d;
                case ElectricResistanceUnit.Megaohm: return (_value) * 1e6d;
                case ElectricResistanceUnit.Microohm: return (_value) * 1e-6d;
                case ElectricResistanceUnit.Milliohm: return (_value) * 1e-3d;
                case ElectricResistanceUnit.Ohm: return _value;
                default:
                    throw new NotImplementedException($"Can not convert {Unit} to base units.");
            }
        }

        private double GetValueAs(ElectricResistanceUnit unit)
        {
            if (Unit == unit)
                return _value;

            var baseUnitValue = GetValueInBaseUnit();

            switch (unit)
            {
                case ElectricResistanceUnit.Gigaohm: return (baseUnitValue) / 1e9d;
                case ElectricResistanceUnit.Kiloohm: return (baseUnitValue) / 1e3d;
                case ElectricResistanceUnit.Megaohm: return (baseUnitValue) / 1e6d;
                case ElectricResistanceUnit.Microohm: return (baseUnitValue) / 1e-6d;
                case ElectricResistanceUnit.Milliohm: return (baseUnitValue) / 1e-3d;
                case ElectricResistanceUnit.Ohm: return baseUnitValue;
                default:
                    throw new NotImplementedException($"Can not convert {Unit} to {unit}.");
            }
        }
    }
}
