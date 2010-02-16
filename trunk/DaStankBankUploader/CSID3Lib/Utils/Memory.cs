// Copyright(C) 2002-2009 Hugo Rumayor Montemayor, All rights reserved.

using System;

namespace Id3Lib
{
    /// <summary>
    /// Provides static methods to compare, find, copy and clear a byte array.
    /// </summary>
    internal class Memory
    {
        #region Methods
        /// <summary>
        /// Compare two byte arrays and determine if they are equal
        /// </summary>
        /// <param name="b1">First byte array</param>
        /// <param name="b2">Second byte array</param>
        /// <param name="count">Number of bytes to compare</param>
        /// <returns>Returns true if the arrays are equal</returns>
        public static unsafe bool Compare(byte[] b1, byte[] b2, int count)
        {
            if (b1 == null)
                throw new ArgumentNullException("b1");
            if (b2 == null)
                throw new ArgumentNullException("b2");
            if (count < 0 || b1.Length < count || b2.Length < count)
                throw new InvalidOperationException();

            fixed (byte* pSrc = b1, pDst = b2)
            {
                byte* ps = pSrc;
                byte* pd = pDst;
                // Loop over the count in blocks of 4 bytes, comparing an
                // integer at a time:
                for (int n = count >> 2; n != 0; n--)
                {
                    if (*((int*)pd) != *((int*)ps))
                        return false;
                    pd += 4;
                    ps += 4;
                }
                // Complete the copy by moving any bytes that weren't
                // moved in blocks of 4:
                for (count &= 3; count != 0; count--)
                {
                    if (*pd != *ps)
                        return false;
                    pd++;
                    ps++;
                }
            }
            return true;
        }

        /// <summary>
        /// Compare two byte arrays and determine if they are equal
        /// </summary>
        /// <param name="b1">First byte array</param>
        /// <param name="b1Index">Offset of the first byte array</param>
        /// <param name="b2">Second byte array</param>
        /// <param name="b2Index">Offset of the second byte array</param>
        /// <param name="count">Number of bytes to compare</param>
        /// <returns>Returns true if the arrays are equal</returns>
        public static unsafe bool Compare(byte[] b1, int b1Index, byte[] b2, int b2Index, int count)
        {
            if (b1 == null)
                throw new ArgumentNullException("b1");
            if (b2 == null)
                throw new ArgumentNullException("b2");

            if (b1 == null || b1Index < 0 || b2 == null || b2Index < 0 || count < 0)
                throw new InvalidOperationException();
          
            if (b1.Length - b1Index < count || b2.Length - b2Index < count)
                throw new InvalidOperationException();
            
            fixed (byte* pSrc = b1, pDst = b2)
            {
                byte* ps = pSrc + b1Index;
                byte* pd = pDst + b2Index;
                // Loop over the count in blocks of 4 bytes, comparing an
                // integer at a time:
                for (int n = count >> 2; n != 0; n--)
                {
                    if (*((int*)pd) != *((int*)ps))
                        return false;
                    pd += 4;
                    ps += 4;
                }
                // Complete the copy by moving any bytes that weren't
                // moved in blocks of 4:
                for (count &= 3; count != 0; count--)
                {
                    if (*pd != *ps)
                        return false;
                    pd++;
                    ps++;
                }
            }
            return true;
        }

        /// <summary>
        /// Copy form the source array to the destination array
        /// </summary>
        /// <param name="src">Source array</param>
        /// <param name="dst">Destination array</param>
        /// <param name="count">Number of bytes to copy</param>
        public static unsafe void Copy(byte[] src, byte[] dst, int count)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");

            if (count < 0 || src.Length < count || dst.Length < count)
            {
                throw new InvalidOperationException();
            }
            fixed (byte* pSrc = src, pDst = dst)
            {
                byte* ps = pSrc;
                byte* pd = pDst;
                // Loop over the count in blocks of 4 bytes, comparing an
                // integer at a time:
                for (int n = count >> 2; n != 0; n--)
                {
                    *((int*)pd) = *((int*)ps);
                    pd += 4;
                    ps += 4;
                }
                // Complete the copy by moving any bytes that weren't
                // moved in blocks of 4:
                for (count &= 3; count != 0; count--)
                {
                    *pd = *ps;
                    pd++;
                    ps++;
                }
            }
        }
        /// <summary>
        /// Copy form the source array to the destination array
        /// </summary>
        /// <param name="src">Source array</param>
        /// <param name="srcIndex">Offset of the source array</param>
        /// <param name="dst">Destination array</param>
        /// <param name="dstIndex">Offset of the destination array</param>
        /// <param name="count">Number of bytes to copy</param>
        public static unsafe void Copy(byte[] src, int srcIndex, byte[] dst, int dstIndex, int count)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");

