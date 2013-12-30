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
	public partial class EmailMessageHistory : Object
	{		
		#region Constructors/Destructors
		
		public EmailMessageHistory()
		{
		}
		
		#endregion
		
		#region Fields/Constants

		private bool isNew = true;
		private Nullable<Int64> @timestampId;
		private Nullable<Int32> @emailMessageId;
		private String @from;
		private String @sender;
		private String @replyTo;
		private String @to;
		private String @carbonCopy;
		private String @blindCarbonCopy;
		private String @subject;
		private Nullable<Boolean> @isBodyHtml;
		private String @body;
		private Nullable<Boolean> @processed;
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
				return this.isNew;
			}
			set
			{
				this.isNew = value;
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Int64> @TimestampId
		{
			get
			{
				return this.@timestampId;
			}
			set
			{
				this.@timestampId = value;
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
		
		public String @CarbonCopy
		{
			get
			{
				return this.@carbonCopy;
			}
			set
			{
				this.@carbonCopy = value;
			}
		}
		
		public String @BlindCarbonCopy
		{
			get
			{
				return this.@blindCarbonCopy;
			}
			set
			{
				this.@blindCarbonCopy = value;
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
