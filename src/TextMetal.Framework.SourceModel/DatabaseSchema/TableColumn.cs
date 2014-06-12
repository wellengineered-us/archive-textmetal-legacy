﻿/*
	Copyright ©2002-2014 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Xml.Serialization;

namespace TextMetal.Framework.SourceModel.DatabaseSchema
{
	[Serializable]
	public class TableColumn : Column
	{
		#region Constructors/Destructors

		/// <summary>
		/// Initializes a new instance of the TableColumn class.
		/// </summary>
		public TableColumn()
		{
		}

		#endregion

		#region Fields/Constants

		private bool columnHasCheck;
		private bool columnHasDefault;
		private bool columnIsComputed;
		private bool columnIsIdentity;
		private bool columnIsPrimaryKey;

		#endregion

		#region Properties/Indexers/Events

		[XmlAttribute]
		public bool ColumnHasCheck
		{
			get
			{
				return this.columnHasCheck;
			}
			set
			{
				this.columnHasCheck = value;
			}
		}

		[XmlAttribute]
		public bool ColumnHasDefault
		{
			get
			{
				return this.columnHasDefault;
			}
			set
			{
				this.columnHasDefault = value;
			}
		}

		[XmlAttribute]
		public bool ColumnIsComputed
		{
			get
			{
				return this.columnIsComputed;
			}
			set
			{
				this.columnIsComputed = value;
			}
		}

		[XmlAttribute]
		public bool ColumnIsIdentity
		{
			get
			{
				return this.columnIsIdentity;
			}
			set
			{
				this.columnIsIdentity = value;
			}
		}

		[XmlAttribute]
		public bool ColumnIsPrimaryKey
		{
			get
			{
				return this.columnIsPrimaryKey;
			}
			set
			{
				this.columnIsPrimaryKey = value;
			}
		}

		public bool IsColumnServerGeneratedPrimaryKey
		{
			get
			{
				return this.ColumnIsPrimaryKey && this.ColumnIsIdentity;
			}
		}

		#endregion
	}
}