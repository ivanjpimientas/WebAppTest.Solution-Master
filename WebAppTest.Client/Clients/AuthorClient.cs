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
        public async Task<List<Author>> GetAllAuthors()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/GetAllAuthors"));
            return await GetAsync<List<Author>>(requestUrl);
        }

        public async Task<Message<Author>> CreateAuthor(Author model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/CreateAuthor"));
            return await PostAsync<Author>(requestUrl, model);
        }

        public async Task<Message<Author>> UpdateAuthor(Author model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/UpdateAuthor"));
            return await PostAsync<Author>(requestUrl, model);
        }

        public async Task<Message<Author>> DeleteAuthor(Author model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/DeleteAuthor"));
            return await PostAsync<Author>(requestUrl, model);
        }
    }
}
