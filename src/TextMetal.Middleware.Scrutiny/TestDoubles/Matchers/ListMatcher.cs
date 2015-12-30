#region Using

using System.Collections;
using System.IO;

#endregion

namespace NMock.Matchers
{
	/// <summary>
	/// Used by NMock framework to make sure two lists are equal.
	/// </summary>
	public class ListMatcher : Matcher
	{
		#region Constructors/Destructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="sourceList"> The list containing the expected results. </param>
		public ListMatcher(IList sourceList)
		{
			this.list = sourceList;
		}

		#endregion

		#region Fields/Constants

		private readonly IList list;

		#endregion

		#region Methods/Operators

		/// <summary>
		/// Describes this matcher.
		/// </summary>
		/// <param name="writer"> The text writer to which the description is added. </param>
		public override void DescribeTo(TextWriter writer)
		{
			writer.Write("List:");
			foreach (object o in this.list)
				writer.Write(o + " ");
		}

		/// <summary>
		/// Called by NMock to verify o corresponds to the source list.
		/// </summary>
		/// <param name="o"> List to compare against the source list for equality. </param>
		/// <returns> True: the two lists have the same number of items and their items are equal. </returns>
		public override bool Matches(object o)
		{
			if (!(o is IList))
				return false;
			IList otherList = (IList)o;

			if (this.list.Count != otherList.Count)
				return false;
			for (int i = 0; i < this.list.Count; i++)
			{
				if (!this.list[i].Equals(otherList[i]))
					return false;
			}
			return true;
		}

		#endregion
	}
}