using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAppTest.Core.Entities
{
    public class CommonEnt
    {
    }

    #region Common Entities Test One

    public class Student : EntityBase
    {
        [Required]
        [StringLength(25)]
        public string NumDocument { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public string Email { get; set; }
        [StringLength(50)]
        public string Grade { get; set; }
    }

    public class Course : EntityBase
    {
        [StringLength(35)]
        public string CourseCode { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
    }

    public class Address : EntityBase
    {
        [StringLength(35)]
        public string AddressCode { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
    }

    public class AddressCourse : EntityBase
    {
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }

    public class CourseStudent : EntityBase
    {
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }

    #endregion

    #region Common Entities Test Two

    public class Book : EntityBase
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Anio { get; set; }

        [Required]
        [StringLength(100)]
        public string Genre { get; set; }
        [Required]
        public int PagesNumber { get; set; }
        
        public Editorial Editorial { get; set; }
        public int EditorialId { get; set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }

    public class Author : EntityBase
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(50)]
        public string BirthDate { get; set; }
        [StringLength(150)]
        public string Country { get; set; }
        [Required]
        public string Email { get; set; }
    }

    public class Editorial : EntityBase
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string AddressEditorial { get; set; }
        [Required]
        public string Email { get; set; }
        public int CountBooks { get; set; }
    }

    #endregion
}
