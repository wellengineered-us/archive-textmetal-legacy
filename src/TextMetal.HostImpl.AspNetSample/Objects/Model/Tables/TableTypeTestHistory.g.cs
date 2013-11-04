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
	public partial class TableTypeTestHistory : Object
	{		
		#region Constructors/Destructors
		
		public TableTypeTestHistory()
		{
		}
		
		#endregion
		
		#region Fields/Constants

		private bool isNew = true;
		private Nullable<Int64> @timestampId;
		private Nullable<Int32> @pkId;
		private Nullable<Int64> @data00;
		private Byte[] @data01;
		private Nullable<Boolean> @data02;
		private String @data03;
		private Nullable<DateTime> @data05;
		private Nullable<DateTime> @data06;
		private Nullable<DateTime> @data07;
		private Nullable<DateTimeOffset> @data08;
		private Nullable<Decimal> @data09;
		private Nullable<Double> @data10;
		private Byte[] @data12;
		private Nullable<Int32> @data13;
		private Nullable<Decimal> @data14;
		private String @data15;
		private String @data16;
		private Nullable<Decimal> @data17;
		private String @data18;
		private Nullable<Single> @data19;
		private Nullable<DateTime> @data20;
		private Nullable<Int16> @data21;
		private Nullable<Decimal> @data22;
		private String @data26;
		private Nullable<TimeSpan> @data27;
		private Nullable<Byte> @data29;
		private Nullable<Guid> @data30;
		private Byte[] @data31;
		private String @data32;

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
		public Nullable<Int32> @PkId
		{
			get
			{
				return this.@pkId;
			}
			set
			{
				this.@pkId = value;
			}
		}
		
		public Nullable<Int64> @Data00
		{
			get
			{
				return this.@data00;
			}
			set
			{
				this.@data00 = value;
			}
		}
		
		public Byte[] @Data01
		{
			get
			{
				return this.@data01;
			}
			set
			{
				this.@data01 = value;
			}
		}
		
		public Nullable<Boolean> @Data02
		{
			get
			{
				return this.@data02;
			}
			set
			{
				this.@data02 = value;
			}
		}
		
		public String @Data03
		{
			get
			{
				return this.@data03;
			}
			set
			{
				this.@data03 = value;
			}
		}
		
		public Nullable<DateTime> @Data05
		{
			get
			{
				return this.@data05;
			}
			set
			{
				this.@data05 = value;
			}
		}
		
		public Nullable<DateTime> @Data06
		{
			get
			{
				return this.@data06;
			}
			set
			{
				this.@data06 = value;
			}
		}
		
		public Nullable<DateTime> @Data07
		{
			get
			{
				return this.@data07;
			}
			set
			{
				this.@data07 = value;
			}
		}
		
		public Nullable<DateTimeOffset> @Data08
		{
			get
			{
				return this.@data08;
			}
			set
			{
				this.@data08 = value;
			}
		}
		
		public Nullable<Decimal> @Data09
		{
			get
			{
				return this.@data09;
			}
			set
			{
				this.@data09 = value;
			}
		}
		
		public Nullable<Double> @Data10
		{
			get
			{
				return this.@data10;
			}
			set
			{
				this.@data10 = value;
			}
		}
		
		public Byte[] @Data12
		{
			get
			{
				return this.@data12;
			}
			set
			{
				this.@data12 = value;
			}
		}
		
		public Nullable<Int32> @Data13
		{
			get
			{
				return this.@data13;
			}
			set
			{
				this.@data13 = value;
			}
		}
		
		public Nullable<Decimal> @Data14
		{
			get
			{
				return this.@data14;
			}
			set
			{
				this.@data14 = value;
			}
		}
		
		public String @Data15
		{
			get
			{
				return this.@data15;
			}
			set
			{
				this.@data15 = value;
			}
		}
		
		public String @Data16
		{
			get
			{
				return this.@data16;
			}
			set
			{
				this.@data16 = value;
			}
		}
		
		public Nullable<Decimal> @Data17
		{
			get
			{
				return this.@data17;
			}
			set
			{
				this.@data17 = value;
			}
		}
		
		public String @Data18
		{
			get
			{
				return this.@data18;
			}
			set
			{
				this.@data18 = value;
			}
		}
		
		public Nullable<Single> @Data19
		{
			get
			{
				return this.@data19;
			}
			set
			{
				this.@data19 = value;
			}
		}
		
		public Nullable<DateTime> @Data20
		{
			get
			{
				return this.@data20;
			}
			set
			{
				this.@data20 = value;
			}
		}
		
		public Nullable<Int16> @Data21
		{
			get
			{
				return this.@data21;
			}
			set
			{
				this.@data21 = value;
			}
		}
		
		public Nullable<Decimal> @Data22
		{
			get
			{
				return this.@data22;
			}
			set
			{
				this.@data22 = value;
			}
		}
		
		public String @Data26
		{
			get
			{
				return this.@data26;
			}
			set
			{
				this.@data26 = value;
			}
		}
		
		public Nullable<TimeSpan> @Data27
		{
			get
			{
				return this.@data27;
			}
			set
			{
				this.@data27 = value;
			}
		}
		
		public Nullable<Byte> @Data29
		{
			get
			{
				return this.@data29;
			}
			set
			{
				this.@data29 = value;
			}
		}
		
		public Nullable<Guid> @Data30
		{
			get
			{
				return this.@data30;
			}
			set
			{
				this.@data30 = value;
			}
		}
		
		public Byte[] @Data31
		{
			get
			{
				return this.@data31;
			}
			set
			{
				this.@data31 = value;
			}
		}
		
		public String @Data32
		{
			get
			{
				return this.@data32;
			}
			set
			{
				this.@data32 = value;
			}
		}
		
		#endregion
	}
}