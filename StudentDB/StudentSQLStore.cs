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
            return dbContext.Students.ToList();
        }

        public Student GetStudent(int id)
        {
            return dbContext.Students.Where(s => s.StudentId == id).FirstOrDefault();
        }

        public void RegisterNew(Student student)
        {
            dbContext.Students.Add(student);
            dbContext.SaveChanges();
        }

        public void ChangeFirstName(int id, string edit)
        {
            Student student = GetStudent(id);
            student.FirstName = edit;
            dbContext.SaveChanges();
        }

        public void ChangeLastName(int id, string edit)
        {
            Student student = GetStudent(id);
            student.LastName = edit;
            dbContext.SaveChanges();
        }

        public void ChangeCity(int id, string edit)
        {
            Student student = GetStudent(id);
            student.City = edit;
            dbContext.SaveChanges();
        }
    }
}

