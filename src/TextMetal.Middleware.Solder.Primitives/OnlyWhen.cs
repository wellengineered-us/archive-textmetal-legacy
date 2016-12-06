﻿/*
	Copyright ©2002-2017 Daniel P. Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Diagnostics;

namespace TextMetal.Middleware.Solder.Primitives
{
	public static class OnlyWhen
	{
		#region Methods/Operators

		[Conditional("PROFILE")]
		public static void _PROFILE_ThenPrint(string message)
		{
			/* THIS METHOD SHOULD NOT BE DEFINED IN RELEASE/PRODUCTION BUILDS */
			Debug.WriteLine(message);
		}

		#endregion

		//[Conditional("PROFILE")]
		//[AssemblyLoaderEventSinkMethod]
		//public static void ThisAssemblyDependencyRegistration(AssemblyLoaderEventType assemblyLoaderEventType, AssemblyLoaderContainerContext assemblyLoaderContainerContext)
		//{
		//	/* THIS METHOD SHOULD NOT BE DEFINED IN RELEASE/PRODUCTION BUILDS */

		//	if ((object)assemblyLoaderContainerContext == null)
		//		throw new ArgumentNullException(nameof(assemblyLoaderContainerContext));

		//	switch (assemblyLoaderEventType)
		//	{
		//		case AssemblyLoaderEventType.Startup:
		//		case AssemblyLoaderEventType.Shutdown:
		//			Debug.WriteLine(assemblyLoaderEventType);
		//			break;
		//		default:
		//			throw new ArgumentOutOfRangeException(nameof(assemblyLoaderEventType), assemblyLoaderEventType, null);
		//	}
		//}
	}
}