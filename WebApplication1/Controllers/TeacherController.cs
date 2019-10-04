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
using Microsoft.EntityFrameworkCore;

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
        /// <summary>
        /// Returns replied assignment of the teacher
        /// </summary>
        /// <param name="assignmentId">assignment Id</param>
        /// <param name="personId">teacher Id</param>
        /// <returns></returns>
        [HttpGet("GetMyNotifications")]
        public List<NotificationViewModel> GetMyNotifications(string assignmentId, string personId)
        {
            var list = _dbContext.Notifications.Include(q=>q.Student).Include(a=>a.Assignment).ThenInclude(a=>a.Teacher).ThenInclude(a=>a.Course).Where(s => s.AssignmentId == assignmentId).ToList();
            return list.Select(a=>new NotificationViewModel { Id=a.StudentId,
            Assignment=a.Title,
            Course=a.Assignment.Teacher.Course.Title,
            IssueDate=a.CreateDate,
            PersonName=a.Student.Title,
            Title=a.Title,
            Status=a.Status,
            StatusTitle=a.StatusTitle}).ToList();
        }

        /// <summary>
        /// To make action(Accept/Reject) on specific notofication
        /// </summary>
        /// <param name="notificationId"></param>
        /// <param name="title"></param>
        /// <param name="isAccept"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        [HttpPost("ActionOnAssignment")]
        public bool ActionOnAssignment(string notificationId, string title, bool isAccept, string desc)
        {
            var not = _dbContext.Notifications.SingleOrDefault(a => a.Id == notificationId);
            if (not == null) return false;
            _dbContext.Notifications.Add(new Notification
            {
                AssignmentId = not.AssignmentId,
                StudentId = not.StudentId,
                Status = isAccept,
                Title = title,
                CreateDate = DateTime.Now,
                Desc = desc,
            });
            return _dbContext.SaveChanges() > 0;

        }
        /// <summary>
        /// Returns assignments belongs to the teacher
        /// </summary>
        /// <param name="teacherId"> teahcer id</param>
        /// <returns></returns>
        [HttpGet("GetActivities")]
        public List<ActivitiesViewModel> GetActivities(string teacherId)
        {
            return _dbContext.Assignments
                .Where(s => s.TeacherId == teacherId)
                .Select(a => new ActivitiesViewModel
                {
                    Id = a.Id,
                    CreateDate = a.CreateDate,
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
