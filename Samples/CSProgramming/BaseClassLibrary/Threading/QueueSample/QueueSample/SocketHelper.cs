// This software may be used for any purpose. 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
// FITNESS FOR A PARTICULAR PURPOSE.
// Garry Barclay. Codescent BV. 25 Jan 2006 http://www.codescent.com
using System;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace QueueSample
{
	/// <summary>Useful Socket routines</summary>
	public class SocketHelper
	{
		private static RateCounter rc; 
		private SocketHelper() {}

		private static BinaryFormatter bf = new BinaryFormatter();

		/// <summary>Start the ratecounter</summary>
		public static void StartRateCounter(TimeSpan ts)
		{
			SocketHelper.rc = new RateCounter(ts);
		}

		/// <summary>Increment our transcation rate counter</summary>
		public static void Increment()
		{
			rc.Increment();
		}

		// Process the request from an accepted socket
		public static void ProcessConnection(object o)
		{
			// Had to have object to make signature compatible with WaitCallback 
			Socket s = (Socket) o; 

			// get the message
			string name = (string) SocketHelper.ReadMessage(s);

			// process the message
			System.Threading.Thread.Sleep(500); // simulate the database work

			// send the response
			SocketHelper.WriteMessage(s, "Goodbye " + name);

			// client will close the socket
			SocketHelper.ReadMessage(s); // will be null
			s.Shutdown(SocketShutdown.Both);
			s.Close();

			if (rc != null) Increment();
		}

		/// <summary>Read a prefixed serialized object from the socket</summary>
		public static object ReadMessage(Socket s)
		{
			// read the prefix
			byte[] bytes = ReadBytes(s, 4); 
			if (bytes == null) return null; // stream closed
			int length = BytesToInt(bytes);

			//read and deserialize the message
			bytes = ReadBytes(s, length);
			if (bytes == null) return null;
			return bf.Deserialize(new MemoryStream(bytes)); 
		}

		/// <summary>Write a prefixed, serialized object to the socket</summary>
		public static void WriteMessage(Socket s, object o)
		{
			// serialize the message
			MemoryStream ms = new MemoryStream();
			bf.Serialize(ms, o);
			byte[] bytes = ms.ToArray();

			// write the message
			WriteBytes(s, IntToBytes(bytes.Length));
			WriteBytes(s, bytes);
		}

		// read exact number of bytes from socket
		private static byte[] ReadBytes(Socket s, int bytesToRead)
		{
			byte[] bytes = new byte[bytesToRead];
			int count = 0; 
			while (count < bytesToRead)
			{
				int result = s.Receive(bytes, count, bytesToRead - count, SocketFlags.None);
				if (result == 0) return null; // socket closed
				count += result;
			}
			return bytes;
		}

		// read exact number of bytes from socket
		private static void WriteBytes(Socket s, byte[] bytes)
		{
			int count = 0; 
			while (count < bytes.Length)
				count += s.Send(bytes, count, bytes.Length - count, SocketFlags.None);
		}

		// quick and dirty int to binary conversion
		private static byte[] IntToBytes(int i)
		{
			return new byte[4] { 
								   (byte)((i >> 24) & 0xFF),
								   (byte)((i >> 16) & 0xFF),
								   (byte)((i >>  8) & 0xFF),
								   (byte)((i      ) & 0xFF)};
		}

		// quick and dirty binary to int conversion
		private static int BytesToInt(byte[] bytes)
		{
			return bytes[3] + (bytes[2] << 8) + (bytes[1] << 16) + (bytes[0] << 24);
		}

	}
}
