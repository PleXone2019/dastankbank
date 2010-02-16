// Copyright(C) 2002-2009 Hugo Rumayor Montemayor, All rights reserved.
namespace Id3Lib
{
	using System;
using System.Runtime.Serialization;

	/// <summary>
	/// The exception is thrown when a frame is corrupt.
	/// </summary>
    [Serializable]
    public class InvalidFrameException : InvalidStructureException
	{
        protected InvalidFrameException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        /// <summary>
        /// 
        /// </summary>
		public InvalidFrameException()
		{
		}
	
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
		public InvalidFrameException(string message): base(message)
		{
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
		public InvalidFrameException(string message, Exception inner): base(message, inner)
		{
		}
	}
}