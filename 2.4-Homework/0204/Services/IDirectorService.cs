using _0204.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0204.Services
{
    public interface IDirectorService
    {
        public abstract Director AddDirector(Director director);
        public bool DeleteDirector(Guid directorId);
        public bool UpdateDirector(Director director);
        public List<Director> GetAllDirectors();
    }
}
