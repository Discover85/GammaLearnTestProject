using GL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GL.Data
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {

        }
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Assignment> Assignments{ get; set; }
        public DbSet<Course> Courses{ get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
