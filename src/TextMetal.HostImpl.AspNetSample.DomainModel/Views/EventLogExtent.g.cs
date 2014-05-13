﻿//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by:
// TextMetal 6.0.0.29228;
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
using System.Collections.Generic;
using System.Xml;

using TextMetal.Common.Core;
using TextMetal.Common.Data;
using TextMetal.Common.Data.Framework;
using TextMetal.Common.Expressions;

namespace TextMetal.HostImpl.AspNetSample.DomainModel.Views
{
	public partial class EventLogExtent : Object, IEventLogExtent
	{		
		#region Constructors/Destructors
		
		public EventLogExtent()
		{
		}
		
		#endregion
		
		#region Fields/Constants
		
		public const string SCHEMA_NAME = "dbo";
		public const string TABLE_NAME = "EventLogExtent";
		public const bool HAS_SINGLE_COLUMN_SERVER_GENERATED_PRIMARY_KEY = false;
		public const string COLUMN_NAME_MIN_CREATION_TIMESTAMP = "MinCreationTimestamp";
		public const string COLUMN_NAME_AVG_DIFFERENCE_TIMESTAMPS = "AvgDifferenceTimestamps";
		public const string COLUMN_NAME_MAX_MODIFICATION_TIMESTAMP = "MaxModificationTimestamp";

		private Nullable<DateTime> @minCreationTimestamp;
		private Nullable<Int32> @avgDifferenceTimestamps;
		private Nullable<DateTime> @maxModificationTimestamp;

		#endregion

		#region Properties/Indexers/Events
		
		public virtual bool IsNew
		{
			get
			{
				throw new NotSupportedException(string.Format("The model type '{0}' does not support the IsNew property.", this.GetType().FullName));
			}
			set
			{
				throw new NotSupportedException(string.Format("The model type '{0}' does not support the IsNew property.", this.GetType().FullName));
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<DateTime> @MinCreationTimestamp
		{
			get
			{
				return this.@minCreationTimestamp;
			}
			set
			{
				this.@minCreationTimestamp = value;
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Int32> @AvgDifferenceTimestamps
		{
			get
			{
				return this.@avgDifferenceTimestamps;
			}
			set
			{
				this.@avgDifferenceTimestamps = value;
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<DateTime> @MaxModificationTimestamp
		{
			get
			{
				return this.@maxModificationTimestamp;
			}
			set
			{
				this.@maxModificationTimestamp = value;
			}
		}
		
		#endregion
		
		#region Methods/Operators
		
		partial void OnMark();
		
		partial void OnValidate(ref IEnumerable<Message> messages);
		
		public virtual void Mark()
		{
			this.OnMark();
		}
		
		public virtual IEnumerable<Message> Validate()
		{
			IEnumerable<Message> messages = null;
			
			this.OnValidate(ref messages);
			
			return messages ?? new Message[] { };
		}
		
		#endregion
	}
}
