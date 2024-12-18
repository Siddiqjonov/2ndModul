using Student_pattern.DataAccess.Entities;
using Student_pattern.Repositories;
using Student_pattern.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Student_pattern.Services;

public class StudentService : IStudentService
{
    StudentRepository _studentRepository;
    // ctor
    public StudentService()
    {
        _studentRepository = new StudentRepository();
    }

    // Create
    public GetStudentsDto AddStudent(CreateStudentDto dto)
    {
        var checkingEmail = _studentRepository.CheckEmailContains(dto.Email);
        if(!dto.Email.EndsWith("@gmail.com") || checkingEmail)
        {
            return null;
        }
        /*
        Student student = ConvertToUserEntity(dto);
        Student studentFromDb = _studentRepository.WriteStudent(student);
        //Console.WriteLine(object.ReferenceEquals(student, studentFromDb));
        */
        var studentFromDb = _studentRepository.WriteStudent(ConvertToUserEntity(dto));
        var userDto = ConvertToDto(studentFromDb);
        return userDto;
    }
    // Read
    public List<GetStudentsDto> GetAllStudents()
    {
        var studentsFromDb = _studentRepository.ReadStudents();
        var getStudentsDto = new List<GetStudentsDto>();
        foreach (var student in studentsFromDb)
        {
            getStudentsDto.Add(ConvertToDto(student));
        }
        return getStudentsDto;
    }
    public bool UpdateStudent(UpdateStudentDto studentUpdateDto)
    {
        // var is Student
        var studenrt = ConvertToUserEntity(studentUpdateDto);
        return _studentRepository.UpdateStudent(studenrt);

    }
    public bool DeleteStudent(Guid studentId)
    {
        return _studentRepository.RemoveStudent(studentId);
    }
    private Student ConvertToUserEntity(CreateStudentDto dto)
    {
        return new Student
        {
            Id = Guid.NewGuid(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Age = dto.Age,
            Email = dto.Email,
            Password = dto.Password,
            School = dto.School,
        };
    }

    private Student ConvertToUserEntity(UpdateStudentDto dto)
    {
        return new Student()
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Age = dto.Age,
            Email = dto.Email,
            Password = dto.Password,
            School = dto.School,
        };
    }
    private GetStudentsDto ConvertToDto(Student student)
    {
        return new GetStudentsDto
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Age = student.Age,
            Email = student.Email,
            School = student.School,
        };
    }
}
