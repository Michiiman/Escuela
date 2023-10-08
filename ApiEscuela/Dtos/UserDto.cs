using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEscuela.Dtos;
public class UserDto
{
    public int Id {get; set;}
public string Email { get; set; }
public string Password { get; set; }
public int StudentIdFk{ get; set; }
public StudentDto Student { get; set; }
public int TeacherIdFk{ get; set; }
public TeacherDto Teacher { get; set; }
}