using _0202.Moduls;
using _0202.Services;
using System.Numerics;

namespace _0202
{
    internal class Program
    {
        // Default usernames and passwords
        // Minister of public education
        private static string ministerUserName = "Minister";
        private static string ministerPassword = "Minister123";
        // Director
        private static string directorUserName = "Director";
        private static string directorPassword = "Director123";
        // Techer
        private static string teacherUserName = "Teacher";
        private static string teacherPassword = "Teacher123";
        // Student1
        static string student1UserName = "Bob";
        static string student1Password = "Bob123";
        // Student2
        static string student2UserName = "Devid";
        static string student2Password = "Devid123";

        static void Main(string[] args)
        {
            StartFrontEnd();
        }

        public static void StartFrontEnd()
        {
            GetUsernameAndPassword();
        }

        public static void GetUsernameAndPassword()
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            Console.Write("Enter password: ");
            var password = Console.ReadLine();
            DetectUser(username, password);
        }

        public static void DetectUser(string username, string password)
        {
            bool isMinister = username == ministerUserName && password == ministerPassword;
            bool isDirector = username == directorUserName && password == directorPassword;
            bool isTeacher = username == teacherUserName && password == teacherPassword;
            bool isStudent1 = username == student1UserName && password == student1Password;
            bool isStudent2 = username == student2UserName && password == student2Password;


            if (isMinister)
            {
                Console.Clear();
                Console.WriteLine("Welcome Minister of public education");
                ControlDirectorsAsAnEdicationMinister();
            }
            else if (isDirector)
            {
                Console.Clear();
                Console.WriteLine("Welcome Director");
                ControlTeachersAsADirector();
            }
            else if (isTeacher)
            {
                Console.Clear();
                Console.WriteLine("Welcome Teacher");
                ControlStudentsAndTestsAsATeacher();
            }
            else if (isStudent1)
            {
                Console.Clear();
                Console.WriteLine($"Welome {student1UserName}");
                TestAndHistoryOfStudetnts();
            }
            else if (isStudent2)
            {
                Console.Clear();
                Console.WriteLine($"Welome {student2UserName}");
                TestAndHistoryOfStudetnts();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Username or Password is incorrect");
                GetUsernameAndPassword();
            }
        }

        // Local variables
        private static int trueAnswer = 0;
        private static int falseAnswer = 0;



