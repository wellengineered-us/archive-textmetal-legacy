#region Using

using System;
using System.IO;

using NMock.Monitoring;

#endregion

namespace NMock.Actions
{
	/// <summary>
	/// Action that sets the result value on an invocation. The value is aquired by calling the delegate specified in the constructor.
	/// </summary>
	public class LazyReturnAction : IAction
	{
		#region Constructors/Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="LazyReturnAction" /> class.
		/// </summary>
		/// <param name="evaluate"> The delegate used to aquire the return value. </param>
		public LazyReturnAction(Evaluate evaluate)
		{
			this.evaluate = evaluate;
		}

		#endregion

		#region Fields/Constants

		/// <summary>
		/// Stores the evaluate delegate for this action.
		/// </summary>
		private readonly Evaluate evaluate;

		#endregion

		#region Methods/Operators

		/// <summary>
		/// Describes this object.
		/// </summary>
		/// <param name="writer"> The text writer the description is added to. </param>
		void ISelfDescribing.DescribeTo(TextWriter writer)
		{
			if (writer == null)
				throw new ArgumentNullException("writer");

			writer.Write("lazy return value");
		}

		/// <summary>
		/// Invokes this object.
		/// </summary>
		/// <param name="invocation"> The invocation. </param>
		void IAction.Invoke(Invocation invocation)
		{
			if (invocation == null)
				throw new ArgumentNullException("invocation");

			invocation.Result = this.evaluate();
		}

		#endregion

		#region Classes/Structs/Interfaces/Enums/Delegates

		/// <summary>
		/// Delegate that is used to get the return value.
		/// </summary>
		/// <returns>
		/// Returns an object...
		/// </returns>
		public delegate object Evaluate();

		#endregion
	}
}