﻿//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by:
// TextMetal 5.0.3.40772;
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
	public partial class EmailAttachmentHistory : Object
	{		
		#region Constructors/Destructors
		
		public EmailAttachmentHistory()
		{
		}
		
		#endregion
		
		#region Fields/Constants

		private bool isNew = true;
		private Nullable<Int64> @timestampId;
		private Nullable<Int32> @emailAttachmentId;
		private Nullable<Int32> @emailMessageId;
		private String @mimeType;
		private Byte[] @attachmentBits;
		private Nullable<DateTime> @creationTimestamp;
		private Nullable<DateTime> @modificationTimestamp;
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
