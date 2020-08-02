using HexadLMServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HexadLMServices.Interfaces
{
    public interface ILibraryLogic
    {
        Task<List<Book>> GetBooks(string searchText);
    }
}
