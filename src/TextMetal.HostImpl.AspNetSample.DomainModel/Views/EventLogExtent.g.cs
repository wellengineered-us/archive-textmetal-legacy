﻿//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by:
// TextMetal 5.1.0.41861;
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

namespace TextMetal.HostImpl.AspNetSample.DomainModel.Views
{
	public partial class EventLogExtent : Object
	{		
		#region Constructors/Destructors
		
		public EventLogExtent()
		{
		}
		
		#endregion
		
		#region Fields/Constants

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
	}
}
