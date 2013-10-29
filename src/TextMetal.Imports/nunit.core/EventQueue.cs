// ****************************************************************
// Copyright 2007, Charlie Poole
// This is free software licensed under the NUnit license. You may
// obtain a copy of the license at http://nunit.org.
// ****************************************************************

using System;
using System.Collections;
using System.Globalization;
using System.Runtime.Serialization;
using System.Threading;

namespace NUnit.Core
{

	#region Individual Event Classes

	/// <summary>
	/// 	NUnit.Core.Event is the abstract base for all stored events.
	/// 	An Event is the stored representation of a call to the 
	/// 	EventListener interface and is used to record such calls
	/// 	or to queue them for forwarding on another thread or at
	/// 	a later time.
	/// </summary>
	public abstract class Event
	{
		#region Properties/Indexers/Events

		/// <summary>
		/// 	Gets a value indicating whether this event is delivered synchronously by the NUnit <see cref="EventPump" />.
		/// 	<para> If <c>true</c> , and if <see cref="EventQueue.SetWaitHandleForSynchronizedEvents" /> has been used to set a WaitHandle, <see
		/// 	 cref="EventQueue.Enqueue" /> blocks its calling thread until the <see cref="EventPump" /> thread has delivered the event and sets the WaitHandle. </para>
		/// </summary>
		public virtual bool IsSynchronous
		{
			get
			{
				return false;
			}
		}

		#endregion

		#region Methods/Operators

		protected static Exception WrapUnserializableException(Exception ex)
		{
			string message = string.Format(
				CultureInfo.InvariantCulture,
				"(failed to serialize original Exception - original Exception follows){0}{1}",
				Environment.NewLine,
				ex);
			return new Exception(message);
		}

		public abstract void Send(EventListener listener);

		#endregion
	}

	public class RunStartedEvent : Event
	{
		#region Constructors/Destructors

		public RunStartedEvent(string name, int testCount)
		{
			this.name = name;
			this.testCount = testCount;
		}

		#endregion

		#region Fields/Constants

		private string name;
		private int testCount;

		#endregion

		#region Properties/Indexers/Events

		public override bool IsSynchronous
		{
			get
			{
				return true;
			}
		}

		#endregion

		#region Methods/Operators

		public override void Send(EventListener listener)
		{
			listener.RunStarted(this.name, this.testCount);
		}

		#endregion
	}

	public class RunFinishedEvent : Event
	{
		#region Constructors/Destructors

		public RunFinishedEvent(TestResult result)
		{
			this.result = result;
		}

		public RunFinishedEvent(Exception exception)
		{
			this.exception = exception;
		}

		#endregion

		#region Fields/Constants

		private Exception exception;
		private TestResult result;

		#endregion

		#region Methods/Operators

		public override void Send(EventListener listener)
		{
			if (this.exception != null)
			{
				try
				{
					listener.RunFinished(this.exception);
				}
				catch (SerializationException)
				{
					Exception wrapped = WrapUnserializableException(this.exception);
					listener.RunFinished(wrapped);
				}
			}
			else
				listener.RunFinished(this.result);
		}

		#endregion
	}

	public class TestStartedEvent : Event
	{
		#region Constructors/Destructors

		public TestStartedEvent(TestName testName)
		{
			this.testName = testName;
		}

		#endregion

		#region Fields/Constants

		private TestName testName;

		#endregion

		#region Properties/Indexers/Events

		public override bool IsSynchronous
		{
			get
			{
				return true;
			}
		}

		#endregion

		#region Methods/Operators

		public override void Send(EventListener listener)
		{
			listener.TestStarted(this.testName);
		}

		#endregion
	}

	public class TestFinishedEvent : Event
	{
		#region Constructors/Destructors

		public TestFinishedEvent(TestResult result)
		{
			this.result = result;
		}

		#endregion

		#region Fields/Constants

		private TestResult result;

		#endregion

		#region Methods/Operators

		public override void Send(EventListener listener)
		{
			listener.TestFinished(this.result);
		}

		#endregion
	}

	public class SuiteStartedEvent : Event
	{
		#region Constructors/Destructors

		public SuiteStartedEvent(TestName suiteName)
		{
			this.suiteName = suiteName;
		}

		#endregion

		#region Fields/Constants

		private TestName suiteName;

		#endregion

		#region Properties/Indexers/Events

		public override bool IsSynchronous
		{
			get
			{
				return true;
			}
		}

		#endregion

		#region Methods/Operators

		public override void Send(EventListener listener)
		{
			listener.SuiteStarted(this.suiteName);
		}

		#endregion
	}

	public class SuiteFinishedEvent : Event
	{
		#region Constructors/Destructors

		public SuiteFinishedEvent(TestResult result)
		{
			this.result = result;
		}

		#endregion

		#region Fields/Constants

