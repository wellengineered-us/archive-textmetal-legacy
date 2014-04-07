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
	public partial class PropertyBagHistory : Object
	{		
		#region Constructors/Destructors
		
		public PropertyBagHistory()
		{
		}
		
		#endregion
		
		#region Fields/Constants

		private Nullable<Int64> @propertyBagHistoryId;
		private Nullable<DateTime> @propertyBagHistoryTs;
		private Nullable<Int32> @propertyBagId;
		private String @propertyKey;
		private String @propertyType;
		private String @propertyValue;
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
				return this.PropertyBagHistoryId == default(Nullable<Int64>);
			}
			set
			{
				if(value)
					this.PropertyBagHistoryId =  default(Nullable<Int64>);
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Int64> @PropertyBagHistoryId
		{
			get
			{
				return this.@propertyBagHistoryId;
			}
			set
			{
				this.@propertyBagHistoryId = value;
			}
		}
		
		public Nullable<DateTime> @PropertyBagHistoryTs
		{
			get
			{
				return this.@propertyBagHistoryTs;
			}
			set
			{
				this.@propertyBagHistoryTs = value;
			}
		}
		
		public Nullable<Int32> @PropertyBagId
		{
			get
			{
				return this.@propertyBagId;
			}
			set
			{
				this.@propertyBagId = value;
			}
		}
		
		public String @PropertyKey
		{
			get
			{
				return this.@propertyKey;
			}
			set
			{
				this.@propertyKey = value;
			}
		}
		
		public String @PropertyType
		{
			get
			{
				return this.@propertyType;
			}
			set
			{
				this.@propertyType = value;
			}
		}
		
		public String @PropertyValue
		{
			get
			{
				return this.@propertyValue;
			}
			set
			{
				this.@propertyValue = value;
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
