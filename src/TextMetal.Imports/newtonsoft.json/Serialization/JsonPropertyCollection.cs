#region License

// Copyright (c) 2007 James Newton-King
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

#endregion

using System;
using System.Collections.ObjectModel;
using System.Globalization;

using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Serialization
{
	/// <summary>
	/// A collection of <see cref="JsonProperty" /> objects.
	/// </summary>
	public class JsonPropertyCollection : KeyedCollection<string, JsonProperty>
	{
		#region Constructors/Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="JsonPropertyCollection" /> class.
		/// </summary>
		/// <param name="type"> The type. </param>
		public JsonPropertyCollection(Type type)
			: base(StringComparer.Ordinal)
		{
			ValidationUtils.ArgumentNotNull(type, "type");
			this._type = type;
		}

		#endregion

		#region Fields/Constants

		private readonly Type _type;

		#endregion

		#region Methods/Operators

		/// <summary>
		/// Adds a <see cref="JsonProperty" /> object.
		/// </summary>
		/// <param name="property"> The property to add to the collection. </param>
		public void AddProperty(JsonProperty property)
		{
			if (this.Contains(property.PropertyName))
			{
				// don't overwrite existing property with ignored property
				if (property.Ignored)
					return;

				JsonProperty existingProperty = this[property.PropertyName];
				bool duplicateProperty = true;

				if (existingProperty.Ignored)
				{
					// remove ignored property so it can be replaced in collection
					Remove(existingProperty);
					duplicateProperty = false;
				}
				else
				{
					if (property.DeclaringType != null && existingProperty.DeclaringType != null)
					{
						if (property.DeclaringType.IsSubclassOf(existingProperty.DeclaringType))
						{
							// current property is on a derived class and hides the existing
							Remove(existingProperty);
							duplicateProperty = false;
						}
						if (existingProperty.DeclaringType.IsSubclassOf(property.DeclaringType))
						{
							// current property is hidden by the existing so don't add it
							return;
						}
					}
				}

				if (duplicateProperty)
					throw new JsonSerializationException("A member with the name '{0}' already exists on '{1}'. Use the JsonPropertyAttribute to specify another name.".FormatWith(CultureInfo.InvariantCulture, property.PropertyName, this._type));
			}

			this.Add(property);
		}

		/// <summary>
		/// Gets the closest matching <see cref="JsonProperty" /> object.
		/// First attempts to get an exact case match of propertyName and then
		/// a case insensitive match.
		/// </summary>
		/// <param name="propertyName"> Name of the property. </param>
		/// <returns> A matching property if found. </returns>
		public JsonProperty GetClosestMatchProperty(string propertyName)
		{
			JsonProperty property = this.GetProperty(propertyName, StringComparison.Ordinal);
			if (property == null)
				property = this.GetProperty(propertyName, StringComparison.OrdinalIgnoreCase);

			return property;
		}

		/// <summary>
		/// When implemented in a derived class, extracts the key from the specified element.
		/// </summary>
		/// <param name="item"> The element from which to extract the key. </param>
		/// <returns> The key for the specified element. </returns>
		protected override string GetKeyForItem(JsonProperty item)
		{
			return item.PropertyName;
		}

		/// <summary>
		/// Gets a property by property name.
		/// </summary>
		/// <param name="propertyName"> The name of the property to get. </param>
		/// <param name="comparisonType"> Type property name string comparison. </param>
		/// <returns> A matching property if found. </returns>
		public JsonProperty GetProperty(string propertyName, StringComparison comparisonType)
		{
			// KeyedCollection has an ordinal comparer
			if (comparisonType == StringComparison.Ordinal)
			{
				JsonProperty property;
				if (this.TryGetValue(propertyName, out property))
					return property;

				return null;
			}

			foreach (JsonProperty property in this)
			{
				if (string.Equals(propertyName, property.PropertyName, comparisonType))
					return property;
			}

			return null;
		}

		private bool TryGetValue(string key, out JsonProperty item)
		{
			if (this.Dictionary == null)
			{
				item = default(JsonProperty);
				return false;
			}

			return this.Dictionary.TryGetValue(key, out item);
		}

		#endregion
	}
}