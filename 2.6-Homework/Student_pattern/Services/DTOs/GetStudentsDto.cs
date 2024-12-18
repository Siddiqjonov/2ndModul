using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_pattern.Services.DTOs;

public class GetStudentsDto : BaseStudentDto
{
    public Guid Id { get; set; }
}
