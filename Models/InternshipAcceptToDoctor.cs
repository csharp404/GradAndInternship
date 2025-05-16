namespace GradAndInternship.Models;

public class InternshipAcceptToDoctor
{
    public Guid Id { set; get; } = Guid.NewGuid();

    public int SemesterGraduate { set; get; }
    public int SemesterInternship { set; get; }
    public int NumberOfHours { set; get; }
    public string  CompanyName { set; get; }
    public string  Address { set; get; }
    public string Email { set; get; }
    public string Description { set; get; }
    public string TypeOfInternship { set; get; }

    public Student Student { set; get; }
    public Guid StudentId { set; get; }

    
    public ICollection<Report> Reports { set; get; }
    public ICollection<Phase> Phases { set; get; }
    public ICollection<DetailsInternshipDays> Scheduals { set; get; }





}