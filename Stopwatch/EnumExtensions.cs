
namespace System
{
    /// <summary>
    /// Extension for the Enum class
    /// </summary>
    public static class EnumExtentsions
    {
        /// <summary>
        /// Returns a Boolean telling whether a given integral value, or its name as a string,
        /// exists in a specified enumeration.
        /// </summary>
        /// <param name="enumType">An enumeration type.</param>
        /// <param name="value">The value or name of a constant in enumType.</param>
        /// <returns></returns>
        public static bool IsDefined(this Enum enumExt, Type enumType, object value)
        {
            if ((enumType == null) || (value == null))
            {
                throw new ArgumentNullException("enumType or value is null.");
            }

            if (!enumType.IsEnum)
            {
                throw new ArgumentException("enumType is not an Enum. -or- The type of value is an enumeration, but it is " +
                    "not an enumeration of type enumType. -or- The type of value is not an underlying type of enumType.");
            }

            if ((typeof(ValueType) == typeof(sbyte)) ||
               (typeof(ValueType) == typeof(short)) ||
               (typeof(ValueType) == typeof(int)) ||
               (typeof(ValueType) == typeof(long)) ||
               (typeof(ValueType) == typeof(ushort)) ||
               (typeof(ValueType) == typeof(uint)) ||
               (typeof(ValueType) == typeof(ulong)) ||
               (typeof(ValueType) == typeof(string)) ||
               (typeof(ValueType) == typeof(byte)))
            {
                // TODO: check if the enum is defined                
                return true;
            }

            throw new InvalidOperationException("value is not type System.SByte, System.Int16, System.Int32, System.Int64, System.Byte, System.UInt16, System.UInt32, or System.UInt64, or System.String.");
        }
    }
}
