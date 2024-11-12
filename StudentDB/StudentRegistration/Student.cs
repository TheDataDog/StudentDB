using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB.StudentRegistration
{
    internal class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public Address? Address { get; set; }

        public Student()
        {

        }

        public Student(string firstName, string lastName, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }

        public override string? ToString()
        {
            return $"Id: {StudentId.ToString().PadRight(5)} " +
           $"Namn: {FirstName.PadRight(15)} " +
           $"Efternamn: {LastName.PadRight(15)} " +
           $"Stad: {Address.City.PadRight(10)}";
        }


    }
}
