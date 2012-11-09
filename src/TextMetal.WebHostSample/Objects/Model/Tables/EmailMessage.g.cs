﻿//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by:
// TextMetal 4.4.5.39286;
// 		Copyright ©2002-2012 Daniel Bullington (dpbullington@gmail.com)
//		Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
//		Project URL: https://github.com/dpbullington/textmetal
//
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//
// </auto-generated>
//------------------------------------------------------------------------------

/*
	Copyright ©2002-2012 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

using TextMetal.Plumbing.CommonFacilities;

namespace TextMetal.WebHostSample.Objects.Model.Tables
{
	public partial class EmailMessage : Object
	{		
		#region Constructors/Destructors
		
		public EmailMessage()
		{
		}
		
		#endregion
		
		#region Fields/Constants
		
		public const string SCHEMA_NAME_DBO = "dbo";
		public const string TABLE_NAME_EMAIL_MESSAGE = "EmailMessage";
		
		public const string COLUMN_NAME_EMAIL_MESSAGE_ID = "EmailMessageId";
		public const string COLUMN_NAME_FROM = "From";
		public const string COLUMN_NAME_SENDER = "Sender";
		public const string COLUMN_NAME_REPLY_TO = "ReplyTo";
		public const string COLUMN_NAME_TO = "To";
		public const string COLUMN_NAME_CC = "CC";
		public const string COLUMN_NAME_BCC = "BCC";
		public const string COLUMN_NAME_SUBJECT = "Subject";
		public const string COLUMN_NAME_IS_BODY_HTML = "IsBodyHtml";
		public const string COLUMN_NAME_BODY = "Body";
		public const string COLUMN_NAME_PROCESSED = "Processed";
		public const string COLUMN_NAME_CREATION_TIMESTAMP = "CreationTimestamp";
		public const string COLUMN_NAME_MODIFICATION_TIMESTAMP = "ModificationTimestamp";
		public const string COLUMN_NAME_LOGICAL_DELETE = "LogicalDelete";

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
		public Nullable<Int32> EmailMessageId
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
		
		public String From
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
		
		public String Sender
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
		
		public String ReplyTo
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
		
		public String To
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
		
		public String Cc
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
		
		public String Bcc
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
		
		public String Subject
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
		
		public Nullable<Boolean> IsBodyHtml
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
		
		public String Body
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
		
		public Nullable<Boolean> Processed
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
		
		public Nullable<DateTime> CreationTimestamp
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
		
		public Nullable<DateTime> ModificationTimestamp
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
		
		public Nullable<Boolean> LogicalDelete
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
