// This software may be used for any purpose. 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
// FITNESS FOR A PARTICULAR PURPOSE.
// Garry Barclay. Codescent BV. 25 Jan 2006 http://www.codescent.com
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace QueueSample
{
	/// <summary>Simple client to simulate a number of requesters and a given load</summary>
	public class Client
	{
		private static Random rand = new Random();
		private Thread[] threads; 
		private int threadWait;
		private DateTime end; 

		/// <summary>Prepare the client</summary>
		/// <param name="threadCount">Number of requesters to simulate</param>
		/// <param name="targetRate">Overall target rate to attempt</param>
		/// <param name="duration">Duration of test</param>
		/// <param name="rc">RateCounter to increment for measurements</param>
		public Client(int threadCount, double targetRate, TimeSpan duration)
		{
			double targetIntervalMs = 1000.0 / targetRate;
			this.threadWait = (int) Math.Round(targetIntervalMs, 0);
			this.end = DateTime.Now + duration;
			threads = new Thread[threadCount];
			for (int i = 0; i < threadCount; ++i)
			{
				threads[i] = new Thread(new ThreadStart(ThreadLoop));
				threads[i].IsBackground = true;
			}
		}

		/// <summary>Run the test</summary>
		public void Run()
		{
			Thread.Sleep(rand.Next(0, threadWait)); 
			foreach (Thread th in threads)
				th.Start();
			foreach (Thread th in threads)
				th.Join();
		}

		private void ThreadLoop()
		{
			while (DateTime.Now < end)
			{
				try
				{
					Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
					s.Connect(new IPEndPoint(IPAddress.Loopback, 8081));

					SocketHelper.WriteMessage(s, "Garry");
					SocketHelper.ReadMessage(s);
					s.Shutdown(SocketShutdown.Both);
					s.Close();

					SocketHelper.Increment();
				}
				catch (SocketException se)
				{
					Console.WriteLine(se);
					Console.ReadLine();
					// local address at e
				}
				Thread.Sleep(threadWait);
			}
		}
	}
}
