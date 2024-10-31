using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB
{
    internal class StudentSQLStore : IStore
    {

        private StudentDbContext dbContext;

        public StudentSQLStore(StudentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Student> GetAllStudents()
        {
            return dbContext.Students.Include(s => s.Address).ToList();
        }

        public Student? GetStudent(int id)
        {
            return dbContext.Students.Include(s => s.Address).FirstOrDefault(s => s.StudentId == id);
        }

        public void RegisterNew(Student student)
        {
            dbContext.Students.Add(student);
            dbContext.SaveChanges();
        }

        public void ChangeFirstName(Student student, string edit)
        {
            student.FirstName = edit;
            dbContext.SaveChanges();
        }

        public void ChangeLastName(Student student, string edit)
        {
            student.LastName = edit;
            dbContext.SaveChanges();
        }

        public void ChangeCity(Student student, string edit)
        {
            student.Address.City = edit;
            dbContext.SaveChanges();
        }

        public void Delete(Student student)
        {
            dbContext.Students.Remove(student);
            dbContext.SaveChanges();
        }
    }
}

