﻿/*
	Copyright ©2002-2014 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Collections;
using System.Collections.Generic;

using TextMetal.Common.Core.HierarchicalObjects;

namespace TextMetal.Common.Xml
{
	/// <summary>
	/// Serves as a covariant list adapter.
	/// </summary>
	/// <typeparam name="TToBase"> The target list super type. </typeparam>
	/// <typeparam name="TFromDerived"> The source list sub type. </typeparam>
	public class CovariantListAdapter<TToBase, TFromDerived> : IXmlObjectCollection<TToBase>
		where TFromDerived : class, IXmlObject, TToBase
		where TToBase : class, IXmlObject
	{
		#region Constructors/Destructors

		/// <summary>
		/// Initializes a new instance of the CovariantListAdapter`2 class.
		/// </summary>
		/// <param name="inner"> The inner list instance. </param>
		public CovariantListAdapter(IXmlObjectCollection<TFromDerived> inner)
		{
			this.inner = inner;
		}

		#endregion

		#region Fields/Constants

		private readonly IXmlObjectCollection<TFromDerived> inner;

		#endregion

		#region Properties/Indexers/Events

		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <returns> The element at the specified index. </returns>
		/// <param name="index"> The zero-based index of the element to get or set. </param>
		public TToBase this[int index]
		{
			get
			{
				return this.Inner[index];
			}
			set
			{
				this.Inner[index] = (TFromDerived)value;
			}
		}

		/// <summary>
		/// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1" /> .
		/// </summary>
		/// <returns>
		/// The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1" /> .
		/// </returns>
		public int Count
		{
			get
			{
				return this.Inner.Count;
			}
		}

		/// <summary>
		/// Gets the inner list from the derived type.
		/// </summary>
		public IXmlObjectCollection<TFromDerived> Inner
		{
			get
			{
				return this.inner;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
		/// </summary>
		/// <returns>
		/// true if the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only; otherwise, false.
		/// </returns>
		public bool IsReadOnly
		{
			get
			{
				return this.Inner.IsReadOnly;
			}
		}

		/// <summary>
		/// Gets the site XML object or null if this is unattached.
		/// </summary>
		public IXmlObject Site
		{
			get
			{
				return null;
			}
		}

		/// <summary>
		/// Gets the site hierarchical object or null if this is unattached.
		/// </summary>
		IHierarchicalObject IHierarchicalObjectCollection.Site
		{
			get
			{
				return null;
			}
		}

		#endregion

		#region Methods/Operators

		/// <summary>
		/// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1" /> .
		/// </summary>
		/// <param name="item">
		/// The object to add to the <see cref="T:System.Collections.Generic.ICollection`1" /> .
		/// </param>
		public void Add(TToBase item)
		{
			this.Inner.Add((TFromDerived)item);
		}

		/// <summary>
		/// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1" /> .
		/// </summary>
		public void Clear()
		{
			this.Inner.Clear();
		}

		/// <summary>
		/// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1" /> contains a specific value.
		/// </summary>
		/// <returns>
		/// true if <paramref name="item" /> is found in the <see cref="T:System.Collections.Generic.ICollection`1" /> ; otherwise, false.
		/// </returns>
		/// <param name="item">
		/// The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1" /> .
		/// </param>
		public bool Contains(TToBase item)
		{
			return this.Inner.Contains((TFromDerived)item);
		}

		/// <summary>
		/// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1" /> to an
		/// <see
		///     cref="T:System.Array" />
		/// , starting at a particular
		/// <see
		///     cref="T:System.Array" />
		/// index.
		/// </summary>
		/// <param name="array">
		/// The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from
		/// <see
		///     cref="T:System.Collections.Generic.ICollection`1" />
		/// . The <see cref="T:System.Array" /> must have zero-based indexing.
		/// </param>
		/// <param name="arrayIndex">
		/// The zero-based index in <paramref name="array" /> at which copying begins.
		/// </param>
		public void CopyTo(TToBase[] array, int arrayIndex)
		{
			this.Inner.CopyTo((TFromDerived[])(object)array, arrayIndex);
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
		/// </returns>
		public IEnumerator<TToBase> GetEnumerator()
		{
			if ((object)this.Inner != null)
			{
				foreach (TFromDerived obj in this.Inner)
					yield return obj;
			}
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)this.Inner).GetEnumerator();
		}

		/// <summary>
		/// Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1" /> .
		/// </summary>
		/// <returns>
		/// The index of <paramref name="item" /> if found in the list; otherwise, -1.
		/// </returns>
		/// <param name="item">
		/// The object to locate in the <see cref="T:System.Collections.Generic.IList`1" /> .
		/// </param>
		public int IndexOf(TToBase item)
		{
			return this.Inner.IndexOf((TFromDerived)item);
		}

		/// <summary>
		/// Inserts an item to the <see cref="T:System.Collections.Generic.IList`1" /> at the specified index.
		/// </summary>
		/// <param name="index">
		/// The zero-based index at which <paramref name="item" /> should be inserted.
		/// </param>
		/// <param name="item">
		/// The object to insert into the <see cref="T:System.Collections.Generic.IList`1" /> .
		/// </param>
		public void Insert(int index, TToBase item)
		{
			this.Inner.Insert(index, (TFromDerived)item);
		}

		/// <summary>
		/// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1" /> .
		/// </summary>
		/// <returns>
		/// true if <paramref name="item" /> was successfully removed from the
		/// <see
		///     cref="T:System.Collections.Generic.ICollection`1" />
		/// ; otherwise, false. This method also returns false if
		/// <paramref
		///     name="item" />
		/// is not found in the original <see cref="T:System.Collections.Generic.ICollection`1" /> .
		/// </returns>
		/// <param name="item">
		/// The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" /> .
		/// </param>
		public bool Remove(TToBase item)
		{
			return this.Inner.Remove((TFromDerived)item);
		}

		/// <summary>
		/// Removes the <see cref="T:System.Collections.Generic.IList`1" /> item at the specified index.
		/// </summary>
		/// <param name="index"> The zero-based index of the item to remove. </param>
		public void RemoveAt(int index)
		{
			this.Inner.RemoveAt(index);
		}

		#endregion
	}
}