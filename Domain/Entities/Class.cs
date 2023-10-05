using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Class:BaseEntity
{
    public string Name { get; set; }
    public int StudentIdFk { get; set; }
    public Student Student { get; set; }
    public ICollection<Student> Students { get; set; }
    public ICollection<Subject> Subjects{ get; set; }
    
}