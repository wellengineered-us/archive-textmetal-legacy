﻿/*
	Copyright ©2002-2017 Daniel P. Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

/* CERTIFICATION OF UNIT TESTING: dpbullington@gmail.com / 2016-04-18 / 100% code coverage */

namespace TextMetal.Middleware.Solder.Injection
{
	/// <summary>
	/// Marks a static void (AssemblyLoaderEventType, AgnosticAppDomain) method as an assembly loader method.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
	public sealed class AssemblyLoaderEventSinkMethodAttribute : Attribute
	{
		#region Constructors/Destructors

		/// <summary>
		/// Initializes a new instance of the AssemblyLoaderEventSinkMethodAttribute class.
		/// </summary>
		public AssemblyLoaderEventSinkMethodAttribute()
		{
		}

		#endregion
	}
}