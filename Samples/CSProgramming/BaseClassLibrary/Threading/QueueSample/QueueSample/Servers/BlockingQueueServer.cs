// This software may be used for any purpose. 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
// FITNESS FOR A PARTICULAR PURPOSE.
// Garry Barclay. Codescent BV. 25 Jan 2006 http://www.codescent.com
using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace QueueSample
{
	public class BlockingQueueServer
	{
		private static BlockingQueue queue = new BlockingQueue();
		private static Thread[] threads; 

		public static void Run(int serverThreadCount)
		{
			threads = new Thread[serverThreadCount];
			for (int i = 0; i < serverThreadCount; ++i)
			{
				threads[i] = new Thread(new ThreadStart(BlockingQueueServer.ThreadLoop));
				threads[i].Name = "Sample Reader Thread " + Thread.CurrentThread.GetHashCode();
				threads[i].IsBackground = true;
				threads[i].Start();
			}

			Socket acceptingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
			acceptingSocket.Bind(new IPEndPoint(IPAddress.Any, 8081));
			acceptingSocket.Listen(10);
			while (true)
			{
				Socket s = acceptingSocket.Accept();
				queue.Enqueue(s);
			}
		}

		private static void ThreadLoop()
		{
			while (true)
			{
				Socket s = (Socket) queue.Dequeue();
				SocketHelper.ProcessConnection(s); 
			}
		}
	}
}
