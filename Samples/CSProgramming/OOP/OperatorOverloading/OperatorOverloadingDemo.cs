using System;

namespace OOP.OperatorOverloading {
    public class OperatorOverloadingDemo {
        public static void Main() {
            Time t1 = new Time(DateTime.Now);
            Time t2 = new Time(DateTime.Now.AddHours(2));
            TimeSpan tSpan = t2 - t1;
            Console.WriteLine("Difference between t1 and t2 is " + 
                tSpan.Hours.ToString() + " hours.");
            Console.WriteLine("Calling wrapper method: " + Time.SubtractTimes(t1,t2).Hours.ToString());
            Console.ReadLine();
        }
    }

    public class Time {
        DateTime _time;
        public Time(DateTime time) {
            _time = time;
        }

        //overload - operator
        public static TimeSpan operator -(Time t1, Time t2) { 
            return t1._time.Subtract(t2._time);
        } 

        public static TimeSpan SubtractTimes(Time t1, Time t2) {
            return t2 - t1;
        }
    }
}
