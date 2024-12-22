using School_CRUD.DataAccess.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace School_CRUD.Repositories;

public class SchoolRepository : ISchoolRepository
{
    private readonly string _path;
    private readonly List<School> _schools;
    public SchoolRepository()
    {
        _path = "../../../DataAccess/Data/Schools.json";
        _schools = new List<School>();
        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }

        _schools = ReadAll();
    }

    public void Delete(Guid id)
    {
        var studentFromDb = GetById(id);
        _schools.Remove(studentFromDb);
        SaveData();
    }

    public School GetById(Guid id)
    {
        var schools = ReadAll();
        foreach (var school in schools)
        {
            if(school.Id == id)
            {
                return school;
            }
        }

        throw new Exception("IdNotFoundExeption");
    }

    public List<School> ReadAll()
    {
        var schoolJson = File.ReadAllText(_path);
        var schools = JsonSerializer.Deserialize<List<School>>(schoolJson);
        return schools;
    }

    public void Update(School school)
    {
        var schoolFromDb = GetById(school.Id);
        var index = _schools.IndexOf(schoolFromDb);
        _schools[index] = school;
        SaveData();
    }

    public Guid Write(School school)
    {
        _schools.Add(school);
        SaveData();
        return school.Id;
    }

    public void EmailContains(string email)
    {
        foreach (var school in _schools)
        {
            if (school.Email == email)
            {
                throw new Exception("EmailAlreadyExists");
            }
        }
    }

    private void SaveData()
    {
        var schoolJson = JsonSerializer.Serialize(_schools);
        File.WriteAllText(_path, schoolJson);
    }
}
