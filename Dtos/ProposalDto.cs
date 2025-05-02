namespace GradAndInternship.Dtos;

public class ProposalDto
{
    public List<StudentDetails> Students { set; get; }
    public Guid DoctorId { set; get; }
    public Guid DepartmentId { set; get; }
    public string Title { set; get; }
    public string Description { set; get; }
    public string Number { set; get; }
    public string Objective { set; get; }
    public string TimeLine { set; get; }
    public List<TasksDto> Tasks { set; get; }
}