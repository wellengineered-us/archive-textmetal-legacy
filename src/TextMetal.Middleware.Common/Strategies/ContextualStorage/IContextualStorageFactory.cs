﻿/*
	Copyright ©2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

namespace TextMetal.Middleware.Common.Strategies.ContextualStorage
{
	public interface IContextualStorageFactory
	{
		#region Methods/Operators

		IContextualStorageStrategy GetContextualStorage();

		#endregion
	}
}