using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
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
    public class EditorialController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EditorialController(IOptions<MySettingsModel> app, IWebHostEnvironment _hostEnvironment)
        {
            appSettings = app;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
            webHostEnvironment = _hostEnvironment;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            IEnumerable<Editorial> lstObj = new List<Editorial>();
            lstObj = await ApiClientFactory.Instance.GetAllEditorials();
            if (!String.IsNullOrEmpty(searchString))
            {
                lstObj = await GetSearchResult(searchString);
            }

            return View(lstObj);
        }

        public async Task<ActionResult> AddEditEditorial(int itemId)
        {
            Editorial model = new Editorial();
            if (itemId > 0)
            {
                model = await GetEditorialData(itemId);
            }
            return PartialView("_editorialForm", model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Editorial newEditorial)
        {
            if (newEditorial.Id > 0)
            {
                await UpdateEditorial(newEditorial);
            }
            else
            {
                await AddEditorial(newEditorial);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            Editorial editorial = new Editorial();
            IEnumerable<Editorial> lstEditorial = new List<Editorial>();
            lstEditorial = await ApiClientFactory.Instance.GetAllEditorials();

            editorial = lstEditorial.Where(x => x.Id == id).FirstOrDefault();

            await DeleteEditorial(editorial);
            return RedirectToAction("Index");
        }

        public async Task<IEnumerable<Editorial>> GetSearchResult(string searchString)
        {
            List<Editorial> exp = new List<Editorial>();
            try
            {
                IEnumerable<Editorial> result = new List<Editorial>();
                exp = await ApiClientFactory.Instance.GetAllEditorials();
                result = exp.Where(x => x.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1
                            || x.Email.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task AddEditorial(Editorial editorial)
        {
            try
            {
                await ApiClientFactory.Instance.CreateEditorial(editorial);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateEditorial(Editorial editorial)
        {
            try
            {
                await ApiClientFactory.Instance.UpdateEditorial(editorial);

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Editorial> GetEditorialData(int itemId)
        {
            try
            {
                var result = await ApiClientFactory.Instance.GetAllEditorials();
                Editorial editorial = result.Where(x => x.Id == itemId).FirstOrDefault();
                return editorial;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteEditorial(Editorial editorial)
        {
            try
            {
                await ApiClientFactory.Instance.DeleteEditorial(editorial);

                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
