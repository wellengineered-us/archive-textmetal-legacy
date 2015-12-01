﻿/*
	Copyright ©2002-2016 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

namespace TextMetal.Middleware.Solder.Context
{
	public interface IApplicationSpecificStorageStrategy : IContextualStorageStrategy
	{
		#region Properties/Indexers/Events

		bool IsSafeCrossPrincipal
		{
			get;
		}

		#endregion
	}
}