            if (src == null || srcIndex < 0 || dst == null || dstIndex < 0 || count < 0)
                throw new InvalidOperationException();
            
            if (src.Length - srcIndex < count || dst.Length - dstIndex < count)
                throw new InvalidOperationException();
            
            fixed (byte* pSrc = src, pDst = dst)
            {
                byte* ps = pSrc + srcIndex;
                byte* pd = pDst + dstIndex;
                // Loop over the count in blocks of 4 bytes, copying an
                // integer at a time:
                for (int n = count >> 2; n != 0; n--)
                {
                    *((int*)pd) = *((int*)ps);
                    pd += 4;
                    ps += 4;
                }
                // Complete the copy by moving any bytes that weren't
                // moved in blocks of 4:
                for (count &= 3; count != 0; count--)
                {
                    *pd = *ps;
                    pd++;
                    ps++;
                }
            }
        }

        /// <summary>
        /// Find a byte in the array
        /// </summary>
        /// <param name="src">Source array</param>
        /// <param name="val">Byte value to find</param>
        /// <param name="index">Offset of the source array</param>
        /// <returns></returns>
        public static unsafe int FindByte(byte[] src, byte val, int index)
        {
            int n, size = src.Length;

            if (index > size)
                throw new InvalidOperationException();

            fixed (byte* pSrc = src)
            {
                byte* ps = &pSrc[index];

                for (n = index; n < size; n++)
                {
                    if (*ps == val)
                    {
                        return n - index;
                    };
                    ps++;
                }
            }
            return -1;
        }
        /// <summary>
        /// Find a short in the array
        /// </summary>
        /// <param name="src">Source array</param>
        /// <param name="val">Short value to find</param>
        /// <param name="index">Offset of the source array</param>
        /// <returns></returns>
        public static unsafe int FindShort(byte[] src, short val, int index)
        {
            if (src == null)
                throw new ArgumentNullException("src");

            int n, size = src.Length;
            if (index > size)
                throw new InvalidOperationException();

            fixed (byte* pSrc = src)
            {
                byte* ps = &pSrc[index];

                for (n = (size - index) >> 1; n != 0; n--)
                {
                    if (*(short*)ps == val)
                    {
                        return (((size - index) >> 1) - n) * 2;
                    };
                    ps += 2;
                }
            }
            return -1;
        }

        /// <summary>
        /// Clear an array
        /// </summary>
        /// <param name="src">Source array</param>
        /// <param name="begin">Start position</param>
        /// <param name="end">End position</param>
        public static unsafe void Clear(byte[] src, int begin, int end)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (begin > end || begin > src.Length || end > src.Length)
                throw new InvalidOperationException();

            fixed (byte* pSrc = src)
            {
                byte* ps = &pSrc[begin];
                int count = end - begin;
                // Loop over the count in blocks of 4 bytes, comparing an
                // integer at a time:
                for (int n = count >> 2; n != 0; n--)
                {
                    *((int*)ps) = 0;
                    ps += 4;
                }
                // Complete the copy by moving any bytes that weren't
                // moved in blocks of 4:
                for (count &= 3; count != 0; count--)
                {
                    *ps = 0;
                    ps++;
                }
            }
        }

        /// <summary>
        /// Get a unsigned long from a byte array
        /// </summary>
        /// <param name="value">a byte array from 1 to 8 bytes</param>
        /// <returns>unsigned long</returns>
        public static unsafe ulong ToInt64(byte[] value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            if (value.Length > 8)
                throw new InvalidOperationException("The count is to large to be stored");

            ulong count = 0;
            byte* pCount = (byte*)&count;

            for (int i = 0; i < value.Length; i++)
            {
                pCount[i] = value[i];
            }
            return count;
        }

        /// <summary>
        /// get an array from the unsiged long not smaller that 4 bytes
        /// </summary>
        /// <param name="value">unsigned long to convert to an array</param>
        /// <returns>the used bytes form the unsgened long</returns>
        public static unsafe byte[] GetBytes(ulong value)
        {
            byte[] source = BitConverter.GetBytes(value);

            int i;
            for (i = sizeof(ulong) - 1; i > 3; i--)
            {
                if (source[i] != 0)
                    break;
            }
            byte[] result = new byte[i + 1];
            Array.Copy(source, result, i + 1);
            return result;
        }

        #endregion
    }
}
