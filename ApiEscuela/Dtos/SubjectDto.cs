using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEscuela.Dtos;
public class SubjectDto
{
    public int Id {get; set;}
    public string Name { get; set; }
    public int TeacherIdFk { get; set; }
    public TeacherDto Teacher { get; set; }
    public int StudentIdFk { get; set; }
    public StudentDto Student{ get; set; }
    public List<GradeDto> Grades { get; set; }
}