// ****************************************************************
// This is free software licensed under the NUnit license. You
// may obtain a copy of the license as well as information regarding
// copyright ownership at http://nunit.org.
// ****************************************************************

using System.Runtime.Serialization;

namespace NUnit.Framework
{
	using System;

	/// <summary>
	/// 	Thrown when a test executes inconclusively.
	/// </summary>
	[Serializable]
	public class InconclusiveException : Exception
	{
		#region Constructors/Destructors

		/// <param name="message"> The error message that explains the reason for the exception </param>
		public InconclusiveException(string message)
			: base(message)
		{
		}

		/// <param name="message"> The error message that explains the reason for the exception </param>
		/// <param name="inner"> The exception that caused the current exception </param>
		public InconclusiveException(string message, Exception inner)
			:
				base(message, inner)
		{
		}

		/// <summary>
		/// 	Serialization Constructor
		/// </summary>
		protected InconclusiveException(SerializationInfo info,
		                                StreamingContext context)
			: base(info, context)
		{
		}

		#endregion
	}
}