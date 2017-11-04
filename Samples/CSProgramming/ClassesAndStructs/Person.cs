namespace ClassesAndStructs {
  public class Person {
    private int _Age;
    
    public int Age {
        get {
             return _Age; 
        }
        set {
 	        _Age = value;
        }
    }

    public string Walk() {
        return "The person walked!";
    }
  }
}
