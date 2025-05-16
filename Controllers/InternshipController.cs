using AutoMapper;
using GradAndInternship.Data;
using GradAndInternship.Dtos;
using GradAndInternship.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradAndInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternshipController(MyDbContext db, IMapper map, IWebHostEnvironment _env) : ControllerBase
    {

        [HttpPost("Create-Internship")]
        public IActionResult Create(InternshipDto model)
        {
            var data = map.Map<Internship>(model);
            data.StudentId = new Guid("13131313-1313-1313-1313-131313131313");
            db.Internships.Add(data);
            db.SaveChanges();
            return Ok(data);
        }


        [HttpPost("Create-Internship-To-Doctor")]
        public IActionResult CreateDoctorInternship(InternshipToDoctorDto model)
        {
            var data = map.Map<InternshipAcceptToDoctor>(model);
            data.StudentId = new Guid("13131313-1313-1313-1313-131313131313");
            db.InternshipAcceptToDoctors.Add(data);
            db.SaveChanges();
            return Ok(data);
        }
    }
}
