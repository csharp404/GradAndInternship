namespace GradAndInternship.Models
{
    public class Internship
    {
        public Guid Id { set; get; } = Guid.NewGuid();
        public int SemeterNumber { set; get; }

        public Student Student { set; get; }
        public Guid StudentId { set; get; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { set; get; }
        public string Address { set; get; }
        public string SuperVisor { set; get; }
        public string SuperVisorJobTitle { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public bool IsThereItDepartment { set; get; }

    }
}
