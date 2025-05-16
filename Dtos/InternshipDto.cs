using GradAndInternship.Models;

namespace GradAndInternship.Dtos
{
    public class InternshipDto
    {
        public int SemeterNumber { set; get; }

        public Guid? StudentId { set; get; }
      
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
