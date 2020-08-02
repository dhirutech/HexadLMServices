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
                        .Where(b => b.IsActive == true
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
    }
}
