using _0204.Moduls;
using _0204.Services;
using System.Text.Json;

namespace _0204.Services;

public class DirectorService : IDirectorService
{
    private string directorFilePath;
    private List<Director> _directors;

    public DirectorService()
    {
        directorFilePath = "../../../Data/Director.json";
        if (File.Exists(directorFilePath) is false)
        {
            File.WriteAllText(directorFilePath, "[]");
        }

        _directors = new List<Director>();
        _directors = GetAllDirectors();
    }

    public List<Director> GetAllDirectors()
    {
        return GetDirectors();
    }

    public Director AddDirector(Director director)
    {
        director.Id = Guid.NewGuid();
        _directors.Add(director);
        SaveData();
        return director;
    }

    public Director GetById(Guid directorId)
    {
        foreach (var director in _directors)
        {
            if (director.Id == directorId)
            {
                return director;
            }
        }
        return null;
    }

    public bool DeleteDirector(Guid directorId)
    {
        var directorFromDb = GetById(directorId);
        {
            if (directorFromDb is null)
            {
                return false;
            }
        }

        _directors.Remove(directorFromDb);
        SaveData();
        return true;
    }

    public bool UpdateDirector(Director director)
    {
        var directorFromDb = GetById(director.Id);
        if (directorFromDb is null)
        {
            return false;
        }

        var index = _directors.IndexOf(directorFromDb);
        _directors[index] = director;
        SaveData();
        return true;
    }


    public void SaveData()
    {
        var directorJson = JsonSerializer.Serialize(_directors);
        File.WriteAllText(directorFilePath, directorJson);
    }

    private List<Director> GetDirectors()
    {
        var directorJson = File.ReadAllText(directorFilePath);
        var directors = JsonSerializer.Deserialize<List<Director>>(directorJson);
        return directors;
    }
}
