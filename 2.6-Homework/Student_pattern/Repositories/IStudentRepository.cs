using Student_pattern.DataAccess.Entities;

namespace Student_pattern.Repositories;

public interface IStudentRepository
{
    Student WriteStudent(Student student);
    bool RemoveStudent(Guid id);
    bool UpdateStudent(Student student);
    Student ReadStudentById(Guid id);
    List<Student> ReadStudents();
    bool CheckEmailContains(string email);
}