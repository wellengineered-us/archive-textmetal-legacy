// ****************************************************************
// Copyright 2009, Charlie Poole
// This is free software licensed under the NUnit license. You may
// obtain a copy of the license at http://nunit.org
// ****************************************************************

using System;
using System.Collections;
using System.Collections.Generic;

#if CLR_2_0 || CLR_4_0

#endif

namespace NUnit.Framework.Constraints
{
	/// <summary>
	/// ComparisonAdapter class centralizes all comparisons of
	/// values in NUnit, adapting to the use of any provided
	/// IComparer, IComparer&lt;T&gt; or Comparison&lt;T&gt;
	/// </summary>
	public abstract class ComparisonAdapter
	{
		/// <summary>
		/// Gets the default ComparisonAdapter, which wraps an
		/// NUnitComparer object.
		/// </summary>
		public static ComparisonAdapter Default
		{
			get
			{
				return new DefaultComparisonAdapter();
			}
		}

		/// <summary>
		/// Returns a ComparisonAdapter that wraps an IComparer
		/// </summary>
		public static ComparisonAdapter For(IComparer comparer)
		{
			return new ComparerAdapter(comparer);
		}

#if CLR_2_0 || CLR_4_0
		/// <summary>
		/// Returns a ComparisonAdapter that wraps an IComparer&lt;T&gt;
		/// </summary>
		public static ComparisonAdapter For<T>(IComparer<T> comparer)
		{
			return new ComparerAdapter<T>(comparer);
		}

		/// <summary>
		/// Returns a ComparisonAdapter that wraps a Comparison&lt;T&gt;
		/// </summary>
		public static ComparisonAdapter For<T>(Comparison<T> comparer)
		{
			return new ComparisonAdapterForComparison<T>(comparer);
		}
#endif

		/// <summary>
		/// Compares two objects
		/// </summary>
		public abstract int Compare(object expected, object actual);

		private class DefaultComparisonAdapter : ComparerAdapter
		{
			#region Constructors/Destructors

			/// <summary>
			/// Construct a default ComparisonAdapter
			/// </summary>
			public DefaultComparisonAdapter()
				: base(NUnitComparer.Default)
			{
			}

			#endregion
		}

		private class ComparerAdapter : ComparisonAdapter
		{
			#region Constructors/Destructors

			/// <summary>
			/// Construct a ComparisonAdapter for an IComparer
			/// </summary>
			public ComparerAdapter(IComparer comparer)
			{
				this.comparer = comparer;
			}

			#endregion

			#region Fields/Constants

			private IComparer comparer;

			#endregion

			#region Methods/Operators

			/// <summary>
			/// Compares two objects
			/// </summary>
			/// <param name="expected"> </param>
			/// <param name="actual"> </param>
			/// <returns> </returns>
			public override int Compare(object expected, object actual)
			{
				return this.comparer.Compare(expected, actual);
			}

			#endregion
		}

#if CLR_2_0 || CLR_4_0
		/// <summary>
		/// ComparisonAdapter&lt;T&gt; extends ComparisonAdapter and
		/// allows use of an IComparer&lt;T&gt; or Comparison&lt;T&gt;
		/// to actually perform the comparison.
		/// </summary>
		private class ComparerAdapter<T> : ComparisonAdapter
		{
			#region Constructors/Destructors

			/// <summary>
			/// Construct a ComparisonAdapter for an IComparer&lt;T&gt;
			/// </summary>
			public ComparerAdapter(IComparer<T> comparer)
			{
				this.comparer = comparer;
			}

			#endregion

			#region Fields/Constants

			private IComparer<T> comparer;

			#endregion

			#region Methods/Operators

			/// <summary>
			/// Compare a Type T to an object
			/// </summary>
			public override int Compare(object expected, object actual)
			{
				if (!typeof(T).IsAssignableFrom(expected.GetType()))
					throw new ArgumentException("Cannot compare " + expected.ToString());

				if (!typeof(T).IsAssignableFrom(actual.GetType()))
					throw new ArgumentException("Cannot compare to " + actual.ToString());

				return this.comparer.Compare((T)expected, (T)actual);
			}

			#endregion
		}

		private class ComparisonAdapterForComparison<T> : ComparisonAdapter
		{
			#region Constructors/Destructors

			/// <summary>
			/// Construct a ComparisonAdapter for a Comparison&lt;T&gt;
			/// </summary>
			public ComparisonAdapterForComparison(Comparison<T> comparer)
			{
				this.comparison = comparer;
			}

			#endregion

			#region Fields/Constants

			private Comparison<T> comparison;

			#endregion

			#region Methods/Operators

			/// <summary>
			/// Compare a Type T to an object
			/// </summary>
			public override int Compare(object expected, object actual)
			{
				if (!typeof(T).IsAssignableFrom(expected.GetType()))
					throw new ArgumentException("Cannot compare " + expected.ToString());

				if (!typeof(T).IsAssignableFrom(actual.GetType()))
					throw new ArgumentException("Cannot compare to " + actual.ToString());

				return this.comparison.Invoke((T)expected, (T)actual);
			}

			#endregion
		}
#endif
	}
}