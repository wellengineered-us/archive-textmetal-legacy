/*
	Copyright �2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

using NUnit.Framework;

using TextMetal.Common.Data.Framework.Mapping;

namespace TextMetal.Common.UnitTests.Data.Framework.Mapping._
{
	[TestFixture]
	public class TableMappingAttributeTests
	{
		#region Constructors/Destructors

		public TableMappingAttributeTests()
		{
		}

		#endregion

		#region Methods/Operators

		[Test]
		public void ShouldCreateTest()
		{
			TableMappingAttribute tableMappingAttribute;

			tableMappingAttribute = new TableMappingAttribute();

			Assert.IsNotNull(tableMappingAttribute);

			tableMappingAttribute.TableName = "x";
			Assert.AreEqual("x", tableMappingAttribute.TableName);

			tableMappingAttribute.SchemaName = "y";
			Assert.AreEqual("y", tableMappingAttribute.SchemaName);

			tableMappingAttribute.DatabaseName = "z";
			Assert.AreEqual("z", tableMappingAttribute.DatabaseName);

			tableMappingAttribute.IsView = true;
			Assert.AreEqual(true, tableMappingAttribute.IsView);
		}

		#endregion
	}
}