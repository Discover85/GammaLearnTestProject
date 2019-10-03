using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GL.Data.Models
{
    public class BaseModel
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]

        public string Title { get; set; }
    }
    public class PersonBaseModel:BaseModel
    {
        public string Address{ get; set; }
        public string Tell{ get; set; }
        public string UserName{ get; set; }
        public string Password{ get; set; }
    }
    public class StudentGroup : BaseModel
    {
    }
    public class Teacher : PersonBaseModel
    {

        [ForeignKey("Course")]
        public string CourseId { get; set; }
        public Course Course { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
    public class Student : PersonBaseModel
    {
        [ForeignKey("StudentGroup")]
        public string StudentGroupId { get; set; }
        public StudentGroup StudentGroup { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
   public class CourseAndStudentGroup
    {
        [ForeignKey("StudentGroup")]
        public string StudentGroupId { get; set; }
        public StudentGroup StudentGroup { get; set; }

        [ForeignKey("Course")]
        public string CourseId { get; set; }
        public Course Course { get; set; }

    }
    public class Course : BaseModel
    {
    }
    public class Assignment : BaseModel
    {
        [ForeignKey("Teacher")]
        public string TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [ForeignKey("Course")]
        public string CourseId { get; set; }
        public Course Course { get; set; }

        public string FilePath { get; set; }
    }
    public class Notification : BaseModel
    {
        [ForeignKey("Assignment")]
        public string AssignmentId { get; set; }
        public Assignment Assignment { get; set; }

        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public Student Student { get; set; }

        public bool? Status { get; set; }
        public string FilePath { get; set; }
        public string Desc { get; set; }
    }
}
