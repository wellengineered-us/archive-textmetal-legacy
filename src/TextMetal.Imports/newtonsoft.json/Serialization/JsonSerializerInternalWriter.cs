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
#if !(NET35 || NET20 || PORTABLE40)
using System.Dynamic;
#endif
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Utilities;
#if NET20
using Newtonsoft.Json.Utilities.LinqBridge;
#else
using System.Linq;

#endif

namespace Newtonsoft.Json.Serialization
{
	internal class JsonSerializerInternalWriter : JsonSerializerInternalBase
	{
		private JsonContract _rootContract;
		private readonly List<object> _serializeStack = new List<object>();
		private JsonSerializerProxy _internalSerializer;

		public JsonSerializerInternalWriter(JsonSerializer serializer)
			: base(serializer)
		{
		}

		public void Serialize(JsonWriter jsonWriter, object value, Type objectType)
		{
			if (jsonWriter == null)
				throw new ArgumentNullException("jsonWriter");

			if (objectType != null)
				this._rootContract = this.Serializer._contractResolver.ResolveContract(objectType);

			this.SerializeValue(jsonWriter, value, this.GetContractSafe(value), null, null, null);
		}

		private JsonSerializerProxy GetInternalSerializer()
		{
			if (this._internalSerializer == null)
				this._internalSerializer = new JsonSerializerProxy(this);

			return this._internalSerializer;
		}

		private JsonContract GetContractSafe(object value)
		{
			if (value == null)
				return null;

			return this.Serializer._contractResolver.ResolveContract(value.GetType());
		}

		private void SerializePrimitive(JsonWriter writer, object value, JsonPrimitiveContract contract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerProperty)
		{
			if (contract.TypeCode == PrimitiveTypeCode.Bytes)
			{
				// if type name handling is enabled then wrap the base64 byte string in an object with the type name
				bool includeTypeDetails = this.ShouldWriteType(TypeNameHandling.Objects, contract, member, containerContract, containerProperty);
				if (includeTypeDetails)
				{
					writer.WriteStartObject();
					this.WriteTypeProperty(writer, contract.CreatedType);
					writer.WritePropertyName(JsonTypeReflector.ValuePropertyName, false);

					JsonWriter.WriteValue(writer, contract.TypeCode, value);

					writer.WriteEndObject();
					return;
				}
			}

			JsonWriter.WriteValue(writer, contract.TypeCode, value);
		}

		private void SerializeValue(JsonWriter writer, object value, JsonContract valueContract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerProperty)
		{
			if (value == null)
			{
				writer.WriteNull();
				return;
			}

			JsonConverter converter;
			if ((((converter = (member != null) ? member.Converter : null) != null)
				|| ((converter = (containerProperty != null) ? containerProperty.ItemConverter : null) != null)
				|| ((converter = (containerContract != null) ? containerContract.ItemConverter : null) != null)
				|| ((converter = valueContract.Converter) != null)
				|| ((converter = this.Serializer.GetMatchingConverter(valueContract.UnderlyingType)) != null)
				|| ((converter = valueContract.InternalConverter) != null))
				&& converter.CanWrite)
			{
				this.SerializeConvertable(writer, converter, value, valueContract, containerContract, containerProperty);
				return;
			}

			switch (valueContract.ContractType)
			{
				case JsonContractType.Object:
					this.SerializeObject(writer, value, (JsonObjectContract)valueContract, member, containerContract, containerProperty);
					break;
				case JsonContractType.Array:
					JsonArrayContract arrayContract = (JsonArrayContract)valueContract;
					if (!arrayContract.IsMultidimensionalArray)
						this.SerializeList(writer, (IEnumerable)value, arrayContract, member, containerContract, containerProperty);
					else
						SerializeMultidimensionalArray(writer, (Array)value, arrayContract, member, containerContract, containerProperty);
					break;
				case JsonContractType.Primitive:
					this.SerializePrimitive(writer, value, (JsonPrimitiveContract)valueContract, member, containerContract, containerProperty);
					break;
				case JsonContractType.String:
					this.SerializeString(writer, value, (JsonStringContract)valueContract);
					break;
				case JsonContractType.Dictionary:
					JsonDictionaryContract dictionaryContract = (JsonDictionaryContract)valueContract;
					this.SerializeDictionary(writer, (value is IDictionary) ? (IDictionary)value : dictionaryContract.CreateWrapper(value), dictionaryContract, member, containerContract, containerProperty);
					break;
#if !(NET35 || NET20 || PORTABLE40)
        case JsonContractType.Dynamic:
          SerializeDynamic(writer, (IDynamicMetaObjectProvider)value, (JsonDynamicContract)valueContract, member, containerContract, containerProperty);
          break;
#endif
#if !(SILVERLIGHT || NETFX_CORE || PORTABLE40 || PORTABLE)
        case JsonContractType.Serializable:
          SerializeISerializable(writer, (ISerializable)value, (JsonISerializableContract)valueContract, member, containerContract, containerProperty);
          break;
#endif
				case JsonContractType.Linq:
					((JToken)value).WriteTo(writer, this.Serializer.Converters.ToArray());
					break;
			}
		}

