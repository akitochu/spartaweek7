using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesApp
{
    // A Class to represent a Person
    public class BaseClass 
    {
        private string fn;
        private string _lastName;
        private int _age;
        private string _hobbies;
        private int _houseNo;
        private string _street;
        private string _town;
        public BaseClass() { }
        public BaseClass(string fName, string lName, int hNo = 0, string street = "", string town = "")
        {
            fn = fName;
            _lastName = lName;
            _houseNo = hNo;
            _street = street;
            _town = town;
        }

        public int Age
        {
            get { return _age; }
            set { if (value >= 0) _age = value; }
        }

        public string GetFullName()
        {
            return $"{fn} {_lastName}";
        }

        public string Move()
        {
            return "Walking along";
            Console.WriteLine("Can't get here");
        }

        public string Move(int times)
        {
            return $"Walking along {times} times";
        }

        public override string ToString()
        {
            var addressString = $"Address: {_houseNo} {_street}, {_town}";
            return $"{base.ToString()} Name: {fn}  { _lastName} Age: {Age}. {addressString}";
        }

        //public int StupidMethod()
        //{
        //    return 3;
        //}
    }
}
