using System;
using System.Collections;

namespace BaseClassLibrary.Collections
{
    public class PersonFirstNameComparer : IComparer {

        //Less than zero - x is less than y. 
        //Zero - x equals y. 
        //Greater than zero - x is greater than y. 

		public int Compare(object x, object y) {
			Person perX = (Person)x;
			Person perY = (Person)y;
			return string.Compare(perX.FirstName, perY.FirstName);
		}
    }
}
