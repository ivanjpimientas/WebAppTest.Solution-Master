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
    public class AddressController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AddressController(IOptions<MySettingsModel> app, IWebHostEnvironment _hostEnvironment)
        {
            appSettings = app;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
            webHostEnvironment = _hostEnvironment;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            IEnumerable<Address> lstObj = new List<Address>();
            lstObj = await ApiClientFactory.Instance.GetAllAddresses();
            if (!String.IsNullOrEmpty(searchString))
            {
                lstObj = await GetSearchResult(searchString);
            }

            return View(lstObj);
        }

        public async Task<ActionResult> AddEditAddress(int itemId)
        {
            Address model = new Address();
            if (itemId > 0)
            {
                model = await GetAddressData(itemId);
            }
            return PartialView("_addressForm", model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Address newAddress)
        {
            if (newAddress.Id > 0)
            {
                await UpdateAddress(newAddress);
            }
            else
            {
                await AddAddress(newAddress);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            Address address = new Address();
            IEnumerable<Address> lstAddress = new List<Address>();
            lstAddress = await ApiClientFactory.Instance.GetAllAddresses();

            address = lstAddress.Where(x => x.Id == id).FirstOrDefault();

            await DeleteAddress(address);
            return RedirectToAction("Index");
        }

        public async Task<IEnumerable<Address>> GetSearchResult(string searchString)
        {
            List<Address> exp = new List<Address>();
            try
            {
                IEnumerable<Address> result = new List<Address>();
                exp = await ApiClientFactory.Instance.GetAllAddresses();
                result = exp.Where(x => x.AddressCode.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1
                            || x.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task AddAddress(Address address)
        {
            try
            {
                await ApiClientFactory.Instance.CreateAddress(address);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateAddress(Address address)
        {
            try
            {
                await ApiClientFactory.Instance.UpdateAddress(address);

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Address> GetAddressData(int itemId)
        {
            try
            {
                var result = await ApiClientFactory.Instance.GetAllAddresses();
                Address address = result.Where(x => x.Id == itemId).FirstOrDefault();
                return address;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteAddress(Address address)
        {
            try
            {
                await ApiClientFactory.Instance.DeleteAddress(address);

                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
