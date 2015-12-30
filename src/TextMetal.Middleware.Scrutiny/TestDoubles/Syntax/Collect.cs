#region Using

using NMock.Actions;

#endregion

namespace NMock
{
	/// <summary>
	/// Gather information about invocations.
	/// </summary>
	public class Collect
	{
		#region Methods/Operators

		/// <summary>
		/// Calls the specified <paramref name="collectDelegate" /> with the method argument at index <paramref name="argumentIndex" />.
		/// Can only be used as action of an expectation on a method call.
		/// </summary>
		/// <typeparam name="TArgument"> The type of the argument. </typeparam>
		/// <param name="argumentIndex"> Index of the argument. </param>
		/// <param name="collectDelegate"> The collect delegate. </param>
		/// <returns> Action that collects a method argument. </returns>
		public static IAction MethodArgument<TArgument>(int argumentIndex, CollectAction<TArgument>.Collect collectDelegate)
		{
			return new CollectAction<TArgument>(argumentIndex, collectDelegate);
		}

		/// <summary>
		/// Calls the specified <paramref name="collectDelegate" /> with the value that is set to the property.
		/// Can only be used as action of an expectation on a property setter.
		/// </summary>
		/// <typeparam name="TValue"> The type of the value. </typeparam>
		/// <param name="collectDelegate"> The collect delegate. </param>
		/// <returns> Action that collects a property value. </returns>
		public static IAction PropertyValue<TValue>(CollectAction<TValue>.Collect collectDelegate)
		{
			return new CollectAction<TValue>(0, collectDelegate);
		}

		#endregion
	}
}