// This software may be used for any purpose. 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
// FITNESS FOR A PARTICULAR PURPOSE.
// Garry Barclay. Codescent BV. 25 Jan 2006 http://www.codescent.com
using System;

namespace QueueSample
{
	/// <summary>Calculations for an M/M/c queue</summary>
	/// <remarks>No overflow or divide by zero checks. These calculations WILL fail for large values of c.</remarks>
	public class QueueMmc
	{
		private double lambda; // arrival rate
		private double mu; // service rate
		private int c; // number of servers

		public QueueMmc(double arrivalRate, double serviceRate, int servers)
		{
			lambda = arrivalRate;
			mu = serviceRate;
			c = servers;
		}

		private double load = double.MinValue;
		/// <summary>Load on the system (0..1)</summary>
		public double Load
		{
			get
			{
				if (load == double.MinValue)
					load = lambda / (mu * c); 
				return load;
			}
		}

		private double p0 = double.MinValue;
		/// <summary>Probability that there the queue is empty when a new request arrives</summary>
		public double ProbSystemIsEmpty
		{
			get
			{
				if (p0 == double.MinValue)
				{
					double accum = 0; 
					for (int k = 0; k < c; ++k)
						accum += Math.Pow(c * Load, k) / Fact(k);
					double rterm = Math.Pow(c * Load, c) / (Fact(c) * (1 - Load));
					p0 = 1 / (accum + rterm);
				}
				return p0;
			}
		}

		private double pq = double.MinValue;
		/// <summary>Probability that a newly arrived request must wait</summary>
		public double ProbRequestMustWait
		{
			get
			{
				if (pq == double.MinValue)
				{
					double load = Load;
					double num = ProbSystemIsEmpty * Math.Pow(c * load, c);
					double den = Fact(c) * (1 - load);
					pq = num / den;
				}
				return pq;
			}
		}

		/// <summary>Expected waiting time in queue</summary>
		public double ExpWaitTimeInQueue
		{
			get
			{
				double load = Load;
				return load * ProbRequestMustWait / (lambda * (1 - load)); 
			}
		}
		
		/// <summary>Mean number of Items in the Queue</summary>
		public double ExpectedQueueLength
		{
			get
			{
				double load = Load;
				return load * ProbRequestMustWait / (1 - load); 
			}
		}

		/// <summary>Average time waiting in the system (queuing plus being served)</summary>
		public double ExpWaitTimeTotal
		{
			get
			{
				return (1 / mu) + ExpWaitTimeInQueue;
			}
		}

		/// <summary>Average time waiting in the system (queuing plus being served)</summary>
		public double ExpNumberInSystem
		{
			get
			{
				double load = Load;
				return load * c + ExpectedQueueLength;
			}
		}

		/// <summary>Wait-time distribution</summary>
		/// <param name="t">The maximum time to wait</param>
		/// <returns>Probability that the actual time in the queue will be less than or equal to this time</returns>
		public double ProbWait(double t)
		{
			double lm = lambda / mu; 
			double p0 = ProbSystemIsEmpty;

			// t == 0 case
			double num = c * Math.Pow(lm, c);
			double den = Fact(c) * (c - lm);
			double pt0 = 1 - (num / den) * p0;
			if (t == 0.0) return pt0;

			// other cases
			num = Math.Pow(lm, c) * (1 - Math.Pow(Math.E, -1 * (mu * c - lambda) * t)); 
			den = Fact(c-1) * (c - lm); 
			return (num / den) * p0 + pt0;
		}

		// Factorial function 
		private static double Fact(double n)
		{
			if (n > 1.0) return n * Fact(n-1);
			return 1.0;
		}
	}
}
