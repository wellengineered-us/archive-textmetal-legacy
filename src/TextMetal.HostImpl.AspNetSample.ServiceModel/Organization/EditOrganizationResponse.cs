﻿/*
	Copyright ©2002-2014 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

namespace TextMetal.HostImpl.AspNetSample.ServiceModel.Organization
{
	public sealed class EditOrganizationResponse : ResponseBase
	{
		#region Properties/Indexers/Events

		public bool MustChangePassword
		{
			get;
			set;
		}

		#endregion
	}
}