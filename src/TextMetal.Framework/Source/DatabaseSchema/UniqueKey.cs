﻿/*
	Copyright ©2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TextMetal.Framework.Source.DatabaseSchema
{
	[Serializable]
	public class UniqueKey
	{
		#region Constructors/Destructors

		/// <summary>
		/// Initializes a new instance of the UniqueKey class.
		/// </summary>
		public UniqueKey()
		{
		}

		#endregion

		#region Fields/Constants

		private readonly List<UniqueKeyColumn> uniqueKeyColumn = new List<UniqueKeyColumn>();
		private int uniqueKeyId;
		private bool uniqueKeyIsSystemNamed;
		private string uniqueKeyName;
		private string uniqueKeyNameCamelCase;
		private string uniqueKeyNameConstantCase;
		private string uniqueKeyNamePascalCase;
		private string uniqueKeyNamePluralCamelCase;
		private string uniqueKeyNamePluralConstantCase;
		private string uniqueKeyNamePluralPascalCase;
		private string uniqueKeyNameSingularCamelCase;
		private string uniqueKeyNameSingularConstantCase;
		private string uniqueKeyNameSingularPascalCase;
		private string uniqueKeyNameSqlMetalCamelCase;
		private string uniqueKeyNameSqlMetalPascalCase;
		private string uniqueKeyNameSqlMetalPluralCamelCase;
		private string uniqueKeyNameSqlMetalPluralPascalCase;
		private string uniqueKeyNameSqlMetalSingularCamelCase;
		private string uniqueKeyNameSqlMetalSingularPascalCase;

		#endregion

		#region Properties/Indexers/Events

		[XmlArray(ElementName = "UniqueKeyColumns")]
		[XmlArrayItem(ElementName = "UniqueKeyColumn")]
		public List<UniqueKeyColumn> UniqueKeyColumns
		{
			get
			{
				return this.uniqueKeyColumn;
			}
		}

		[XmlAttribute]
		public int UniqueKeyId
		{
			get
			{
				return this.uniqueKeyId;
			}
			set
			{
				this.uniqueKeyId = value;
			}
		}

		[XmlAttribute]
		public bool UniqueKeyIsSystemNamed
		{
			get
			{
				return this.uniqueKeyIsSystemNamed;
			}
			set
			{
				this.uniqueKeyIsSystemNamed = value;
			}
		}

		[XmlAttribute]
		public string UniqueKeyName
		{
			get
			{
				return this.uniqueKeyName;
			}
			set
			{
				this.uniqueKeyName = value;
			}
		}

		[XmlAttribute]
		public string UniqueKeyNameCamelCase
		{
			get
			{
				return this.uniqueKeyNameCamelCase;
			}
			set
			{
				this.uniqueKeyNameCamelCase = value;
			}
		}

		[XmlAttribute]
		public string UniqueKeyNameConstantCase
		{
			get
			{
				return this.uniqueKeyNameConstantCase;
			}
			set
			{
				this.uniqueKeyNameConstantCase = value;
			}
		}

		[XmlAttribute]
		public string UniqueKeyNamePascalCase
		{
			get
			{
				return this.uniqueKeyNamePascalCase;
			}
			set
			{
				this.uniqueKeyNamePascalCase = value;
			}
		}

		[XmlAttribute]
		public string UniqueKeyNamePluralCamelCase
		{
			get
			{
				return this.uniqueKeyNamePluralCamelCase;
			}
			set
			{
				this.uniqueKeyNamePluralCamelCase = value;
			}
		}

		[XmlAttribute]
		public string UniqueKeyNamePluralConstantCase
		{
			get
			{
				return this.uniqueKeyNamePluralConstantCase;
			}
			set
			{
				this.uniqueKeyNamePluralConstantCase = value;
			}
		}

		[XmlAttribute]
		public string UniqueKeyNamePluralPascalCase
		{
			get
			{
				return this.uniqueKeyNamePluralPascalCase;
			}
			set
			{
				this.uniqueKeyNamePluralPascalCase = value;
			}
		}

		[XmlAttribute]
		public string UniqueKeyNameSingularCamelCase
		{
			get
			{
				return this.uniqueKeyNameSingularCamelCase;
			}
			set
			{
				this.uniqueKeyNameSingularCamelCase = value;
			}
		}

		[XmlAttribute]
		public string UniqueKeyNameSingularConstantCase
		{
			get
			{
				return this.uniqueKeyNameSingularConstantCase;
			}
			set
			{
				this.uniqueKeyNameSingularConstantCase = value;
			}
		}

		[XmlAttribute]
		public string UniqueKeyNameSingularPascalCase
		{
			get
			{
				return this.uniqueKeyNameSingularPascalCase;
			}
			set
			{
				this.uniqueKeyNameSingularPascalCase = value;
			}
		}

		[XmlAttribute]
		public string UniqueKeyNameSqlMetalCamelCase
		{
			get
			{
				return this.uniqueKeyNameSqlMetalCamelCase;
			}
			set
			{
				this.uniqueKeyNameSqlMetalCamelCase = value;
			}
		}

		[XmlAttribute]
		public string UniqueKeyNameSqlMetalPascalCase
		{
			get
			{
				return this.uniqueKeyNameSqlMetalPascalCase;
			}
			set
			{
				this.uniqueKeyNameSqlMetalPascalCase = value;
			}
		}

		[XmlAttribute]
		public string UniqueKeyNameSqlMetalPluralCamelCase
		{
			get
			{
				return this.uniqueKeyNameSqlMetalPluralCamelCase;
			}
			set
			{
				this.uniqueKeyNameSqlMetalPluralCamelCase = value;
			}
		}

		[XmlAttribute]
		public string UniqueKeyNameSqlMetalPluralPascalCase
		{
			get
			{
				return this.uniqueKeyNameSqlMetalPluralPascalCase;
			}
			set
			{
				this.uniqueKeyNameSqlMetalPluralPascalCase = value;
			}
		}

		[XmlAttribute]
		public string UniqueKeyNameSqlMetalSingularCamelCase
		{
			get
			{
				return this.uniqueKeyNameSqlMetalSingularCamelCase;
			}
			set
			{
				this.uniqueKeyNameSqlMetalSingularCamelCase = value;
			}
		}

		[XmlAttribute]
		public string UniqueKeyNameSqlMetalSingularPascalCase
		{
			get
			{
				return this.uniqueKeyNameSqlMetalSingularPascalCase;
			}
			set
			{
				this.uniqueKeyNameSqlMetalSingularPascalCase = value;
			}
		}

		#endregion
	}
}