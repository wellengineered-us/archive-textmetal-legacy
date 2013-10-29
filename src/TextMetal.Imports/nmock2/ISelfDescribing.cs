//-----------------------------------------------------------------------
// <copyright file="ISelfDescribing.cs" company="NMock2">
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

namespace NMock2
{
	/// <summary>
	/// 	This interface is used to get a description of the implementator.
	/// </summary>
	public interface ISelfDescribing
	{
		#region Methods/Operators

		/// <summary>
		/// 	Describes this object.
		/// </summary>
		/// <param name="writer"> The text writer the description is added to. </param>
		void DescribeTo(TextWriter writer);

		#endregion
	}
}