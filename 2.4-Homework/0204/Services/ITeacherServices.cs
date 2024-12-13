using _0204.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0204.Services
{
    public interface ITeacherServices
    {
        public Teacher AddTeacher(Teacher teacher);
        public bool DeleteTeacher(Guid teacherId);
        public bool UpdateTeacher(Teacher teacher);
        public List<Teacher> GetAllTeachers();

    }
}
