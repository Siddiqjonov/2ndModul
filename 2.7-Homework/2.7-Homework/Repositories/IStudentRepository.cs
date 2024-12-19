using _2._7_Homework.DataAccess.Entities;

namespace _2._7_Homework.Repositories;

public interface IStudentRepository
{
    Guid WriteStudent(Student student);
    List<Student> ReadAllStudents();
    void RemoveStudent(Guid studentId);
    void UpdateStudent(Student student);
    Student ReadStudentById(Guid studentId);
    void EmailContains(string email);
}