using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB.StudentRegistration
{
    internal class Address
    {
        public int AddressId { get; set; }
        public string? Street { get; set; }
        public int? StreetNumber { get; set; }
        public string? ZipCode { get; set; }
        public string City { get; set; } = "";
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public Address()
        {

        }

        public Address(string city)
        {
            City = city;
        }

        public override string? ToString()
        {
            return $"{City}";
        }
    }
}
