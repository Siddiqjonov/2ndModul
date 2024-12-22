using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_CRUD.Services.DTOs;

public class SchoolExtendedDto : SchoolDto
{
    public Guid Id { get; set; }
}
