using HexadLMServices.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HexadLMServices.Repositories.Interfaces
{
    public interface ILibraryRepository
    {
        Task<List<Book>> GetBooks(string searchText);
        Task<List<BookStore>> GetStockBooks(List<int> bookIds);
        Task<bool> BorrowBooks(List<UserBook> userBooks, List<BookStore> bookStores);
        Task<List<UserBook>> GetUserBooks(int userId);
    }
}
