//-----------------------------------------------------------------------
// <copyright file="BuildableExpectation.cs" company="NMock2">
//
//   http://www.sourceforge.net/projects/NMock2
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.IO;

using NMock2.Matchers;
using NMock2.Monitoring;

namespace NMock2.Internal
{
	using System;

	public class BuildableExpectation : IExpectation
	{
		#region Constructors/Destructors

		/// <summary>
		/// 	Initializes a new instance of the <see cref="BuildableExpectation" /> class.
		/// </summary>
		/// <param name="expectationDescription"> The expectation description. </param>
		/// <param name="requiredCountMatcher"> The required count matcher. </param>
		/// <param name="matchingCountMatcher"> The matching count matcher. </param>
		public BuildableExpectation(string expectationDescription, Matcher requiredCountMatcher, Matcher matchingCountMatcher)
		{
			this.expectationDescription = expectationDescription;
			this.requiredCountMatcher = requiredCountMatcher;
			this.matchingCountMatcher = matchingCountMatcher;
		}

		#endregion

		#region Fields/Constants

		private const string AddEventHandlerPrefix = "add_";
		private const string RemoveEventHandlerPrefix = "remove_";
		private ArrayList actions = new ArrayList();
		private Matcher argumentsMatcher = new AlwaysMatcher(true, "(any arguments)");
		private int callCount = 0;

		private string expectationComment;
		private string expectationDescription;
		private ArrayList extraMatchers = new ArrayList();
		private Matcher genericMethodTypeMatcher = new AlwaysMatcher(true, string.Empty);
		private Matcher matchingCountMatcher;

		private Matcher methodMatcher = new AlwaysMatcher(true, "<any method>");
		private string methodSeparator = ".";
		private IMockObject receiver;
		private Matcher requiredCountMatcher;

		#endregion

		#region Properties/Indexers/Events

		public Matcher ArgumentsMatcher
		{
			get
			{
				return this.argumentsMatcher;
			}
			set
			{
				this.argumentsMatcher = value;
			}
		}

		public Matcher GenericMethodTypeMatcher
		{
			get
			{
				return this.genericMethodTypeMatcher;
			}
			set
			{
				this.genericMethodTypeMatcher = value;
			}
		}

		public bool HasBeenMet
		{
			get
			{
				return this.requiredCountMatcher.Matches(this.callCount);
			}
		}

		public bool IsActive
		{
			get
			{
				return this.matchingCountMatcher.Matches(this.callCount + 1);
			}
		}

		public Matcher MethodMatcher
		{
			get
			{
				return this.methodMatcher;
			}
			set
			{
				this.methodMatcher = value;
			}
		}

		public IMockObject Receiver
		{
			get
			{
				return this.receiver;
			}
			set
			{
				this.receiver = value;
			}
		}

		#endregion

		#region Methods/Operators

		private static bool IsEventAccessorMethod(Invocation invocation)
		{
			return invocation.Method.IsSpecialName &&
			       (invocation.Method.Name.StartsWith(AddEventHandlerPrefix) ||
			        invocation.Method.Name.StartsWith(RemoveEventHandlerPrefix));
		}

		private static void MockEventHandler(Invocation invocation, IMockObject mockObject)
		{
			Delegate handler = invocation.Parameters[0] as Delegate;

			if (invocation.Method.Name.StartsWith(AddEventHandlerPrefix))
			{
				mockObject.AddEventHandler(
					invocation.Method.Name.Substring(AddEventHandlerPrefix.Length), handler);
			}

			if (invocation.Method.Name.StartsWith(RemoveEventHandlerPrefix))
			{
				mockObject.RemoveEventHandler(
					invocation.Method.Name.Substring(RemoveEventHandlerPrefix.Length),
					handler);
			}
		}

		private static void ProcessEventHandlers(Invocation invocation)
		{
			if (IsEventAccessorMethod(invocation))
			{
				IMockObject mockObject = invocation.Receiver as IMockObject;
				if (mockObject != null)
					MockEventHandler(invocation, mockObject);
			}
		}

