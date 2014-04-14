﻿/*
	Copyright ©2002-2014 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

namespace TextMetal.HostImpl.AspNetSample.ServiceModel.User
{
	public sealed class SuspendAccountRequest : RequestBase
	{
		#region Properties/Indexers/Events

		public string PasswordClearText
		{
			get;
			set;
		}

		public int? UserId
		{
			get;
			set;
		}

		#endregion
	}
}