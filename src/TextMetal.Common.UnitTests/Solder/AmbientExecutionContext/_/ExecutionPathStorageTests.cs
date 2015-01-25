﻿/*
	Copyright ©2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.Hosting;

using NUnit.Framework;

using TextMetal.Common.Solder;
using TextMetal.Common.Solder.AmbientExecutionContext;

namespace TextMetal.Common.UnitTests.Solder.AmbientExecutionContext._
{
	[TestFixture]
	public static class ExecutionPathStorageTests
	{
		#region Classes/Structs/Interfaces/Enums/Delegates

		[TestFixture]
		public class CallContextExecutionPathStorageTests
		{
			#region Constructors/Destructors

			public CallContextExecutionPathStorageTests()
			{
			}

			#endregion

			#region Methods/Operators

			[Test]
			public void ShouldCreateAddGetRemoveCallContextExecutionPathStorageTest()
			{
				Assert.IsNull(ExecutionPathStorage.GetValue<object>("x"));

				ExecutionPathStorage.SetValue("x", 1);

				Assert.IsNotNull(ExecutionPathStorage.GetValue<object>("x"));

				Assert.AreEqual(1, ExecutionPathStorage.GetValue<object>("x"));

				ExecutionPathStorage.SetValue<object>("x", null);

				Assert.IsNull(ExecutionPathStorage.GetValue<object>("x"));

				ExecutionPathStorage.RemoveValue("x");

				Assert.IsNull(ExecutionPathStorage.GetValue<object>("x"));
			}

			[Test]
			public void ShouldThreadSafeRunCallContextExecutionPathStorageTest()
			{
				Thread t;

				Assert.IsNull(ExecutionPathStorage.GetValue<object>("x"));

				ExecutionPathStorage.SetValue("x", 1);

				t = new Thread(this.TlsOtherThreadCallContext);
				t.Start();
				t.Join();

				Assert.IsNotNull(ExecutionPathStorage.GetValue<object>("x"));
				Assert.AreEqual(1, ExecutionPathStorage.GetValue<object>("x"));
			}

			[SetUp]
			public void TestSetUp()
			{
				HttpContext.Current = null;
			}

			[TearDown]
			public void TestTearDown()
			{
				HttpContext.Current = null;
			}

			private void TlsOtherThreadCallContext()
			{
				Thread.Sleep(1000);

				Assert.IsNull(ExecutionPathStorage.GetValue<object>("x"));

				ExecutionPathStorage.SetValue("x", 2);
			}

			#endregion
		}

		[TestFixture]
		public class HttpContextExecutionPathStorageTests
		{
			#region Constructors/Destructors

			public HttpContextExecutionPathStorageTests()
			{
			}

			#endregion

			#region Methods/Operators

			[Test]
			public void ShouldCreateAddGetRemoveExecutionPathStorageTest()
			{
				Assert.IsTrue(HttpContextExecutionPathStorage.IsInHttpContext);

				Assert.IsNull(ExecutionPathStorage.GetValue<object>("x"));

				ExecutionPathStorage.SetValue("x", 1);

				Assert.IsNotNull(ExecutionPathStorage.GetValue<object>("x"));

				Assert.AreEqual(1, ExecutionPathStorage.GetValue<object>("x"));

				ExecutionPathStorage.SetValue<object>("x", null);

				Assert.IsNull(ExecutionPathStorage.GetValue<object>("x"));

				ExecutionPathStorage.RemoveValue("x");

				Assert.IsNull(ExecutionPathStorage.GetValue<object>("x"));
			}

			[Test]
			public void ShouldThreadSafeRunExecutionPathStorageTest()
			{
				Thread t;

				Assert.IsNull(ExecutionPathStorage.GetValue<object>("x"));

				ExecutionPathStorage.SetValue("x", 1);

				t = new Thread(this.TlsOtherThreadHttpContext);
				t.Start();
				t.Join();

				Assert.IsNotNull(ExecutionPathStorage.GetValue<object>("x"));
				Assert.AreEqual(1, ExecutionPathStorage.GetValue<object>("x"));
			}

			[SetUp]
			public void TestSetUp()
			{
				TextWriter tw;
				HttpWorkerRequest wr;

				// fake up HttpContext
				tw = new StringWriter();
				wr = new SimpleWorkerRequest("/webapp", "c:\\inetpub\\wwwroot\\webapp\\", "default.aspx", string.Empty, tw);

				HttpContext.Current = new HttpContext(wr);
			}

			[TearDown]
			public void TestTearDown()
			{
				HttpContext.Current = null;
			}

			private void TlsOtherThreadHttpContext()
			{
				TextWriter tw;
				HttpWorkerRequest wr;

				// fake up HttpContext
				tw = new StringWriter();
				wr = new SimpleWorkerRequest("/webapp", "c:\\inetpub\\wwwroot\\webapp\\", "default.aspx", string.Empty, tw);
				HttpContext.Current = new HttpContext(wr);

				Thread.Sleep(1000);

				Assert.IsNull(ExecutionPathStorage.GetValue<object>("x"));

				ExecutionPathStorage.SetValue("x", 2);

				HttpContext.Current = null;
			}

			#endregion
		}

		#endregion
	}
}