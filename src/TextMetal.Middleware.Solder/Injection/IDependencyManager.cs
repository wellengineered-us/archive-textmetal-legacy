﻿/*
	Copyright ©2002-2016 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

namespace TextMetal.Middleware.Solder.Injection
{
	/// <summary>
	/// Provides dependency registration and resoltuion services.
	/// </summary>
	public interface IDependencyManager : IDisposable
	{
		#region Methods/Operators

		/// <summary>
		/// Adds a new dependency resolution for a given target type and selector key. Throws a DependencyException if the target type and selector key combination has been previously registered in this instance. This is the generic overload.
		/// </summary>
		/// <typeparam name="TObject"> The target type of resolution. </typeparam>
		/// <param name="selectorKey"> An non-null, zero or greater length string selector key. </param>
		/// <param name="includeAssignableTypes"> A boolean value indicating whether to include assignable types in the candidate resolution existence check. </param>
		/// <param name="dependencyResolution"> The dependency resolution. </param>
		void AddResolution<TObject>(string selectorKey, bool includeAssignableTypes, IDependencyResolution dependencyResolution);

		/// <summary>
		/// Adds a new dependency resolution for a given target type and selector key. Throws a DependencyException if the target type and selector key combination has been previously registered in this instance. This is the non-generic overload.
		/// </summary>
		/// <param name="targetType"> The target type of resolution. </param>
		/// <param name="selectorKey"> An non-null, zero or greater length string selector key. </param>
		/// <param name="includeAssignableTypes"> A boolean value indicating whether to include assignable types in the candidate resolution existence check. </param>
		/// <param name="dependencyResolution"> The dependency resolution. </param>
		void AddResolution(Type targetType, string selectorKey, bool includeAssignableTypes, IDependencyResolution dependencyResolution);

		/// <summary>
		/// Clears all registered dependency resolutions from this instance.
		/// </summary>
		/// <returns> A value indicating if at least one dependency resolution was removed. </returns>
		bool ClearAllResolutions();

		/// <summary>
		/// Clears all registered dependency resolutions of the specified target type from this instance. This is the generic overload.
		/// </summary>
		/// <typeparam name="TObject"> The target type of removal. </typeparam>
		/// <param name="includeAssignableTypes"> A boolean value indicating whether to include assignable types in the candidate resolution removal list. </param>
		/// <returns> A value indicating if at least one dependency resolution was removed. </returns>
		bool ClearTypeResolutions<TObject>(bool includeAssignableTypes);

		/// <summary>
		/// Clears all registered dependency resolutions of the specified target type from this instance. This is the non-generic overload.
		/// </summary>
		/// <param name="targetType"> The target type of removal. </param>
		/// <param name="includeAssignableTypes"> A boolean value indicating whether to include assignable types in the candidate resolution removal list. </param>
		/// <returns> A value indicating if at least one dependency resolution was removed. </returns>
		bool ClearTypeResolutions(Type targetType, bool includeAssignableTypes);

		/// <summary>
		/// Gets a value indicating whether there are any registered dependency resolutions of the specified target type in this instance. If selector key is a null value, then this method will return true if any resolution exists for the specified target type, regardless of selector key; otherwise, this method will return true only if a resolution exists for the specified target type and selector key. This is the generic overload.
		/// </summary>
		/// <param name="selectorKey"> An null or zero or greater length string selector key. </param>
		/// <param name="includeAssignableTypes"> A boolean value indicating whether to include assignable types in the candidate resolution existence check. </param>
		/// <typeparam name="TObject"> The target type of the check. </typeparam>
		/// <returns> A value indicating if at least one dependency resolution is present. </returns>
		bool HasTypeResolution<TObject>(string selectorKey, bool includeAssignableTypes);

		/// <summary>
		/// Gets a value indicating whether there are any registered dependency resolutions of the specified target type in this instance. If selector key is a null value, then this method will return true if any resolution exists for the specified target type, regardless of selector key; otherwise, this method will return true only if a resolution exists for the specified target type and selector key. This is the non-generic overload.
		/// </summary>
		/// <param name="targetType"> The target type of the check. </param>
		/// <param name="selectorKey"> An null or zero or greater length string selector key. </param>
		/// <param name="includeAssignableTypes"> A boolean value indicating whether to include assignable types in the candidate resolution existence check. </param>
		/// <returns> A value indicating if at least one dependency resolution is present. </returns>
		bool HasTypeResolution(Type targetType, string selectorKey, bool includeAssignableTypes);

		/// <summary>
		/// Removes the registered dependency resolution of the specified target type and selector key from this instance. Throws a DependencyException if the target type and selector key combination has not been previously registered in this instance. This is the generic overload.
		/// </summary>
		/// <typeparam name="TObject"> The target type of removal. </typeparam>
		/// <param name="includeAssignableTypes"> A boolean value indicating whether to include assignable types in the candidate resolution removal list. </param>
		/// <param name="selectorKey"> An non-null, zero or greater length string selector key. </param>
		void RemoveResolution<TObject>(string selectorKey, bool includeAssignableTypes);

		/// <summary>
		/// Removes the registered dependency resolution of the specified target type and selector key from this instance. Throws a DependencyException if the target type and selector key combination has not been previously registered in this instance. This is the non-generic overload.
		/// </summary>
		/// <param name="targetType"> The target type of removal. </param>
		/// <param name="selectorKey"> An non-null, zero or greater length string selector key. </param>
		/// <param name="includeAssignableTypes"> A boolean value indicating whether to include assignable types in the candidate resolution removal list. </param>
		void RemoveResolution(Type targetType, string selectorKey, bool includeAssignableTypes);

		/// <summary>
		/// Resolves a dependency for the given target type and selector key combination. Throws a DependencyException if the target type and selector key combination has not been previously registered in this instance. Throws a DependencyException if the resolved value cannot be assigned to the target type. This is the non-generic overload.
		/// </summary>
		/// <typeparam name="TObject"> The target type of resolution. </typeparam>
		/// <param name="selectorKey"> An non-null, zero or greater length string selector key. </param>
		/// <param name="includeAssignableTypes"> A boolean value indicating whether to include assignable types in the candidate resolution lookup list. </param>
		/// <returns> An object instance of assisgnable to the target type. </returns>
		TObject ResolveDependency<TObject>(string selectorKey, bool includeAssignableTypes);

		/// <summary>
		/// Resolves a dependency for the given target type and selector key combination. Throws a DependencyException if the target type and selector key combination has not been previously registered in this instance. Throws a DependencyException if the resolved value cannot be assigned to the target type. This is the non-generic overload.
		/// </summary>
		/// <param name="targetType"> The target type of resolution. </param>
		/// <param name="selectorKey"> An non-null, zero or greater length string selector key. </param>
		/// <param name="includeAssignableTypes"> A boolean value indicating whether to include assignable types in the candidate resolution lookup list. </param>
		/// <returns> An object instance of assisgnable to the target type. </returns>
		object ResolveDependency(Type targetType, string selectorKey, bool includeAssignableTypes);

		#endregion
	}
}