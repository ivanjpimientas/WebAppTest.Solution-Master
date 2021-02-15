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
    public class CourseController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CourseController(IOptions<MySettingsModel> app, IWebHostEnvironment _hostEnvironment)
        {
            appSettings = app;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
            webHostEnvironment = _hostEnvironment;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            IEnumerable<Course> lstObj = new List<Course>();
            lstObj = await ApiClientFactory.Instance.GetAllCourses();
            if (!String.IsNullOrEmpty(searchString))
            {
                lstObj = await GetSearchResult(searchString);
            }

            return View(lstObj);
        }

        public async Task<ActionResult> AddEditCourse(int itemId)
        {
            Course model = new Course();
            if (itemId > 0)
            {
                model = await GetCourseData(itemId);
            }
            return PartialView("_courseForm", model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Course newCourse) 
        {
            if (newCourse.Id > 0)
            {
                await UpdateCourse(newCourse);
            }
            else
            {
                await AddCourse(newCourse);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            Course course = new Course();
            IEnumerable<Course> lstCourse = new List<Course>();
            lstCourse = await ApiClientFactory.Instance.GetAllCourses();

            course = lstCourse.Where(x => x.Id == id).FirstOrDefault();

            await DeleteCourse(course);
            return RedirectToAction("Index");
        }

        public async Task<IEnumerable<Course>> GetSearchResult(string searchString)
        {
            List<Course> exp = new List<Course>();
            try
            {
                IEnumerable<Course> result = new List<Course>();
                exp = await ApiClientFactory.Instance.GetAllCourses();
                result = exp.Where(x => x.CourseCode.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1
                            || x.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task AddCourse(Course course)
        {
            try
            {
                await ApiClientFactory.Instance.CreateCourse(course);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateCourse(Course course)
        {
            try
            {
                await ApiClientFactory.Instance.UpdateCourse(course);

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Course> GetCourseData(int itemId)
        {
            try
            {
                var result = await ApiClientFactory.Instance.GetAllCourses();
                Course course = result.Where(x => x.Id == itemId).FirstOrDefault();
                return course;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteCourse(Course course)
        {
            try
            {
                await ApiClientFactory.Instance.DeleteCourse(course);

                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
