using School_CRUD.Services.DTOs;

namespace School_CRUD.Services;

public interface ISchoolService
{
    Guid AddSchool(SchoolDto schoolDto);
    List<SchoolExtendedDto> GetAllShcools();
    void DeleteSchool(Guid schoolId);
    void UpdateSchool(SchoolExtendedDto schoolExtendedDto);
    SchoolExtendedDto GetSchoolById(Guid schoolId);
}