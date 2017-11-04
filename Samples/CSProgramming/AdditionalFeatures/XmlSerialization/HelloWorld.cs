using System;
namespace AdditionalFeatures.XmlSerialization {
	public class HelloWorld {
		string _Greeting;
		public string Greeting {
			get {
				return _Greeting;
			}
			set {
				_Greeting = value;
			}
		}
	}
}
