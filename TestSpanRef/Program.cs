using System;
using System.Diagnostics;

namespace TestSpanRef
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                decimal dec = 23;
                Debug.WriteLine($"{dec}");
                //SpanByte span = new byte[2];
                //span[0] = 42;
                //span[1] = 24;
                //Debug.WriteLine($"{span.Length}, {span[0]}, {span[1]}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex}");
            }
        }
    }

    public ref struct SpanByte
    {
        private byte[] _array;
        private int _length;

        public SpanByte(byte[] array)
        {
            _array = array;
            _length = array == null ? 0 : array.Length;
        }

        public ref byte this[int index] => ref _array[index];

        public int Length => _length;

        public static implicit operator SpanByte(byte[] array)
        {
            return new SpanByte(array);
        }
    }

}
