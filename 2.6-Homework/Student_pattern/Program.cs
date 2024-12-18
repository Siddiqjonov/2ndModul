using Student_pattern.Services;
using Student_pattern.Services.DTOs;

namespace Student_pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<< Welcome >>");
            var quit = false;
            StudentService studentService = new StudentService();

            while (!quit)
            {
                //Console.Clear();
                Console.WriteLine("0. Quit ");
                Console.WriteLine("1. Add student");
                Console.WriteLine("2. Read student");
                Console.WriteLine("3. Update student");
                Console.WriteLine("4. Delete student");
                Console.Write("Enter: ");
                var option = int.Parse(Console.ReadLine());
                Console.Clear();

                if(option == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Quiting...");
                    Console.ReadLine();
                    quit = true;
                }
                else if (option == 1)
                {
                    Console.Clear();
                    CreateStudentDto createStudentDto = new CreateStudentDto();
                    Console.Write("Enter first name: ");
                    createStudentDto.FirstName = Console.ReadLine();
                    Console.Write("Enter last name: ");
                    createStudentDto.LastName = Console.ReadLine();
                    Console.Write("Enter age: ");
                    createStudentDto.Age = int.Parse(Console.ReadLine());
                    Console.Write("Enter school name: ");
                    createStudentDto.School = Console.ReadLine();
                    Console.Write("Enter email: ");
                    createStudentDto.Email = Console.ReadLine();
                    Console.Write("Enter password: ");
                    createStudentDto.Password = Console.ReadLine();

                    studentService.AddStudent(createStudentDto);
                    Console.WriteLine("Added successfully");
                    Console.ReadLine();
                    Console.Clear();

                }
                else if (option == 2)
                {
                    Console.Clear();
                    var stusents = studentService.GetAllStudents();
                    foreach (var student in stusents)
                    {
                        Console.WriteLine(student.FirstName);
                        Console.WriteLine(student.LastName);
                        Console.WriteLine(student.Age);
                        Console.WriteLine(student.School);
                        Console.WriteLine(student.Email);
                        Console.WriteLine(student.Id);
                        Console.WriteLine(new string('-',30));
                    }
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (option == 3)
                {
                    Console.Clear();
                    UpdateStudentDto updateStudentdto = new UpdateStudentDto();

                    Console.Write("Enter student id to update: ");
                    updateStudentdto.Id = Guid.Parse(Console.ReadLine());
                    Console.Write("Enter first name: ");
                    updateStudentdto.FirstName = Console.ReadLine();
                    Console.Write("Enter last name: ");
                    updateStudentdto.LastName = Console.ReadLine();
                    Console.Write("Enter age: ");
                    updateStudentdto.Age = int.Parse(Console.ReadLine());
                    Console.Write("Enter school name: ");
                    updateStudentdto.School = Console.ReadLine();
                    Console.Write("Enter email: ");
                    updateStudentdto.Email = Console.ReadLine();
                    Console.Write("Enter password: ");
                    updateStudentdto.Password = Console.ReadLine();
                    
                    studentService.UpdateStudent(updateStudentdto);
                    Console.WriteLine("Updated successfully");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (option == 4)
                {
                    Console.Clear();
                    Console.Write("Enter student id: ");
                    studentService.DeleteStudent(Guid.Parse(Console.ReadLine()));
                    Console.WriteLine("Deleted successfully");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong option");
                    Console.WriteLine("Try again");
                    Console.Clear();
                    continue;
                }
            }
        }
    }
}
