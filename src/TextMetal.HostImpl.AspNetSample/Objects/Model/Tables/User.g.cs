﻿//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by:
// TextMetal 5.0.3.597;
// 		Copyright ©2002-2013 Daniel Bullington (dpbullington@gmail.com)
//		Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
//		Project URL: https://github.com/dpbullington/textmetal
//
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//
// </auto-generated>
//------------------------------------------------------------------------------

/*
	Copyright ©2002-2013 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Xml;

using TextMetal.Common.Core;

namespace TextMetal.HostImpl.AspNetSample.Objects.Model.Tables
{
	public partial class User : Object
	{		
		#region Constructors/Destructors
		
		public User()
		{
		}
		
		#endregion
		
		#region Fields/Constants

		private Nullable<Int32> @userId;
		private String @emailAddress;
		private String @userName;
		private String @saltValue;
		private String @passwordHash;
		private String @question;
		private String @answerHash;
		private Nullable<DateTime> @lastLoginSuccessTimestamp;
		private Nullable<DateTime> @lastLoginFailureTimestamp;
		private Nullable<Int16> @failedLoginCount;
		private Nullable<Boolean> @mustChangePassword;
		private Nullable<Byte> @sortOrder;
		private Nullable<DateTime> @creationTimestamp;
		private Nullable<DateTime> @modificationTimestamp;
		private Nullable<Int32> @creationUserId;
		private Nullable<Int32> @modificationUserId;
		private Nullable<Boolean> @logicalDelete;

		#endregion

		#region Properties/Indexers/Events
		
		public virtual bool IsNew
		{
			get
			{
				return this.UserId == default(Nullable<Int32>);
			}
			set
			{
				if(value)
					this.UserId =  default(Nullable<Int32>);
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Int32> @UserId
		{
			get
			{
				return this.@userId;
			}
			set
			{
				this.@userId = value;
			}
		}
		
		public String @EmailAddress
		{
			get
			{
				return this.@emailAddress;
			}
			set
			{
				this.@emailAddress = value;
			}
		}
		
		public String @UserName
		{
			get
			{
				return this.@userName;
			}
			set
			{
				this.@userName = value;
			}
		}
		
		public String @SaltValue
		{
			get
			{
				return this.@saltValue;
			}
			set
			{
				this.@saltValue = value;
			}
		}
		
		public String @PasswordHash
		{
			get
			{
				return this.@passwordHash;
			}
			set
			{
				this.@passwordHash = value;
			}
		}
		
		public String @Question
		{
			get
			{
				return this.@question;
			}
			set
			{
				this.@question = value;
			}
		}
		
		public String @AnswerHash
		{
			get
			{
				return this.@answerHash;
			}
			set
			{
				this.@answerHash = value;
			}
		}
		
		public Nullable<DateTime> @LastLoginSuccessTimestamp
		{
			get
			{
				return this.@lastLoginSuccessTimestamp;
			}
			set
			{
				this.@lastLoginSuccessTimestamp = value;
			}
		}
		
		public Nullable<DateTime> @LastLoginFailureTimestamp
		{
			get
			{
				return this.@lastLoginFailureTimestamp;
			}
			set
			{
				this.@lastLoginFailureTimestamp = value;
			}
		}
		
		public Nullable<Int16> @FailedLoginCount
		{
			get
			{
				return this.@failedLoginCount;
			}
			set
			{
				this.@failedLoginCount = value;
			}
		}
		
		public Nullable<Boolean> @MustChangePassword
		{
			get
			{
				return this.@mustChangePassword;
			}
			set
			{
				this.@mustChangePassword = value;
			}
		}
		
		public Nullable<Byte> @SortOrder
		{
			get
			{
				return this.@sortOrder;
			}
			set
			{
				this.@sortOrder = value;
			}
		}
		
		public Nullable<DateTime> @CreationTimestamp
		{
			get
			{
				return this.@creationTimestamp;
			}
			set
			{
				this.@creationTimestamp = value;
			}
		}
		
		public Nullable<DateTime> @ModificationTimestamp
		{
			get
			{
				return this.@modificationTimestamp;
			}
			set
			{
				this.@modificationTimestamp = value;
			}
		}
		
		public Nullable<Int32> @CreationUserId
		{
			get
			{
				return this.@creationUserId;
			}
			set
			{
				this.@creationUserId = value;
			}
		}
		
		public Nullable<Int32> @ModificationUserId
		{
			get
			{
				return this.@modificationUserId;
			}
			set
			{
				this.@modificationUserId = value;
			}
		}
		
		public Nullable<Boolean> @LogicalDelete
		{
			get
			{
				return this.@logicalDelete;
			}
			set
			{
				this.@logicalDelete = value;
			}
		}
		
		#endregion
	}
}
