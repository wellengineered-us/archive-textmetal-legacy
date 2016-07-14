﻿/*
	Copyright ©2002-2016 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System.Collections.Generic;

namespace TextMetal.Middleware.Solder.Primitives
{
	public interface IRecord : IDictionary<string, object>
	{
		#region Properties/Indexers/Events

		object Context
		{
			get;
		}

		#endregion
	}
}