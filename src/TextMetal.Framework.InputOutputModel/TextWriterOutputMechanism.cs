﻿/*
	Copyright ©2002-2014 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.IO;

using TextMetal.Common.Core;
using TextMetal.Common.Core.Cerealization;
using TextMetal.Common.Xml;

namespace TextMetal.Framework.InputOutputModel
{
	public class TextWriterOutputMechanism : OutputMechanism
	{
		#region Constructors/Destructors

		/// <summary>
		/// Initializes a new instance of the TextWriterOutputMechanism class.
		/// </summary>
		public TextWriterOutputMechanism(TextWriter textWriter, IXmlPersistEngine xpe)
		{
			if ((object)textWriter == null)
				throw new ArgumentNullException("textWriter");

			if ((object)xpe == null)
				throw new ArgumentNullException("xpe");

			base.TextWriters.Push(textWriter);
			this.xpe = xpe;
		}

		#endregion

		#region Fields/Constants

		private readonly IXmlPersistEngine xpe;

		#endregion

		#region Properties/Indexers/Events

		private IXmlPersistEngine Xpe
		{
			get
			{
				return this.xpe;
			}
		}

		#endregion

		#region Methods/Operators

		protected override void CoreEnter(string scopeName, bool appendMode)
		{
		}

		protected override void CoreLeave(string scopeName)
		{
		}

		protected override void CoreWriteObject(object obj, string objectName)
		{
			IXmlObject xmlObject;
			ITextSerializationStrategy serializationStrategy;

			if ((object)obj == null)
				throw new ArgumentNullException("obj");

			xmlObject = obj as IXmlObject;

			// this should support XPE, XML, JSON
			if ((object)xmlObject != null)
				serializationStrategy = new XpeSerializationStrategy(this.Xpe);
			else if ((object)Reflexion.Instance.GetOneAttribute<SerializableAttribute>(obj.GetType()) != null)
				serializationStrategy = new XmlSerializationStrategy();
			else
				serializationStrategy = new JsonSerializationStrategy();

			serializationStrategy.SetObjectToWriter(this.CurrentTextWriter, obj);
		}

		#endregion
	}
}