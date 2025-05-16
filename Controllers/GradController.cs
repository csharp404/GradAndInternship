using AutoMapper;
using GradAndInternship.Data;
using GradAndInternship.Dtos;
using GradAndInternship.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Numerics;
using System.Runtime.InteropServices.ComTypes;
using Task = GradAndInternship.Models.Task;

namespace GradAndInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradController (MyDbContext db,IMapper map,IWebHostEnvironment _env): ControllerBase
    {
        [HttpGet("Proposal")]
        public IActionResult Proposal()
        {
            var data = db.ProjectDetails.Include(x=>x.Student).Where(x=>x.DoctorId==new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA")).ToList();
            return Ok(data);
        }

        [HttpGet("Proposal-Get-By-Id/{stdNum}")]
        public IActionResult ProposalGetById(string stdNum)
        {
            var data = db.ProjectDetails.Include(x => x.Student).Where(x => x.Student.FirstOrDefault().StudentNumber == stdNum).ToList();
            return Ok(data);
        }
        [HttpPut("Proposal-Update-Status/{stdNum}")]
        public async Task< IActionResult> ProposalUpdateStatus(string stdNum , UpdateStatusProposal model)
        {
            var data = await  db.ProjectDetails.Include(x => x.Student).Where(x => x.Student.FirstOrDefault().StudentNumber == stdNum).FirstOrDefaultAsync();
            data.Status = model.status;
            if (model.status == 2)
            {
                data.StatusDetails = model.details ?? "";
            }
            else if (model.status == 1)
            {
                data.StatusDetails =  "Accepted";
            }
            else
            {
                data.StatusDetails =  "rejected";
            }

            db.SaveChanges();
            return Ok(data);
        }

        #region testCase
        //{
        //"students": [
        //{
        //    "name": "Bob Smith",
        //    "number": "CS1002"
        //},
        //{
        //    "name": "Alice Johnson",
        //    "number": "CS1001"
        //},
        //{
        //    "name": "George White",
        //    "number": "CS1003"
        //}
        //],
        //"doctorId": "BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBBBB",
        //"departmentId": "11111111-1111-1111-1111-111111111111",
        //"title": "xxx",
        //"description": "xxx",
        //"number": "xx",
        //"objective": "xx",
        //"timeLine": "xxx",
        //"tasks": [
        //{
        //    "title": "string",
        //    "description": "string",
        //    "starTime": "2025-04-05T20:37:49.680Z",
        //    "endTime": "2025-04-05T20:37:49.680Z"
        //}
        //]
        // }


        #endregion

        [HttpPost("Create-Proposal")]
        public IActionResult Proposal(ProposalDto model)
        {
           
            var department = db.Departments
                .Include(x => x.Students)
                .FirstOrDefault(x => x.Id == model.DepartmentId);

            if (department == null)
            {
                return NotFound("Department not found");
            }

            var doc = db.Doctors.Where(x => x.Id == model.DoctorId);
            if (doc == null)
            {
                return BadRequest("One or more students don't belong to the department");

            }

          
            var departmentStudentNums = department.Students.Where(x=>x.ProjectId==null).Select(s => s.StudentNumber).ToList();
            var modelStudentNums = model.Students.Select(s => s.Number).ToList();
            

            if (!modelStudentNums.All(num => departmentStudentNums.Contains(num)) )
            {
                return BadRequest("One or more students don't belong to the department");
            }

            var project = map.Map<ProjectDetails>(model);

         
            var charts = map.Map<List<Chart>>(model.Tasks);

            
            var studentNumbers = model.Students.Select(s => s.Number).ToList();
            var students = db.Students
                .Where(s => studentNumbers.Contains(s.StudentNumber))
                .ToList();

            
            project.Department = department;
            project.Student = students;
            project.Tasks = charts;

           
            db.ProjectDetails.Add(project);
            db.SaveChanges();

            

            return Ok();
        }



        [HttpPost("Upload-Document")]
        public async Task<IActionResult> UploadDoc(UploadDocumentDto model)
        {
            if (model.File.Length == 0)
            {
                return BadRequest("there is no file ");
            }
            var filePath = Path.Combine("Uploads", model.File.FileName);

            using (var f = new FileStream(filePath,FileMode.Create))
            {
                await model.File.CopyToAsync(f);
            }

            var doc = new Document()
            {
                CommentFromDoctor = "",
                PathDocument = model.File.FileName,
                Status = "Pending",
                Title = model.Title,
                UploadedAt = DateTime.Now,
                UrlDocument = filePath,
                StudentId = new Guid("12121212-1212-1212-1212-121212121212")
            };
           await  db.Documents.AddAsync(doc);
         await    db.SaveChangesAsync();

            return Ok(new { message = "File uploaded successfully!" });
        }


        [HttpGet("Get-Document")]
        public async Task<IActionResult> GetAllDocuemt()
        {
            var data = db.Documents.Where(x => x.StudentId == new Guid("12121212-1212-1212-1212-121212121212"));
            return Ok(data);
        }

        [HttpGet("Download-file/{file}")]
        public async Task<IActionResult> Download(string file)
        {
            var fileName = await db.Documents.Where(x => x.PathDocument == file).FirstOrDefaultAsync();

            var filePath = Path.Combine( "Uploads", fileName.PathDocument);

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/octet-stream", fileName.PathDocument);
        }
       



        [HttpPost("Create-Appointment")]
        public async Task<IActionResult> CreateAppointment(AppointmentDto model)
        {
            var std =await db.Students.FirstOrDefaultAsync(x => x.Id == new Guid("66666666-6666-6666-6666-666666666666"));
            var data = db.Students.Where(x => x.ProjectId == std.ProjectId).ToList();

            List<Appointment> app = new List<Appointment>()
            {
                new Appointment() { DateAppointment = model.Date.ToString(), Student = data[0] ,Stauts = "Pending"},
                new Appointment() { DateAppointment = model.Date.ToString(), Student = data[1] ,Stauts = "Pending"},
                new Appointment() { DateAppointment = model.Date.ToString(), Student = data[2],Stauts = "Pending" },
            };

           await  db.Appointments.AddRangeAsync(app);
           await db.SaveChangesAsync();

           return Ok("Appointment Created Successfully...!");
        }

        [HttpPost("Update-Appointment")]
        public async Task<IActionResult> UpdateAppointment(AppointmentDto model)
        {
            var sttd = await db.Students.FirstOrDefaultAsync(x => x.Id == new Guid("66666666-6666-6666-6666-666666666666"));
            var data = db.Students.Where(x => x.ProjectId == sttd.ProjectId).ToList();
            var studentIds = data.Select(x => x.Id).ToList();
            var std = db.Appointments.Where(x => studentIds.Contains(x.StudentId)).ToList();
            foreach (var item in std)
            {
                item.TimeAppointment = model.Time.ToString();
            }

            db.Appointments.UpdateRange(std);
            await db.SaveChangesAsync();

            return Ok("Appointment Created Successfully...!");
        }

        [HttpGet("Get-Appointment")]
        public async Task<IActionResult> GetAppointMent()
        {
            var data = db.Appointments
                .Where(x => x.StudentId == new Guid("66666666-6666-6666-6666-666666666666"))
                .Include(x => x.Student).ThenInclude(x => x.Project).ThenInclude(x => x.Doctor).ToList();
                

            return Ok(data);
        }
        [HttpGet("Get-Appointment-asDoctor/{doctorId}")]
        public async Task<IActionResult> GetAppointMent(Guid doctorId)
        {
            var data = db.Appointments
                .Where(x => x.Student.Project.Doctor.Id == doctorId)
                .Include(x => x.Student).ThenInclude(x => x.Project).ThenInclude(x => x.Doctor).ToList();
                

            return Ok(data);
        }
    }
}
