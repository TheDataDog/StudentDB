using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB
{
    internal class StudentHandler
    {
        private IStore storeStudent;

        public StudentHandler(IStore storeStudent)
        {
            this.storeStudent = storeStudent;
        }

        //public void CreateAStudent()
        //{
        //    Student student = new Student("Johanna", "Svensson", "Karlstad");
        //    storeStudent.RegisterNew(student);
        //}

        public void RegisterNew(string firstName, string lastName, string city)
        {
            Student student = CreateNew(firstName, lastName, city);
            storeStudent.RegisterNew(student);
        }

        public bool ChangeExisting(int id, int editPost, string edit)
        {
            Student student = GetStudent(id);
            if (student != null)
            {
                if (editPost == 1)
                {
                    storeStudent.ChangeFirstName(student, edit);
                    return true;
                }
                if (editPost == 2)
                {
                    storeStudent.ChangeLastName(student, edit);
                    return true;
                }
                if (editPost == 3)
                {
                    storeStudent.ChangeCity(student, edit);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteExisting(int id)
        {
            Student student = GetStudent(id);
            if(student != null)
            {
                storeStudent.Delete(student);
            }
            return false;

        }

        public List<Student> GetAllStudents()
        {
            return storeStudent.GetAllStudents();
        }

        private Student GetStudent(int id)
        {
            return storeStudent.GetStudent(id);
        }

        public List<Student> GetMatches(int searchPost, string searchInput)
        {
            List<Student> students = GetAllStudents();
            if (searchPost == 1)
            {
                var matches = students.Where(s => s.FirstName == searchInput).ToList();
                if(matches.Count == 0)
                {
                    return null;
                }
                return matches;
            }
            if (searchPost == 2)
            {
                var matches = students.Where(s => s.LastName == searchInput).ToList();
                if (matches.Count == 0)
                {
                    return null;
                }
                return matches;
            }
            if (searchPost == 3)
            {
                var matches = students.Where(s => s.City == searchInput).ToList();
                if (matches.Count == 0)
                {
                    return null;
                }
                return matches;
            }
            return null;
        }

        public bool CheckIfValid(int id)
        {
            Student student = GetStudent(id);
            if (student != null)
            {
                return true;
            }
            return false;
        }

        private Student CreateNew(string firstName, string lastName, string city)
        {
            return new Student(firstName, lastName, city);
        }
    }
}

