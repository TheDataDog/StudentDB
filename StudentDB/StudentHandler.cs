using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentDB.Enum;

namespace StudentDB
{
    internal class StudentHandler
    {
        private IStore storeStudent;

        public StudentHandler(IStore storeStudent)
        {
            this.storeStudent = storeStudent;
        }

        public void RegisterNew(string firstName, string lastName, string city)
        {
            Student student = CreateNew(firstName, lastName, city);
            storeStudent.RegisterNew(student);
        }

        public bool ChangeExisting(int id, ModifyField field, string edit)
        {
            Student? student = GetStudent(id);
            if (student != null)
            {
                if (field == ModifyField.FirstName)
                {
                    storeStudent.ChangeFirstName(student, edit);
                    return true;
                }
                if (field == ModifyField.LastName)
                {
                    storeStudent.ChangeLastName(student, edit);
                    return true;
                }
                if (field == ModifyField.City)
                {
                    storeStudent.ChangeCity(student, edit);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteExisting(int id)
        {
            Student? student = GetStudent(id);
            if(student != null)
            {
                storeStudent.Delete(student);
                return true;
            }
            return false;
        }

        public List<Student> GetAllStudents()
        {
            return storeStudent.GetAllStudents();
        }

        private Student? GetStudent(int id)
        {
            return storeStudent.GetStudent(id);
        }

        public List<Student> GetMatches(ModifyField field, string searchInput)
        {
            List<Student> students = GetAllStudents();
            if (field == ModifyField.FirstName)
            {
                var matches = students.Where(s => s.FirstName == searchInput).ToList();
                return matches;
            }
            if (field == ModifyField.LastName)
            {
                var matches = students.Where(s => s.LastName == searchInput).ToList();
                return matches;
            }
            if (field == ModifyField.City)
            {
                var matches = students.Where(s => s.Address.City == searchInput).ToList();
                return matches;
            }
            return new List<Student>();
        }

        public bool CheckIfValid(int id)
        {
            Student? student = GetStudent(id);
            if (student != null)
            {
                return true;
            }
            return false;
        }

        private Student CreateNew(string firstName, string lastName, string city)
        {
            return new Student(firstName, lastName, new Address(city));
        }
    }
}

