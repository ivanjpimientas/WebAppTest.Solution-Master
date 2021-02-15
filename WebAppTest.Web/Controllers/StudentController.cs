using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppTest.Core.Entities;
using WebAppTest.Web.Factory;
using WebAppTest.Web.Models;
using WebAppTest.Web.Utility;

namespace WebAppTest.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;
        private readonly IWebHostEnvironment webHostEnvironment;

        public StudentController(IOptions<MySettingsModel> app, IWebHostEnvironment _hostEnvironment)
        {
            appSettings = app;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
            webHostEnvironment = _hostEnvironment;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            IEnumerable<Student> lstObj = new List<Student>();
            lstObj = await ApiClientFactory.Instance.GetAllStudents();
            if (!String.IsNullOrEmpty(searchString))
            {
                lstObj = await GetSearchResult(searchString);
            }

            return View(lstObj);
        }

        public async Task<ActionResult> AddEditStudent(int itemId)
        {
            Student model = new Student();
            if (itemId > 0)
            {
                model = await GetStudentData(itemId);
            }
            return PartialView("_studentForm", model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Student newStudent)
        {
            if (newStudent.Id > 0)
            {
                await UpdateStudent(newStudent);
            }
            else
            {
                await AddStudent(newStudent);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            Student student = new Student();
            IEnumerable<Student> lstStudent = new List<Student>();
            lstStudent = await ApiClientFactory.Instance.GetAllStudents();

            student = lstStudent.Where(x => x.Id == id).FirstOrDefault();

            await DeleteStudent(student);
            return RedirectToAction("Index");
        }

        public async Task<IEnumerable<Student>> GetSearchResult(string searchString)
        {
            List<Student> exp = new List<Student>();
            try
            {
                IEnumerable<Student> result = new List<Student>();
                exp = await ApiClientFactory.Instance.GetAllStudents();
                result = exp.Where(x => x.NumDocument.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1
                            || x.FirstName.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task AddStudent(Student student)
        {
            try
            {
                await ApiClientFactory.Instance.CreateStudent(student);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateStudent(Student student)
        {
            try
            {
                await ApiClientFactory.Instance.UpdateStudent(student);

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Student> GetStudentData(int itemId)
        {
            try
            {
                var result = await ApiClientFactory.Instance.GetAllStudents();
                Student student = result.Where(x => x.Id == itemId).FirstOrDefault();
                return student;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteStudent(Student student)
        {
            try
            {
                await ApiClientFactory.Instance.DeleteStudent(student);

                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
