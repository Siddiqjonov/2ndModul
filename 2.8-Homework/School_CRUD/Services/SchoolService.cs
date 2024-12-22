using School_CRUD.DataAccess.Entitiy;
using School_CRUD.Repositories;
using School_CRUD.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_CRUD.Services;

public class SchoolService : ISchoolService
{
    ISchoolRepository _schoolRepository;
    public SchoolService()
    {
        _schoolRepository = new SchoolRepository();
    }

    public Guid AddSchool(SchoolDto schoolDto)
    {
        var result = ValidateStudentCreateDto(schoolDto);
        if (result == false)
        {
            throw new Exception("SomethringIsInvaliedWhileAdding");
        }
        var id = _schoolRepository.Write(ConvertToEntity(schoolDto));
        return id;
    }

    public void DeleteSchool(Guid schoolId)
    {
        _schoolRepository.Delete(schoolId);
    }

    public List<SchoolExtendedDto> GetAllShcools()
    {
        var schoolsExtedndedDto = new List<SchoolExtendedDto>();
        var schools = _schoolRepository.ReadAll();

        foreach (var school in schools)
        {
            schoolsExtedndedDto.Add(ConvertToDto(school));
        }
        return schoolsExtedndedDto;
    }

    public SchoolExtendedDto GetSchoolById(Guid schoolId)
    {
        var schoolFromDb = _schoolRepository.GetById(schoolId);
        var schoolExtendedDto = ConvertToDto(schoolFromDb);
        return schoolExtendedDto;
    }

    public void UpdateSchool(SchoolExtendedDto schoolExtendedDto)
    {
        var school = ConvertToEntity(schoolExtendedDto);
        _schoolRepository.Update(school);
    }

    private School ConvertToEntity(SchoolExtendedDto dto)
    {
        return new School()
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Address = dto.Address,
            Email = dto.Email,
            City = dto.City,
            PhoneNumber = dto.PhoneNumber,
            Type = (DataAccess.Enum.SchoolType)dto.TypeOfSchool,
        };
    }
    private School ConvertToEntity(SchoolDto dto)
    {
        return new School()
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Address = dto.Address,
            Email = dto.Email,
            City = dto.City,
            PhoneNumber = dto.PhoneNumber,
            Type = (DataAccess.Enum.SchoolType)dto.TypeOfSchool,
        };
    }

    private SchoolExtendedDto ConvertToDto(School school)
    {
        return new SchoolExtendedDto()
        {
            Id = school.Id,
            Name = school.Name,
            Address = school.Address,
            Email = school.Email,
            City = school.City,
            PhoneNumber = school.PhoneNumber,
            TypeOfSchool = (DTOs.Enums.SchoolTypeDto)school.Type,
        };
    }
    private bool ValidateStudentCreateDto(SchoolDto dtoObj)
    {
        _schoolRepository.EmailContains(dtoObj.Email);

        if (string.IsNullOrWhiteSpace(dtoObj.Name) || dtoObj.Name.Length > 50)
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(dtoObj.City) || dtoObj.City.Length > 50)
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(dtoObj.PhoneNumber) || dtoObj.PhoneNumber.Length < 9)
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(dtoObj.Email) || !dtoObj.Email.EndsWith("@gmail.com")
            || dtoObj.Email.Length > 100 || dtoObj.Email.Length <= 10)
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(dtoObj.Address) || dtoObj.Address.Length > 50 || dtoObj.Address.Length < 8)
        {
            return false;
        }

        return true;
    }
}
