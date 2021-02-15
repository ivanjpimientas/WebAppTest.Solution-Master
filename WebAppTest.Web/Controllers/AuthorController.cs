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
    public class AuthorController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AuthorController(IOptions<MySettingsModel> app, IWebHostEnvironment _hostEnvironment)
        {
            appSettings = app;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
            webHostEnvironment = _hostEnvironment;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            IEnumerable<Author> lstObj = new List<Author>();
            lstObj = await ApiClientFactory.Instance.GetAllAuthors();
            if (!String.IsNullOrEmpty(searchString))
            {
                lstObj = await GetSearchResult(searchString);
            }

            return View(lstObj);
        }

        public async Task<ActionResult> AddEditAuthor(int itemId)
        {
            Author model = new Author();
            if (itemId > 0)
            {
                model = await GetAuthorData(itemId);
            }
            return PartialView("_authorForm", model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Author newAuthor)
        {
            if (newAuthor.Id > 0)
            {
                await UpdateAuthor(newAuthor);
            }
            else
            {
                await AddAuthor(newAuthor);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            Author author = new Author();
            IEnumerable<Author> lstAuthor = new List<Author>();
            lstAuthor = await ApiClientFactory.Instance.GetAllAuthors();

            author = lstAuthor.Where(x => x.Id == id).FirstOrDefault();

            await DeleteAuthor(author);
            return RedirectToAction("Index");
        }

        public async Task<IEnumerable<Author>> GetSearchResult(string searchString)
        {
            List<Author> exp = new List<Author>();
            try
            {
                IEnumerable<Author> result = new List<Author>();
                exp = await ApiClientFactory.Instance.GetAllAuthors();
                result = exp.Where(x => x.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1
                            || x.Email.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task AddAuthor(Author author)
        {
            try
            {
                await ApiClientFactory.Instance.CreateAuthor(author);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateAuthor(Author author)
        {
            try
            {
                await ApiClientFactory.Instance.UpdateAuthor(author);

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Author> GetAuthorData(int itemId)
        {
            try
            {
                var result = await ApiClientFactory.Instance.GetAllAuthors();
                Author author = result.Where(x => x.Id == itemId).FirstOrDefault();
                return author;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteAuthor(Author author)
        {
            try
            {
                await ApiClientFactory.Instance.DeleteAuthor(author);

                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
