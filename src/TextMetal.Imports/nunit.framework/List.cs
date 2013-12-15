// ****************************************************************
// Copyright 2007, Charlie Poole
// This is free software licensed under the NUnit license. You may
// obtain a copy of the license at http://nunit.org
// ****************************************************************

using System;
using System.Collections;

namespace NUnit.Framework
{
	/// <summary>
	/// The List class is a helper class with properties and methods
	/// that supply a number of constraints used with lists and collections.
	/// </summary>
	public class List
	{
		#region Methods/Operators

		/// <summary>
		/// List.Map returns a ListMapper, which can be used to map
		/// the original collection to another collection.
		/// </summary>
		/// <param name="actual"> </param>
		/// <returns> </returns>
		public static ListMapper Map(ICollection actual)
		{
			return new ListMapper(actual);
		}

		#endregion
	}
}