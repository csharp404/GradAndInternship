using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GradAndInternship.Models
{
    public class Student {



        public Guid Id { get; set; }
        public string StudentNumber { set; get; }
        public string StudentName { set; get; }
        public virtual ICollection<Document> Documents { get; set; }

    
        public virtual ICollection<Appointment> Appointment{ set; get; }


        public Guid? ProjectId { set; get; }
        public virtual ProjectDetails? Project { get; set; }

    }
}
