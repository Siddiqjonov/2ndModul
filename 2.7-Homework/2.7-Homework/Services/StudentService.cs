using _2._7_Homework.DataAccess.Entities;
using _2._7_Homework.DataAccess.Enums;
using _2._7_Homework.Repositories;
using _2._7_Homework.Services.DTOs;
using _2._7_Homework.Services.DTOs.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7_Homework.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService()
    {
        _studentRepository = new StudentRepository();
    }
    public Guid AddStudent(StudentCreateDto dto)
    {
        var result = ValidateStudentCreateDto(dto);
        if(result == false)
        {
            throw new Exception("Hatolik yuz berdi while adding");
        }

        var entity = ConvertToEntity(dto);
        var id = _studentRepository.WriteStudent(entity);
        return id;

    }

    public void DeleleStudent(Guid studnetId)
    {
        _studentRepository.RemoveStudent(studnetId);
    }

    //public StudentGetDto GetStudentById(Guid studentId)
    //{
    //    var entity = _studentRepository.ReadStudentById(studentId);
    //    var dto = ConvertToDto(entity);
    //    return dto;
    //}

    public List<StudentGetDto> GetStudents()
    {
        var students = _studentRepository.ReadAllStudents();
        var studentsDto = new List<StudentGetDto>();
        foreach (var student in students)
        {
            studentsDto.Add(ConvertToDto(student));
        }
        return studentsDto;
    }

    public List<StudentGetDto> GetStudentsByDegree(DegreeStatusDto degreeStatusDto)
    {
        var students = _studentRepository.ReadAllStudents();
        var studentsDegreeDto = new List<StudentGetDto>();
        foreach (var student in students)
        {
            if ((DegreeStatusDto)student.Degree == degreeStatusDto)
            {
                studentsDegreeDto.Add(ConvertToDto(student));
            }
        }
        return studentsDegreeDto;
    }
    
    public List<StudentGetDto> GetStudentsByGender(GenderDto genderDto)
    {
        var students = _studentRepository.ReadAllStudents();
        var studentsGenderDto = new List<StudentGetDto>();
        foreach (var student in students)
        {
            if(student.Gender == (DataAccess.Enums.Gender)genderDto)
            {
                studentsGenderDto.Add(ConvertToDto(student));
            }
        }

        return studentsGenderDto;
    }

    public void UpdateStudent(StudentUpdateDto dto)
    {
        _studentRepository.UpdateStudent(ConvertToEntity(dto));
    }

    private Student ConvertToEntity(StudentCreateDto studentCreateDto)
    {
        return new Student()
        {
            Id = Guid.NewGuid(),
            FirstName = studentCreateDto.FirstName,
            LastName = studentCreateDto.LastName,
            Age = studentCreateDto.Age,
            Email = studentCreateDto.Email,
            Password = studentCreateDto.Password,
            Degree = (DataAccess.Enums.DegreeStatus)studentCreateDto.Degree,
            Gender = (DataAccess.Enums.Gender)studentCreateDto.Gender
        };
    }
    private Student ConvertToEntity(StudentUpdateDto studentUpdateDto)
    {
        return new Student()
        {
            Id = studentUpdateDto.Id,
            FirstName = studentUpdateDto.FirstName,
            LastName = studentUpdateDto.LastName,
            Age = studentUpdateDto.Age,
            Email = studentUpdateDto.Email,
            Password = studentUpdateDto.Password,
            Degree = (DataAccess.Enums.DegreeStatus)studentUpdateDto.Degree,
            Gender = (DataAccess.Enums.Gender)studentUpdateDto.Gender
        };
    }
    private StudentGetDto ConvertToDto(Student student)
    {
        return new StudentGetDto()
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Age = student.Age,
            Email = student.Email,
            Degree = (DegreeStatusDto)student.Degree,
            Gender = (GenderDto)student.Gender
        };
    }
    private bool ValidateStudentCreateDto(StudentCreateDto obj)
    {
        _studentRepository.EmailContains(obj.Email);

        if (string.IsNullOrWhiteSpace(obj.FirstName) || obj.FirstName.Length > 50)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(obj.LastName) || obj.LastName.Length > 50)
        {
            return false;
        }
        if (obj.Age < 15 || obj.Age > 150)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(obj.Email) || !obj.Email.EndsWith("@gmail.com") || obj.Email.Length > 100 
            || obj.Email.Length <= 10)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(obj.Password) || obj.Password.Length > 50 || obj.Password.Length < 8)
        {
            return false;
        }

        return true;
    }
}
