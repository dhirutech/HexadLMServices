using HexadLMServices.Repositories.Models;
using System.Threading.Tasks;

namespace HexadLMServices.Repositories.Interfaces
{
    public interface IBooksRepository
    {
        Task<bool> AddBook(Book book, BookStore bookStore);
        Task<bool> EditBook(Book book);
        Task<bool> DeleteBook(int id);
    }
}
