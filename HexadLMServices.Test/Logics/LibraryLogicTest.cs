using AutoMapper;
using FizzWare.NBuilder;
using HexadLMServices.Logics;
using HexadLMServices.Models;
using HexadLMServices.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel = HexadLMServices.Repositories.Models;

namespace HexadLMServices.Test.Logics
{
    [TestClass]
    public class LibraryLogicTest
    {
        private readonly Mock<ILibraryRepository> _mockLibraryRepo = new Mock<ILibraryRepository>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private LibraryLogic _libraryLogic;

        private List<DataModel.Book> _bookDMList;
        private List<Book> _bookVMList;
        private BorrowBook _borrowBook;
        private List<DataModel.BookStore> _bookStoreDMList;

        [TestInitialize]
        public void TestInitialization()
        {
            _libraryLogic = new LibraryLogic(_mockMapper.Object, _mockLibraryRepo.Object);
            _bookDMList = Builder<DataModel.Book>.CreateListOfSize(2).Build().ToList();
            _bookVMList = Builder<Book>.CreateListOfSize(2).Build().ToList();
            _borrowBook = Builder<BorrowBook>.CreateNew().Build();
            _borrowBook.UserId = 1;
            _borrowBook.BookIds = new List<int>() { 1, 2 };
            _bookStoreDMList = Builder<DataModel.BookStore>.CreateListOfSize(2).Build().ToList();
        }

        [TestMethod]
        public async Task GetBooks_ReturnsBooks_Sucessfully()
        {
            string searchText = "test";
            _bookVMList[0].Author = "TestAuthor";
            _mockMapper.Setup(m => m.Map<List<Book>>(It.IsAny<List<DataModel.Book>>())).Returns(_bookVMList);
            _mockLibraryRepo.Setup(x => x.GetBooks(It.IsAny<string>())).ReturnsAsync(_bookDMList);

            var response = await _libraryLogic.GetBooks(searchText);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Count, 2);
            Assert.AreEqual(response[0].Author, "TestAuthor");
        }

        [TestMethod]
        public async Task BorrowBooks_ReturnsTrue()
        {
            _mockLibraryRepo.Setup(x => x.GetStockBooks(It.IsAny<List<int>>())).ReturnsAsync(_bookStoreDMList);
            _mockLibraryRepo.Setup(x => x.BorrowBooks(It.IsAny<List<DataModel.UserBook>>(), It.IsAny<List<DataModel.BookStore>>())).ReturnsAsync(true);

            var response = await _libraryLogic.BorrowBooks(_borrowBook);

            Assert.IsTrue(response);
        }

        [TestMethod]
        public async Task BorrowBooks_Returns_Exception1()
        {
            string expectedError = "You can't borrow more then 2 books at any point of time!.";
            _borrowBook.BookIds = new List<int>() { 1, 2, 3 };

            _mockLibraryRepo.Setup(x => x.GetStockBooks(It.IsAny<List<int>>())).ReturnsAsync(_bookStoreDMList);
            _mockLibraryRepo.Setup(x => x.BorrowBooks(It.IsAny<List<DataModel.UserBook>>(), It.IsAny<List<DataModel.BookStore>>())).ReturnsAsync(true);

            try
            {
                var response = await _libraryLogic.BorrowBooks(_borrowBook);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, expectedError);
            }
        }

        [TestMethod]
        public async Task BorrowBooks_Returns_Exception2()
        {
            string expectedError = $"bookId-1 not avaible in store at this moment.";
            _bookStoreDMList[0].BookId = 3;
            _mockLibraryRepo.Setup(x => x.GetStockBooks(It.IsAny<List<int>>())).ReturnsAsync(_bookStoreDMList);
            _mockLibraryRepo.Setup(x => x.BorrowBooks(It.IsAny<List<DataModel.UserBook>>(), It.IsAny<List<DataModel.BookStore>>())).ReturnsAsync(true);
            try
            {
                var response = await _libraryLogic.BorrowBooks(_borrowBook);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, expectedError);
            }
        }
    }
}
