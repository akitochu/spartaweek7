using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClassesApp
{
    public class Address
    {
        public Address(int houseNo, string street, string town)
        {
            HouseNo = houseNo;
            Street = street;
            Town = town;
        }

        public int HouseNo { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }

        public string GetAddress()
        {
            return $"Address: {HouseNo} {Street}, {Town}";
        }
    }
}
