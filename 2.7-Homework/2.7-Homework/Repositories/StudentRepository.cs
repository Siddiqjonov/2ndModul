using _2._7_Homework.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _2._7_Homework.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly string _path;
    List<Student> _students;
    public StudentRepository()
    {
        _path = "../../../DataAccess/Data/Students.json";
        _students = new List<Student>();
        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }
        _students = ReadAllStudents();
    }

    public void EmailContains(string email)
    {
        foreach (var student in _students)
        {
            if (student.Email == email)
            {
                throw new Exception("Bunday email bor, qosha olmaysiz");
            }
        }
    }

    public List<Student> ReadAllStudents()
    {
        var studentsJson = File.ReadAllText(_path);
        var students = JsonSerializer.Deserialize<List<Student>>(studentsJson);
        return students;
    }

    public Student ReadStudentById(Guid studentId)
    {
        foreach (var student in _students)
        {
            if (student.Id == studentId)
                return student;
        }
        throw new Exception($"Bunday id: {studentId} li talaba mavjud, qosha olmaysiz");
    }

    public void RemoveStudent(Guid studentId)
    {
        var studnet = ReadStudentById(studentId);
        _students.Remove(studnet);
        SaveData();
    }

    public void UpdateStudent(Student student)
    {
        var studentFromDb = ReadStudentById(student.Id);
        var index = _students.IndexOf(studentFromDb);
        _students[index] = student;
        SaveData();
    }

    public Guid WriteStudent(Student student)
    {
        _students.Add(student);
        SaveData();
        return student.Id;
    }
    private void SaveData()
    {
        var studentsJson = JsonSerializer.Serialize(_students);
        File.WriteAllText(_path, studentsJson);
    }
}
