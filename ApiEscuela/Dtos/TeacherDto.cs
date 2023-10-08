using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEscuela.Dtos;
public class TeacherDto
{
    public int Id {get; set;}
public string Name { get; set; }
public string Lastname { get; set; }
public List<SubjectDto> Subjects { get; set; }
public UserDto User { get; set; }
}