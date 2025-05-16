namespace GradAndInternship.Models;

public class Phase
{
    public Guid Id { set; get; } = Guid.NewGuid();
    public string Name { set; get; }

    public  List<Task> Tasks { set; get; }
}