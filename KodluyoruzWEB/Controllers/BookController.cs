using KodluyoruzWEB.Models;
using KodluyoruzWEB.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KodluyoruzWEB.Controllers
{
    [Route("[controller]/[action]")]
    public class BookController : Controller
    {

        private readonly IBookRepository _bookRepository = null;
        private readonly ILanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _env;
        public BookController( IBookRepository bookRepository,ILanguageRepository
             languageRepository, IWebHostEnvironment env)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("~/all-books")]
        public async Task<IActionResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        [Route("~/book-details/{id:int:min(1)}", Name = "bookDetailsRoute")]
        public async Task<IActionResult> GetBook(int id, string nameOfBook)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        //[Authorize]
        public async Task<IActionResult> AddNewBook(bool isSuccess = false, int bookid = 0)
        {
            var model = new BookModel();
            ViewBag.languages = new SelectList(await _languageRepository.GetLanguages(),"id","name");

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookid;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.coverPhoto != null)
                {
                    string folder = "books/cover/";
                    model.coverImageUrl=  await UploadImage(folder,model.coverPhoto);

                }
                if (model.GalleryFiles != null)
                {
                    string folder = "books/gallery/";

                    model.Gallery = new List<GalleryModel>();

                    foreach (var file in model.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        { 
                           name=file.FileName,
                           url = await UploadImage(folder, file)
                        };
                        model.Gallery.Add(gallery);
                    }
                }
                if (model.BookPdf != null)
                {
                    string folder = "books/pdf/";
                    model.BookPdfUrl = await UploadImage(folder, model.BookPdf);
                }

                int id = await _bookRepository.AddNewBook(model);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookid = id });
                }

            }

            ViewBag.languages = new SelectList(await _languageRepository.GetLanguages(), "id", "name");


            return View();

        }

        private async Task<string> UploadImage(string folderPath,IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
      
            string serverFolder = Path.Combine(_env.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + folderPath;
        }

    }
}


