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
	public partial class TableWithCompositePrimaryKeyNoIdentity : Object
	{		
		#region Constructors/Destructors
		
		public TableWithCompositePrimaryKeyNoIdentity()
		{
		}
		
		#endregion
		
		#region Fields/Constants

		private bool isNew = true;
		private Nullable<Int32> @pk0;
		private Nullable<Int32> @pk1;
		private Nullable<Int32> @pk2;
		private Nullable<Int32> @pk3;
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
		public Nullable<Int32> @Pk0
		{
			get
			{
				return this.@pk0;
			}
			set
			{
				this.@pk0 = value;
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Int32> @Pk1
		{
			get
			{
				return this.@pk1;
			}
			set
			{
				this.@pk1 = value;
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Int32> @Pk2
		{
			get
			{
				return this.@pk2;
			}
			set
			{
				this.@pk2 = value;
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Int32> @Pk3
		{
			get
			{
				return this.@pk3;
			}
			set
			{
				this.@pk3 = value;
			}
		}
		
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
