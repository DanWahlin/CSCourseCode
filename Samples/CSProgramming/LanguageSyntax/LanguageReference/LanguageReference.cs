using System;
using System.Collections;
using System.IO;

namespace StructureByDesign.Syntax {
    /********************************************************************/
    public class Class1: Object {
        public static int Main(string[] args) {       // Entry point.
            System.Console.WriteLine("Hello");
            Class2 aclass2 = new Class2();
            aclass2.run();
            return 0;
        }
    }

    /********************************************************************/
    interface Interface1 {
        void run();
    }

    /********************************************************************/
    class Class2: Class1, Interface1 {
        public const int CONSTANT = 1;          // Access not restricted, implicitly static.
        private int m_intPrivateField;          // Access limited to containing type.
        //////////////////////////////////////////////////////////////
        public Class2() : base() {                // Constructor.
            initialize();
        }
        //////////////////////////////////////////////////////////////
        protected void initialize() {             // Object initialization.
                                            // Access limited to containing class or types derived.
            Number = 1;
        }
        //////////////////////////////////////////////////////////////
        protected int Number {                    // Language property feature.
            get {
                return m_intPrivateField;
            }
            set {
                m_intPrivateField = value;      // Implicit parameter.
            }
        }
        //////////////////////////////////////////////////////////////
        public void run() {
            anonymousCode();
            arrays();
            collections();
            comparison();
            control();
            filesStreamsAndExceptions();
            numbersAndMath();
            primitivesAndConstants();
            runtimeTyping();
            strings();
        }
        //////////////////////////////////////////////////////////////
        void anonymousCode() {
            Delegate adelegate = new Delegate(Run);
            adelegate();
        }
        delegate void Delegate();
        void Run() {
            Console.WriteLine("Run");
        }
        //////////////////////////////////////////////////////////////
        void arrays() {
            int[] arrayOfInts = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            arrayOfInts[0] = 9;
            assert(arrayOfInts[0] == arrayOfInts[9]);

            String[] arrayOfStrings = new String[10];
            assert(arrayOfStrings[0] == null);
            assert(arrayOfStrings.Length == 10);

            arrayOfStrings = new String[] { "one", "two" };

            byte[,] arrayOfBytes = { {0,0,0}, {
                                  0,1,2}, {
                                  0,2,4}};
            assert(arrayOfBytes[2,2] == 4);
        }
        //////////////////////////////////////////////////////////////
        void collections() {
            IList ailist = new ArrayList();
            ailist.Add("zero"); ailist.Add("one"); ailist.Add("three");
            ailist[2] = "two";
            assert(ailist[2].Equals("two"));
            ailist.Remove("two");
            ((ArrayList)ailist).Sort();
            for(IEnumerator aie = ((ArrayList)ailist).GetEnumerator(); aie.MoveNext(); )
                ;
            foreach(String astring in ailist)
                ;

            IDictionary aidictionary = new Hashtable();
            aidictionary.Add("key", "value");
            assert(aidictionary["key"].Equals("value"));

            // Set not available.
        }
        //////////////////////////////////////////////////////////////
        void comparison() {
            int aint1 = 1;
            int aint2 = 2;
            int aint = 1;
            String astring1 = "one";
            String astring2 = "two";
            String astring = astring1;

            assert(aint == aint1);
            assert(aint1 != aint2);
            assert(astring == astring1);
            assert(astring1 == String.Copy("one"));         // For strings == is overloaded to compare values.
            assert(!astring1.Equals(astring2));
            assert(astring1.Equals(String.Copy("one")));

            astring = null;
            if (astring != null && astring.Length > 0)      // Conditional evaluation.
                assert(false);

            if (aint2 < 0 || 1 < aint2)
                assert(true);
        }
        //////////////////////////////////////////////////////////////
        void control() {
            if (true)
                assert(true);
            else
                assert(false);
            /////
            switch ('b') {
                case 'a':
                    assert(false);
                    break;
                case 'b':
                    assert(true);
                    break;
                default:
                    assert(false);
                    break;
            }
            /////
            for (int ai1 = 0; ai1 < 10; ai1++)
                assert(true);
            /////
            int ai = 0;
            while (ai < 10) {
                assert(true);
                ai++;
            }
            /////
            do
                ai--;
            while (ai > 0);
            /////
            for (int x = 0; x < 10; x++)        // Labeled break/continue not available.
                for (int y = 0; y < 10; y++)
                    if (x == 9)
                        break;
                    else
                        continue;
        }
        //////////////////////////////////////////////////////////////
        void filesStreamsAndExceptions() {
            FileInfo afileinfo = new FileInfo("list.txt");
            try {
                StreamWriter asw = new StreamWriter("list.txt");
                asw.WriteLine("line");
                asw.WriteLine("line");
                asw.Close();

                assert(afileinfo.Exists);

                StreamReader asr = new StreamReader("list.txt");
                String astringLine;
                while ((astringLine = asr.ReadLine()) != null)
                    assert(astringLine.Equals("line"));
                asr.Close();
            } catch (IOException aexception) {
                System.Console.WriteLine(aexception.Message);
                throw new NotSupportedException();
            }
            finally {
                afileinfo.Delete();
            }
        }
        //////////////////////////////////////////////////////////////
        void numbersAndMath() {
            assert(Int32.Parse("123") == 123);
            assert(123.ToString().Equals("123"));

            assert(Math.PI.ToString("n3").Equals("3.142"));

            assert(Int32.MaxValue < Int64.MaxValue);

            assert(Math.Abs(Math.Sin(0) - 0) <= Double.Epsilon);
            assert(Math.Abs(Math.Cos(0) - 1) <= Double.Epsilon);
            assert(Math.Abs(Math.Tan(0) - 0) <= Double.Epsilon);

            assert(Math.Abs(Math.Sqrt(4) - 2) <= Double.Epsilon);
            assert(Math.Abs(Math.Pow(3,3) - 27) <= Double.Epsilon);

            assert(Math.Max(0,1) == 1);
            assert(Math.Min(0,1) == 0);

            assert(Math.Abs(Math.Ceiling(9.87) - 10.0) <= Double.Epsilon);
            assert(Math.Abs(Math.Floor(9.87) - 9.0) <= Double.Epsilon);
            assert(Math.Round(9.87) == 10);

            Random arandom = new Random();
            double adouble = arandom.NextDouble();
            assert(0.0 <= adouble && adouble < 1.0);
            int aint = arandom.Next(10);
            assert(0 <= aint && aint < 10);
        }
        //////////////////////////////////////////////////////////////
        enum Season: byte { Spring=0, Summer, Fall, Winter };

