namespace GradAndInternship.Models;

public class Appointment
{
    public Guid Id { set; get; }
    public string? DateAppointment { set; get; }
    public string? TimeAppointment { set; get; }

    public string? Stauts { set; get; }
    public Guid StudentId { set; get; }
    public Student Student { set; get; }

}