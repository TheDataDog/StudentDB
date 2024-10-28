using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB
{
    internal class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string City { get; set; } = "";

        public Student(string firstName, string lastName, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            City = city;
        }

        public override string? ToString()
        {
            return $"Id: {StudentId.ToString().PadRight(5)} " +
           $"Namn: {FirstName.PadRight(15)} " +
           $"Efternamn: {LastName.PadRight(15)} " +
           $"Stad: {City.PadRight(10)}";
        }


    }
}
