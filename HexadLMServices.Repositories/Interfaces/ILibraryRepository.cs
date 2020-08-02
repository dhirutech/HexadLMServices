using HexadLMServices.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HexadLMServices.Repositories.Interfaces
{
    public interface ILibraryRepository
    {
        Task<List<Book>> GetBooks(string searchText);
    }
}
