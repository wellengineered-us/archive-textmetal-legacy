﻿/*
	Copyright ©2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Reflection;

using NUnit.Framework;

using TextMetal.Middleware.Testing;
using TextMetal.Middleware.UnitTests.TestingInfrastructure;

namespace TextMetal.Middleware.UnitTests.Solder.SoC._
{
	[TestFixture]
	public class AspectDynamicInvokerTests
	{
		#region Constructors/Destructors

		public AspectDynamicInvokerTests()
		{
		}

		#endregion

		#region Methods/Operators

		[Test]
		public void ShouldCloneInvokeTest()
		{
			MockAspectDynamicInvoker mockAspectDynamicInvoker;
			object proxyInstance;
			Type proxiedType;
			MethodInfo invokedMethodInfo;
			object[] invocationParameters;
			object returnValue;

			proxyInstance = new object();
			proxiedType = typeof(ICloneable);
			invokedMethodInfo = (MethodInfo)MemberInfoProxy<ICloneable>.GetLastMemberInfo(exec => exec.Clone());
			invocationParameters = new object[] { };

			mockAspectDynamicInvoker = new MockAspectDynamicInvoker();
			returnValue = mockAspectDynamicInvoker.Invoke(proxiedType, invokedMethodInfo, proxyInstance, invocationParameters);

			Assert.IsNull(returnValue);
			Assert.AreEqual("ICloneable::Clone", mockAspectDynamicInvoker.LastOperationName);
		}

		[Test]
		public void ShouldDisposeInvokeTest()
		{
			MockAspectDynamicInvoker mockAspectDynamicInvoker;
			object proxyInstance;
			Type proxiedType;
			MethodInfo invokedMethodInfo;
			object[] invocationParameters;
			object returnValue;

			proxyInstance = new object();
			proxiedType = typeof(IDisposable);
			invokedMethodInfo = (MethodInfo)MemberInfoProxy<IDisposable>.GetLastMemberInfo(exec => exec.Dispose());
			invocationParameters = new object[] { };

			mockAspectDynamicInvoker = new MockAspectDynamicInvoker();
			returnValue = mockAspectDynamicInvoker.Invoke(proxiedType, invokedMethodInfo, proxyInstance, invocationParameters);

			Assert.IsNull(returnValue);
			Assert.IsFalse(mockAspectDynamicInvoker.Disposed);
		}

		[Test]
		[ExpectedException(typeof(ObjectDisposedException))]
		public void ShouldFailOnDisposedInvokeTest()
		{
			MockAspectDynamicInvoker mockAspectDynamicInvoker;
			object proxyInstance;
			Type proxiedType;
			MethodInfo invokedMethodInfo;
			object[] invocationParameters;
			object returnValue;

			proxyInstance = new object();
			proxiedType = typeof(IMockObject);
			invokedMethodInfo = (MethodInfo)MemberInfoProxy<IMockObject>.GetLastMemberInfo(exec => exec.ToString());
			invocationParameters = new object[] { };

			mockAspectDynamicInvoker = new MockAspectDynamicInvoker(new MockObject());
			mockAspectDynamicInvoker.Dispose();
			returnValue = mockAspectDynamicInvoker.Invoke(proxiedType, invokedMethodInfo, proxyInstance, invocationParameters);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ShouldFailOnNullInputParameterInvokeTest()
		{
			MockAspectDynamicInvoker mockAspectDynamicInvoker;
			object proxyInstance;
			Type proxiedType;
			MethodInfo invokedMethodInfo;
			object[] invocationParameters;

			proxyInstance = new object();
			proxiedType = typeof(IMockObject);
			invokedMethodInfo = (MethodInfo)MemberInfoProxy<IMockObject>.GetLastMemberInfo(exec => exec.ToString());
			invocationParameters = null;

			mockAspectDynamicInvoker = new MockAspectDynamicInvoker();
			mockAspectDynamicInvoker.Invoke(proxiedType, invokedMethodInfo, proxyInstance, invocationParameters);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ShouldFailOnNullInvokingTypeInvokeTest()
		{
			MockAspectDynamicInvoker mockAspectDynamicInvoker;
			object proxyInstance;
			Type proxiedType;
			MethodInfo invokedMethodInfo;
			object[] invocationParameters;

			proxyInstance = new object();
			proxiedType = null;
			invokedMethodInfo = (MethodInfo)MemberInfoProxy<IMockObject>.GetLastMemberInfo(exec => exec.ToString());
			invocationParameters = new object[] { };

			mockAspectDynamicInvoker = new MockAspectDynamicInvoker();
			mockAspectDynamicInvoker.Invoke(proxiedType, invokedMethodInfo, proxyInstance, invocationParameters);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ShouldFailOnNullMethodInfoInvokeTest()
		{
			MockAspectDynamicInvoker mockAspectDynamicInvoker;
			object proxyInstance;
			Type proxiedType;
			MethodInfo invokedMethodInfo;
			object[] invocationParameters;

			proxyInstance = new object();
			proxiedType = typeof(IMockObject);
			invokedMethodInfo = null;
			invocationParameters = new object[] { };

			mockAspectDynamicInvoker = new MockAspectDynamicInvoker();
			mockAspectDynamicInvoker.Invoke(proxiedType, invokedMethodInfo, proxyInstance, invocationParameters);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ShouldFailOnNullTargetInstanceInvokeTest()
		{
			MockAspectDynamicInvoker mockAspectDynamicInvoker;
			object proxyInstance;
			Type proxiedType;
			MethodInfo invokedMethodInfo;
			object[] invocationParameters;

			proxyInstance = null;
			proxiedType = typeof(IMockObject);
			invokedMethodInfo = (MethodInfo)MemberInfoProxy<IMockObject>.GetLastMemberInfo(exec => exec.ToString());
			invocationParameters = new object[] { };

			mockAspectDynamicInvoker = new MockAspectDynamicInvoker();
			mockAspectDynamicInvoker.Invoke(proxiedType, invokedMethodInfo, proxyInstance, invocationParameters);
		}

		[Test]
		public void ShouldNotFailOnDoubleDisposeTest()
		{
			MockAspectDynamicInvoker mockAspectDynamicInvoker;

			mockAspectDynamicInvoker = new MockAspectDynamicInvoker();

			Assert.IsNotNull(mockAspectDynamicInvoker);

			mockAspectDynamicInvoker.Dispose();
			mockAspectDynamicInvoker.Dispose();
		}

		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void ShouldThrowOnProceedInvokeTest()
		{
			MockAspectDynamicInvoker mockAspectDynamicInvoker;
			object proxyInstance;
			Type proxiedType;
			MethodInfo invokedMethodInfo;
			object[] invocationParameters;
			object returnValue;

			proxyInstance = new object();
			proxiedType = typeof(IMockObject);
			invokedMethodInfo = (MethodInfo)MemberInfoProxy<IMockObject>.GetLastMemberInfo(exec => exec.ToString());
			invocationParameters = new object[] { };

			mockAspectDynamicInvoker = new MockAspectDynamicInvoker(new InvalidOperationException());
			returnValue = mockAspectDynamicInvoker.Invoke(proxiedType, invokedMethodInfo, proxyInstance, invocationParameters);
		}

		[Test]
		public void ShouldToStringInvokeTest()
		{
			MockAspectDynamicInvoker mockAspectDynamicInvoker;
			object proxyInstance;
			Type proxiedType;
			MethodInfo invokedMethodInfo;
			object[] invocationParameters;
			object returnValue;

			proxyInstance = new object();
			proxiedType = typeof(IMockObject);
			invokedMethodInfo = (MethodInfo)MemberInfoProxy<IMockObject>.GetLastMemberInfo(exec => exec.ToString());
			invocationParameters = new object[] { };

			mockAspectDynamicInvoker = new MockAspectDynamicInvoker(new MockObject());
			returnValue = mockAspectDynamicInvoker.Invoke(proxiedType, invokedMethodInfo, proxyInstance, invocationParameters);

			Assert.AreEqual(typeof(MockObject).FullName, returnValue);
		}

		#endregion
	}
}