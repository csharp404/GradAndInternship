using GradAndInternship.Dtos;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradAndInternship.Models;

public class ProjectDetails
{
    public Guid Id { set; get; }
    public string Title { set; get; }
    public string Description { set; get; }
    public string Number { set; get; }
    public string Objective { set; get; }
    public string TimeLine { set; get; }
    public int? Status { set; get; }
    public string? StatusDetails { set; get; }
 

    public List<Student> Student { set; get; }

    [ForeignKey(nameof(DoctorId))]
    public Doctor Doctor { set; get; }
    public Guid DoctorId { set; get; }

    [ForeignKey(nameof(DepartmentId))]

    public Department Department { set; get; }
    public Guid DepartmentId { set; get; }

    public virtual List<Chart> Tasks { set; get; }




}