#region Using

using System;
using System.IO;
using System.Reflection;

using NMock.Monitoring;

#endregion

namespace NMock.Actions
{
	/// <summary>
	/// Action that sets the parameter of the invocation with the specified name to the specified value.
	/// </summary>
	public class SetNamedParameterAction : IAction
	{
		#region Constructors/Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="SetNamedParameterAction" /> class.
		/// </summary>
		/// <param name="name"> The name of the parameter to set. </param>
		/// <param name="value"> The value. </param>
		public SetNamedParameterAction(string name, object value)
		{
			this.name = name;
			this.value = value;
		}

		#endregion

		#region Fields/Constants

		/// <summary>
		/// Stores the name of the parameter when the class gets initialized.
		/// </summary>
		private readonly string name;

		/// <summary>
		/// Stores the value of the parameter when the class gets initialized.
		/// </summary>
		private readonly object value;

		#endregion

		#region Methods/Operators

		/// <summary>
		/// Describes this object.
		/// </summary>
		/// <param name="writer"> The text writer the description is added to. </param>
		void ISelfDescribing.DescribeTo(TextWriter writer)
		{
			writer.Write("set ");
			writer.Write(this.name);
			writer.Write("=");
			writer.Write(this.value);
		}

		/// <summary>
		/// Invokes this object. Sets the value of the parameter with the specified name of the invocation.
		/// </summary>
		/// <param name="invocation"> The invocation. </param>
		void IAction.Invoke(Invocation invocation)
		{
			ParameterInfo[] paramsInfo = invocation.MethodParameters;

			for (int i = 0; i < paramsInfo.Length; i++)
			{
				if (paramsInfo[i].Name == this.name)
				{
					invocation.Parameters[i] = this.value;
					return;
				}
			}

			throw new ArgumentException("no such parameter", this.name);
		}

		#endregion
	}
}