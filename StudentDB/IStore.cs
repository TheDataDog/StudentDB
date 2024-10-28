using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB
{
    internal interface IStore
    {
        void ChangeCity(int id, string edit);
        void ChangeFirstName(int id, string edit);
        void ChangeLastName(int id, string edit);
        List<Student> GetAllStudents();
        Student GetStudent(int id);
        void RegisterNew(Student student);
    }
}
