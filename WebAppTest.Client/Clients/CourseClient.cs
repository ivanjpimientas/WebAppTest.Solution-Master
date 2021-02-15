using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAppTest.Client.Models;
using WebAppTest.Core.DataObjects;
using WebAppTest.Core.Entities;

namespace WebAppTest.Client.Clients
{
    public partial class ApiClient
    {
        public async Task<List<Course>> GetAllCourses()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/GetAllCourses"));
            return await GetAsync<List<Course>>(requestUrl);
        }

        public async Task<Message<Course>> CreateCourse(Course model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/CreateCourse"));
            return await PostAsync<Course>(requestUrl, model);
        }

        public async Task<Message<Course>> UpdateCourse(Course model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/UpdateCourse"));
            return await PostAsync<Course>(requestUrl, model);
        }

        public async Task<Message<Course>> DeleteCourse(Course model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/DeleteCourse"));
            return await PostAsync<Course>(requestUrl, model);
        }
    }
}
