using Student_pattern.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Student_pattern.Repositories;

public class StudentRepository : IStudentRepository
{
    private string path;
    private List<Student> _students;

    // ctor
    public StudentRepository()
    {
        path = "../../../DataAccess/Data/Students.json";
        _students = new List<Student>();
        if(!File.Exists(path))
        {
            File.WriteAllText(path, "[]");
        }    
        
        _students = ReadStudents();
    }

    // C Create
    public Student WriteStudent(Student student)
    {
        _students.Add(student);
        SaveData();
        return student;
    }

    // R Read
    public List<Student> ReadStudents()
    {
        string studentsJosn = File.ReadAllText(path);
        var students = JsonSerializer.Deserialize<List<Student>>(studentsJosn);
        return students;
    }

    // U Update
    public bool UpdateStudent(Student student)
    {
        var studentUpdate = ReadStudentById(student.Id);
        if (studentUpdate == null)
        {
            return false;
        }

        var index = _students.IndexOf(studentUpdate);
        _students[index] = student;
        SaveData();
        return true;
    }

    // Delete
    public bool RemoveStudent(Guid id)
    {
        var student = ReadStudentById(id);
        if (student == null)
        {
            return false;
        }

        _students.Remove(student);
        SaveData();
        return true;
    }


    // Checks if List object contins the same email
    public bool CheckEmailContains(string email)
    {
        var students = ReadStudents();
        foreach(var student in students)
        {
            if(student.Email == email)
            {
                return true;
            }
        }
        return false;
    }

    // Return student by its id
    public Student ReadStudentById(Guid id)
    {
        foreach (var student in _students)
        {
            if (student.Id == id)
            {
                return student;
            }
        }
        return null;
    }

    
    // Save Data
    private void SaveData()
    {
        var studentsJson = JsonSerializer.Serialize(_students);
        File.WriteAllText(path, studentsJson);
    }
}
