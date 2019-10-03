using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private MainContext _dbContext;
        private IHostingEnvironment _hostingEnvironment;

        public StudentController(MainContext dbContext, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

            _dbContext = dbContext;
        }
        [HttpPost("ActionOnAssignment")]
        public bool ActionOnAssignment()
        {
            var hreq = HttpContext.Request;
            var assignmentId = hreq.Form["assignmentId"];

            var not = _dbContext.Notifications.SingleOrDefault(a => a.Id == assignmentId);
            if (not == null) return false;
            var title = hreq.Form["title"];
            var file = hreq.Form.Files[0];
            string fileName = string.Empty;

            try
            {

                string folderName = "Documents";
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                if (file.Length > 0)
                {
                    fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    fileName = Path.GetFileNameWithoutExtension(fileName) + DateTime.Now.ToString("yyyymmssfff") + Path.GetExtension(file.FileName);
                    string fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    _dbContext.Notifications.Add(new Notification
                    {
                        Id = Guid.NewGuid().ToString(),
                        AssignmentId = not.AssignmentId,
                        StudentId = not.StudentId,
                    });
                    return _dbContext.SaveChanges() > 0;
                }
                else return false;
            }
            catch (Exception ex) { return false; }

        }


        [HttpGet("GetMyAssignments")]
        public List<StudentAssignmentViewModel> GetMyAssignments(string studentId)
        {
            var student = _dbContext.Students.SingleOrDefault(a => a.Id == studentId);
            if (student == null) return new List<StudentAssignmentViewModel>();
            var allAssi = _dbContext.Assignments.Include(p => p.Teacher).ThenInclude(q => q.Course).ToList();
            var list = _dbContext.Assignments.Include(p => p.Notifications).Include(p => p.Teacher).ThenInclude(q => q.Course)
              .Where(s => s.Teacher.Course.StudentGroupId == student.StudentGroupId).ToList();
            if (!list.Any()) return new List<StudentAssignmentViewModel>();

            return list
              .Select(a => new StudentAssignmentViewModel
              {
                  Assignment = a.Title,
                  Teacher = a.Teacher.Title,
                  Course = a.Teacher.Course.Title,
                  IssueDate = a.CreateDate,
                  Status = !a.Notifications.Any(q => q.StudentId == studentId) ? null : a.Notifications.LastOrDefault(q => q.StudentId == studentId).Status,
                  StatusTitle = !a.Notifications.Any(q => q.StudentId == studentId) ? "Pending" : a.Notifications.LastOrDefault(q => q.StudentId == studentId).StatusTitle,
              }).ToList();
        }


    }
}
