using _0204.Moduls;
using _0204.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _0204.Services
{
    public class TeacherServices : ITeacherServices
    {
        private string teachersFilePath;
        public List<Teacher> _teachers;


        // Creates file
        public TeacherServices()
        {
            teachersFilePath = "../../../Data/Teachers.json";
            if (File.Exists(teachersFilePath) is false)
            {
                File.WriteAllText(teachersFilePath, "[]");
            }

            _teachers = new List<Teacher>();
            _teachers = GetAllTeachers();
        }


        // Create
        // Adds a new teacher 
        public Teacher AddTeacher(Teacher teacher)
        {
            teacher.Id = Guid.NewGuid(); // Unique id to a new teacher
            _teachers.Add(teacher); // Adding a new teacher to a DataBase
            SaveData(); // Saving a new teacher to DataBase
            return teacher; // return a new teacher
        }

        // Cheching a unique id of a spesific teacher
        public Teacher GetById(Guid teacherId)
        {
            var teachers = GetTeachers();
            foreach (Teacher teacher in _teachers)
            {
                if (teacher.Id == teacherId)
                {
                    return teacher;
                }
            }
            return null;
        }


        // Delete
        public bool DeleteTeacher(Guid teacherId)
        {
            var teacherFromDb = GetById(teacherId);
            if (teacherFromDb is null)
            {
                return false;
            }
            _teachers.Remove(teacherFromDb);
            SaveData();
            return true;
        }

        // Update
        public bool UpdateTeacher(Teacher teacher)
        {
            var teacherFromDb = GetById(teacher.Id);
            if (teacherFromDb is null)
            {
                return false;
            }

            var index = _teachers.IndexOf(teacherFromDb);
            _teachers[index] = teacher;
            SaveData();
            return true;
        }


        public List<Teacher> GetAllTeachers()
        {
            return GetTeachers();
        }


        // Read
        // Turns techers file to object and returns tham
        private List<Teacher> GetTeachers()
        {
            var teachersJson = File.ReadAllText(teachersFilePath);
            var teachers = JsonSerializer.Deserialize<List<Teacher>>(teachersJson);
            return teachers;
        }


        // Saves info about teachers
        private void SaveData()
        {
            var teachersJson = JsonSerializer.Serialize(_teachers);
            File.WriteAllText(teachersFilePath, teachersJson);
        }
    }
}
