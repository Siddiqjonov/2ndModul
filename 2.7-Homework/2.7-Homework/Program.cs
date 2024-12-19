using _2._7_Homework.DataAccess.Enums;
using _2._7_Homework.Services;
using _2._7_Homework.Services.DTOs;
using _2._7_Homework.Services.DTOs.Enums;

namespace _2._7_Homework;

internal class Program
{
    static void Main(string[] args)
    {
        /*
            Guid AddStudent(StudentCreateDto dto);
            List<StudentGetDto> GetStudents();
            void DeleleStudent(Guid studnetId);
            void UpdateStudent(StudentUpdateDto dto);
            //StudentGetDto GetStudentById(Guid studentId);
            List<StudentGetDto> GetStudentsByDegree(DegreeStatusDto degreeStatusDto);
            List<StudentGetDto> GetStudentsByGender(GenderDto genderDto);
        */
        IStudentService studentService = new StudentService();
        Console.WriteLine("<< Welcome >>");
        var quit = false;
        while (!quit)
        {
            Console.WriteLine("0. Quit");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Read All Students");
            Console.WriteLine("3. Read Students By Degree");
            Console.WriteLine("4. Read Students By Gender");
            Console.WriteLine("5. Delete Students");
            Console.WriteLine("6. Update Students");
            Console.WriteLine(new string('-', 30));
            Console.Write("Enter: ");
            var option = int.Parse(Console.ReadLine());
            Console.Clear();

            if (option == 0)
            {
                Console.Clear();
                Console.WriteLine("Quitting...");
                Console.ReadLine();
                quit = true;
            }
            else if (option == 1)
            {
                StudentCreateDto obj = new StudentCreateDto();

                Console.Write("Enter first name: ");
                obj.FirstName = Console.ReadLine();
                Console.Write("Enter last name: ");
                obj.LastName = Console.ReadLine();
                Console.Write("Enter age: ");
                obj.Age = int.Parse(Console.ReadLine());
                Console.Write("Enter email: ");
                obj.Email = Console.ReadLine();
                Console.Write("Enter password: ");
                obj.Password = Console.ReadLine();
                Console.Write("Gender (1. Male 2. Female): ");
                var gender = int.Parse(Console.ReadLine());
                obj.Gender = gender == 1 ? GenderDto.Male : gender == 2 ? GenderDto.Female : GenderDto.Unknown;
                Console.Write("Degree (1. Bachelor 2. Master 3. Phd): ");
                var degree = int.Parse(Console.ReadLine());
                obj.Degree = degree == 1 ? DegreeStatusDto.Bachelor : degree == 2 ?
                             DegreeStatusDto.Master : degree == 3 ? DegreeStatusDto.Phd : DegreeStatusDto.Not_Shown;

                studentService.AddStudent(obj);

                Console.WriteLine("Added");
                Console.ReadLine();
                Console.Clear();
            }
            else if (option == 2)
            {
                var students = studentService.GetStudents();
                foreach (var student in students)
                {
                    Console.WriteLine("Id: " + student.Id);
                    Console.WriteLine("First name: " + student.FirstName);
                    Console.WriteLine("Last name: " + student.LastName);
                    Console.WriteLine("Age: " + student.Age);
                    Console.WriteLine("Email: " + student.Email);
                    Console.WriteLine("Degree: " + student.Degree);
                    Console.WriteLine("Gender: " + student.Gender);
                    Console.WriteLine(new string('-', 30));
                }
                Console.ReadLine();
                Console.Clear();
            }
            else if (option == 3)
            {
                Console.Write("Degree (1. Bachelor 2. Master 3. Phd: ");
                var degree = int.Parse(Console.ReadLine());
                var studentsByDegree = studentService.GetStudentsByDegree(degree == 1 ? DegreeStatusDto.Bachelor : degree == 2 ?
                             DegreeStatusDto.Master : degree == 3 ? DegreeStatusDto.Phd : DegreeStatusDto.Not_Shown);
                foreach (var student in studentsByDegree)
                {
                    Console.WriteLine("Id: " + student.Id);
                    Console.WriteLine("First name: " + student.FirstName);
                    Console.WriteLine("Last name: " + student.LastName);
                    Console.WriteLine("Age: " + student.Age);
                    Console.WriteLine("Email: " + student.Email);
                    Console.WriteLine("Degree: " + student.Degree);
                    Console.WriteLine("Gender: " + student.Gender);
                    Console.WriteLine(new string('-', 30));
                }
                Console.ReadLine();
                Console.Clear();
            }
            else if (option == 4)
            {
                Console.Write("Gender (1. Male 2. Female): ");
                var gender = int.Parse(Console.ReadLine());
                var studentsByGender = studentService.GetStudentsByGender(gender == 1 ? GenderDto.Male : gender == 2 ?
                    GenderDto.Female : GenderDto.Unknown);
                foreach (var student in studentsByGender)
                {
                    Console.WriteLine(student.Id);
                    Console.WriteLine(student.FirstName);
                    Console.WriteLine(student.LastName);
                    Console.WriteLine(student.Age);
                    Console.WriteLine(student.Email);
                    Console.WriteLine(student.Degree);
                    Console.WriteLine(student.Gender);
                    Console.WriteLine(new string('-', 30));
                }
                Console.ReadLine();
                Console.Clear();
            }
            else if (option == 5)
            {
                Console.Write("Enter student's id): ");
                var id = Guid.Parse(Console.ReadLine());
                studentService.DeleleStudent(id);
                Console.WriteLine("Deleted");
                Console.ReadLine();
                Console.Clear();
            }
            else if (option == 6)
            {
                StudentUpdateDto updateStudnet = new StudentUpdateDto();

                Console.Write("Enter id to update: ");
                updateStudnet.Id = Guid.Parse(Console.ReadLine());
                Console.Write("Enter first name: ");
                updateStudnet.FirstName = Console.ReadLine();
                Console.Write("Enter last name: ");
                updateStudnet.LastName = Console.ReadLine();
                Console.Write("Enter age: ");
                updateStudnet.Age = int.Parse(Console.ReadLine());
                Console.Write("Enter email: ");
                updateStudnet.Email = Console.ReadLine();
                Console.Write("Enter password: ");
                updateStudnet.Password = Console.ReadLine();
                Console.Write("Gender (1. Male 2. Female: ");
                var gender = int.Parse(Console.ReadLine());
                updateStudnet.Gender = gender == 1 ? GenderDto.Male : gender == 2 ? GenderDto.Female : GenderDto.Unknown;
                Console.Write("Degree (1. Bachelor 2. Master 3. Phd: ");
                var degree = int.Parse(Console.ReadLine());
                updateStudnet.Degree = degree == 1 ? DegreeStatusDto.Bachelor : degree == 2 ?
                             DegreeStatusDto.Master : degree == 3 ? DegreeStatusDto.Phd : DegreeStatusDto.Not_Shown;

                studentService.UpdateStudent(updateStudnet);

                Console.WriteLine("Updated");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Wrong option");
                Console.WriteLine("Try again");
                Console.ReadLine();
                Console.Clear();
                continue;
            }
        }
    }
}
