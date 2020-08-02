using AutoMapper;
using HexadLMServices.Interfaces;
using HexadLMServices.Models;
using HexadLMServices.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel = HexadLMServices.Repositories.Models;

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

        public async Task<bool> BorrowBooks(MyBooks borrowBooks)
        {
            var userBooks = new List<DataModel.UserBook>();
            var bookinStores = new List<DataModel.BookStore>();
            var userBooksExist = new List<DataModel.UserBook>();

            if (borrowBooks.BookIds.Count > 0)
            {
                if (borrowBooks.BookIds.Count > 2)
                    throw new Exception("You can't borrow more then 2 books at any point of time!.");
                if (borrowBooks.BookIds.Count > 1 && borrowBooks.BookIds.Distinct().Count() == 1)
                    throw new Exception("Only 1 copy of a book can be borrowed at any point of time!.");

                userBooksExist = await _libraryRepo.GetUserBooks(borrowBooks.UserId);
                if (userBooksExist.Count == 2 || (userBooksExist.Count + borrowBooks.BookIds.Count) > 2)
                    throw new Exception($"You can't borrow more then 2 books at any point of time!. You have already {userBooksExist.Count} nos of book(s) available in your borrowed list.");
                if (userBooksExist.Any(ub => borrowBooks.BookIds.Contains(ub.BookId)))
                    throw new Exception("Only 1 copy of a book can be borrowed at any point of time!.");

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
            else
                return false;
        }

        public async Task<bool> ReturnBooks(MyBooks returnBooks)
        {
            var status = false;
            var userBooksExist = await _libraryRepo.GetUserBooks(returnBooks.UserId);
            if (userBooksExist.Count > 0)
            {
                foreach (var bookId in returnBooks.BookIds)
                {
                    if (userBooksExist.Any(bs => bs.BookId == bookId))
                    {
                        //remove book from mylist and add book to store
                        status = await _libraryRepo.RemoveMyBooksBackToStore(returnBooks.UserId, bookId);
                    }
                    else
                        throw new Exception($"No such bookId - {bookId} available with you to return!.");
                }
            }
            else
                throw new Exception("No book available with you to return!.");

            return status;
        }
    }
}
