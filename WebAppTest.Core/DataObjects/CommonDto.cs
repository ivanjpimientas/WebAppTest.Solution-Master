using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppTest.Core.DataObjects
{
    public class CommonDto
    {
    }

    #region Common Data Objects Test One

    public class StudentDto
    {
        public int Id { get; set; }
        public string NumDocument { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Grade { get; set; }
    }

    public class CourseDto
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class AddressDto
    {
        public int Id { get; set; }
        public string AddressCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class AddressCourseDto
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public int CourseId { get; set; }
    }

    public class CourseStudentDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }

    #endregion

    #region Common Data Objects Test Two

    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Anio { get; set; }
        public string Genre { get; set; }
        public int PagesNumber { get; set; }
        public int EditorialId { get; set; }
        public int AuthorId { get; set; }
    }

    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
    }

    public class EditorialDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressEditorial { get; set; }
        public string Email { get; set; }
        public int CountBooks { get; set; }
    }

    #endregion
}
