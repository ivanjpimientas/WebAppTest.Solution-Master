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
        public async Task<List<Book>> GetAllBooks()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/GetAllBooks"));
            return await GetAsync<List<Book>>(requestUrl);
        }

        public async Task<Message<Book>> CreateBook(Book model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/CreateBook"));
            return await PostAsync<Book>(requestUrl, model);
        }

        public async Task<Message<Book>> UpdateBook(Book model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/UpdateBook"));
            return await PostAsync<Book>(requestUrl, model);
        }

        public async Task<Message<Book>> DeleteBook(Book model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/DeleteBook"));
            return await PostAsync<Book>(requestUrl, model);
        }
    }
}