		public void AddAction(IAction action)
		{
			this.actions.Add(action);
		}

		public void AddComment(string comment)
		{
			this.expectationComment = comment;
		}

		public void AddInvocationMatcher(Matcher matcher)
		{
			this.extraMatchers.Add(matcher);
		}

		public void DescribeActiveExpectationsTo(TextWriter writer)
		{
			if (this.IsActive)
				this.DescribeTo(writer);
		}

		public void DescribeAsIndexer()
		{
			this.methodSeparator = string.Empty;
		}

		private void DescribeTo(TextWriter writer)
		{
			writer.Write(this.expectationDescription);
			writer.Write(": ");
			writer.Write(this.receiver.MockName);
			writer.Write(this.methodSeparator);
			this.methodMatcher.DescribeTo(writer);
			this.genericMethodTypeMatcher.DescribeTo(writer);
			this.argumentsMatcher.DescribeTo(writer);
			foreach (Matcher extraMatcher in this.extraMatchers)
			{
				writer.Write(", ");
				extraMatcher.DescribeTo(writer);
			}

			if (this.actions.Count > 0)
			{
				writer.Write(", will ");
				((IAction)this.actions[0]).DescribeTo(writer);
				for (int i = 1; i < this.actions.Count; i++)
				{
					writer.Write(", ");
					((IAction)this.actions[i]).DescribeTo(writer);
				}
			}

			writer.Write(" [called ");
			writer.Write(this.callCount);
			writer.Write(" time");
			if (this.callCount != 1)
				writer.Write("s");

			writer.Write("]");

			if (!string.IsNullOrEmpty(this.expectationComment))
			{
				writer.Write(" Comment: ");
				writer.Write(this.expectationComment);
			}
		}

		public void DescribeUnmetExpectationsTo(TextWriter writer)
		{
			if (!this.HasBeenMet)
				this.DescribeTo(writer);
		}

		private bool ExtraMatchersMatch(Invocation invocation)
		{
			foreach (Matcher matcher in this.extraMatchers)
			{
				if (!matcher.Matches(invocation))
					return false;
			}

			return true;
		}

		/// <summary>
		/// 	Checks whether stored expectations matches the specified invocation.
		/// </summary>
		/// <param name="invocation"> The invocation to check. </param>
		/// <returns> Returns whether one of the stored expectations has met the specified invocation. </returns>
		public bool Matches(Invocation invocation)
		{
			return this.IsActive
			       && this.receiver == invocation.Receiver
			       && this.methodMatcher.Matches(invocation.Method)
			       && this.argumentsMatcher.Matches(invocation)
			       && this.ExtraMatchersMatch(invocation)
			       && this.GenericMethodTypeMatcher.Matches(invocation);
		}

		public bool MatchesIgnoringIsActive(Invocation invocation)
		{
			return this.receiver == invocation.Receiver
			       && this.methodMatcher.Matches(invocation.Method)
			       && this.argumentsMatcher.Matches(invocation)
			       && this.ExtraMatchersMatch(invocation)
			       && this.GenericMethodTypeMatcher.Matches(invocation);
		}

		public void Perform(Invocation invocation)
		{
			this.callCount++;
			ProcessEventHandlers(invocation);
			foreach (IAction action in this.actions)
				action.Invoke(invocation);
		}

		/// <summary>
		/// 	Adds itself to the <paramref name="result" /> if the <see cref="Receiver" /> matches
		/// 	the specified <paramref name="mock" />.
		/// </summary>
		/// <param name="mock"> The mock for which expectations are queried. </param>
		/// <param name="result"> The result to add matching expectations to. </param>
		public void QueryExpectationsBelongingTo(IMockObject mock, IList<IExpectation> result)
		{
			if (this.Receiver == mock)
				result.Add(this);
		}

		#endregion
	}
}