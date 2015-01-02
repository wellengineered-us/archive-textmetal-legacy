﻿/*
	Copyright ©2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

using TextMetal.Common.Solder.DependencyManagement;

namespace TextMetal.Common.UnitTests.TestingInfrastructure
{
	public class MockDependantObject
	{
		#region Constructors/Destructors

		public MockDependantObject()
		{
			this.text = null;
		}

		public MockDependantObject([DependencyInjection(SelectorKey = "")] string text)
		{
			this.text = text ?? string.Empty;
		}

		public MockDependantObject([DependencyInjection(SelectorKey = "named_dep_obj")] MockDependantObject left, MockDependantObject right)
		{
			this.text = string.Empty;
			this.left = left;
			this.right = right;
		}

		#endregion

		#region Fields/Constants

		private readonly MockDependantObject left;
		private readonly MockDependantObject right;
		private readonly string text;

		#endregion

		#region Properties/Indexers/Events

		public MockDependantObject Left
		{
			get
			{
				return this.left;
			}
		}

		public MockDependantObject Right
		{
			get
			{
				return this.right;
			}
		}

		public string Text
		{
			get
			{
				return this.text;
			}
		}

		#endregion
	}
}