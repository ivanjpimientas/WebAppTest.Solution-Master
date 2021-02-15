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
        public async Task<List<Editorial>> GetAllEditorials()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/GetAllEditorials"));
            return await GetAsync<List<Editorial>>(requestUrl);
        }

        public async Task<Message<Editorial>> CreateEditorial(Editorial model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/CreateEditorial"));
            return await PostAsync<Editorial>(requestUrl, model);
        }

        public async Task<Message<Editorial>> UpdateEditorial(Editorial model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/UpdateEditorial"));
            return await PostAsync<Editorial>(requestUrl, model);
        }

        public async Task<Message<Editorial>> DeleteEditorial(Editorial model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/DeleteEditorial"));
            return await PostAsync<Editorial>(requestUrl, model);
        }
    }
}
