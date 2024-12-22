using School_CRUD.DataAccess.Enum;
using School_CRUD.Services.DTOs.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_CRUD.Services.DTOs;

public class SchoolDto
{
    public string Name { get; set; }
    public string City { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public SchoolTypeDto TypeOfSchool { get; set; }
}
