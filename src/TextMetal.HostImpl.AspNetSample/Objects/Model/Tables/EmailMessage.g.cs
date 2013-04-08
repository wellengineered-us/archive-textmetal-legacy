﻿//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by:
// TextMetal 5.0.0.26315;
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

using TextMetal.Common.Core;
using TextMetal.HostImpl.Web.Email;

namespace TextMetal.HostImpl.AspNetSample.Objects.Model.Tables
{
	public partial class EmailMessage : Object
	{		
		#region Constructors/Destructors
		
		public EmailMessage()
		{
		}
		
		#endregion
		
		#region Fields/Constants

		// public const string EMAIL_MESSAGE_ID = "EmailMessageId";
		// public const string FROM = "From";
		// public const string SENDER = "Sender";
		// public const string REPLY_TO = "ReplyTo";
		// public const string TO = "To";
		// public const string CC = "Cc";
		// public const string BCC = "Bcc";
		// public const string SUBJECT = "Subject";
		// public const string IS_BODY_HTML = "IsBodyHtml";
		// public const string BODY = "Body";
		// public const string PROCESSED = "Processed";
		// public const string CREATION_TIMESTAMP = "CreationTimestamp";
		// public const string MODIFICATION_TIMESTAMP = "ModificationTimestamp";
		// public const string LOGICAL_DELETE = "LogicalDelete";
		private Nullable<Int32> @emailMessageId;
		private String @from;
		private String @sender;
		private String @replyTo;
		private String @to;
		private String @cc;
		private String @bcc;
		private String @subject;
		private Nullable<Boolean> @isBodyHtml;
		private String @body;
		private Nullable<Boolean> @processed;
		private Nullable<DateTime> @creationTimestamp;
		private Nullable<DateTime> @modificationTimestamp;
		private Nullable<Boolean> @logicalDelete;

		#endregion

		#region Properties/Indexers/Events
		
		public virtual bool IsNew
		{
			get
			{
				return this.EmailMessageId == default(Nullable<Int32>);
			}
			set
			{
				if(value)
					this.EmailMessageId =  default(Nullable<Int32>);
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Int32> @EmailMessageId
		{
			get
			{
				return this.@emailMessageId;
			}
			set
			{
				this.@emailMessageId = value;
			}
		}
		
		public String @From
		{
			get
			{
				return this.@from;
			}
			set
			{
				this.@from = value;
			}
		}
		
		public String @Sender
		{
			get
			{
				return this.@sender;
			}
			set
			{
				this.@sender = value;
			}
		}
		
		public String @ReplyTo
		{
			get
			{
				return this.@replyTo;
			}
			set
			{
				this.@replyTo = value;
			}
		}
		
		public String @To
		{
			get
			{
				return this.@to;
			}
			set
			{
				this.@to = value;
			}
		}
		
		public String @Cc
		{
			get
			{
				return this.@cc;
			}
			set
			{
				this.@cc = value;
			}
		}
		
		public String @Bcc
		{
			get
			{
				return this.@bcc;
			}
			set
			{
				this.@bcc = value;
			}
		}
		
		public String @Subject
		{
			get
			{
				return this.@subject;
			}
			set
			{
				this.@subject = value;
			}
		}
		
		public Nullable<Boolean> @IsBodyHtml
		{
			get
			{
				return this.@isBodyHtml;
			}
			set
			{
				this.@isBodyHtml = value;
			}
		}
		
		public String @Body
		{
			get
			{
				return this.@body;
			}
			set
			{
				this.@body = value;
			}
		}
		
		public Nullable<Boolean> @Processed
		{
			get
			{
				return this.@processed;
			}
			set
			{
				this.@processed = value;
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
