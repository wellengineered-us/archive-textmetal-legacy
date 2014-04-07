﻿//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by:
// TextMetal 5.0.6.35568;
// 		Copyright ©2002-2014 Daniel Bullington (dpbullington@gmail.com)
//		Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
//		Project URL: https://github.com/dpbullington/textmetal
//
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//
// </auto-generated>
//------------------------------------------------------------------------------

/*
	Copyright ©2002-2014 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Xml;

using TextMetal.Common.Core;

namespace TextMetal.HostImpl.AspNetSample.DomainModel.Tables
{
	public partial class EmailAttachmentHistory : Object
	{		
		#region Constructors/Destructors
		
		public EmailAttachmentHistory()
		{
		}
		
		#endregion
		
		#region Fields/Constants

		private Nullable<Int64> @emailAttachmentHistoryId;
		private Nullable<DateTime> @emailAttachmentHistoryTs;
		private Nullable<Int32> @emailMessageId;
		private Nullable<Int32> @emailAttachmentId;
		private String @fileName;
		private Nullable<Int64> @fileSize;
		private String @mimeType;
		private Byte[] @attachmentBits;
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
				return this.EmailAttachmentHistoryId == default(Nullable<Int64>);
			}
			set
			{
				if(value)
					this.EmailAttachmentHistoryId =  default(Nullable<Int64>);
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Int64> @EmailAttachmentHistoryId
		{
			get
			{
				return this.@emailAttachmentHistoryId;
			}
			set
			{
				this.@emailAttachmentHistoryId = value;
			}
		}
		
		public Nullable<DateTime> @EmailAttachmentHistoryTs
		{
			get
			{
				return this.@emailAttachmentHistoryTs;
			}
			set
			{
				this.@emailAttachmentHistoryTs = value;
			}
		}
		
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
		
		public Nullable<Int32> @EmailAttachmentId
		{
			get
			{
				return this.@emailAttachmentId;
			}
			set
			{
				this.@emailAttachmentId = value;
			}
		}
		
		public String @FileName
		{
			get
			{
				return this.@fileName;
			}
			set
			{
				this.@fileName = value;
			}
		}
		
		public Nullable<Int64> @FileSize
		{
			get
			{
				return this.@fileSize;
			}
			set
			{
				this.@fileSize = value;
			}
		}
		
		public String @MimeType
		{
			get
			{
				return this.@mimeType;
			}
			set
			{
				this.@mimeType = value;
			}
		}
		
		public Byte[] @AttachmentBits
		{
			get
			{
				return this.@attachmentBits;
			}
			set
			{
				this.@attachmentBits = value;
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
