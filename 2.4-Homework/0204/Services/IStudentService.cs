using _0204.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0204.Services
{
    public interface IStudentService
    {
        public Student AddStudent(Student student);
        public bool DeleteStudents(Guid studentId);
        public bool UpdateStudents(Student student);
        public List<Student> GetAllStudents();

    }
}
