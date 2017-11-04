
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
namespace Generics.Arrays
{
    class ArrayDemo
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            Array.ForEach(numbers, TraceValue);

            Trace.WriteLine("********************");

            int[] primes = Array.FindAll(numbers, IsPrime);
            Array.ForEach(primes, TraceValue);
        }
        static void TraceValue(int number)
        {
            Trace.WriteLine(number);
        }
        static bool IsPrime(int number)
        {
            Debug.Assert(number <= 20);
            switch (number)
            {
                case 1:
                case 2:
                case 3:
                case 5:
                case 7:
                case 11:
                case 13:
                case 17:
                case 19:
                    return true;
                default:
                    return false;
            }
        }
    }
}