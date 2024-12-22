using School_CRUD.DataAccess.Entitiy;

namespace School_CRUD.Repositories;

public interface ISchoolRepository
{
    Guid Write(School school);
    List<School> ReadAll();
    void Delete(Guid id);
    void Update(School school);
    School GetById(Guid id);
    void EmailContains(string email);
}