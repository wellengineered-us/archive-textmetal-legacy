// ****************************************************************
// Copyright 2007, Charlie Poole
// This is free software licensed under the NUnit license. You may
// obtain a copy of the license at http://nunit.org
// ****************************************************************

using System;

namespace NUnit.Framework
{
	/// <summary>
	/// Attribute used to provide descriptive text about a
	/// test case or fixture.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
	public class DescriptionAttribute : Attribute
	{
		#region Constructors/Destructors

		/// <summary>
		/// Construct the attribute
		/// </summary>
		/// <param name="description"> Text describing the test </param>
		public DescriptionAttribute(string description)
		{
			this.description = description;
		}

		#endregion

		#region Fields/Constants

		private string description;

		#endregion

		#region Properties/Indexers/Events

		/// <summary>
		/// Gets the test description
		/// </summary>
		public string Description
		{
			get
			{
				return this.description;
			}
		}

		#endregion
	}
}