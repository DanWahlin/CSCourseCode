using System;

namespace AdditionalFeatures.Reflection {
    public class Person {
        private string _FirstName;
        private string _LastName;

		public string FirstName {
			get {
				return _FirstName;
			}
			set {
				_FirstName = value;
			}
		}

		public string LastName {
			get {
				return _LastName;
			}
			set {
				_LastName = value;
			}
		}

		public static string CalculateAge(System.DateTime born) {
			System.DateTime currDate  = System.DateTime.Now;
			System.TimeSpan span = currDate.Subtract(born);
			return Convert.ToString(span.TotalDays / 365);
		}
    }
}
