namespace GradAndInternship.Models;

public class Task
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    

    public Phase? Phase { set; get; }
    public Guid? PhaseId { set; get; }


}