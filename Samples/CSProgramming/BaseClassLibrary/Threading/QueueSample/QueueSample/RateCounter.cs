// This software may be used for any purpose. 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
// FITNESS FOR A PARTICULAR PURPOSE.
// Garry Barclay. Codescent BV. 25 Jan 2006 http://www.codescent.com
using System;
using System.Threading;

namespace QueueSample
{
	/// <summary>Class to show request rates</summary>
	public class RateCounter
	{
		private int counter = 0; 
		private Timer timer; 
		private int lastCount = 0;
		private DateTime lastTime = DateTime.Now;

		/// <summary>Constructor</summary>
		/// <param name="ts">Period at which to show rate count</param>
		public RateCounter(TimeSpan ts)
		{
			timer = new Timer(new TimerCallback(ShowRate), null, ts, ts);
		}

		/// <summary>Increment the counter</summary>
		public void Increment()
		{
			Interlocked.Increment(ref counter);
		}

		// Show the rate
		private void ShowRate(object o)
		{
			int thisCount = counter;
			DateTime now = DateTime.Now;

			TimeSpan interval = now - lastTime;
			double rate = (double) (thisCount - lastCount) / interval.TotalSeconds;

			lastCount = thisCount; 
			lastTime = now;

			Console.WriteLine("Rate = {0:F2} per second", rate);
		}
	}
}
