using _0202.Moduls;
using System.Text.Json;

namespace _0202.Services
{
    // Create Read Update Delete
    public class StudentService
    {
        private string studentFilePath;
        private List<Student> _students;

        // Constructor shows the path to create new file 
        public StudentService()
        {
            studentFilePath = "../../../Data/Students.json"; // Path to create new file

            if (File.Exists(studentFilePath) is false) // Check is file exists or not
            {
                File.WriteAllText(studentFilePath, "[]"); // Creates new file is the is no file exists
            }
            _students = new List<Student>();
            _students = GetAllStudents();
        }

        // Create
        // Adds students to the list
        public Student AddStudent(Student student)
        {
            student.Id = Guid.NewGuid(); // Assining a niw id to a new student
            _students.Add(student); // Adding to the list 
            SaveData(); // Saving to file
            return student; // Returning the student object
        }


        // Checks if there is a student with that id
        public Student GetById(Guid studentId)
        {
            foreach (Student student in _students) // Cicles through all students
            {
                if (student.Id == studentId) // Checks if there is the same id
                {
                    return student; // if condition is true return the student
                }
            }
            return null; // if false returns null
        }

        // Deletes students 
        // Deletes students by their id
        public bool DeleteStudents(Guid studentId)
        {
            var studentFromDB = GetById(studentId); // DB is DataBase // 
            if (studentFromDB is null)
            {
                return false;
            }
            _students.Remove(studentFromDB); // Removes the student 
            SaveData(); // Saves to the file
            return true;
        }

        // Update
        public bool UpdateStudents(Student student)
        {
            var studentFromDb = GetById(student.Id); // Uses id to fint the specific student
            if (student is null)
            {
                return false;
            }

            var index = _students.IndexOf(studentFromDb); // Finds the index of the student in the list
            _students[index] = student;
            
            SaveData();
            return true;

        }

        // Read
        // Returns students INFO formatting them from Json file to Student list
        private List<Student> GetStudents()
        {
            var strudentsJson = File.ReadAllText(studentFilePath); // Saving info of student into string in Json file format
            var students = JsonSerializer.Deserialize<List<Student>>(strudentsJson); // Deserializing to Students list from Json file
            return students; // Returns the objects of students 
        }

        // Data sever
        // Saves data in text format
        public void SaveData()
        {
            var studentsJson = JsonSerializer.Serialize(_students); // Turns the list of students' data into text
            File.WriteAllText(studentFilePath, studentsJson); // Writes the text info of students into the file 
        }

        public List<Student> GetAllStudents()
        {
            return GetStudents();
        }
    }
}
