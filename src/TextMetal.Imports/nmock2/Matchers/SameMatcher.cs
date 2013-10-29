//-----------------------------------------------------------------------
// <copyright file="SameMatcher.cs" company="NMock2">
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

using System.IO;

namespace NMock2.Matchers
{
	/// <summary>
	/// 	Matcher that checks whether the actual object is the same as the expected one (equality by reference).
	/// </summary>
	public class SameMatcher : Matcher
	{
		#region Constructors/Destructors

		/// <summary>
		/// 	Initializes a new instance of the <see cref="SameMatcher" /> class.
		/// </summary>
		/// <param name="expected"> The expected object. </param>
		public SameMatcher(object expected)
		{
			this.expected = expected;
		}

		#endregion

		#region Fields/Constants

		private readonly object expected;

		#endregion

		#region Methods/Operators

		/// <summary>
		/// 	Describes this object.
		/// </summary>
		/// <param name="writer"> The text writer the description is added to. </param>
		public override void DescribeTo(TextWriter writer)
		{
			writer.Write("same as ");
			writer.Write(this.expected);
		}

		/// <summary>
		/// 	Matches the specified object to this matcher and returns whether it matches.
		/// </summary>
		/// <param name="o"> The object to match. </param>
		/// <returns> Whether the object is the same as the expected one. </returns>
		public override bool Matches(object o)
		{
			return this.expected == o;
		}

		#endregion
	}
}