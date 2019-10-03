using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting.Internal;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class TeacherController : Controller
    {
        private MainContext _dbContext;
        private IHostingEnvironment _hostingEnvironment;

        public TeacherController(MainContext dbContext, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

            _dbContext = dbContext;
        }
        [HttpPost("CreateAssignment")]
        public bool CreateAssignment()
        {
            //Uploading...
            var hreq = HttpContext.Request;
            var title = hreq.Form["title"];
            var teacherId = hreq.Form["teacherId"];
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
                }
            }
            catch (Exception ex) { return false; }

            _dbContext.Assignments.Add(new Assignment
            {
                Id = Guid.NewGuid().ToString(),
                FilePath = fileName,
                TeacherId = teacherId,
                Title = title,
                CreateDate = DateTime.Now,

            });
            return _dbContext.SaveChanges() > 0;
        }
        [HttpPost("GetMyNotifications")]
        public List<Notification> GetMyNotifications(string assignmentId, string personId)
        {
            var list = _dbContext.Notifications.Where(s => s.AssignmentId == assignmentId).ToList();
            return list;
        }
        [HttpPost("ActionOnAssignment")]
        public bool ActionOnAssignment(string notificationId,string title, bool isAccept, string desc)
        {
           var not= _dbContext.Notifications.SingleOrDefault(a=>a.Id==notificationId);
            if (not == null) return false;
            _dbContext.Notifications.Add(new Notification { AssignmentId=not.AssignmentId,
            StudentId=not.StudentId,
            Status=isAccept,
            Title=title,
            CreateDate=DateTime.Now,
            Desc=desc,
            });
            return _dbContext.SaveChanges() > 0;

        }
        [HttpGet("GetActivities")]
        public List<ActivitiesViewModel> GetActivities(string teacherId)
        {
            return _dbContext.Assignments
                .Where(s => s.TeacherId == teacherId)
                .Select(a => new ActivitiesViewModel
                {
                    Assignment = a.Title,
                    Course = a.Teacher.Course.Title,
                    Users = a.Teacher.Course.StudentGroup.Students.Count,
                    Accepted = a.Notifications.Count(s => s.Status.HasValue && s.Status.Value),
                    Rejected = a.Notifications.Count(s => s.Status.HasValue && !s.Status.Value),
                    Pending = a.Notifications.Count(s => !s.Status.HasValue),
                }).ToList();
        }

    }
}
