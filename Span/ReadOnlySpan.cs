namespace System
{
    /// <summary>
    /// Provides a type- and memory-safe representation of a contiguous region of arbitrary
    /// </summary>
    /// <typeparam name="T">The type of items in the System.ReadOnlySpan.</typeparam>
    public readonly ref struct ReadOnlySpan<T>
    {
        private readonly T[] _array;
        private readonly int _start;
        private readonly int _length;

        /// <summary>
        /// Creates a new System.ReadOnlySpan`1 object over the entirety of a specified array.
        /// </summary>
        /// <param name="array">The array from which to create the System.ReadOnlySpan object.</param>
        public ReadOnlySpan(T[]? array)
        {
            _array = array;
            _length = array != null ? array.Length : 0;
            _start = 0;
        }

        //
        // Summary:
        //     Creates a new System.ReadOnlySpan`1 object from a specified number of T elements starting
        //     at a specified memory address.
        //
        // Parameters:
        //   pointer:
        //     A pointer to the starting address of a specified number of T elements in memory.
        //
        //   length:
        //     The number of T elements to be included in the System.ReadOnlySpan`1.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     T is a reference type or contains pointers and therefore cannot be stored in
        //     unmanaged memory.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     length is negative.
        //[CLSCompliant(false)]
        //public ReadOnlySpan(void* pointer, int length);

        /// <summary>
        /// Creates a new System.ReadOnlySpan`1 object that includes a specified number of elements
        /// of an array starting at a specified index.
        /// </summary>
        /// <param name="array">The source array.</param>
        /// <param name="start">The index of the first element to include in the new System.ReadOnlySpan</param>
        /// <param name="length">The number of elements to include in the new System.ReadOnlySpan</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// array is null, but start or length is non-zero. -or- start is outside the bounds
        /// of the array. -or- start and length exceeds the number of elements in the array.
        /// </exception>
        public ReadOnlySpan(T[]? array, int start, int length)
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
        // public ref T this[int index] => ref _array[_start + index]; // <= this is not working and raises exception after few access
        public T this[int index]
        {
            get
            {
                return _array[_start + index];
            }            
        }

        /// <summary>
        /// Returns an empty System.ReadOnlySpan object.
        /// </summary>
        public static ReadOnlySpan<T> Empty => new ReadOnlySpan<T>();

        /// <summary>
        /// Returns the length of the current ReadOnlySpan.
        /// </summary>
        public int Length => _length;

        /// <summary>
        /// Returns a value that indicates whether the current System.ReadOnlySpan is empty.
        /// true if the current ReadOnlySpan is empty; otherwise, false.
        /// </summary>
        public bool IsEmpty => Length == 0;

        /// <summary>
        /// Copies the contents of this System.ReadOnlySpan into a destination System.ReadOnlySpan.
        /// </summary>
        /// <param name="destination"> The destination System.ReadOnlySpan object.</param>
        /// <exception cref="System.ArgumentException">
        /// destination is shorter than the source System.ReadOnlySpan.
        /// </exception>
        public void CopyTo(Span<T> destination)
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
        /// Forms a slice out of the current ReadOnlySpan that begins at a specified index.
        /// </summary>
        /// <param name="start">The index at which to begin the slice.</param>
        /// <returns>A ReadOnlySpan that consists of all elements of the current ReadOnlySpan from start to the end of the ReadOnlySpan.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">start is less than zero or greater than System.ReadOnlySpan.Length.</exception>
        public ReadOnlySpan<T> Slice(int start)
        {
            if ((start > _length - _start) || (start < 0))
            {
                throw new ArgumentOutOfRangeException($"start is less than zero or greater than length");
            }

            return new ReadOnlySpan<T>(_array, start, Length - start);
        }

        /// <summary>
        /// Forms a slice out of the current ReadOnlySpan starting at a specified index for a specified length.
        /// </summary>
        /// <param name="start">The index at which to begin this slice.</param>
        /// <param name="length">The desired length for the slice.</param>
        /// <returns>A ReadOnlySpan that consists of length elements from the current ReadOnlySpan starting at start.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">start or start + length is less than zero or greater than System.ReadOnlySpan.Length.</exception>
        public ReadOnlySpan<T> Slice(int start, int length)
        {
            if ((start < 0) || (start + length < 0) || (start + length > _length - _start))
            {
                throw new ArgumentOutOfRangeException($"start or start + length is less than zero or greater than length");
            }

            return new ReadOnlySpan<T>(_array, start, length);
        }

        /// <summary>
        /// Copies the contents of this ReadOnlySpan into a new array.
        /// </summary>
        /// <returns> An array containing the data in the current ReadOnlySpan.</returns>
        public T[] ToArray()
        {
            T[] array = new T[Length];
            for (int i = 0; i < Length; i++)
            {
                array[i] = _array[_start + i];
            }

            return array;
        }
    }
}