		private bool? ResolveIsReference(JsonContract contract, JsonProperty property, JsonContainerContract collectionContract, JsonProperty containerProperty)
		{
			bool? isReference = null;

			// value could be coming from a dictionary or array and not have a property
			if (property != null)
				isReference = property.IsReference;

			if (isReference == null && containerProperty != null)
				isReference = containerProperty.ItemIsReference;

			if (isReference == null && collectionContract != null)
				isReference = collectionContract.ItemIsReference;

			if (isReference == null)
				isReference = contract.IsReference;

			return isReference;
		}

		private bool ShouldWriteReference(object value, JsonProperty property, JsonContract valueContract, JsonContainerContract collectionContract, JsonProperty containerProperty)
		{
			if (value == null)
				return false;
			if (valueContract.ContractType == JsonContractType.Primitive || valueContract.ContractType == JsonContractType.String)
				return false;

			bool? isReference = this.ResolveIsReference(valueContract, property, collectionContract, containerProperty);

			if (isReference == null)
			{
				if (valueContract.ContractType == JsonContractType.Array)
					isReference = this.HasFlag(this.Serializer._preserveReferencesHandling, PreserveReferencesHandling.Arrays);
				else
					isReference = this.HasFlag(this.Serializer._preserveReferencesHandling, PreserveReferencesHandling.Objects);
			}

			if (!isReference.Value)
				return false;

			return this.Serializer.GetReferenceResolver().IsReferenced(this, value);
		}

		private bool ShouldWriteProperty(object memberValue, JsonProperty property)
		{
			if (property.NullValueHandling.GetValueOrDefault(this.Serializer._nullValueHandling) == NullValueHandling.Ignore &&
				memberValue == null)
				return false;

			if (this.HasFlag(property.DefaultValueHandling.GetValueOrDefault(this.Serializer._defaultValueHandling), DefaultValueHandling.Ignore)
				&& MiscellaneousUtils.ValueEquals(memberValue, property.GetResolvedDefaultValue()))
				return false;

			return true;
		}

		private bool CheckForCircularReference(JsonWriter writer, object value, JsonProperty property, JsonContract contract, JsonContainerContract containerContract, JsonProperty containerProperty)
		{
			if (value == null || contract.ContractType == JsonContractType.Primitive || contract.ContractType == JsonContractType.String)
				return true;

			ReferenceLoopHandling? referenceLoopHandling = null;

			if (property != null)
				referenceLoopHandling = property.ReferenceLoopHandling;

			if (referenceLoopHandling == null && containerProperty != null)
				referenceLoopHandling = containerProperty.ItemReferenceLoopHandling;

			if (referenceLoopHandling == null && containerContract != null)
				referenceLoopHandling = containerContract.ItemReferenceLoopHandling;

			if (this._serializeStack.IndexOf(value) != -1)
			{
				string message = "Self referencing loop detected";
				if (property != null)
					message += " for property '{0}'".FormatWith(CultureInfo.InvariantCulture, property.PropertyName);
				message += " with type '{0}'.".FormatWith(CultureInfo.InvariantCulture, value.GetType());

				switch (referenceLoopHandling.GetValueOrDefault(this.Serializer._referenceLoopHandling))
				{
					case ReferenceLoopHandling.Error:
						throw JsonSerializationException.Create(null, writer.ContainerPath, message, null);
					case ReferenceLoopHandling.Ignore:
						if (this.TraceWriter != null && this.TraceWriter.LevelFilter >= TraceLevel.Verbose)
							this.TraceWriter.Trace(TraceLevel.Verbose, JsonPosition.FormatMessage(null, writer.Path, message + ". Skipping serializing self referenced value."), null);

						return false;
					case ReferenceLoopHandling.Serialize:
						if (this.TraceWriter != null && this.TraceWriter.LevelFilter >= TraceLevel.Verbose)
							this.TraceWriter.Trace(TraceLevel.Verbose, JsonPosition.FormatMessage(null, writer.Path, message + ". Serializing self referenced value."), null);

						return true;
				}
			}

			return true;
		}

