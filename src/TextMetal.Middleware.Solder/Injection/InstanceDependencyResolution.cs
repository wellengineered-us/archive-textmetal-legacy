﻿/*
	Copyright ©2002-2016 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

/* CERTIFICATION OF UNIT TESTING: dpbullington@gmail.com / 2016-03-10 / 100% code coverage */

namespace TextMetal.Middleware.Solder.Injection
{
	/// <summary>
	/// A dependency resolution implementation that allows only a specific instance
	/// to be provided, cached, and reused; the specific instance is passed as a constructor parameter.
	/// From 'Dependency Injection in ASP.NET MVC6':
	/// Instance lifetime services: you can choose to add an instance directly to the services container. If you do so, this instance will be used for all subsequent requests (this technique will create a Singleton-scoped instance). One key difference between Instance services and Singleton services is that the Instance service is created in ConfigureServices, while the Singleton service is lazy-loaded the first time it is requested.
	/// </summary>
	public sealed class InstanceDependencyResolution : IDependencyResolution
	{
		#region Constructors/Destructors

		/// <summary>
		/// Initializes a new instance of the InstanceDependencyResolution class.
		/// </summary>
		/// <param name="instance"> The instance to use for resolution. </param>
		public InstanceDependencyResolution(object instance)
		{
			this.instance = instance;
		}

		#endregion

		#region Fields/Constants

		private readonly object instance;

		#endregion

		#region Properties/Indexers/Events

		public object Instance
		{
			get
			{
				return this.instance;
			}
		}

		#endregion

		#region Methods/Operators

		public static InstanceDependencyResolution From<TObject>(TObject instance)
		{
			return new InstanceDependencyResolution(instance);
		}

		public void Dispose()
		{
			// do nothing
		}

		/// <summary>
		/// Resolves a dependency.
		/// </summary>
		/// <param name="dependencyManager"> The current in-effect dependency manager requesting this resolution. </param>
		/// <returns> An instance of an object or null. </returns>
		public object Resolve(IDependencyManager dependencyManager)
		{
			if ((object)dependencyManager == null)
				throw new ArgumentNullException(nameof(dependencyManager));

			return this.Instance;
		}

		#endregion
	}
}