        void primitivesAndConstants() {
            bool abool = false;
            char achar = 'A';           // 16 bits, Unicode

            byte abyte = 0x0;           // 8 bits, unsigned, hex constant
            sbyte asbyte = 0;           // 8 bits, signed

            short ashort = 0;           // 16 bits, signed
            ushort aushort = 0;         // 16 bits, unsigned

            int aint = 0;               // 32 bits, signed
            uint aunit = 0;             // 32 bits, unsigned

            long along = 0L;            // 64 bits, signed
            ulong aulong = 0;           // 64 bits, unsigned

            float afloat = 0.0F;        // 32 bits
            double adouble = 0.0;       // 64 bits

            decimal adecimal = 0;       // 128 bits, financial calculations

            Season aseason = Season.Fall;
            assert((byte)aseason == 2);
        }
        //////////////////////////////////////////////////////////////
        void runtimeTyping() {
            assert(new int[] { 1 } is int[]);
                assert(new ArrayList() is ArrayList);

            assert((new ArrayList()).GetType() == typeof(ArrayList));
            assert(typeof(Int32) is Type);      // Type of primitive type.

            assert(Type.GetType("System.Collections.ArrayList") == typeof(ArrayList));
        }
        //////////////////////////////////////////////////////////////
        void strings() {
            String astring1 = "one";
            String astring2 = "TWO";

            assert((astring1 + "/" + astring2).Equals("one/TWO"));
            assert(astring2.ToLower().Equals("two"));   // Equals ignoring case not available.
            assert(astring1.Length == 3);
            assert(astring1.Substring(0,2).Equals("on"));
            assert(astring1[2] == 'e');
            assert(astring1.ToUpper().Equals("ONE"));
            assert(astring2.ToLower().Equals("two"));
            assert(astring1.CompareTo("p") < 0);
            assert(astring1.IndexOf('e') == 2);
            assert(astring1.IndexOf("ne") == 1);
            assert(astring1.Trim().Length == astring1.Length);

            assert(Char.IsDigit('1'));
            assert(Char.IsLetter('a'));
            assert(Char.IsWhiteSpace('\t'));
            assert(Char.ToLower('A') == 'a');
            assert(Char.ToUpper('a') == 'A');
        }
        //////////////////////////////////////////////////////////////
        private void assert(bool abool) {
            if (!abool)
                throw new Exception("assert failed");
        }
    }
}
