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
	public partial class TableNoPrimaryKeyWithIdentityHistory : Object
	{		
		#region Constructors/Destructors
		
		public TableNoPrimaryKeyWithIdentityHistory()
		{
		}
		
		#endregion
		
		#region Fields/Constants

		private bool isNew = true;
		private Nullable<Int64> @timestampId;
		private Nullable<Int32> @id;
		private Nullable<Boolean> @data01;
		private Nullable<DateTime> @data02;
		private Nullable<Int32> @data03;
		private String @data04;

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
		public Nullable<Int32> @Id
		{
			get
			{
				return this.@id;
			}
			set
			{
				this.@id = value;
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Boolean> @Data01
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
		
		/* PRIMARY_KEY */
		public Nullable<DateTime> @Data02
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
		
		/* PRIMARY_KEY */
		public Nullable<Int32> @Data03
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
		
		/* PRIMARY_KEY */
		public String @Data04
		{
			get
			{
				return this.@data04;
			}
			set
			{
				this.@data04 = value;
			}
		}
		
		#endregion
	}
}
