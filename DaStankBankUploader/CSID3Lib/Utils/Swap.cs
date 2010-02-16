// Copyright(C) 2002-2009 Hugo Rumayor Montemayor, All rights reserved.
using System;

namespace Id3Lib
{
    /// <summary>
    /// Performs byte swaping.
    /// </summary>
    internal class Swap
    {
        #region Methods

        public static unsafe ulong UInt64(ulong val)
        {
            byte[] value = BitConverter.GetBytes(val);
            Array.Reverse(value);
            return BitConverter.ToUInt64(value, 0);
        }

        public static unsafe int Int32(int val)
        {
            byte* pVal = (byte*)&val;
            byte swap = pVal[3];
            pVal[3] = pVal[0];
            pVal[0] = swap;
            swap = pVal[2];
            pVal[2] = pVal[1];
            pVal[1] = swap;
            return val;
        }

        public static unsafe uint UInt32(uint val)
        {
            byte* pVal = (byte*)&val;
            byte swap = pVal[3];
            pVal[3] = pVal[0];
            pVal[0] = swap;
            swap = pVal[2];
            pVal[2] = pVal[1];
            pVal[1] = swap;
            return val;
        }

        public static unsafe short Int16(short val)
        {
            byte* pVal = (byte*)&val;
            byte swap = pVal[1];
            pVal[1] = pVal[0];
            pVal[0] = swap;
            return val;
        }

        public static unsafe ushort UInt16(ushort val)
        {
            byte* pVal = (byte*)&val;
            byte swap = pVal[1];
            pVal[1] = pVal[0];
            pVal[0] = swap;
            return val;
        }
        #endregion
    }
}
