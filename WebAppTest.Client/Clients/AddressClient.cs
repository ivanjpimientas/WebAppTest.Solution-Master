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
        public async Task<List<Address>> GetAllAddresses()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/GetAllAddresses"));
            return await GetAsync<List<Address>>(requestUrl);
        }

        public async Task<Message<Address>> CreateAddress(Address model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/CreateAddress"));
            return await PostAsync<Address>(requestUrl, model);
        }

        public async Task<Message<Address>> UpdateAddress(Address model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/UpdateAddress"));
            return await PostAsync<Address>(requestUrl, model);
        }

        public async Task<Message<Address>> DeleteAddress(Address model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Main/DeleteAddress"));
            return await PostAsync<Address>(requestUrl, model);
        }
    }
}
