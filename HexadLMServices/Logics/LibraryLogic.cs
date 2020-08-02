using AutoMapper;
using HexadLMServices.Interfaces;
using HexadLMServices.Models;
using HexadLMServices.Repositories.Interfaces;
using DataModel = HexadLMServices.Repositories.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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

        public async Task<bool> BorrowBooks(BorrowBook borrowBooks)
        {
            var userBooks = new List<DataModel.UserBook>();
            var bookinStores = new List<DataModel.BookStore>();

            if (borrowBooks.BookIds.Count > 2)
                throw new Exception("You can't borrow more then 2 books at any point of time!.");
            if (borrowBooks.BookIds.Count > 0)
            {
                bookinStores = await _libraryRepo.GetStockBooks(borrowBooks.BookIds);
                foreach (var bookId in borrowBooks.BookIds)
                {
                    if (bookinStores.Any(bs => bs.BookId == bookId))
                    {
                        bookinStores.Where(bs => bs.BookId == bookId).FirstOrDefault().StockCount--;
                        userBooks.Add(new DataModel.UserBook()
                        {
                            UserId = borrowBooks.UserId,
                            BookId = bookId,
                            CreatedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow
                        });
                    }
                    else
                        throw new Exception($"bookId-{bookId} not avaible in store at this moment.");
                }
                return await _libraryRepo.BorrowBooks(userBooks, bookinStores);
            }
            return false;
        }
    }
}
