// This software may be used for any purpose. 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
// FITNESS FOR A PARTICULAR PURPOSE.
// Garry Barclay. Codescent BV. 25 Jan 2006 http://www.codescent.com
using System;
using System.Collections;
using System.Threading;

namespace QueueSample
{
	/// <summary>
	/// Represents a queue of work items in memory with support for
	/// dequeueing by a number of threads with blocking.
	/// </summary>
	public class BlockingQueue : Queue
	{
		/// <summary>The <see cref="AutoResetEvent"/> signaled when an item is available</summary>
		protected AutoResetEvent availableEvent = new AutoResetEvent(false);

		/// <summary>The capacitiy of this <see cref="BlockingQueue"/></summary>
		protected int capacity = 32;
		/// <summary>The growth factor of this <see cref="BlockingQueue"/></summary>
		protected float growth = 2; 

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the BlockingQueue class that is empty,
		/// has the default initial capacity (32) and uses the default growth factor (2).
		/// </summary>
		public BlockingQueue() : base() {}
		/// <summary>
		/// Initializes a new instance of the BlockingQueue class that contains elements copied from the
		/// specified collection, has the same initial capacity as the number of elements copied and uses
		/// the default growth factor.
		/// </summary>
		/// <param name="col">Collections containing initial items</param>
		public BlockingQueue(ICollection col) : base(col) {}
		/// <summary>
		/// Initializes a new instance of the Queue class that is empty, has the
		/// specified initial capacity and uses the default growth factor.
		/// </summary>
		/// <param name="capacity">The initial number of elements that the Queue can contain.</param>
		public BlockingQueue(int capacity) : base(capacity) 
		{
			this.capacity = capacity; 
		}
		/// <summary>
		/// Initializes a new instance of the Queue class that is empty, has the specified initial
		/// capacity and uses the specified growth factor.
		/// </summary>
		/// <param name="capacity">The initial number of elements that the Queue can contain.</param>
		/// <param name="growFactor">The factor by which the capacity of the BlockingQueue is expanded.</param>
		public BlockingQueue(int capacity, float growFactor) : base(capacity, growFactor) 
		{
			this.capacity = capacity;
			this.growth = growFactor;
		}
		#endregion

		#region Trivial Overrides
		/// <summary>Gets a value indicating whether this instance is synchronized.</summary>
		public override bool IsSynchronized
		{
			get { return true; }
		}

		/// <summary>Clears the queue of all entries.</summary>
		public override void Clear()
		{
			while (base.Count > 0)
				Dequeue(); 
		}
	
		/// <summary>Clones this instance.</summary>
		/// <returns>Cloned <see cref="BlockingQueue"/></returns>
		public override object Clone()
		{
			lock (SyncRoot)
			{
				BlockingQueue newQ = new BlockingQueue(capacity, growth);
				object[] elements = this.ToArray();
				foreach (object o in elements)
					newQ.Enqueue(o);
				return newQ;
			}
		}

		/// <summary>Returns whether this <see cref="BlockingQueue"/> contains the specified object.</summary>
		public override bool Contains(object o)
		{
			lock (SyncRoot)
				return base.Contains(o);
		}

		/// <summary>
		/// Copies the BlockingQueue elements to an existing one-dimensional 
		/// Array, starting at the specified array index.
		/// </summary>
		/// <param name="array">Target array</param>
		/// <param name="index">The index in array at which copying begins.</param>
		public override void CopyTo(Array array, int index)
		{
			lock (SyncRoot)
				base.CopyTo(array, index);
		}

		/// <summary>Gets an enumerator over all items in the queue</summary>
		/// <returns>Enumerator</returns>
		public override IEnumerator GetEnumerator()
		{
			lock (SyncRoot)
				return base.GetEnumerator();
		}

		/// <summary>Takes a peek at the first item in the queue.</summary>
		/// <returns>First item in queue</returns>
		/// <remarks>Note that this won't work as expected unless only one reader thread is defined</remarks>
		public override object Peek()
		{
			lock (SyncRoot)
				return base.Peek();
		}

		/// <summary>Create an array containing all items in the queue</summary>
		/// <returns>An array of all items in queue</returns>
		public override object[] ToArray()
		{
			lock (SyncRoot)
				return base.ToArray();
		}
		#endregion

		/// <summary>Enqueues the specified object.</summary>
		/// <param name="o">object to enqueue</param>
		public override void Enqueue(object o)
		{
			lock (SyncRoot)
			{
				base.Enqueue(o);
				if (base.Count == 1)
					availableEvent.Set();
			}
		}

		/// <summary>Dequeues an item from the queue, blocks until an item is available.</summary>
		/// <returns>The dequeued object</returns>
		public override object Dequeue()
		{
			object result = null;

			// wait until an object is available in the queue
			availableEvent.WaitOne(); 

			// acquire the lock
			lock(SyncRoot)
			{
				// get the object 
				result = base.Dequeue();

				// if there are requests remaining, wake up another thread
				if (base.Count > 0)
					availableEvent.Set();
			}

			return result;
		}
	}
}