		private void WriteReference(JsonWriter writer, object value)
		{
			string reference = this.GetReference(writer, value);

			if (this.TraceWriter != null && this.TraceWriter.LevelFilter >= TraceLevel.Info)
				this.TraceWriter.Trace(TraceLevel.Info, JsonPosition.FormatMessage(null, writer.Path, "Writing object reference to Id '{0}' for {1}.".FormatWith(CultureInfo.InvariantCulture, reference, value.GetType())), null);

			writer.WriteStartObject();
			writer.WritePropertyName(JsonTypeReflector.RefPropertyName, false);
			writer.WriteValue(reference);
			writer.WriteEndObject();
		}

		private string GetReference(JsonWriter writer, object value)
		{
			try
			{
				string reference = this.Serializer.GetReferenceResolver().GetReference(this, value);

				return reference;
			}
			catch (Exception ex)
			{
				throw JsonSerializationException.Create(null, writer.ContainerPath, "Error writing object reference for '{0}'.".FormatWith(CultureInfo.InvariantCulture, value.GetType()), ex);
			}
		}

		internal static bool TryConvertToString(object value, Type type, out string s)
		{
#if !(NETFX_CORE || PORTABLE40 || PORTABLE)
      TypeConverter converter = ConvertUtils.GetConverter(type);

      // use the objectType's TypeConverter if it has one and can convert to a string
      if (converter != null
#if !SILVERLIGHT
 && !(converter is ComponentConverter)
#endif
 && converter.GetType() != typeof(TypeConverter))
      {
        if (converter.CanConvertTo(typeof(string)))
        {
#if !SILVERLIGHT
          s = converter.ConvertToInvariantString(value);
#else
          s = converter.ConvertToString(value);
#endif
          
          return true;
        }
      }
#endif

#if SILVERLIGHT || NETFX_CORE || PORTABLE
      if (value is Guid || value is Uri || value is TimeSpan)
      {
        s = value.ToString();
        return true;
      }
#endif

			if (value is Type)
			{
				s = ((Type)value).AssemblyQualifiedName;
				return true;
			}

			s = null;
			return false;
		}

		private void SerializeString(JsonWriter writer, object value, JsonStringContract contract)
		{
			this.OnSerializing(writer, contract, value);

			string s;
			TryConvertToString(value, contract.UnderlyingType, out s);
			writer.WriteValue(s);

			this.OnSerialized(writer, contract, value);
		}

		private void OnSerializing(JsonWriter writer, JsonContract contract, object value)
		{
			if (this.TraceWriter != null && this.TraceWriter.LevelFilter >= TraceLevel.Info)
				this.TraceWriter.Trace(TraceLevel.Info, JsonPosition.FormatMessage(null, writer.Path, "Started serializing {0}".FormatWith(CultureInfo.InvariantCulture, contract.UnderlyingType)), null);

			contract.InvokeOnSerializing(value, this.Serializer._context);
		}

		private void OnSerialized(JsonWriter writer, JsonContract contract, object value)
		{
			if (this.TraceWriter != null && this.TraceWriter.LevelFilter >= TraceLevel.Info)
				this.TraceWriter.Trace(TraceLevel.Info, JsonPosition.FormatMessage(null, writer.Path, "Finished serializing {0}".FormatWith(CultureInfo.InvariantCulture, contract.UnderlyingType)), null);

			contract.InvokeOnSerialized(value, this.Serializer._context);
		}

