using School_CRUD.Services;
using School_CRUD.Services.DTOs;
using School_CRUD.Services.DTOs.Enums;

namespace School_CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SchoolService schoolService = new SchoolService();
            
            SchoolDto school1 = new SchoolDto()
            {
                Name = "Hamza",
                City = "Tashkent, Piskent",
                PhoneNumber = "991234567",
                Email = "HamzaschoolN1@gmail.com",
                Address = "Amir Temur 34",
                TypeOfSchool = SchoolTypeDto.Public,
            };
            SchoolDto school2 = new SchoolDto()
            {
                Name = "Oybek",
                City = "Tashkent, Piskent",
                PhoneNumber = "994582132",
                Email = "OybekschoolN5@gmail.com",
                Address = "Begobot 23",
                TypeOfSchool = SchoolTypeDto.International,
            };


            schoolService.AddSchool(school1);
            schoolService.AddSchool(school2);

            Console.ReadLine();
        }
    }
}
