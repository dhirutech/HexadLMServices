using HexadLMServices.Repositories.Interfaces;
using HexadLMServices.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HexadLMServices.Repositories.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        public async Task<List<Book>> GetBooks(string searchText)
        {
            try
            {
                using (var context = new HDBContext())
                {
                    return await context.Book
                        .Include(b => b.BookStore)
                        .Where(b => b.BookStore.StockCount > 0 && b.IsActive == true
                            && (String.IsNullOrEmpty(searchText) || (b.Title + b.Author).ToLower().Contains(searchText.ToLower()))
                            )
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BookStore>> GetStockBooks(List<int> bookIds)
        {
            try
            {
                using (var context = new HDBContext())
                {
                    return await context.BookStore
                        .Where(b => bookIds.Contains(b.BookId) && b.StockCount > 0)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> BorrowBooks(List<UserBook> userBooks, List<BookStore> bookStores)
        {
            try
            {
                using (var context = new HDBContext())
                {
                    context.BookStore.UpdateRange(bookStores);
                    context.UserBook.AddRange(userBooks);
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
