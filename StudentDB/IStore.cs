using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB
{
    internal interface IStore
    {
        void ChangeCity(Student student, string edit);
        void ChangeFirstName(Student student, string edit);
        void ChangeLastName(Student student, string edit);
        List<Student> GetAllStudents();
        Student GetStudent(int id);
        void RegisterNew(Student student);
        void Delete(Student student);

    }
}
