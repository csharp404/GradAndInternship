namespace GradAndInternship.Models;

public class Report
{
    public Guid Id { set; get; } = Guid.NewGuid();
    public int Number { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}
