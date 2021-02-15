using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppTest.Core.DataObjects;
using WebAppTest.Core.Entities;
using WebAppTest.Infrastructure.Models;

namespace WebAppTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : Controller
    {
        private readonly WebAppTestDBContext context;

        public MainController(WebAppTestDBContext _context)
        {
            context = _context;
        }

        #region TestOne Methods

        // GET: api/Student
        [HttpGet]
        [Route("GetAllStudents")]
        public IEnumerable<Student> GetAllStudents()
        {
            try
            {
                var result = context.Students.ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        [Route("GetAllStudents")]
        public Student GetAllStudents(int id)
        {
            try
            {
                var result = context.Students.ToList().Find(x => x.Id == id);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: api/Student
        [HttpPost]
        [Route("CreateStudent")]
        public Student CreateStudent(Student _model)
        {
            try
            {
                context.Students.Add(_model);
                context.SaveChanges();

                var resultObj = context.Students.ToList().Last();
                return resultObj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/Student/
        [HttpPost]
        [Route("UpdateStudent")]
        public Student UpdateStudent(Student _model)
        {
            try
            {
                context.Entry(_model).State = EntityState.Modified;
                context.SaveChanges();

                var resultObj = context.Students.ToList().Find(x => x.Id == _model.Id);
                return resultObj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE: api/Student/
        [HttpPost]
        [Route("DeleteStudent")]
        public Student DeleteStudent(Student _model)
        {
            try
            {
                context.Students.Remove(_model);
                context.SaveChanges();

                return new Student();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Course
        [HttpGet]
        [Route("GetAllCourses")]
        public IEnumerable<Course> GetAllCourses()
        {
            try
            {
                var result = context.Courses.ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Course/5
        [HttpGet("{id}")]
        [Route("GetAllCourses")]
        public Course GetAllCourses(int id)
        {
            try
            {
                var result = context.Courses.ToList().Find(x => x.Id == id);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: api/Course
        [HttpPost]
        [Route("CreateCourse")]
        public Course CreateCourse(Course _model)
        {
            try
            {
                context.Courses.Add(_model);
                context.SaveChanges();

                var resultObj = context.Courses.ToList().Last();
                return resultObj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/Course/
        [HttpPost]
        [Route("UpdateCourse")]
        public Course UpdateCourse(Course _model)
        {
            try
            {
                context.Entry(_model).State = EntityState.Modified;
                context.SaveChanges();

                var resultObj = context.Courses.ToList().Find(x => x.Id == _model.Id);
                return resultObj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE: api/Course/
        [HttpPost]
        [Route("DeleteCourse")]
        public Course DeleteCourse(Course _model)
        {
            try
            {
                context.Courses.Remove(_model);
                context.SaveChanges();

                return new Course();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Address
        [HttpGet]
        [Route("GetAllAddresses")]
        public IEnumerable<Address> GetAllAddresses()
        {
            try
            {
                var result = context.Addresses.ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Address/5
        [HttpGet("{id}")]
        [Route("GetAllAddresses")]
        public Address GetAllAddresses(int id)
        {
            try
            {
                var result = context.Addresses.ToList().Find(x => x.Id == id);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: api/Address
        [HttpPost]
        [Route("CreateAddress")]
        public Address CreateAddress(Address _model)
        {
            try
            {
                context.Addresses.Add(_model);
                context.SaveChanges();

                var resultObj = context.Addresses.ToList().Last();
                return resultObj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/Address/
        [HttpPost]
        [Route("UpdateAddress")]
        public Address UpdateAddress(Address _model)
        {
            try
            {
                context.Entry(_model).State = EntityState.Modified;
                context.SaveChanges();

                var resultObj = context.Addresses.ToList().Find(x => x.Id == _model.Id);
                return resultObj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE: api/Address/
        [HttpPost]
        [Route("DeleteAddress")]
        public Address DeleteAddress(Address _model)
        {
            try
            {
                context.Addresses.Remove(_model);
                context.SaveChanges();

                return new Address();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region TestTwo Methods

        // GET: api/Book
        [HttpGet]
        [Route("GetAllBooks")]
        public IEnumerable<Book> GetAllBooks()
        {
            try
            {
                var result = context.Books.ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        [Route("GetAllBooks")]
        public Book GetAllBooks(int id)
        {
            try
            {
                var result = context.Books.ToList().Find(x => x.Id == id);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: api/Book
        [HttpPost]
        [Route("CreateBook")]
        public Book CreateBook(Book _model)
        {
            try
            {
                context.Books.Add(_model);
                context.SaveChanges();

                var resultObj = context.Books.ToList().Last();
                return resultObj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/Book/
        [HttpPost]
        [Route("UpdateBook")]
        public Book UpdateBook(Book _model)
        {
            try
            {
                context.Entry(_model).State = EntityState.Modified;
                context.SaveChanges();

                var resultObj = context.Books.ToList().Find(x => x.Id == _model.Id);
                return resultObj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE: api/Book/
        [HttpPost]
        [Route("DeleteBook")]
        public Book DeleteBook(Book _model)
        {
            try
            {
                context.Books.Remove(_model);
                context.SaveChanges();

                return new Book();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Author
        [HttpGet]
        [Route("GetAllAuthors")]
        public IEnumerable<Author> GetAllAuthors()
        {
            try
            {
                var result = context.Authors.ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Author/5
        [HttpGet("{id}")]
        [Route("GetAllAuthors")]
        public Author GetAllAuthors(int id)
        {
            try
            {
                var result = context.Authors.ToList().Find(x => x.Id == id);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: api/Author
        [HttpPost]
        [Route("CreateAuthor")]
        public Author CreateAuthor(Author _model)
        {
            try
            {
                context.Authors.Add(_model);
                context.SaveChanges();

                var resultObj = context.Authors.ToList().Last();
                return resultObj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/Author/
        [HttpPost]
        [Route("UpdateAuthor")]
        public Author UpdateAuthor(Author _model)
        {
            try
            {
                context.Entry(_model).State = EntityState.Modified;
                context.SaveChanges();

                var resultObj = context.Authors.ToList().Find(x => x.Id == _model.Id);
                return resultObj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE: api/Author/
        [HttpPost]
        [Route("DeleteAuthor")]
        public Author DeleteAuthor(Author _model)
        {
            try
            {
                context.Authors.Remove(_model);
                context.SaveChanges();

                return new Author();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Editorial
        [HttpGet]
        [Route("GetAllEditorials")]
        public IEnumerable<Editorial> GetAllEditorials()
        {
            try
            {
                var result = context.Editorials.ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Editorial/5
        [HttpGet("{id}")]
        [Route("GetAllEditorials")]
        public Editorial GetAllEditorials(int id)
        {
            try
            {
                var result = context.Editorials.ToList().Find(x => x.Id == id);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: api/Editorial
        [HttpPost]
        [Route("CreateEditorial")]
        public Editorial CreateEditorial(Editorial _model)
        {
            try
            {
                context.Editorials.Add(_model);
                context.SaveChanges();

                var resultObj = context.Editorials.ToList().Last();
                return resultObj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/Editorial/
        [HttpPost]
        [Route("UpdateEditorial")]
        public Editorial UpdateEditorial(Address _model)
        {
            try
            {
                context.Entry(_model).State = EntityState.Modified;
                context.SaveChanges();

                var resultObj = context.Editorials.ToList().Find(x => x.Id == _model.Id);
                return resultObj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE: api/Editorial/
        [HttpPost]
        [Route("DeleteEditorial")]
        public Editorial DeleteEditorial(Editorial _model)
        {
            try
            {
                context.Editorials.Remove(_model);
                context.SaveChanges();

                return new Editorial();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