		private TestResult result;

		#endregion

		#region Methods/Operators

		public override void Send(EventListener listener)
		{
			listener.SuiteFinished(this.result);
		}

		#endregion
	}

	public class UnhandledExceptionEvent : Event
	{
		#region Constructors/Destructors

		public UnhandledExceptionEvent(Exception exception)
		{
			this.exception = exception;
		}

		#endregion

		#region Fields/Constants

		private Exception exception;

		#endregion

		#region Methods/Operators

		public override void Send(EventListener listener)
		{
			try
			{
				listener.UnhandledException(this.exception);
			}
			catch (SerializationException)
			{
				Exception wrapped = WrapUnserializableException(this.exception);
				listener.UnhandledException(wrapped);
			}
		}

		#endregion
	}

	public class OutputEvent : Event
	{
		#region Constructors/Destructors

		public OutputEvent(TestOutput output)
		{
			this.output = output;
		}

		#endregion

		#region Fields/Constants

		private TestOutput output;

		#endregion

		#region Methods/Operators

		public override void Send(EventListener listener)
		{
			listener.TestOutput(this.output);
		}

		#endregion
	}

	#endregion

	/// <summary>
	/// 	Implements a queue of work items each of which
	/// 	is queued as a WaitCallback.
	/// </summary>
	public class EventQueue
	{
		#region Constructors/Destructors

		public EventQueue()
		{
			this.syncRoot = this.queue.SyncRoot;
		}

		#endregion

		#region Fields/Constants

		private readonly Queue queue = new Queue();
		private readonly object syncRoot;
		private bool stopped;

		/// <summary>
		/// 	WaitHandle for synchronous event delivery in <see cref="Enqueue" />.
		/// 	<para> Having just one handle for the whole <see cref="EventQueue" /> implies that there may be only one producer (the test thread) for synchronous events. If there can be multiple producers for synchronous events, one would have to introduce one WaitHandle per event. </para>
		/// </summary>
		private AutoResetEvent synchronousEventSent;

		#endregion

		#region Properties/Indexers/Events

		public int Count
		{
			get
			{
				lock (this.syncRoot)
				{
					return this.queue.Count;
				}
			}
		}

		#endregion

		#region Methods/Operators

		/// <summary>
		/// 	Removes the first element from the queue and returns it (or <c>null</c>).
		/// </summary>
		/// <param name="blockWhenEmpty"> If <c>true</c> and the queue is empty, the calling thread is blocked until either an element is enqueued, or <see
		/// 	 cref="Stop" /> is called. </param>
		/// <returns> <list type="bullet">
		/// 	          <item>
		/// 		          <term>If the queue not empty</term>
		/// 		          <description>the first element.</description>
		/// 	          </item>
		/// 	          <item>
		/// 		          <term>otherwise, if
		/// 			          <paramref name="blockWhenEmpty" />
		/// 			          ==
		/// 			          <c>false</c>
		/// 			          or
		/// 			          <see cref="Stop" />
		/// 			          has been called</term>
		/// 		          <description>
		/// 			          <c>null</c>
		/// 			          .</description>
		/// 	          </item>
		///           </list> </returns>
		public Event Dequeue(bool blockWhenEmpty)
		{
			lock (this.syncRoot)
			{
				while (this.queue.Count == 0)
				{
					if (blockWhenEmpty && !this.stopped)
						Monitor.Wait(this.syncRoot);
					else
						return null;
				}

				return (Event)this.queue.Dequeue();
			}
		}

		public void Enqueue(Event e)
		{
			lock (this.syncRoot)
			{
				this.queue.Enqueue(e);
				Monitor.Pulse(this.syncRoot);
			}

			if (this.synchronousEventSent != null && e.IsSynchronous)
				this.synchronousEventSent.WaitOne();
			else
				Thread.Sleep(0); // give EventPump thread a chance to process the event
		}

		/// <summary>
		/// 	Sets a handle on which to wait, when <see cref="Enqueue" /> is called
		/// 	for an <see cref="Event" /> with <see cref="Event.IsSynchronous" /> == true.
		/// </summary>
		/// <param name="synchronousEventWaitHandle"> The wait handle on which to wait, when <see cref="Enqueue" /> is called for an <see
		/// 	 cref="Event" /> with <see cref="Event.IsSynchronous" /> == true.
		/// 	<para> The caller is responsible for disposing this wait handle. </para>
		/// </param>
		public void SetWaitHandleForSynchronizedEvents(AutoResetEvent synchronousEventWaitHandle)
		{
			this.synchronousEventSent = synchronousEventWaitHandle;
		}

		public void Stop()
		{
			lock (this.syncRoot)
			{
				if (!this.stopped)
				{
					this.stopped = true;
					Monitor.Pulse(this.syncRoot);
				}
			}
		}

		#endregion
	}
}