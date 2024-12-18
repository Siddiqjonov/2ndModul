using Student_pattern.DataAccess.Entities;
using Student_pattern.Services.DTOs;

namespace Student_pattern.Services;

public interface IStudentService
{
    GetStudentsDto AddStudent(CreateStudentDto student);
    List<GetStudentsDto> GetAllStudents();
    bool UpdateStudent(UpdateStudentDto studentUpdateDto);
    bool DeleteStudent(Guid studentId);
}