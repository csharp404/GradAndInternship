using System.Runtime.InteropServices.JavaScript;

namespace GradAndInternship.Models;

public class Chart
{
    public Guid Id { set; get; }
    public string Title { set; get; }
    public string Description { set; get; }
    public DateTime StarTime { set; get; }
    public DateTime EndTime { set; get; }

    public Guid ProjectId { set; get; }
    public ProjectDetails Project { set; get; }

}