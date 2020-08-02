using AutoMapper;
using HexadLMServices.Interfaces;
using HexadLMServices.Models;
using HexadLMServices.Repositories.Interfaces;
using System.Threading.Tasks;
using DataModels = HexadLMServices.Repositories.Models;

namespace HexadLMServices.Logics
{
    public class BooksLogic : IBooksLogic
    {
        private readonly IMapper _mapper;
        private readonly IBooksRepository _booksRepo;
        public BooksLogic(IMapper mapper, IBooksRepository booksRepo)
        {
            _mapper = mapper;
            _booksRepo = booksRepo;
        }

        public async Task<bool> AddBook(Book book)
        {
            var resBook = _mapper.Map<DataModels.Book>(book);
            var resBookStore = _mapper.Map<DataModels.BookStore>(book);
            return await _booksRepo.AddBook(resBook, resBookStore);
        }

        public async Task<bool> EditBook(Book book)
        {
            var resBook = _mapper.Map<DataModels.Book>(book);
            return await _booksRepo.EditBook(resBook);
        }

        public async Task<bool> DeleteBook(int id)
        {
            return await _booksRepo.DeleteBook(id);
        }
    }
}
