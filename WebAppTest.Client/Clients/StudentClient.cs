using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAppTest.Client.Models;
using WebAppTest.Core.Entities;

namespace WebAppTest.Client.Clients
{
    public partial class ApiClient
    {
        public async Task<List<Student>> GetAllStudents()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/GetAllStudents"));
            return await GetAsync<List<Student>>(requestUrl);
        }

        public async Task<Message<Student>> CreateStudent(Student model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/CreateStudent"));
            return await PostAsync<Student>(requestUrl, model);
        }

        public async Task<Message<Student>> UpdateStudent(Student model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/UpdateStudent"));
            return await PostAsync<Student>(requestUrl, model);
        }

        public async Task<Message<Student>> DeleteStudent(Student model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/DeleteStudent"));
            return await PostAsync<Student>(requestUrl, model);
        }
    }
}
