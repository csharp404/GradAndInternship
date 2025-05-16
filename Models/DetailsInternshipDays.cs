namespace GradAndInternship.Models;

public class DetailsInternshipDays
{
    public Guid Id { set; get; } = Guid.NewGuid();
    public string Status { set; get; }
    public DateTime StartTime{ set; get; }
    public DateTime EndTime{ set; get; }

}