using AutoMapper;
using HexadLMServices.Interfaces;
using HexadLMServices.Models;
using HexadLMServices.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HexadLMServices.Logics
{
    public class LibraryLogic : ILibraryLogic
    {
        private readonly IMapper _mapper;
        private readonly ILibraryRepository _libraryRepo;
        public LibraryLogic(IMapper mapper, ILibraryRepository libraryRepo)
        {
            _mapper = mapper;
            _libraryRepo = libraryRepo;
        }

        public async Task<List<Book>> GetBooks(string searchText)
        {
            var resBooks = await _libraryRepo.GetBooks(searchText);
            var resBook = _mapper.Map<List<Book>>(resBooks);
            return resBook;
        }
    }
}
