﻿/*
	Copyright ©2002-2016 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

using TextMetal.Middleware.Solder.Runtime;

namespace TextMetal.Middleware.Solder.Injection
{
	/// <summary>
	/// Provides dependency registration and resolution services. Uses reader-writer lock for asynchronous protection (i.e. thread-safety).
	/// </summary>
	public sealed class DependencyManager : IDependencyManager
	{
		#region Constructors/Destructors

		/// <summary>
		/// Initializes a new instance of the DependencyManager class.
		/// </summary>
		public DependencyManager()
		{
		}

		#endregion

		#region Fields/Constants

		private readonly Dictionary<KeyValuePair<Type, string>, IDependencyResolution> dependencyResolutionRegistrations = new Dictionary<KeyValuePair<Type, string>, IDependencyResolution>();
		private readonly ReaderWriterLockSlim readerWriterLock = new ReaderWriterLockSlim();
		private bool disposed;

		#endregion

		#region Properties/Indexers/Events

		/// <summary>
		/// Gets the singleton instance associated with the current application domain. Most applications will use this instance instead of creating their own instance.
		/// </summary>
		public static IDependencyManager AppDomainInstance
		{
			get
			{
				return AssemblyLoaderContainerContext.TheOnlyAllowedInstance.DependencyManager;
			}
		}

		private Dictionary<KeyValuePair<Type, string>, IDependencyResolution> DependencyResolutionRegistrations
		{
			get
			{
				return this.dependencyResolutionRegistrations;
			}
		}

		private ReaderWriterLockSlim ReaderWriterLock
		{
			get
			{
				return this.readerWriterLock;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the current instance has been disposed.
		/// </summary>
		public bool Disposed
		{
			get
			{
				return this.disposed;
			}
			private set
			{
				this.disposed = value;
			}
		}

		#endregion

		#region Methods/Operators

		/// <summary>
		/// Adds a new dependency resolution for a given target type and selector key. Throws a DependencyException if the target type and selector key combination has been previously registered in this instance. This is the generic overload.
		/// </summary>
		/// <typeparam name="TObject"> The target type of resolution. </typeparam>
		/// <param name="selectorKey"> An non-null, zero or greater length string selector key. </param>
		/// <param name="dependencyResolution"> The dependency resolution. </param>
		public void AddResolution<TObject>(string selectorKey, IDependencyResolution dependencyResolution)
		{
			Type targetType;

			if (this.Disposed)
				throw new ObjectDisposedException(typeof(DependencyManager).FullName);

			if ((object)selectorKey == null)
				throw new ArgumentNullException("selectorKey");

			if ((object)dependencyResolution == null)
				throw new ArgumentNullException("dependencyResolution");

			targetType = typeof(TObject);

			this.AddResolution(targetType, selectorKey, dependencyResolution);
		}

		/// <summary>
		/// Adds a new dependency resolution for a given target type and selector key. Throws a DependencyException if the target type and selector key combination has been previously registered in this instance. This is the non-generic overload.
		/// </summary>
		/// <param name="targetType"> The target type of resolution. </param>
		/// <param name="selectorKey"> An non-null, zero or greater length string selector key. </param>
		/// <param name="dependencyResolution"> The dependency resolution. </param>
		public void AddResolution(Type targetType, string selectorKey, IDependencyResolution dependencyResolution)
		{
			KeyValuePair<Type, string> trait;

			if (this.Disposed)
				throw new ObjectDisposedException(typeof(DependencyManager).FullName);

			if ((object)targetType == null)
				throw new ArgumentNullException("targetType");

			if ((object)selectorKey == null)
				throw new ArgumentNullException("selectorKey");

			if ((object)dependencyResolution == null)
				throw new ArgumentNullException("dependencyResolution");

			// cop a reader lock
			this.ReaderWriterLock.EnterUpgradeableReadLock();

			try
			{
				// cop a writer lock
				this.ReaderWriterLock.EnterWriteLock();

				try
				{
					trait = new KeyValuePair<Type, string>(targetType, selectorKey);

					if (this.DependencyResolutionRegistrations.ContainsKey(trait))
						throw new DependencyException(string.Format("Dependency resolution already exists in the dependency manager for target type '{0}' and selector key '{1}'.", targetType.FullName, selectorKey));

					this.DependencyResolutionRegistrations.Add(trait, dependencyResolution);
				}
				finally
				{
					this.ReaderWriterLock.ExitWriteLock();
				}
			}
			finally
			{
				this.ReaderWriterLock.ExitUpgradeableReadLock();
			}
		}

		/// <summary>
		/// Clears all registered dependency resolutions from this instance.
		/// </summary>
		/// <returns> A value indicating if at least one dependency resolution was removed. </returns>
		public bool ClearAllResolutions()
		{
			bool result;

			if (this.Disposed)
				throw new ObjectDisposedException(typeof(DependencyManager).FullName);

			this.FreeDependencyResolutions();

			// cop a reader lock
			this.ReaderWriterLock.EnterUpgradeableReadLock();

			try
			{
				// cop a writer lock
				this.ReaderWriterLock.EnterWriteLock();

				try
				{
					result = this.DependencyResolutionRegistrations.Count > 0;

					this.DependencyResolutionRegistrations.Clear();

					return result;
				}
				finally
				{
					this.ReaderWriterLock.ExitWriteLock();
				}
			}
			finally
			{
				this.ReaderWriterLock.ExitUpgradeableReadLock();
			}
		}

		/// <summary>
		/// Clears all registered dependency resolutions of the specified target type from this instance. This is the generic overload.
		/// </summary>
		/// <typeparam name="TObject"> The target type of removal. </typeparam>
		/// <returns> A value indicating if at least one dependency resolution was removed. </returns>
		public bool ClearTypeResolutions<TObject>()
		{
			Type targetType;

			if (this.Disposed)
				throw new ObjectDisposedException(typeof(DependencyManager).FullName);

			targetType = typeof(TObject);

			return this.ClearTypeResolutions(targetType);
		}

		/// <summary>
		/// Clears all registered dependency resolutions of the specified target type from this instance. This is the non-generic overload.
		/// </summary>
		/// <param name="targetType"> The target type of removal. </param>
		/// <returns> A value indicating if at least one dependency resolution was removed. </returns>
		public bool ClearTypeResolutions(Type targetType)
		{
			List<KeyValuePair<Type, string>> traitsToRemove;

			if (this.Disposed)
				throw new ObjectDisposedException(typeof(DependencyManager).FullName);

			if ((object)targetType == null)
				throw new ArgumentNullException("targetType");

			// cop a reader lock
			this.ReaderWriterLock.EnterUpgradeableReadLock();

			try
			{
				// cop a writer lock
				this.ReaderWriterLock.EnterWriteLock();

				try
				{
					traitsToRemove = new List<KeyValuePair<Type, string>>();

					foreach (KeyValuePair<KeyValuePair<Type, string>, IDependencyResolution> dependencyResolutionRegistration in this.DependencyResolutionRegistrations)
					{
						if (dependencyResolutionRegistration.Key.Key == targetType)
							traitsToRemove.Add(dependencyResolutionRegistration.Key);
					}

					foreach (KeyValuePair<Type, string> trait in traitsToRemove)
						this.DependencyResolutionRegistrations.Remove(trait);

					return traitsToRemove.Count > 0;
				}
				finally
				{
					this.ReaderWriterLock.ExitWriteLock();
				}
			}
			finally
			{
				this.ReaderWriterLock.ExitUpgradeableReadLock();
			}
		}

		/// <summary>
		/// Clears all dependency resolutions and cleans up any resources. Once disposed, the instance cannot be reused.
		/// </summary>
		public void Dispose()
		{
			if (this.Disposed)
				return;

			this.FreeDependencyResolutions();

			// cop a reader lock
			this.ReaderWriterLock.EnterUpgradeableReadLock();

			try
			{
				// cop a writer lock
				this.ReaderWriterLock.EnterWriteLock();

				try
				{
					this.DependencyResolutionRegistrations.Clear();
				}
				finally
				{
					this.ReaderWriterLock.ExitWriteLock();
				}
			}
			finally
			{
				this.ReaderWriterLock.ExitUpgradeableReadLock();
				this.Disposed = true;
				GC.SuppressFinalize(this);
			}
		}

		private void FreeDependencyResolutions()
		{
			// signal disposal of container ("manager")
			foreach (IDisposable resolutionDisposable in this.DependencyResolutionRegistrations.Values.OfType<IDisposable>())
			{
				if ((object)resolutionDisposable != null)
					resolutionDisposable.Dispose();
			}
		}

		private IDependencyResolution GetDependencyResolution(Type targetType, string selectorKey)
		{
			KeyValuePair<Type, string> trait;
			IDependencyResolution dependencyResolution;

			trait = new KeyValuePair<Type, string>(targetType, selectorKey);

			// first attempt direct resolution: exact type and selector key
			if (!this.DependencyResolutionRegistrations.TryGetValue(trait, out dependencyResolution))
			{
				// second attempt indirect resolution: assignable type and select key
				var candidateResolutions = this.DependencyResolutionRegistrations.Where(r => (object)r.Key != null && targetType.IsAssignableFrom(r.Key.Key)
																							&& (selectorKey == string.Empty || r.Key.Value == selectorKey)).Select(x => x.Value);

				dependencyResolution = candidateResolutions.FirstOrDefault();
			}

			return dependencyResolution;
		}

		/// <summary>
		/// Gets a value indicating whether there are any registered dependency resolutions of the specified target type in this instance. If selector key is a null value, then this method will return true if any resolution exists for the specified target type, regardless of selector key; otherwise, this method will return true only if a resolution exists for the specified target type and selector key. This is the generic overload.
		/// </summary>
		/// <param name="selectorKey"> An null or zero or greater length string selector key. </param>
		/// <typeparam name="TObject"> The target type of the check. </typeparam>
		/// <returns> A value indicating if at least one dependency resolution is present. </returns>
		public bool HasTypeResolution<TObject>(string selectorKey)
		{
			Type targetType;

			if (this.Disposed)
				throw new ObjectDisposedException(typeof(DependencyManager).FullName);

			targetType = typeof(TObject);

			return this.HasTypeResolution(targetType, selectorKey);
		}

		/// <summary>
		/// Gets a value indicating whether there are any registered dependency resolutions of the specified target type in this instance. If selector key is a null value, then this method will return true if any resolution exists for the specified target type, regardless of selector key; otherwise, this method will return true only if a resolution exists for the specified target type and selector key. This is the non-generic overload.
		/// </summary>
		/// <param name="selectorKey"> An null or zero or greater length string selector key. </param>
		/// <param name="targetType"> The target type of the check. </param>
		/// <returns> A value indicating if at least one dependency resolution is present. </returns>
		public bool HasTypeResolution(Type targetType, string selectorKey)
		{
			if (this.Disposed)
				throw new ObjectDisposedException(typeof(DependencyManager).FullName);

			// selector key can be null in this context

			if ((object)targetType == null)
				throw new ArgumentNullException("targetType");

			// cop a reader lock
			this.ReaderWriterLock.EnterUpgradeableReadLock();

			try
			{
				return (object)this.GetDependencyResolution(targetType, selectorKey) != null;
			}
			finally
			{
				this.ReaderWriterLock.ExitUpgradeableReadLock();
			}
		}

		/// <summary>
		/// Removes the registered dependency resolution of the specified target type and selector key from this instance. Throws a DependencyException if the target type and selector key combination has not been previously registered in this instance. This is the generic overload.
		/// </summary>
		/// <typeparam name="TObject"> The target type of removal. </typeparam>
		/// <param name="selectorKey"> An non-null, zero or greater length string selector key. </param>
		public void RemoveResolution<TObject>(string selectorKey)
		{
			Type targetType;

			if (this.Disposed)
				throw new ObjectDisposedException(typeof(DependencyManager).FullName);

			if ((object)selectorKey == null)
				throw new ArgumentNullException("selectorKey");

			targetType = typeof(TObject);

			this.RemoveResolution(targetType, selectorKey);
		}

		/// <summary>
		/// Removes the registered dependency resolution of the specified target type and selector key from this instance. Throws a DependencyException if the target type and selector key combination has not been previously registered in this instance. This is the non-generic overload.
		/// </summary>
		/// <param name="targetType"> The target type of removal. </param>
		/// <param name="selectorKey"> An non-null, zero or greater length string selector key. </param>
		public void RemoveResolution(Type targetType, string selectorKey)
		{
			KeyValuePair<Type, string> trait;
			IDependencyResolution dependencyResolution;

			if (this.Disposed)
				throw new ObjectDisposedException(typeof(DependencyManager).FullName);

			if ((object)targetType == null)
				throw new ArgumentNullException("targetType");

			if ((object)selectorKey == null)
				throw new ArgumentNullException("selectorKey");

			// cop a reader lock
			this.ReaderWriterLock.EnterUpgradeableReadLock();

			try
			{
				// cop a writer lock
				this.ReaderWriterLock.EnterWriteLock();

				try
				{
					trait = new KeyValuePair<Type, string>(targetType, selectorKey);

					dependencyResolution = this.GetDependencyResolution(targetType, selectorKey);

					if ((object)dependencyResolution == null) // nothing to offer up
						throw new DependencyException(string.Format("Dependency resolution in the in-effect dependency manager failed to match for target type '{0}' and selector key '{1}'.", targetType.FullName, selectorKey));

					if ((object)dependencyResolution != null &&
						dependencyResolution is IDisposable)
						((IDisposable)dependencyResolution).Dispose();

					this.DependencyResolutionRegistrations.Remove(trait);
				}
				finally
				{
					this.ReaderWriterLock.ExitWriteLock();
				}
			}
			finally
			{
				this.ReaderWriterLock.ExitUpgradeableReadLock();
			}
		}

		/// <summary>
		/// Resolves a dependency for the given target type and selector key combination. Throws a DependencyException if the target type and selector key combination has not been previously registered in this instance. Throws a DependencyException if the resolved value cannot be assigned to the target type. This is the non-generic overload.
		/// </summary>
		/// <typeparam name="TObject"> The target type of resolution. </typeparam>
		/// <param name="selectorKey"> An non-null, zero or greater length string selector key. </param>
		/// <returns> An object instance of assisgnable to the target type. </returns>
		public TObject ResolveDependency<TObject>(string selectorKey)
		{
			Type targetType;
			TObject value;

			if (this.Disposed)
				throw new ObjectDisposedException(typeof(DependencyManager).FullName);

			if ((object)selectorKey == null)
				throw new ArgumentNullException("selectorKey");

			targetType = typeof(TObject);

			value = (TObject)this.ResolveDependency(targetType, selectorKey);

			return value;
		}

		/// <summary>
		/// Resolves a dependency for the given target type and selector key combination. Throws a DependencyException if the target type and selector key combination has not been previously registered in this instance. Throws a DependencyException if the resolved value cannot be assigned to the target type. This is the non-generic overload.
		/// </summary>
		/// <param name="targetType"> The target type of resolution. </param>
		/// <param name="selectorKey"> An non-null, zero or greater length string selector key. </param>
		/// <returns> An object instance of assisgnable to the target type. </returns>
		public object ResolveDependency(Type targetType, string selectorKey)
		{
			object value;
			IDependencyResolution dependencyResolution;
			Type typeOfValue;

			if (this.Disposed)
				throw new ObjectDisposedException(typeof(DependencyManager).FullName);

			if ((object)targetType == null)
				throw new ArgumentNullException("targetType");

			if ((object)selectorKey == null)
				throw new ArgumentNullException("selectorKey");

			// cop a reader lock
			this.ReaderWriterLock.EnterUpgradeableReadLock();

			try
			{
				dependencyResolution = this.GetDependencyResolution(targetType, selectorKey);

				if ((object)dependencyResolution == null) // nothing to offer up
					throw new DependencyException(string.Format("Dependency resolution in the in-effect dependency manager failed to match for target type '{0}' and selector key '{1}'.", targetType.FullName, selectorKey));

				value = dependencyResolution.Resolve(this);

				if ((object)value != null)
				{
					typeOfValue = value.GetType();

					if (!targetType.IsAssignableFrom(typeOfValue))
						throw new DependencyException(string.Format("Dependency resolution in the dependency manager matched for target type '{0}' and selector key '{1}' but the resolved value type '{2}' is not assignable the target type '{3}'.", targetType.FullName, selectorKey, typeOfValue.FullName, targetType.FullName));
				}

				return value;
			}
			finally
			{
				this.ReaderWriterLock.ExitUpgradeableReadLock();
			}
		}

		#endregion
	}
}