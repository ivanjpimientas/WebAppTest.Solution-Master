using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using WebAppTest.Core.Entities;

namespace WebAppTest.Infrastructure.Models
{
    public class WebAppTestDBContext : DbContext
    {
        public IConfiguration Configuration { get; }

        public WebAppTestDBContext()
        {
        }

        public WebAppTestDBContext(DbContextOptions<WebAppTestDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AddressCourse> AddressCourses { get; set; }
        public virtual DbSet<CourseStudent> CourseStudents { get; set; }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Editorial> Editorials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
