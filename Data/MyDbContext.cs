using GradAndInternship.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GradAndInternship.Data;

public class MyDbContext :DbContext{

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    { }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Doctor> Doctors{ get; set; }
    public DbSet<Document> Documents{ get; set; }
    public DbSet<ProjectDetails> ProjectDetails{ get; set; }
    public DbSet<Student> Students{ get; set; }
    public DbSet<Appointment> Appointments{ get; set; }

   
 
}