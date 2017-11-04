using System;
using System.Collections.Generic;
using System.Text;

namespace DBProviderFactoriesLab
{
    public class Author : Person
    {
        private string _ID;
        private string _Phone;
        private string _Address;
        private string _City;
        private string _State;
        private string _Zip;
        private bool   _HasContract;

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        public string Zip
        {
            get { return _Zip; }
            set { _Zip = value; }
        }

        public bool HasContract
        {
            get { return _HasContract; }
            set { _HasContract = value; }
        }
    }
}
