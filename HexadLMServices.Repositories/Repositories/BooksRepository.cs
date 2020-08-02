using HexadLMServices.Repositories.Interfaces;
using HexadLMServices.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace HexadLMServices.Repositories.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        public async Task<bool> AddBook(Book book)
        {
            try
            {
                using (var context = new HDBContext())
                {
                    book.CreatedDate = DateTime.UtcNow;
                    book.UpdatedDate = DateTime.UtcNow;
                    await context.Book.AddAsync(book);
                    return await context.SaveChangesAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EditBook(Book book)
        {
            try
            {
                using (var context = new HDBContext())
                {
                    var bookData = await context.Book.FirstOrDefaultAsync(b => b.BookId == book.BookId && b.IsActive == true);
                    if (bookData != null)
                    {
                        bookData.Title = book.Title;
                        bookData.Author = book.Author;
                        bookData.Isbn = book.Isbn;
                        bookData.Publication = book.Publication;
                        bookData.Yearofpub = book.Yearofpub;
                        bookData.UpdatedDate = DateTime.UtcNow;
                    }
                    return await context.SaveChangesAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteBook(int id)
        {
            try
            {
                using (var context = new HDBContext())
                {
                    var bookData = await context.Book.FirstOrDefaultAsync(b => b.BookId == id && b.IsActive == true);
                    if (bookData != null)
                    {
                        bookData.IsActive = false;
                        bookData.UpdatedDate = DateTime.UtcNow;
                    }
                    return await context.SaveChangesAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
