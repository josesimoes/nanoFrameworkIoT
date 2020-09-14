﻿namespace System
{
    /// <summary>
    /// Provides a type- and memory-safe representation of a contiguous region of arbitrary
    /// </summary>
    /// <typeparam name="T">The type of items in the System.Span.</typeparam>
    public ref struct SpanByte
    {
        private byte[] _array;
        private readonly int _start;
        private readonly int _length;

        /// <summary>
        /// Creates a new System.Span`1 object over the entirety of a specified array.
        /// </summary>
        /// <param name="array">The array from which to create the System.Span object.</param>
        public SpanByte(byte[] array)
        {
            _array = array;
            _length = array != null ? array.Length : 0;
            _start = 0;
        }

        //
        // Summary:
        //     Creates a new System.Span`1 object from a specified number of T elements starting
        //     at a specified memory address.
        //
        // Parameters:
        //   pointer:
        //     A pointer to the starting address of a specified number of T elements in memory.
        //
        //   length:
        //     The number of T elements to be included in the System.Span`1.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     T is a reference type or contains pointers and therefore cannot be stored in
        //     unmanaged memory.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     length is negative.
        //[CLSCompliant(false)]
        //public Span(void* pointer, int length);

        /// <summary>
        /// Creates a new System.Span`1 object that includes a specified number of elements
        /// of an array starting at a specified index.
        /// </summary>
        /// <param name="array">The source array.</param>
        /// <param name="start">The index of the first element to include in the new System.Span</param>
        /// <param name="length">The number of elements to include in the new System.Span</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// array is null, but start or length is non-zero. -or- start is outside the bounds
        /// of the array. -or- start and length exceeds the number of elements in the array.
        /// </exception>
        public SpanByte(byte[] array, int start, int length)
        {
            if (array != null)
            {
                if ((length > array.Length - start) || (start >= array.Length))
                {
                    throw new ArgumentOutOfRangeException($"Array length too small");
                }
            }
            else
            {
                if ((start != 0) || (length != 0))
                {
                    throw new ArgumentOutOfRangeException($"Array is null but start and length are not 0");
                }
            }

            _array = array;
            _start = start;
            _length = length;
        }

        /// <summary>
        /// Gets the element at the specified zero-based index.
        /// </summary>
        /// <param name="index">The zero-based index of the element.</param>
        /// <returns>The element at the specified index.</returns>
        public byte this[int index]
        {
            get
            {
                return _array[_start + index];
            }
            set
            {
                _array[_start + index] = value;
            }
        }

        /// <summary>
        /// Returns an empty System.Span object.
        /// </summary>
        public static SpanByte Empty => new SpanByte();

        /// <summary>
        /// Returns the length of the current span.
        /// </summary>
        public int Length => _length;

        /// <summary>
        /// Returns a value that indicates whether the current System.Span is empty.
        /// true if the current span is empty; otherwise, false.
        /// </summary>
        public bool IsEmpty => Length == 0;

        /// <summary>
        /// Copies the contents of this System.Span into a destination System.Span.
        /// </summary>
        /// <param name="destination"> The destination System.Span object.</param>
        /// <exception cref="System.ArgumentException">
        /// destination is shorter than the source System.Span.
        /// </exception>
        public void CopyTo(SpanByte destination)
        {
            if (destination.Length < _length - _start)
            {
                throw new ArgumentException($"Destination too small");
            }

            for (int i = 0; i < _array.Length; i++)
            {
                destination[i] = _array[i];
            }
        }

        /// <summary>
        /// Forms a slice out of the current span that begins at a specified index.
        /// </summary>
        /// <param name="start">The index at which to begin the slice.</param>
        /// <returns>A span that consists of all elements of the current span from start to the end of the span.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">start is less than zero or greater than System.Span.Length.</exception>
        public SpanByte Slice(int start)
        {
            if ((start > _length - _start) || (start < 0))
            {
                throw new ArgumentOutOfRangeException($"start is less than zero or greater than length");
            }

            return new SpanByte(_array, _start + start, Length - start - _start);
        }

        /// <summary>
        /// Forms a slice out of the current span starting at a specified index for a specified length.
        /// </summary>
        /// <param name="start">The index at which to begin this slice.</param>
        /// <param name="length">The desired length for the slice.</param>
        /// <returns>A span that consists of length elements from the current span starting at start.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">start or start + length is less than zero or greater than System.Span.Length.</exception>
        public SpanByte Slice(int start, int length)
        {
            if ((start < 0) || (start + length < 0) || (start + length > _length - _start))
            {
                throw new ArgumentOutOfRangeException($"start or start + length is less than zero or greater than length");
            }

            return new SpanByte(_array, _start + start, length);
        }

        /// <summary>
        /// Copies the contents of this span into a new array.
        /// </summary>
        /// <returns> An array containing the data in the current span.</returns>
        public byte[] ToArray()
        {
            byte[] array = new byte[Length];
            for (int i = 0; i < Length; i++)
            {
                array[i] = _array[_start + i];
            }

            return array;
        }

        public static implicit operator SpanByte(byte[] array)
        {
            return new SpanByte(array);
        }

        /// <summary>
        /// Defines an implicit conversion of a System.Span`1 to a System.ReadOnlySpan.
        /// </summary>
        /// <param name="span">The object to convert to a System.ReadOnlySpan.</param>
        //public static implicit operator ReadOnlySpanByte(SpanByte span)
        //{
        //    return span;
        //}
    }
}