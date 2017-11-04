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
	/// <summary>Summary description for Class1.</summary>
	class MainClass
	{
		/// <summary>The main entry point for the application.</summary>
		static void Main(string[] args)
		{
			int workerThreads;
			int completionPortThreads;
			ThreadPool.GetMaxThreads(out workerThreads, out completionPortThreads);
			Console.WriteLine("Max threads = {0}, {1}", workerThreads, completionPortThreads);

			SocketHelper.StartRateCounter(TimeSpan.FromSeconds(1));

			char mode = (args[0].ToLower())[0];
			switch (mode)
			{
				case 'c' : 
					Client client = new Client(100, 200, TimeSpan.FromSeconds(60));
					client.Run();
					break;
				case 's' :
					SingleThreadedServer.Run();
					break;
				case 't' :
					ThreadPoolServer.Run();
					break;
				case 'b' :
					BlockingQueueServer.Run(100);
					break;
				default :
					Console.WriteLine("Expected c|s|t|b");
					return;
			}
		}
	}
}
