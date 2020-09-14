﻿namespace System.Buffers.Binary
{
    /// <summary>
    /// Reads bytes as primitives with specific endianness.
    /// </summary>
    public static class BinaryPrimitives
    {
        /// <summary>
        /// Reads an System.Int16 from the beginning of a read-only span of bytes, as big endian.
        /// </summary>
        /// <param name="source">The read-only span to read.</param>
        /// <returns>The big endian value.</returns>
        public static short ReadInt16BigEndian(byte[] source)
        {
            if (source.Length < 2)
            {
                throw new ArgumentOutOfRangeException($"source is too small to contain an System.Int16.");
            }

            return (short)(source[0] << 8 | source[1]);
        }

        /// <summary>
        /// Reads an System.Int16 from the beginning of a read-only span of bytes, as little endian.
        /// </summary>
        /// <param name="source">The read-only span to read.</param>
        /// <returns>The little endian value.</returns>
        public static short ReadInt16LittleEndian(byte[] source)
        {
            if (source.Length < 2)
            {
                throw new ArgumentOutOfRangeException($"source is too small to contain an System.Int16.");
            }

            return (short)(source[1] << 8 | source[0]);
        }

        /// <summary>
        /// Reads an System.Int32 from the beginning of a read-only span of bytes, as big endian.
        /// </summary>
        /// <param name="source">The read-only span to read.</param>
        /// <returns>The big endian value.</returns>
        public static int ReadInt32BigEndian(byte[] source)
        {
            if (source.Length < 4)
            {
                throw new ArgumentOutOfRangeException($"source is too small to contain an System.Int32.");
            }

            return (int)(source[0] << 24 | source[1] << 16 | source[2] << 8 | source[3]);
        }

        /// <summary>
        /// Reads an System.Int32 from the beginning of a read-only span of bytes, as little endian.
        /// </summary>
        /// <param name="source">The read-only span to read.</param>
        /// <returns>The little endian value.</returns>
        public static int ReadInt32LittleEndian(byte[] source)
        {
            if (source.Length < 4)
            {
                throw new ArgumentOutOfRangeException($"source is too small to contain an System.Int32.");
            }

            return (int)(source[3] << 24 | source[2] << 16 | source[1] << 8 | source[0]);
        }

        /// <summary>
        /// Reads an System.Int64 from the beginning of a read-only span of bytes, as big endian.
        /// </summary>
        /// <param name="source">The read-only span to read.</param>
        /// <returns>The big endian value.</returns>
        public static long ReadInt64BigEndian(byte[] source)
        {
            if (source.Length < 8)
            {
                throw new ArgumentOutOfRangeException($"source is too small to contain an System.Int64.");
            }

            return ((long)source[7] << 56 | (long)source[6] << 48 | (long)source[5] << 40 | (long)source[4] << 32 |
                (long)source[3] << 24 | (long)source[2] << 16 | (long)source[1] << 8 | (long)source[0]);
        }

        /// <summary>
        /// Reads an System.Int64 from the beginning of a read-only span of bytes, as little endian.
        /// </summary>
        /// <param name="source">The read-only span to read.</param>
        /// <returns>The little endian value.</returns>
        public static long ReadInt64LittleEndian(byte[] source)
        {
            if (source.Length < 8)
            {
                throw new ArgumentOutOfRangeException($"source is too small to contain an System.Int64.");
            }

            return ((long)source[0] << 56 | (long)source[1] << 48 | (long)source[2] << 40 | (long)source[3] << 32 |
                (long)source[4] << 24 | (long)source[5] << 16 | (long)source[6] << 8 | (long)source[7]);
        }

        /// <summary>
        /// Reads a System.UInt16 from the beginning of a read-only span of bytes, as big  endian.
        /// </summary>
        /// <param name="source">The read-only span to read.</param>
        /// <returns>The big endian value.</returns>
        public static ushort ReadUInt16BigEndian(byte[] source)
        {
            if (source.Length < 2)
            {
                throw new ArgumentOutOfRangeException($"source is too small to contain an System.UInt16.");
            }

            return (ushort)(source[0] << 8 | source[1]);
        }

        /// <summary>
        /// Reads a System.UInt16 from the beginning of a read-only span of bytes, as little endian.
        /// </summary>
        /// <param name="source">The read-only span to read.</param>
        /// <returns>The little endian value.</returns>
        public static ushort ReadUInt16LittleEndian(byte[] source)
        {
            if (source.Length < 2)
            {
                throw new ArgumentOutOfRangeException($"source is too small to contain an System.UInt16.");
            }

            return (ushort)(source[1] << 8 | source[0]);
        }

        /// <summary>
        /// Reads a System.UInt32 from the beginning of a read-only span of bytes, as big endian.
        /// </summary>
        /// <param name="source">The read-only span to read.</param>
        /// <returns> The big endian value.</returns>
        public static uint ReadUInt32BigEndian(byte[] source)
        {
            if (source.Length < 4)
            {
                throw new ArgumentOutOfRangeException($"source is too small to contain an System.UInt32.");
            }

            return (uint)(source[0] << 24 | source[1] << 16 | source[2] << 8 | source[3]);
        }

        /// <summary>
        /// Reads a System.UInt32 from the beginning of a read-only span of bytes, as little endian.
        /// </summary>
        /// <param name="source">The read-only span of bytes to read.</param>
        /// <returns>The little endian value.</returns>
        public static uint ReadUInt32LittleEndian(byte[] source)
        {
            if (source.Length < 4)
            {
                throw new ArgumentOutOfRangeException($"source is too small to contain an System.UInt32.");
            }

            return (uint)(source[3] << 24 | source[2] << 16 | source[1] << 8 | source[0]);
        }

        /// <summary>
        /// Reads a System.UInt64 from the beginning of a read-only span of bytes, as big  endian.
        /// </summary>
        /// <param name="source">The read-only span of bytes to read.</param>
        /// <returns>The big endian value.</returns>
        public static ulong ReadUInt64BigEndian(byte[] source)
        {
            if (source.Length < 8)
            {
                throw new ArgumentOutOfRangeException($"source is too small to contain an System.UInt64.");
            }

            return ((ulong)source[7] << 56 | (ulong)source[6] << 48 | (ulong)source[5] << 40 | (ulong)source[4] << 32 |
                (ulong)source[3] << 24 | (ulong)source[2] << 16 | (ulong)source[1] << 8 | (ulong)source[0]);
        }

        /// <summary>
        /// Reads a System.UInt64 from the beginning of a read-only span of bytes, as little endian.
        /// </summary>
        /// <param name="source">The read-only span of bytes to read.</param>
        /// <returns>The little endian value.</returns>
        public static ulong ReadUInt64LittleEndian(byte[] source)
        {
            if (source.Length < 8)
            {
                throw new ArgumentOutOfRangeException($"source is too small to contain an System.UInt64.");
            }

            return ((ulong)source[0] << 56 | (ulong)source[1] << 48 | (ulong)source[2] << 40 | (ulong)source[3] << 32 |
                (ulong)source[4] << 24 | (ulong)source[5] << 16 | (ulong)source[6] << 8 | (ulong)source[7]);
        }

        /// <summary>
        /// Writes an System.Int16 into a span of bytes, as big endian.
        /// </summary>
        /// <param name="destination">The span of bytes where the value is to be written, as big endian.</param>
        /// <param name="value">The value to write into the span of bytes.</param>
        public static void WriteInt16BigEndian(byte[] destination, short value)
        {
            if (destination.Length < 2)
            {
                throw new ArgumentOutOfRangeException($"destination is too small to contain an System.Int16.");
            }

            destination[0] = (byte)(value >> 8);
            destination[1] = (byte)value;
        }

        /// <summary>
        /// Writes an System.Int16 into a span of bytes, as little endian.
        /// </summary>
        /// <param name="destination">The span of bytes where the value is to be written, as little endian.</param>
        /// <param name="value">The value to write into the span of bytes.</param>
        public static void WriteInt16LittleEndian(byte[] destination, short value)
        {
            if (destination.Length < 2)
            {
                throw new ArgumentOutOfRangeException($"destination is too small to contain an System.Int16.");
            }

            destination[1] = (byte)(value >> 8);
            destination[0] = (byte)value;
        }

        /// <summary>
        /// Writes an System.Int32 into a span of bytes, as big endian.
        /// </summary>
        /// <param name="destination">The span of bytes where the value is to be written, as big endian.</param>
        /// <param name="value">The value to write into the span of bytes.</param>
        public static void WriteInt32BigEndian(byte[] destination, int value)
        {
            if (destination.Length < 4)
            {
                throw new ArgumentOutOfRangeException($"destination is too small to contain an System.Int32.");
            }

            destination[0] = (byte)(value >> 24);
            destination[1] = (byte)(value >> 16);
            destination[2] = (byte)(value >> 8);
            destination[3] = (byte)value;
        }

        /// <summary>
        /// Writes an System.Int32 into a span of bytes, as little endian.
        /// </summary>
        /// <param name="destination">The span of bytes where the value is to be written, as little endian.</param>
        /// <param name="value">The value to write into the span of bytes.</param>
        public static void WriteInt32LittleEndian(byte[] destination, int value)
        {
            if (destination.Length < 4)
            {
                throw new ArgumentOutOfRangeException($"destination is too small to contain an System.Int32.");
            }

            destination[3] = (byte)(value >> 24);
            destination[2] = (byte)(value >> 16);
            destination[1] = (byte)(value >> 8);
            destination[0] = (byte)value;
        }

        /// <summary>
        /// Writes an System.Int64 into a span of bytes, as big endian.
        /// </summary>
        /// <param name="destination">The span of bytes where the value is to be written, as big endian.</param>
        /// <param name="value">The value to write into the span of bytes.</param>
        public static void WriteInt64BigEndian(byte[] destination, long value)
        {
            if (destination.Length < 8)
            {
                throw new ArgumentOutOfRangeException($"destination is too small to contain an System.Int64.");
            }

            destination[0] = (byte)(value >> 56);
            destination[1] = (byte)(value >> 48);
            destination[2] = (byte)(value >> 40);
            destination[3] = (byte)(value >> 32);
            destination[4] = (byte)(value >> 24);
            destination[5] = (byte)(value >> 16);
            destination[6] = (byte)(value >> 8);
            destination[7] = (byte)value;
        }

        /// <summary>
        /// Writes an System.Int64 into a span of bytes, as little endian.
        /// </summary>
        /// <param name="destination">The span of bytes where the value is to be written, as little endian.</param>
        /// <param name="value">The value to write into the span of bytes.</param>
        public static void WriteInt64LittleEndian(byte[] destination, long value)
        {
            if (destination.Length < 8)
            {
                throw new ArgumentOutOfRangeException($"destination is too small to contain an System.Int64.");
            }

            destination[7] = (byte)(value >> 56);
            destination[6] = (byte)(value >> 48);
            destination[5] = (byte)(value >> 40);
            destination[4] = (byte)(value >> 32);
            destination[3] = (byte)(value >> 24);
            destination[2] = (byte)(value >> 16);
            destination[1] = (byte)(value >> 8);
            destination[0] = (byte)value;
        }

        /// <summary>
        /// Writes a System.UInt16 into a span of bytes, as big endian.
        /// </summary>
        /// <param name="destination">The span of bytes where the value is to be written, as big endian.</param>
        /// <param name="value">The value to write into the span of bytes.</param>
        public static void WriteUInt16BigEndian(byte[] destination, ushort value)
        {
            if (destination.Length < 2)
            {
                throw new ArgumentOutOfRangeException($"destination is too small to contain an System.Int16.");
            }

            destination[0] = (byte)(value >> 8);
            destination[1] = (byte)value;
        }

        /// <summary>
        /// Writes a System.UInt16 into a span of bytes, as little endian.
        /// </summary>
        /// <param name="destination">The span of bytes where the value is to be written, as little endian.</param>
        /// <param name="value">The value to write into the span of bytes.</param>
        public static void WriteUInt16LittleEndian(byte[] destination, ushort value)
        {
            if (destination.Length < 2)
            {
                throw new ArgumentOutOfRangeException($"destination is too small to contain an System.Int16.");
            }

            destination[1] = (byte)(value >> 8);
            destination[0] = (byte)value;
        }

        /// <summary>
        /// Writes a System.UInt32 into a span of bytes, as big endian.
        /// </summary>
        /// <param name="destination">The span of bytes where the value is to be written, as big endian.</param>
        /// <param name="value">The value to write into the span of bytes.</param>
        public static void WriteUInt32BigEndian(byte[] destination, uint value)
        {
            if (destination.Length < 4)
            {
                throw new ArgumentOutOfRangeException($"destination is too small to contain an System.Int32.");
            }

            destination[0] = (byte)(value >> 24);
            destination[1] = (byte)(value >> 16);
            destination[2] = (byte)(value >> 8);
            destination[3] = (byte)value;
        }

        /// <summary>
        /// Writes a System.UInt32 into a span of bytes, as little endian.
        /// </summary>
        /// <param name="destination">The span of bytes where the value is to be written, as little endian.</param>
        /// <param name="value">The value to write into the span of bytes.</param>
        public static void WriteUInt32LittleEndian(byte[] destination, uint value)
        {
            if (destination.Length < 4)
            {
                throw new ArgumentOutOfRangeException($"destination is too small to contain an System.Int32.");
            }

            destination[3] = (byte)(value >> 24);
            destination[2] = (byte)(value >> 16);
            destination[1] = (byte)(value >> 8);
            destination[0] = (byte)value;
        }

        /// <summary>
        /// Writes a System.UInt64 into a span of bytes, as big endian.
        /// </summary>
        /// <param name="destination">The span of bytes where the value is to be written, as big endian.</param>
        /// <param name="value">The value to write into the span of bytes.</param>
        public static void WriteUInt64BigEndian(byte[] destination, ulong value)
        {
            if (destination.Length < 8)
            {
                throw new ArgumentOutOfRangeException($"destination is too small to contain an System.Int64.");
            }

            destination[0] = (byte)(value >> 56);
            destination[1] = (byte)(value >> 48);
            destination[2] = (byte)(value >> 40);
            destination[3] = (byte)(value >> 32);
            destination[4] = (byte)(value >> 24);
            destination[5] = (byte)(value >> 16);
            destination[6] = (byte)(value >> 8);
            destination[7] = (byte)value;
        }

        /// <summary>
        /// Writes a System.UInt64 into a span of bytes, as little endian.
        /// </summary>
        /// <param name="destination">The span of bytes where the value is to be written, as little endian.</param>
        /// <param name="value">The value to write into the span of bytes.</param>
        public static void WriteUInt64LittleEndian(byte[] destination, ulong value)
        {
            if (destination.Length < 8)
            {
                throw new ArgumentOutOfRangeException($"destination is too small to contain an System.Int64.");
            }

            destination[7] = (byte)(value >> 56);
            destination[6] = (byte)(value >> 48);
            destination[5] = (byte)(value >> 40);
            destination[4] = (byte)(value >> 32);
            destination[3] = (byte)(value >> 24);
            destination[2] = (byte)(value >> 16);
            destination[1] = (byte)(value >> 8);
            destination[0] = (byte)value;
        }
    }
}