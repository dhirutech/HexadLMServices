using HexadLMServices.Models;
using System.Threading.Tasks;

namespace HexadLMServices.Interfaces
{
    public interface IBooksLogic
    {
        Task<bool> AddBook(Book book);
        Task<bool> EditBook(Book book);
        Task<bool> DeleteBook(int id);
    }
}
