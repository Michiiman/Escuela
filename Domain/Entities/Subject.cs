namespace Domain.Entities;
public class Subject:BaseEntity
{
    public string Name { get; set; }
    public int TeacherIdFk { get; set; }
    public Teacher Teacher { get; set; }
    public int ClassIdFk { get; set; }
    public Class Class { get; set; }
    public ICollection<Grade> Grades { get; set; }

}