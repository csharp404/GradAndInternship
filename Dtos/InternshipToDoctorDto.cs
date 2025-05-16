using GradAndInternship.Models;

namespace GradAndInternship.Dtos;

public class InternshipToDoctorDto
{

    public int SemesterGraduate { set; get; }
    public int SemesterInternship { set; get; }
    public int NumberOfHours { set; get; }
    public string CompanyName { set; get; }
    public string Address { set; get; }
    public string Email { set; get; }
    public string Description { set; get; }
    public string TypeOfInternship { set; get; }

    public Guid StudentId { set; get; }


    public List<Report>? Reports { set; get; }
    public List<Phase>? Phases { set; get; }
    public List<DetailsInternshipDays>? Scheduals { set; get; }
}