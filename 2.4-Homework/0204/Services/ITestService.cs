using _0204.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0204.Services
{
    public interface ITestService
    {
        public Test AddTest(Test test);
        public bool DeleteTest(Guid testId);
        public bool UpdateTest(Test test);
        public List<Test> GetAllTests();
        public List<Test> GetRandomTests(int count);

    }
}
