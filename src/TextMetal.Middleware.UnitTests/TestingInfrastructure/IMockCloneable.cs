﻿/*
	Copyright ©2002-2016 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

namespace TextMetal.Middleware.UnitTests.TestingInfrastructure
{
	public interface IMockCloneable
	{
		#region Methods/Operators

		object Clone();

		#endregion
	}
}