using _2._7_Homework.Services.DTOs;
using _2._7_Homework.Services.DTOs.Enums;

namespace _2._7_Homework.Services
{
    public interface IStudentService
    {
        Guid AddStudent(StudentCreateDto dto);
        List<StudentGetDto> GetStudents();
        void DeleleStudent(Guid studnetId);
        void UpdateStudent(StudentUpdateDto dto);
        //StudentGetDto GetStudentById(Guid studentId);
        List<StudentGetDto> GetStudentsByDegree(DegreeStatusDto degreeStatusDto);
        List<StudentGetDto> GetStudentsByGender(GenderDto genderDto);
    }
}