        // Test And History Of Studetnts
        public static void TestAndHistoryOfStudetnts()
        {
            var testServise = new TestService();
            var quit = false;

            while (!quit)
            {
                Console.WriteLine("0. Quit");
                Console.WriteLine("1. Solve tests");
                Console.WriteLine("2. Result history");

                Console.Write("Enter: ");
                var choice = int.Parse(Console.ReadLine());
                if (choice == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Quiting...");
                    Console.ReadLine();
                    quit = true;
                }
                
                else if (choice == 1)
                {
                    Console.Clear();
                    Console.WriteLine(new string('-', 30));
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("<< Test >>");
                    Console.ResetColor();
                    Console.WriteLine(new string('-', 30));

                    Console.Write("Enter test amount: ");
                    var testAmount = int.Parse(Console.ReadLine());
                    Console.WriteLine(new string('-', 30));

                    int number = 0;
                    var tests = testServise.GetRandomTests(testAmount);
                    foreach(var testt in tests)
                    {
                        Console.WriteLine($"{++number}. {testt.QuestionTest}");
                        Console.WriteLine($"A: {testt.AVariant}");
                        Console.WriteLine($"B: {testt.BVariant}");
                        Console.WriteLine($"C: {testt.CVariant}");
                        Console.Write("Answer: ");
                        var answer = Console.ReadLine();

                        Console.WriteLine(new string('-', 30));
                        if (answer == testt.Answer)
                        {
                            trueAnswer++;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("True answer");
                            Console.WriteLine("True answer amount: {0}", trueAnswer);
                            Console.ResetColor();
                        }
                        else
                        {
                            falseAnswer++;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("False answer");
                            Console.WriteLine("False answer amount: {0}", falseAnswer);
                            Console.ResetColor();

                        }
                        Console.WriteLine(new string('-', 30));
                    }
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (choice == 2)
                {

                    Console.Clear();
                    Console.WriteLine(new string('-', 30));
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("<< Test history >>");
                    Console.ResetColor();
                    Console.WriteLine(new string('-', 30));

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("True answer amount: {0}", trueAnswer);
                    Console.ResetColor();
                    Console.WriteLine(new string('-', 30));

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("False answer amount: {0}", falseAnswer);
                    Console.ResetColor();
                    Console.WriteLine(new string('-', 30));

                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Incorrect option!!");
                    Console.WriteLine("Try again!!");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
            }
        }


        // Control Directors As An Edication Minister
        public static void ControlDirectorsAsAnEdicationMinister()
        {
            var directorService = new DirectorService();

            bool quit = false;
            while (!quit)
            {
                Console.WriteLine(new string('-', 30));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("<< Control directors menu >>");
                Console.ResetColor();
                Console.WriteLine(new string('-', 30));


                Console.WriteLine("0. Quit");
                Console.WriteLine("1. Add director");
                Console.WriteLine("2. Read directors (see)");
                Console.WriteLine("3. Delete director");
                Console.WriteLine("4. Update director");

                Console.WriteLine(new string('-', 30));
                Console.Write("Enter: ");
                var option = int.Parse(Console.ReadLine());

                Console.Clear();

                if (option == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Quiting...");
                    Console.ReadLine();
                    quit = true;
                }
                else if (option == 1)
                {
                    var director = new Director();

                    Console.Write("Enter director's first name: ");
                    director.FirstName = Console.ReadLine();

                    Console.Write("Enter director's last name: ");
                    director.LastName = Console.ReadLine();

                    Console.Write("Enter the school name: ");
                    director.SchoolName = Console.ReadLine();

                    directorService.AddDirector(director);
                    Console.WriteLine("Successfully added");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (option == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Directors list");
                    var directors = directorService.GetAllDirectors();
                    int count = 0;
                    foreach (var director in directors)
                    {
                        Console.WriteLine(new string('-', 30));
                        Console.WriteLine("Director number: {0}", ++count);
                        Console.WriteLine("Id: {0}", director.Id);
                        Console.WriteLine("First name: {0}", director.FirstName);
                        Console.WriteLine("Last name: {0}", director.LastName);
                        Console.WriteLine("School name: {0}", director.SchoolName);
                        Console.WriteLine(new string('-', 30));
                    }

                    Console.ReadLine();
                    Console.Clear();
                }
                else if (option == 3)
                {
                    Console.Clear();
                    Console.Write("Enter director's Id to delelete: ");
                    var directorId = Guid.Parse(Console.ReadLine());

                    directorService.DeleteDirector(directorId);
                    Console.WriteLine("Successfully updated");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (option == 4)
                {
                    var director = new Director();

                    Console.Write("Enter director's Id to update: ");
                    director.Id = Guid.Parse(Console.ReadLine());

                    Console.Write("Enter director's first name: ");
                    director.FirstName = Console.ReadLine();

                    Console.Write("Enter director's last name: ");
                    director.LastName = Console.ReadLine();

                    Console.Write("Enter the school name: ");
                    director.SchoolName = Console.ReadLine();

                    directorService.UpdateDirector(director);
                    Console.WriteLine("Successfully updated");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Incorrect option!!");
                    Console.WriteLine("Try again!!");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
            }
        }

        // Control Teachers As A Director
        public static void ControlTeachersAsADirector()
        {
            var teacherService = new TeacherServices();

            var quit = false;
            while (!quit)
            {
                Console.WriteLine(new string('-', 30));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("<< Control teachers menu >>");
                Console.ResetColor();
                Console.WriteLine(new string('-', 30));


                Console.WriteLine("0. Quit");
                Console.WriteLine("1. Add teacher");
                Console.WriteLine("2. Read teachers (see)");
                Console.WriteLine("3. Delete teacher");
                Console.WriteLine("4. Update teachers");

                Console.WriteLine(new string('-', 30));
                Console.Write("Enter: ");
                var option = int.Parse(Console.ReadLine());

                Console.Clear();

                if (option == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Quiting...");
                    Console.ReadLine();
                    quit = true;
                }
                else if (option == 1)
                {

                    // new object
                    Teacher teacher = new Teacher();

                    Console.Write("Enter teacher's first name: ");
                    teacher.FirstName = Console.ReadLine();

                    Console.Write("Enter teacher's last name: ");
                    teacher.LastName = Console.ReadLine();

                    Console.Write("Enter teacher's age: ");
                    teacher.Age = int.Parse(Console.ReadLine());

                    Console.Write("Enter teachers's subject: ");
                    teacher.Subject = Console.ReadLine();

                    Console.Write("Enter teacher's gender: ");
                    teacher.Gender = Console.ReadLine();

                    teacherService.AddTeacher(teacher);
                    Console.WriteLine("Successfully added");
                    Console.ReadLine();
                    Console.Clear();
                }

                else if (option == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Teachers list");
                    var teachers = teacherService.GetAllTeachers();
                    int count = 0;
                    foreach (var teacherr in teachers)
                    {
                        Console.WriteLine(new string('-', 30));
                        Console.WriteLine("Teacher number: {0}", ++count);
                        Console.WriteLine("Id: {0}", teacherr.Id);
                        Console.WriteLine("First name: {0}", teacherr.FirstName);
                        Console.WriteLine("Last name: {0}", teacherr.LastName);
                        Console.WriteLine("Age: {0}", teacherr.Age);
                        Console.WriteLine("Subject: {0}", teacherr.Subject);
                        Console.WriteLine("Gender: {0}", teacherr.Gender);
                        Console.WriteLine(new string('-', 30));
                    }
                    Console.ReadLine();
                    Console.Clear();
                }

                else if (option == 3)
                {
                    Console.Clear();
                    Console.Write("Enter teacher's Id to delte: ");
                    var teacherId = Guid.Parse(Console.ReadLine());
                    teacherService.DeleteTeacher(teacherId);
                    Console.WriteLine("Seccessfully delelted");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (option == 4)
                {
                    // Creating a new object of a teacher
                    Teacher teacher = new Teacher();

                    Console.Write("Enter teacher's Id to update: ");
                    teacher.Id = Guid.Parse(Console.ReadLine());

                    Console.Write("Enter teacher's first name: ");
                    teacher.FirstName = Console.ReadLine();

                    Console.Write("Enter teacher's last name: ");
                    teacher.LastName = Console.ReadLine();

                    Console.Write("Enter teacher's age: ");
                    teacher.Age = int.Parse(Console.ReadLine());

                    Console.Write("Enter teachers's subject: ");
                    teacher.Subject = Console.ReadLine();

                    Console.Write("Enter teacher's gender: ");
                    teacher.Gender = Console.ReadLine();

                    teacherService.UpdateTeacher(teacher);
                    Console.WriteLine("Successfully added");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Incorrect option!!");
                    Console.WriteLine("Try again!!");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
            }
        }


        // Control Students And Tests As A Teacher
        public static void ControlStudentsAndTestsAsATeacher()
        {
            var controlStudents = new StudentService();
            var controlTests = new TestService();
            Student student = new Student();

            var quit = true;
            while (quit)
            {
                Console.WriteLine("0. Quit");
                Console.WriteLine("1. Work with students");
                Console.WriteLine("2. Work with tests");
                Console.Write("Enter: ");
                var choice = int.Parse(Console.ReadLine());
                Console.Clear();
                if (choice == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Quiting...");
                    Console.ReadLine();
                    quit = false;
                }
                else if (choice == 1)
                {
                    bool back = true;
                    while (back)
                    {
                        Console.WriteLine(new string('-', 30));
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("<< Studet control menu >>");
                        Console.ResetColor();
                        Console.WriteLine(new string('-', 30));
                        Console.WriteLine("0. Back");
                        Console.WriteLine("1. Add student");
                        Console.WriteLine("2. Read students (see)");
                        Console.WriteLine("3. Delete student");
                        Console.WriteLine("4. Update student");
                        Console.WriteLine(new string('-', 30));
                        Console.Write("Enter: ");
                        int option = int.Parse(Console.ReadLine());
                        Console.WriteLine(new string('-', 30));
                        Console.Clear();

                        if (option == 0)
                        {
                            back = false;
                        }

                        else if (option == 1)
                        {
                            Console.Write("Enter student's first name: ");
                            student.FirstName = Console.ReadLine();

                            Console.Write("Enter student's last name: ");
                            student.LastName = Console.ReadLine();

                            Console.Write("Enter student's age: ");
                            student.Age = int.Parse(Console.ReadLine());

                            Console.Write("Enter student's degree: ");
                            student.Degree = Console.ReadLine();

                            Console.Write("Enter student's gender: ");
                            student.Gender = Console.ReadLine();

                            controlStudents.AddStudent(student);
                            Console.WriteLine("Successfully added!!!");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (option == 2)
                        {
                            List<Student> students = controlStudents.GetAllStudents();
                            int counter = 0;
                            Console.WriteLine(new string('-', 30));
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("<< Students' list >>");
                            Console.ResetColor();
                            foreach (var studentt in students)
                            {
                                Console.WriteLine(new string('-', 30));
                                Console.WriteLine($"Student number: {++counter}");
                                Console.WriteLine("Id: {0}", studentt.Id);
                                Console.WriteLine("First name: {0}", studentt.FirstName);
                                Console.WriteLine("Last name: {0}", studentt.LastName);
                                Console.WriteLine("Age: {0}", studentt.Age);
                                Console.WriteLine("Dgree: {0}", studentt.Degree);
                                Console.WriteLine("Gender: {0}", studentt.Gender);
                                Console.WriteLine(new string('-', 30));
                            }
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (option == 3)
                        {
                            Console.Write("Enter student's Id to delete: ");
                            var studentId = Guid.Parse(Console.ReadLine());
                            controlStudents.DeleteStudents(studentId);
                            Console.WriteLine("Successfully deleted!!!");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (option == 4)
                        {
                            Console.Write("Enter student's Id to Update: ");
                            student.Id = Guid.Parse(Console.ReadLine());

                            Console.Write("Enter student's first name: ");
                            student.FirstName = Console.ReadLine();

                            Console.Write("Enter student's last name: ");
                            student.LastName = Console.ReadLine();

                            Console.Write("Enter student's age: ");
                            student.Age = int.Parse(Console.ReadLine());

                            Console.Write("Enter student's degree: ");
                            student.Degree = Console.ReadLine();

                            Console.Write("Enter student's gender: ");
                            student.Gender = Console.ReadLine();

                            controlStudents.UpdateStudents(student);
                            Console.WriteLine("Successfully updated!!!");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Incorrect option!!");
                            Console.WriteLine("Try again!!");
                            Console.ReadLine();
                            Console.Clear();
                            continue;
                        }
                    }
                }
                else if (choice == 2)
                {
                    bool back = false;
                    while (!back)
                    {
                        Console.WriteLine(new string('-', 30));
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("<< Test control menu >>");
                        Console.ResetColor();
                        Console.WriteLine(new string('-', 30));
                        Console.WriteLine("0. Back");
                        Console.WriteLine("1. Add test");
                        Console.WriteLine("2. Read tests (see)");
                        Console.WriteLine("3. Delete test");
                        Console.WriteLine("4. Update tests");
                        Console.WriteLine(new string('-', 30));
                        Console.Write("Enter: ");
                        int option = int.Parse(Console.ReadLine());
                        Console.WriteLine(new string('-', 30));
                        Console.Clear();
                        if (option == 0)
                        {
                            back = true;
                        }
                        else if (option == 1)
                        {
                            Test test = new Test();
                            Console.Write("Enter test: ");
                            test.QuestionTest = Console.ReadLine();

                            Console.Write("Enter A variant: ");
                            test.AVariant = Console.ReadLine();

                            Console.Write("Enter B variant: ");
                            test.BVariant = Console.ReadLine();

                            Console.Write("Enter C variant: ");
                            test.CVariant = Console.ReadLine();

                            Console.Write("Enter answer: ");
                            test.Answer = Console.ReadLine();

                            controlTests.AddTest(test);
                            Console.WriteLine("Quession added!!!");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (option == 2)
                        {
                            List<Test> tests = controlTests.GetAllTests();
                            int counter = 0;
                            Console.WriteLine(new string('-', 30));
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("<< Test list >>");
                            Console.ResetColor();
                            foreach (var testt in tests)
                            {
                                Console.WriteLine(new string('-', 30));
                                Console.WriteLine($"Test number: {++counter}");
                                Console.WriteLine("Id: {0}", testt.Id);
                                Console.WriteLine("Question: {0}", testt.QuestionTest);
                                Console.WriteLine("A variant: {0}", testt.AVariant);
                                Console.WriteLine("B variant: {0}", testt.BVariant);
                                Console.WriteLine("C variant: {0}", testt.CVariant);
                                Console.WriteLine("Answer: {0}", testt.Answer);
                                Console.WriteLine(new string('-', 30));
                            }
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (option == 3)
                        {
                            Console.Write("Enter test Id to delete: ");
                            var testId = Guid.Parse(Console.ReadLine());
                            controlTests.DeleteTest(testId);
                            Console.WriteLine("Successfully deleted!!!");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (option == 4)
                        {
                            Test test = new Test();

                            Console.Write("Enter test Id to update: ");
                            test.Id = Guid.Parse(Console.ReadLine());

                            Console.Write("Enter test: ");
                            test.QuestionTest = Console.ReadLine();

                            Console.Write("Enter A variant: ");
                            test.AVariant = Console.ReadLine();

                            Console.Write("Enter B variant: ");
                            test.BVariant = Console.ReadLine();

                            Console.Write("Enter C variant: ");
                            test.CVariant = Console.ReadLine();

                            Console.Write("Enter answer: ");
                            test.Answer = Console.ReadLine();

                            controlTests.UpdateTest(test);
                            Console.WriteLine("Successfully updated!!!");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Incorrect option!!");
                            Console.WriteLine("Try again!!");
                            Console.ReadLine();
                            Console.Clear();
                            continue;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect option!!");
                    Console.WriteLine("Try again!!");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
            }
        }


    }
}
