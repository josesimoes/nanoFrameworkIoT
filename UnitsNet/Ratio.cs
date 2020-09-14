using System;
using UnitsNet.Units;

namespace UnitsNet
{
    public struct Ratio
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly RatioUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public RatioUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public Ratio(double value, RatioUnit unit)
        {
            if (unit == RatioUnit.Undefined)
                throw new ArgumentException("The quantity can not be created with an undefined unit.", nameof(unit));

            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of Ratio, which is DecimalFraction. All conversions go via this value.
        /// </summary>
        public static RatioUnit BaseUnit { get; } = RatioUnit.DecimalFraction;

        /// <summary>
        /// Represents the largest possible value of Ratio
        /// </summary>
        public static Ratio MaxValue { get; } = new Ratio(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Ratio
        /// </summary>
        public static Ratio MinValue { get; } = new Ratio(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit DecimalFraction.
        /// </summary>
        public static Ratio Zero { get; } = new Ratio(0, BaseUnit);

        #region Conversion Properties

        /// <summary>
        ///     Get Ratio in DecimalFractions.
        /// </summary>
        public double DecimalFractions => As(RatioUnit.DecimalFraction);

        /// <summary>
        ///     Get Ratio in PartsPerBillion.
        /// </summary>
        public double PartsPerBillion => As(RatioUnit.PartPerBillion);

        /// <summary>
        ///     Get Ratio in PartsPerMillion.
        /// </summary>
        public double PartsPerMillion => As(RatioUnit.PartPerMillion);

        /// <summary>
        ///     Get Ratio in PartsPerThousand.
        /// </summary>
        public double PartsPerThousand => As(RatioUnit.PartPerThousand);

        /// <summary>
        ///     Get Ratio in PartsPerTrillion.
        /// </summary>
        public double PartsPerTrillion => As(RatioUnit.PartPerTrillion);

        /// <summary>
        ///     Get Ratio in Percent.
        /// </summary>
        public double Percent => As(RatioUnit.Percent);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Get Ratio from DecimalFractions.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Ratio FromDecimalFractions(double decimalfractions)
        {
            double value = (double)decimalfractions;
            return new Ratio(value, RatioUnit.DecimalFraction);
        }
        /// <summary>
        ///     Get Ratio from PartsPerBillion.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Ratio FromPartsPerBillion(double partsperbillion)
        {
            double value = (double)partsperbillion;
            return new Ratio(value, RatioUnit.PartPerBillion);
        }
        /// <summary>
        ///     Get Ratio from PartsPerMillion.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Ratio FromPartsPerMillion(double partspermillion)
        {
            double value = (double)partspermillion;
            return new Ratio(value, RatioUnit.PartPerMillion);
        }
        /// <summary>
        ///     Get Ratio from PartsPerThousand.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Ratio FromPartsPerThousand(double partsperthousand)
        {
            double value = (double)partsperthousand;
            return new Ratio(value, RatioUnit.PartPerThousand);
        }
        /// <summary>
        ///     Get Ratio from PartsPerTrillion.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Ratio FromPartsPerTrillion(double partspertrillion)
        {
            double value = (double)partspertrillion;
            return new Ratio(value, RatioUnit.PartPerTrillion);
        }
        /// <summary>
        ///     Get Ratio from Percent.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Ratio FromPercent(double percent)
        {
            double value = (double)percent;
            return new Ratio(value, RatioUnit.Percent);
        }

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="RatioUnit" /> to <see cref="Ratio" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Ratio unit value.</returns>
        public static Ratio From(double value, RatioUnit fromUnit)
        {
            return new Ratio((double)value, fromUnit);
        }

        #endregion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public double As(RatioUnit unit) => GetValueAs(unit);

        /// <summary>
        ///     Converts this Ratio to another Ratio with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>A Ratio with the specified unit.</returns>
        public Ratio ToUnit(RatioUnit unit)
        {
            var convertedValue = GetValueAs(unit);
            return new Ratio(convertedValue, unit);
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
                case RatioUnit.DecimalFraction: return _value;
                case RatioUnit.PartPerBillion: return _value / 1e9;
                case RatioUnit.PartPerMillion: return _value / 1e6;
                case RatioUnit.PartPerThousand: return _value / 1e3;
                case RatioUnit.PartPerTrillion: return _value / 1e12;
                case RatioUnit.Percent: return _value / 1e2;
                default:
                    throw new NotImplementedException($"Can not convert {Unit} to base units.");
            }
        }

        private double GetValueAs(RatioUnit unit)
        {
            if (Unit == unit)
                return _value;

            var baseUnitValue = GetValueInBaseUnit();

            switch (unit)
            {
                case RatioUnit.DecimalFraction: return baseUnitValue;
                case RatioUnit.PartPerBillion: return baseUnitValue * 1e9;
                case RatioUnit.PartPerMillion: return baseUnitValue * 1e6;
                case RatioUnit.PartPerThousand: return baseUnitValue * 1e3;
                case RatioUnit.PartPerTrillion: return baseUnitValue * 1e12;
                case RatioUnit.Percent: return baseUnitValue * 1e2;
                default:
                    throw new NotImplementedException($"Can not convert {Unit} to {unit}.");
            }
        }
    }
}
