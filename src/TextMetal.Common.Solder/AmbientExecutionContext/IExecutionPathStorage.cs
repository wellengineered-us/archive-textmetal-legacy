﻿/*
	Copyright ©2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

namespace TextMetal.Common.Solder.AmbientExecutionContext
{
	public interface IExecutionPathStorage
	{
		#region Methods/Operators

		T GetValue<T>(string key);

		bool HasValue(string key);

		void RemoveValue(string key);

		void SetValue<T>(string key, T value);

		#endregion
	}
}