// Copyright(C) 2002-2009 Hugo Rumayor Montemayor, All rights reserved.
using System;
using System.IO;

namespace Id3Lib
{
	/// <summary>
	/// Provides static methods for making ID3v2 unsynchronisation
	/// </summary>
	/// <remarks>
	/// This helper class takes care of the synchronisation and unsynchronisation needs.
	/// The purpose of unsynchronisation is to make the ID3v2 tag as compatible as possible
	/// with existing software and hardware.
	/// 
	/// Synchsafe integers are integers that keep its highest byte bit (bit 7) zeroed, making seven bits
	/// out of every eight available.
	/// </remarks>
	internal class Sync
	{
		#region Methods
		/// <summary>
		/// Converts from a syncsafe integer to a normal integer
		/// </summary>
		/// <param name="val">Litle-endian Sincsafe value</param>
		/// <returns>Litle-endian normal value</returns>
		public static unsafe uint Unsafe(uint val)
		{
			byte* pVal = (byte*)&val;
			if(pVal[0] > 0x7f || pVal[1] > 0x7f || pVal[2] > 0x7f || pVal[3] > 0x7f)
			{
				throw new InvalidTagException("Syncsafe value corrupted");
			}

			uint sync = 0;
			byte* pSync = (byte*)&sync;
			pSync[0] = (byte)(((pVal[0]>>0) & 0x7f) | ((pVal[1] & 0x01) << 7)); 
			pSync[1] = (byte)(((pVal[1]>>1) & 0x3f) | ((pVal[2] & 0x03) << 6));
			pSync[2] = (byte)(((pVal[2]>>2) & 0x1f) | ((pVal[3] & 0x07) << 5));
			pSync[3] = (byte)(((pVal[3]>>3) & 0x0f));
			return sync;
		}

		/// <summary>
		/// Converts from a normal integer to a syncsafe integer
		/// </summary>
		/// <param name="val">Bigendian normal value</param>
		/// <returns>Bigendian syncsafe value</returns>
		public static unsafe uint Safe(uint val)
		{
			if(val > 0x10000000)
			{
				throw new OverflowException("value is too large for a syncsafe integer") ;
			}
			uint sync = 0;
			byte* pVal = (byte*)&val;
			byte* pSync = (byte*)&sync;
			pSync[0] = (byte)((pVal[0]>>0) & 0x7f); 
			pSync[1] = (byte)(((pVal[0]>>7) & 0x01) | (pVal[1]<<1) & 0x7f ); 
			pSync[2] = (byte)(((pVal[1]>>6) & 0x03) | (pVal[2]<<2) & 0x7f );
			pSync[3] = (byte)(((pVal[2]>>5) & 0x07) | (pVal[3]<<3) & 0x7f );
			return sync;
		}

		/// <summary>
		/// Converts from a syncsafe integer to a normal integer
		/// </summary>
		/// <param name="val">Big-endian Sincsafe value</param>
		/// <returns>Big-endian normal value</returns>
		public static unsafe uint UnsafeBigEndian(uint val)
		{
			byte* pVal = (byte*)&val;
			if(pVal[0] > 0x7f || pVal[1] > 0x7f || pVal[2] > 0x7f || pVal[3] > 0x7f)
			{
				throw new InvalidTagException("Syncsafe value corrupted");
			}

			uint sync = 0;
			byte* pSync = (byte*)&sync;
			pSync[3] = (byte)(((pVal[3]>>0) & 0x7f) | ((pVal[2] & 0x01) << 7)); 
			pSync[2] = (byte)(((pVal[2]>>1) & 0x3f) | ((pVal[1] & 0x03) << 6));
			pSync[1] = (byte)(((pVal[1]>>2) & 0x1f) | ((pVal[0] & 0x07) << 5));
			pSync[0] = (byte)(((pVal[0]>>3) & 0x0f));
			return sync;
		}

		/// <summary>
		/// Converts from a syncsafe integer to a normal integer
		/// </summary>
		/// <param name="val">Big-endian normal value</param>
		/// <returns>Big-endian syncsafe value</returns>
		public static unsafe uint SafeBigEndian(uint val)
		{
			if(val > 0x10000000)
				throw new OverflowException("value is too large for a syncsafe integer") ;

			uint sync = 0;
			byte* pVal = (byte*)&val;
			byte* pSync = (byte*)&sync;
			pSync[3] = (byte)((pVal[3]>>0) & 0x7f); 
			pSync[2] = (byte)(((pVal[3]>>7) & 0x01) | (pVal[2]<<1) & 0x7f ); 
			pSync[1] = (byte)(((pVal[2]>>6) & 0x03) | (pVal[1]<<2) & 0x7f );
			pSync[0] = (byte)(((pVal[1]>>5) & 0x07) | (pVal[0]<<3) & 0x7f );
			return sync;
		}

		/// <summary>
		/// Convert a syncsafe stream to a normal stream
		/// </summary>
		/// <param name="src">Source stream</param>
		/// <param name="dst">Destination stream</param>
		/// <param name="size">Bytes to be proccesed</param>
		/// <returns>Number of bytes removed form the original stream</returns>
		public static uint Unsafe(Stream src, Stream dst, uint size)
		{
			BinaryWriter writer = new BinaryWriter(dst);
			BinaryReader reader = new BinaryReader(src);
			
			byte last = 0;
			uint syncs = 0, count = 0;

			while(count < size)
			{
				byte val = reader.ReadByte();
				if (last == 0xFF && val == 0x00)
				{
					syncs++; // skip the sync byte
				}
				else
				{
					writer.Write(val);
				}
				last = val;
				count++;
			}
			if (last == 0xFF)
			{
				writer.Write((byte)0x00);
				syncs++;
			}
			return syncs; //bytes removed form stream
		}

		/// <summary>
		/// Convert from an unsafe or normal stream to a syncsafe stream 
		/// </summary>
		/// <param name="src">Source stream</param>
		/// <param name="dst">Destination stream</param>
		/// <param name="count">Bytes to be proccesed</param>
		/// <returns>Number of bytes added to the original stream</returns>
		public static uint Safe(Stream src, Stream dst, uint count)
		{
			BinaryWriter writer = new BinaryWriter(dst);
			BinaryReader reader = new BinaryReader(src);
			
			byte last = 0;
			uint syncs = 0;

			while(count > 0)
			{
				byte val = reader.ReadByte();
				if (last == 0xFF && (val == 0x00 || val >= 0xE0))
				{
					writer.Write((byte)0x00);
					syncs++;
				}
				last = val;
				writer.Write(val);
				count--;
			}
			if (last == 0xFF)
			{
				writer.Write((byte)0x00);
				syncs++;
			}
			return syncs; // bytes added to the stream
		}
		#endregion
	}
}
