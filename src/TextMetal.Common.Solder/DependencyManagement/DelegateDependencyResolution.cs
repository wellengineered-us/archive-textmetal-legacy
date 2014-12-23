﻿/*
	Copyright ©2002-2014 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

namespace TextMetal.Common.Solder.DependencyManagement
{
	/// <summary>
	/// Provides the Factory Method pattern used to resolve dependencies.
	/// This implementation executes a callback each time a dependency resolution occurs.
	/// </summary>
	public sealed class DelegateDependencyResolution : IDependencyResolution
	{
		#region Constructors/Destructors

		/// <summary>
		/// Initializes a new instance of the DelegateDependencyResolution class.
		/// </summary>
		/// <param name="method"> The callback method to execute during resolution. </param>
		public DelegateDependencyResolution(Delegate method)
		{
			if ((object)method == null)
				throw new ArgumentNullException("method");

			this.method = method;
		}

		#endregion

		#region Fields/Constants

		private readonly Delegate method;

		#endregion

		#region Properties/Indexers/Events

		private Delegate Method
		{
			get
			{
				return this.method;
			}
		}

		#endregion

		#region Methods/Operators

		/// <summary>
		/// Resolves a dependency.
		/// </summary>
		/// <param name="dependencyManager"> The current in-effect dependency manager requesting this resolution. </param>
		/// <returns> An instance of an object or null. </returns>
		public object Resolve(IDependencyManager dependencyManager)
		{
			if ((object)dependencyManager == null)
				throw new ArgumentNullException("dependencyManager");

			return this.Method.DynamicInvoke(null);
		}

		/// <summary>
		/// Gets an instance of DelegateDependencyResolution from the specified Func`1 delegate.
		/// </summary>
		/// <typeparam name="TObject"> The target type of resolution. </typeparam>
		/// <param name="func"> The callback method to execute during resolution. </param>
		/// <returns> A DelegateDependencyResolution instance. </returns>
		public static DelegateDependencyResolution FromFunc<TObject>(Func<TObject> func)
		{
			if ((object)func == null)
				throw new ArgumentNullException("func");

			return new DelegateDependencyResolution(func);
		}

		#endregion
	}
}