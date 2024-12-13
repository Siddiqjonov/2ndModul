using _0202.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _0202.Services
{
    internal class TestService
    {
        private string testFilePath;
        private List<Test> _tests;

        // Constructor
        public TestService()
        {
            testFilePath = "../../../Data/Test.json";
            if (File.Exists(testFilePath) is false)
            {
                File.WriteAllText(testFilePath, "[]");
            }

            _tests = new List<Test>();
            _tests = GetAllTests();
        }

        private Test GetById(Guid testId)
        {
            
            foreach(Test test in _tests)
            {
                if(test.Id == testId)
                {
                    return test;
                }
            }
            return null;
        }


        // Create
        // Adds tests
        public Test AddTest(Test test)
        {
            test.Id = Guid.NewGuid();
            _tests.Add(test);
            SaveData();
            return test;
        }

        public bool DeleteTest(Guid testId)
        {
            var testFromDb = GetById(testId);
            if (testFromDb is null)
                return false;

            _tests.Remove(testFromDb);
            SaveData();
            return true;
        }



        public bool UpdateTest(Test test)
        {
            var testFromDb = GetById(test.Id); 
            if (testFromDb is null)
            {
                return false;
            }

            var index = _tests.IndexOf(testFromDb);
            _tests[index] = test;
            SaveData();
            return true;

        }

        public List<Test> GetAllTests()
        {
            return GetTests();
        }



        public List<Test> GetRandomTests(int count)
        {
            if (count >= _tests.Count)
            {
                return _tests;
            }

            var randomTests = new List<Test>();
            var rand = new Random();
            for(int i = 0; i < count;)
            {
                var option = rand.Next(0, _tests.Count);
                if (randomTests.Contains(_tests[option]) is false)
                {
                    randomTests.Add(_tests[option]);
                    i++;
                }
            }
            return randomTests;
        }


        // Read
        // Gets students
        public List<Test> GetTests()
        {
            var testsJson = File.ReadAllText(testFilePath);
            var tests = JsonSerializer.Deserialize<List<Test>>(testsJson);
            return tests;
        }

        // Save tests as json file
        private void SaveData()
        {
            var testsJson = JsonSerializer.Serialize(_tests);
            File.WriteAllText(testFilePath, testsJson);
        }
    }
}
