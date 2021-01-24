using KodluyoruzWEB.Data;
using KodluyoruzWEB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KodluyoruzWEB.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                author = model.author,
                CreatedOn = DateTime.UtcNow,
                desciption = model.desciption,
                title = model.title,
                languageId = model.languageId,
                category = model.category,
                totalPages = model.totalPages.HasValue ? model.totalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow,
                coverImageUrl = model.coverImageUrl,
                bookPdfUrl = model.BookPdfUrl
            };
            newBook.bookGalery = new List<BookGallery>();
            foreach (var file in model.Gallery)
            {
                newBook.bookGalery.Add(new BookGallery()
                {
                    Name = file.name,
                    Url = file.url,
                });
            }
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {

            return await _context.Books
             .Select(book => new BookModel()
             {
                 author = book.author,
                 category = book.category,
                 desciption = book.desciption,
                 id = book.id,
                 languageId = book.languageId,
                 language = book.Language.name,
                 title = book.title,
                 totalPages = book.totalPages,
                 coverImageUrl = book.coverImageUrl

             }).ToListAsync();
        }
        public async Task<List<BookModel>> GetTopBooksAsync(int count)
        {
            return await _context.Books
             .Select(book => new BookModel()
             {
                 author = book.author,
                 category = book.category,
                 desciption = book.desciption,
                 id = book.id,
                 languageId = book.languageId,
                 language = book.Language.name,
                 title = book.title,
                 totalPages = book.totalPages,
                 coverImageUrl = book.coverImageUrl
             }).Take(count).ToListAsync();
        }

        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.id == id)
                .Select(book => new BookModel()
                {
                    author = book.author,
                    category = book.category,
                    desciption = book.desciption,
                    id = book.id,
                    languageId = book.languageId,
                    language = book.Language.name,
                    title = book.title,
                    totalPages = book.totalPages,
                    coverImageUrl = book.coverImageUrl,
                    Gallery = book.bookGalery.Select(g => new GalleryModel()
                    {
                        Id = g.Id,
                        name = g.Name,
                        url = g.Url

                    }).ToList(),
                    BookPdfUrl = book.bookPdfUrl
                }).FirstOrDefaultAsync();

        }
        public List<BookModel> SearchBook(string title, string authorName)
        {
            return null;
        }



    }
}
