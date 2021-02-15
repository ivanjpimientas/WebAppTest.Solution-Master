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
    public class BookController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;
        private readonly IWebHostEnvironment webHostEnvironment;

        public BookController(IOptions<MySettingsModel> app, IWebHostEnvironment _hostEnvironment)
        {
            appSettings = app;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
            webHostEnvironment = _hostEnvironment;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            IEnumerable<Book> lstObj = new List<Book>();
            lstObj = await ApiClientFactory.Instance.GetAllBooks();
            if (!String.IsNullOrEmpty(searchString))
            {
                lstObj = await GetSearchResult(searchString);
            }

            return View(lstObj);
        }

        public async Task<ActionResult> AddEditBook(int itemId)
        {
            Book model = new Book();
            if (itemId > 0)
            {
                model = await GetBookData(itemId);
            }
            return PartialView("_bookForm", model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Book newBook)
        {
            if (newBook.Id > 0)
            {
                await UpdateBook(newBook);
            }
            else
            {
                await AddBook(newBook);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            Book book = new Book();
            IEnumerable<Book> lstBook = new List<Book>();
            lstBook = await ApiClientFactory.Instance.GetAllBooks();

            book = lstBook.Where(x => x.Id == id).FirstOrDefault();

            await DeleteBook(book);
            return RedirectToAction("Index");
        }

        public async Task<IEnumerable<Book>> GetSearchResult(string searchString)
        {
            List<Book> exp = new List<Book>();
            try
            {
                IEnumerable<Book> result = new List<Book>();
                exp = await ApiClientFactory.Instance.GetAllBooks();
                result = exp.Where(x => x.Title.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1
                            || x.Genre.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task AddBook(Book book)
        {
            try
            {
                Author _author = new Author();
                IEnumerable<Author> _lstAuthor = new List<Author>();
                _lstAuthor = await ApiClientFactory.Instance.GetAllAuthors();
                _author = _lstAuthor.Where(x => x.Name.Equals(book.Author.Name)).FirstOrDefault();

                Editorial _editorial = new Editorial();
                IEnumerable<Editorial> _lstEditorial = new List<Editorial>();
                _lstEditorial = await ApiClientFactory.Instance.GetAllEditorials();
                _editorial = _lstEditorial.Where(x => x.Name.Equals(book.Editorial.Name)).FirstOrDefault();

                //book.Author = _author;
                book.AuthorId = _author.Id;
                //book.Editorial = _editorial;
                book.EditorialId = _editorial.Id;

                await ApiClientFactory.Instance.CreateBook(book);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateBook(Book book)
        {
            try
            {
                Author _author = new Author();
                IEnumerable<Author> _lstAuthor = new List<Author>();
                _lstAuthor = await ApiClientFactory.Instance.GetAllAuthors();
                _author = _lstAuthor.Where(x => x.Name.Equals(book.Author.Name)).FirstOrDefault();

                Editorial _editorial = new Editorial();
                IEnumerable<Editorial> _lstEditorial = new List<Editorial>();
                _lstEditorial = await ApiClientFactory.Instance.GetAllEditorials();
                _editorial = _lstEditorial.Where(x => x.Name.Equals(book.Editorial.Name)).FirstOrDefault();

                book.Author = _author;
                book.AuthorId = _author.Id;
                book.Editorial = _editorial;
                book.EditorialId = _editorial.Id;

                await ApiClientFactory.Instance.UpdateBook(book);

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Book> GetBookData(int itemId)
        {
            try
            {
                var result = await ApiClientFactory.Instance.GetAllBooks();
                Book book = result.Where(x => x.Id == itemId).FirstOrDefault();

                Author _author = new Author();
                IEnumerable<Author> _lstAuthor = new List<Author>();
                _lstAuthor = await ApiClientFactory.Instance.GetAllAuthors();
                _author = _lstAuthor.Where(x => x.Id == book.AuthorId).FirstOrDefault();

                Editorial _editorial = new Editorial();
                IEnumerable<Editorial> _lstEditorial = new List<Editorial>();
                _lstEditorial = await ApiClientFactory.Instance.GetAllEditorials();
                _editorial = _lstEditorial.Where(x => x.Id == book.EditorialId).FirstOrDefault();

                book.Author = _author;
                book.Editorial = _editorial;

                return book;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteBook(Book book)
        {
            try
            {
                await ApiClientFactory.Instance.DeleteBook(book);

                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
