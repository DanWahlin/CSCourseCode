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
	public class ThreadPoolServer
	{
		private static RateCounter rc;

		public static void Run()
		{
			ThreadPoolServer.rc = rc;
			Socket acceptingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
			acceptingSocket.Bind(new IPEndPoint(IPAddress.Any, 8081));
			acceptingSocket.Listen(50);
			while (true)
			{
				Socket s = acceptingSocket.Accept();
				ThreadPool.QueueUserWorkItem(new WaitCallback(SocketHelper.ProcessConnection), s);
			}
		}
	}
}
