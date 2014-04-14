﻿/*
	Copyright ©2002-2014 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

namespace TextMetal.HostImpl.AspNetSample.ServiceModel.User
{
	public sealed class LoadUserResponse : ResponseBase
	{
		#region Properties/Indexers/Events

		public string AnswerHash
		{
			get;
			set;
		}

		public DateTime? CreationTimestamp
		{
			get;
			set;
		}

		public int? CreationUserId
		{
			get;
			set;
		}

		public string EmailAddress
		{
			get;
			set;
		}

		public short? FailedLoginCount
		{
			get;
			set;
		}

		public DateTime? LastLoginFailureTimestamp
		{
			get;
			set;
		}

		public DateTime? LastLoginSuccessTimestamp
		{
			get;
			set;
		}

		public bool? LogicalDelete
		{
			get;
			set;
		}

		public DateTime? ModificationTimestamp
		{
			get;
			set;
		}

		public bool? MustChangePassword
		{
			get;
			set;
		}

		public string PasswordHash
		{
			get;
			set;
		}

		public string Question
		{
			get;
			set;
		}

		public string SaltValue
		{
			get;
			set;
		}

		public byte? SortOrder
		{
			get;
			set;
		}

		public int? UserId
		{
			get;
			set;
		}

		public string UserName
		{
			get;
			set;
		}

		#endregion
	}
}