		private void SerializeObject(JsonWriter writer, object value, JsonObjectContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
		{
			this.OnSerializing(writer, contract, value);

			this._serializeStack.Add(value);

			this.WriteObjectStart(writer, value, contract, member, collectionContract, containerProperty);

			int initialDepth = writer.Top;

			for (int index = 0; index < contract.Properties.Count; index++)
			{
				JsonProperty property = contract.Properties[index];
				try
				{
					object memberValue;
					JsonContract memberContract;

					if (!this.CalculatePropertyValues(writer, value, contract, member, property, out memberContract, out memberValue))
						continue;

					property.WritePropertyName(writer);
					this.SerializeValue(writer, memberValue, memberContract, property, contract, member);
				}
				catch (Exception ex)
				{
					if (this.IsErrorHandled(value, contract, property.PropertyName, null, writer.ContainerPath, ex))
						this.HandleError(writer, initialDepth);
					else
						throw;
				}
			}

			writer.WriteEndObject();

			this._serializeStack.RemoveAt(this._serializeStack.Count - 1);

			this.OnSerialized(writer, contract, value);
		}

		private bool CalculatePropertyValues(JsonWriter writer, object value, JsonContainerContract contract, JsonProperty member, JsonProperty property, out JsonContract memberContract, out object memberValue)
		{
			if (!property.Ignored && property.Readable && this.ShouldSerialize(writer, property, value) && this.IsSpecified(writer, property, value))
			{
				if (property.PropertyContract == null)
					property.PropertyContract = this.Serializer._contractResolver.ResolveContract(property.PropertyType);

				memberValue = property.ValueProvider.GetValue(value);
				memberContract = (property.PropertyContract.IsSealed) ? property.PropertyContract : this.GetContractSafe(memberValue);

				if (this.ShouldWriteProperty(memberValue, property))
				{
					if (this.ShouldWriteReference(memberValue, property, memberContract, contract, member))
					{
						property.WritePropertyName(writer);
						this.WriteReference(writer, memberValue);
						return false;
					}

					if (!this.CheckForCircularReference(writer, memberValue, property, memberContract, contract, member))
						return false;

					if (memberValue == null)
					{
						JsonObjectContract objectContract = contract as JsonObjectContract;
						Required resolvedRequired = property._required ?? ((objectContract != null) ? objectContract.ItemRequired : null) ?? Required.Default;
						if (resolvedRequired == Required.Always)
							throw JsonSerializationException.Create(null, writer.ContainerPath, "Cannot write a null value for property '{0}'. Property requires a value.".FormatWith(CultureInfo.InvariantCulture, property.PropertyName), null);
					}

					return true;
				}
			}

			memberContract = null;
			memberValue = null;
			return false;
		}

		private void WriteObjectStart(JsonWriter writer, object value, JsonContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
		{
			writer.WriteStartObject();

			bool isReference = this.ResolveIsReference(contract, member, collectionContract, containerProperty) ?? this.HasFlag(this.Serializer._preserveReferencesHandling, PreserveReferencesHandling.Objects);
			if (isReference)
				this.WriteReferenceIdProperty(writer, contract.UnderlyingType, value);
			if (this.ShouldWriteType(TypeNameHandling.Objects, contract, member, collectionContract, containerProperty))
				this.WriteTypeProperty(writer, contract.UnderlyingType);
		}

		private void WriteReferenceIdProperty(JsonWriter writer, Type type, object value)
		{
			string reference = this.GetReference(writer, value);

			if (this.TraceWriter != null && this.TraceWriter.LevelFilter >= TraceLevel.Verbose)
				this.TraceWriter.Trace(TraceLevel.Verbose, JsonPosition.FormatMessage(null, writer.Path, "Writing object reference Id '{0}' for {1}.".FormatWith(CultureInfo.InvariantCulture, reference, type)), null);

			writer.WritePropertyName(JsonTypeReflector.IdPropertyName, false);
			writer.WriteValue(reference);
		}

		private void WriteTypeProperty(JsonWriter writer, Type type)
		{
			string typeName = ReflectionUtils.GetTypeName(type, this.Serializer._typeNameAssemblyFormat, this.Serializer._binder);

			if (this.TraceWriter != null && this.TraceWriter.LevelFilter >= TraceLevel.Verbose)
				this.TraceWriter.Trace(TraceLevel.Verbose, JsonPosition.FormatMessage(null, writer.Path, "Writing type name '{0}' for {1}.".FormatWith(CultureInfo.InvariantCulture, typeName, type)), null);

			writer.WritePropertyName(JsonTypeReflector.TypePropertyName, false);
			writer.WriteValue(typeName);
		}

		private bool HasFlag(DefaultValueHandling value, DefaultValueHandling flag)
		{
			return ((value & flag) == flag);
		}

		private bool HasFlag(PreserveReferencesHandling value, PreserveReferencesHandling flag)
		{
			return ((value & flag) == flag);
		}

		private bool HasFlag(TypeNameHandling value, TypeNameHandling flag)
		{
			return ((value & flag) == flag);
		}

		private void SerializeConvertable(JsonWriter writer, JsonConverter converter, object value, JsonContract contract, JsonContainerContract collectionContract, JsonProperty containerProperty)
		{
			if (this.ShouldWriteReference(value, null, contract, collectionContract, containerProperty))
				this.WriteReference(writer, value);
			else
			{
				if (!this.CheckForCircularReference(writer, value, null, contract, collectionContract, containerProperty))
					return;

				this._serializeStack.Add(value);

				if (this.TraceWriter != null && this.TraceWriter.LevelFilter >= TraceLevel.Info)
					this.TraceWriter.Trace(TraceLevel.Info, JsonPosition.FormatMessage(null, writer.Path, "Started serializing {0} with converter {1}.".FormatWith(CultureInfo.InvariantCulture, value.GetType(), converter.GetType())), null);

				converter.WriteJson(writer, value, this.GetInternalSerializer());

				if (this.TraceWriter != null && this.TraceWriter.LevelFilter >= TraceLevel.Info)
					this.TraceWriter.Trace(TraceLevel.Info, JsonPosition.FormatMessage(null, writer.Path, "Finished serializing {0} with converter {1}.".FormatWith(CultureInfo.InvariantCulture, value.GetType(), converter.GetType())), null);

				this._serializeStack.RemoveAt(this._serializeStack.Count - 1);
			}
		}

		private void SerializeList(JsonWriter writer, IEnumerable values, JsonArrayContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
		{
			IWrappedCollection wrappedCollection = values as IWrappedCollection;
			object underlyingList = wrappedCollection != null ? wrappedCollection.UnderlyingCollection : values;

			this.OnSerializing(writer, contract, underlyingList);

			this._serializeStack.Add(underlyingList);

			bool hasWrittenMetadataObject = this.WriteStartArray(writer, underlyingList, contract, member, collectionContract, containerProperty);

			writer.WriteStartArray();

			int initialDepth = writer.Top;

			int index = 0;
			// note that an error in the IEnumerable won't be caught
			foreach (object value in values)
			{
				try
				{
					JsonContract valueContract = contract.FinalItemContract ?? this.GetContractSafe(value);

					if (this.ShouldWriteReference(value, null, valueContract, contract, member))
						this.WriteReference(writer, value);
					else
					{
						if (this.CheckForCircularReference(writer, value, null, valueContract, contract, member))
							this.SerializeValue(writer, value, valueContract, null, contract, member);
					}
				}
				catch (Exception ex)
				{
					if (this.IsErrorHandled(underlyingList, contract, index, null, writer.ContainerPath, ex))
						this.HandleError(writer, initialDepth);
					else
						throw;
				}
				finally
				{
					index++;
				}
			}

			writer.WriteEndArray();

			if (hasWrittenMetadataObject)
				writer.WriteEndObject();

			this._serializeStack.RemoveAt(this._serializeStack.Count - 1);

			this.OnSerialized(writer, contract, underlyingList);
		}

		private void SerializeMultidimensionalArray(JsonWriter writer, Array values, JsonArrayContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
		{
			this.OnSerializing(writer, contract, values);

			this._serializeStack.Add(values);

			bool hasWrittenMetadataObject = this.WriteStartArray(writer, values, contract, member, collectionContract, containerProperty);

			this.SerializeMultidimensionalArray(writer, values, contract, member, writer.Top, new int[0]);

			if (hasWrittenMetadataObject)
				writer.WriteEndObject();

			this._serializeStack.RemoveAt(this._serializeStack.Count - 1);

			this.OnSerialized(writer, contract, values);
		}

		private void SerializeMultidimensionalArray(JsonWriter writer, Array values, JsonArrayContract contract, JsonProperty member, int initialDepth, int[] indices)
		{
			int dimension = indices.Length;
			int[] newIndices = new int[dimension + 1];
			for (int i = 0; i < dimension; i++)
				newIndices[i] = indices[i];

			writer.WriteStartArray();

			for (int i = 0; i < values.GetLength(dimension); i++)
			{
				newIndices[dimension] = i;
				bool isTopLevel = (newIndices.Length == values.Rank);

				if (isTopLevel)
				{
					object value = values.GetValue(newIndices);

					try
					{
						JsonContract valueContract = contract.FinalItemContract ?? this.GetContractSafe(value);

						if (this.ShouldWriteReference(value, null, valueContract, contract, member))
							this.WriteReference(writer, value);
						else
						{
							if (this.CheckForCircularReference(writer, value, null, valueContract, contract, member))
								this.SerializeValue(writer, value, valueContract, null, contract, member);
						}
					}
					catch (Exception ex)
					{
						if (this.IsErrorHandled(values, contract, i, null, writer.ContainerPath, ex))
							this.HandleError(writer, initialDepth + 1);
						else
							throw;
					}
				}
				else
					this.SerializeMultidimensionalArray(writer, values, contract, member, initialDepth + 1, newIndices);
			}

			writer.WriteEndArray();
		}

		private bool WriteStartArray(JsonWriter writer, object values, JsonArrayContract contract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerProperty)
		{
			bool isReference = this.ResolveIsReference(contract, member, containerContract, containerProperty) ?? this.HasFlag(this.Serializer._preserveReferencesHandling, PreserveReferencesHandling.Arrays);
			bool includeTypeDetails = this.ShouldWriteType(TypeNameHandling.Arrays, contract, member, containerContract, containerProperty);
			bool writeMetadataObject = isReference || includeTypeDetails;

			if (writeMetadataObject)
			{
				writer.WriteStartObject();

				if (isReference)
					this.WriteReferenceIdProperty(writer, contract.UnderlyingType, values);
				if (includeTypeDetails)
					this.WriteTypeProperty(writer, values.GetType());
				writer.WritePropertyName(JsonTypeReflector.ArrayValuesPropertyName, false);
			}

			if (contract.ItemContract == null)
				contract.ItemContract = this.Serializer._contractResolver.ResolveContract(contract.CollectionItemType ?? typeof(object));

			return writeMetadataObject;
		}

#if !(SILVERLIGHT || NETFX_CORE || PORTABLE40 || PORTABLE)
#if !(NET20 || NET35)
    [SecuritySafeCritical]
#endif
    private void SerializeISerializable(JsonWriter writer, ISerializable value, JsonISerializableContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
    {
      if (!JsonTypeReflector.FullyTrusted)
      {
        throw JsonSerializationException.Create(null, writer.ContainerPath, @"Type '{0}' implements ISerializable but cannot be serialized using the ISerializable interface because the current application is not fully trusted and ISerializable can expose secure data.
To fix this error either change the environment to be fully trusted, change the application to not deserialize the type, add JsonObjectAttribute to the type or change the JsonSerializer setting ContractResolver to use a new DefaultContractResolver with IgnoreSerializableInterface set to true.".FormatWith(CultureInfo.InvariantCulture, value.GetType()), null);
      }

      OnSerializing(writer, contract, value);
      _serializeStack.Add(value);

      WriteObjectStart(writer, value, contract, member, collectionContract, containerProperty);

      SerializationInfo serializationInfo = new SerializationInfo(contract.UnderlyingType, new FormatterConverter());
      value.GetObjectData(serializationInfo, Serializer._context);

      foreach (SerializationEntry serializationEntry in serializationInfo)
      {
        JsonContract valueContract = GetContractSafe(serializationEntry.Value);

        if (CheckForCircularReference(writer, serializationEntry.Value, null, valueContract, contract, member))
        {
          writer.WritePropertyName(serializationEntry.Name);
          SerializeValue(writer, serializationEntry.Value, valueContract, null, contract, member);
        }
      }

      writer.WriteEndObject();

      _serializeStack.RemoveAt(_serializeStack.Count - 1);
      OnSerialized(writer, contract, value);
    }
#endif

#if !(NET35 || NET20 || PORTABLE40)
    private void SerializeDynamic(JsonWriter writer, IDynamicMetaObjectProvider value, JsonDynamicContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
    {
      OnSerializing(writer, contract, value);
      _serializeStack.Add(value);

      WriteObjectStart(writer, value, contract, member, collectionContract, containerProperty);

      int initialDepth = writer.Top;

      for (int index = 0; index < contract.Properties.Count; index++)
      {
        JsonProperty property = contract.Properties[index];

        // only write non-dynamic properties that have an explicit attribute
        if (property.HasMemberAttribute)
        {
          try
          {
            object memberValue;
            JsonContract memberContract;

            if (!CalculatePropertyValues(writer, value, contract, member, property, out memberContract, out memberValue))
              continue;

            property.WritePropertyName(writer);
            SerializeValue(writer, memberValue, memberContract, property, contract, member);
          }
          catch (Exception ex)
          {
            if (IsErrorHandled(value, contract, property.PropertyName, null, writer.ContainerPath, ex))
              HandleError(writer, initialDepth);
            else
              throw;
          }
        }
      }

      foreach (string memberName in value.GetDynamicMemberNames())
      {
        object memberValue;
        if (contract.TryGetMember(value, memberName, out memberValue))
        {
          try
          {
            JsonContract valueContract = GetContractSafe(memberValue);

            if (!ShouldWriteDynamicProperty(memberValue))
              continue;

            if (CheckForCircularReference(writer, memberValue, null, valueContract, contract, member))
            {
              string resolvedPropertyName = (contract.PropertyNameResolver != null)
                                              ? contract.PropertyNameResolver(memberName)
                                              : memberName;

              writer.WritePropertyName(resolvedPropertyName);
              SerializeValue(writer, memberValue, valueContract, null, contract, member);
            }
          }
          catch (Exception ex)
          {
            if (IsErrorHandled(value, contract, memberName, null, writer.ContainerPath, ex))
              HandleError(writer, initialDepth);
            else
              throw;
          }
        }
      }

      writer.WriteEndObject();

      _serializeStack.RemoveAt(_serializeStack.Count - 1);
      OnSerialized(writer, contract, value);
    }
#endif

		private bool ShouldWriteDynamicProperty(object memberValue)
		{
			if (this.Serializer._nullValueHandling == NullValueHandling.Ignore && memberValue == null)
				return false;

			if (this.HasFlag(this.Serializer._defaultValueHandling, DefaultValueHandling.Ignore) &&
				(memberValue == null || MiscellaneousUtils.ValueEquals(memberValue, ReflectionUtils.GetDefaultValue(memberValue.GetType()))))
				return false;

			return true;
		}

		private bool ShouldWriteType(TypeNameHandling typeNameHandlingFlag, JsonContract contract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerProperty)
		{
			TypeNameHandling resolvedTypeNameHandling =
				((member != null) ? member.TypeNameHandling : null)
				?? ((containerProperty != null) ? containerProperty.ItemTypeNameHandling : null)
				?? ((containerContract != null) ? containerContract.ItemTypeNameHandling : null)
				?? this.Serializer._typeNameHandling;

			if (HasFlag(resolvedTypeNameHandling, typeNameHandlingFlag))
				return true;

			// instance type and the property's type's contract default type are different (no need to put the type in JSON because the type will be created by default)
			if (this.HasFlag(resolvedTypeNameHandling, TypeNameHandling.Auto))
			{
				if (member != null)
				{
					if (contract.UnderlyingType != member.PropertyContract.CreatedType)
						return true;
				}
				else if (containerContract != null)
				{
					if (containerContract.ItemContract == null || contract.UnderlyingType != containerContract.ItemContract.CreatedType)
						return true;
				}
				else if (this._rootContract != null && this._serializeStack.Count == 1)
				{
					if (contract.UnderlyingType != this._rootContract.CreatedType)
						return true;
				}
			}

			return false;
		}

		private void SerializeDictionary(JsonWriter writer, IDictionary values, JsonDictionaryContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
		{
			IWrappedDictionary wrappedDictionary = values as IWrappedDictionary;
			object underlyingDictionary = wrappedDictionary != null ? wrappedDictionary.UnderlyingDictionary : values;

			this.OnSerializing(writer, contract, underlyingDictionary);
			this._serializeStack.Add(underlyingDictionary);

			this.WriteObjectStart(writer, underlyingDictionary, contract, member, collectionContract, containerProperty);

			if (contract.ItemContract == null)
				contract.ItemContract = this.Serializer._contractResolver.ResolveContract(contract.DictionaryValueType ?? typeof(object));

			if (contract.KeyContract == null)
				contract.KeyContract = this.Serializer._contractResolver.ResolveContract(contract.DictionaryKeyType ?? typeof(object));

			int initialDepth = writer.Top;

			foreach (DictionaryEntry entry in values)
			{
				bool escape;
				string propertyName = this.GetPropertyName(writer, entry, contract.KeyContract, out escape);

				propertyName = (contract.PropertyNameResolver != null)
					? contract.PropertyNameResolver(propertyName)
					: propertyName;

				try
				{
					object value = entry.Value;
					JsonContract valueContract = contract.FinalItemContract ?? this.GetContractSafe(value);

					if (this.ShouldWriteReference(value, null, valueContract, contract, member))
					{
						writer.WritePropertyName(propertyName, escape);
						this.WriteReference(writer, value);
					}
					else
					{
						if (!this.CheckForCircularReference(writer, value, null, valueContract, contract, member))
							continue;

						writer.WritePropertyName(propertyName, escape);

						this.SerializeValue(writer, value, valueContract, null, contract, member);
					}
				}
				catch (Exception ex)
				{
					if (this.IsErrorHandled(underlyingDictionary, contract, propertyName, null, writer.ContainerPath, ex))
						this.HandleError(writer, initialDepth);
					else
						throw;
				}
			}

			writer.WriteEndObject();

			this._serializeStack.RemoveAt(this._serializeStack.Count - 1);

			this.OnSerialized(writer, contract, underlyingDictionary);
		}

		private string GetPropertyName(JsonWriter writer, DictionaryEntry entry, JsonContract contract, out bool escape)
		{
			object key = entry.Key;

			string propertyName;

			JsonPrimitiveContract primitiveContract = contract as JsonPrimitiveContract;
			if (primitiveContract != null)
			{
				if (primitiveContract.TypeCode == PrimitiveTypeCode.DateTime || primitiveContract.TypeCode == PrimitiveTypeCode.DateTimeNullable)
				{
					escape = false;
					StringWriter sw = new StringWriter(CultureInfo.InvariantCulture);
					DateTimeUtils.WriteDateTimeString(sw, (DateTime)key, writer.DateFormatHandling, writer.DateFormatString, writer.Culture);
					return sw.ToString();
				}
#if !NET20
				else if (primitiveContract.TypeCode == PrimitiveTypeCode.DateTimeOffset || primitiveContract.TypeCode == PrimitiveTypeCode.DateTimeOffsetNullable)
				{
					escape = false;
					StringWriter sw = new StringWriter(CultureInfo.InvariantCulture);
					DateTimeUtils.WriteDateTimeOffsetString(sw, (DateTimeOffset)key, writer.DateFormatHandling, writer.DateFormatString, writer.Culture);
					return sw.ToString();
				}
#endif
				else
				{
					escape = true;
					return Convert.ToString(key, CultureInfo.InvariantCulture);
				}
			}
			else if (TryConvertToString(key, key.GetType(), out propertyName))
			{
				escape = true;
				return propertyName;
			}
			else
			{
				escape = true;
				return key.ToString();
			}
		}

		private void HandleError(JsonWriter writer, int initialDepth)
		{
			this.ClearErrorContext();

			if (writer.WriteState == WriteState.Property)
				writer.WriteNull();

			while (writer.Top > initialDepth)
				writer.WriteEnd();
		}

		private bool ShouldSerialize(JsonWriter writer, JsonProperty property, object target)
		{
			if (property.ShouldSerialize == null)
				return true;

			bool shouldSerialize = property.ShouldSerialize(target);

			if (this.TraceWriter != null && this.TraceWriter.LevelFilter >= TraceLevel.Verbose)
				this.TraceWriter.Trace(TraceLevel.Verbose, JsonPosition.FormatMessage(null, writer.Path, "ShouldSerialize result for property '{0}' on {1}: {2}".FormatWith(CultureInfo.InvariantCulture, property.PropertyName, property.DeclaringType, shouldSerialize)), null);

			return shouldSerialize;
		}

		private bool IsSpecified(JsonWriter writer, JsonProperty property, object target)
		{
			if (property.GetIsSpecified == null)
				return true;

			bool isSpecified = property.GetIsSpecified(target);

			if (this.TraceWriter != null && this.TraceWriter.LevelFilter >= TraceLevel.Verbose)
				this.TraceWriter.Trace(TraceLevel.Verbose, JsonPosition.FormatMessage(null, writer.Path, "IsSpecified result for property '{0}' on {1}: {2}".FormatWith(CultureInfo.InvariantCulture, property.PropertyName, property.DeclaringType, isSpecified)), null);

			return isSpecified;
		}
	}
}