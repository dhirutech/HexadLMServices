using AutoMapper;
using FizzWare.NBuilder;
using HexadLMServices.Logics;
using HexadLMServices.Models;
using HexadLMServices.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using DataModel = HexadLMServices.Repositories.Models;

namespace HexadLMServices.Test.Logics
{
    [TestClass]
    public class BooksLogicTest
    {
        private readonly Mock<IBooksRepository> _mockBookRepo = new Mock<IBooksRepository>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private BooksLogic _bookLogic;

        private Book _bookVM;
        private DataModel.Book _bookDM;

        [TestInitialize]
        public void TestInitialization()
        {
            _bookLogic = new BooksLogic(_mockMapper.Object, _mockBookRepo.Object);
            _bookVM = Builder<Book>.CreateNew().Build();
            _bookDM = Builder<DataModel.Book>.CreateNew().Build();
        }

        [TestMethod]
        public async Task AddBook_Sucessfully()
        {
            _mockMapper.Setup(m => m.Map<Book, DataModel.Book>(It.IsAny<Book>())).Returns(_bookDM);
            _mockBookRepo.Setup(x => x.AddBook(It.IsAny<DataModel.Book>(), It.IsAny<DataModel.BookStore>())).ReturnsAsync(true);

            var response = await _bookLogic.AddBook(_bookVM);

            Assert.IsNotNull(response);
            Assert.AreEqual(response, true);
        }

        [TestMethod]
        public async Task EditBook_Sucessfully()
        {
            _mockMapper.Setup(m => m.Map<Book, DataModel.Book>(It.IsAny<Book>())).Returns(_bookDM);
            _mockBookRepo.Setup(x => x.EditBook(It.IsAny<DataModel.Book>())).ReturnsAsync(true);

            var response = await _bookLogic.EditBook(_bookVM);

            Assert.IsNotNull(response);
            Assert.AreEqual(response, true);
        }

        [TestMethod]
        public async Task DeleteBook_Sucessfully()
        {
            int bookId = 1;
            _mockMapper.Setup(m => m.Map<Book, DataModel.Book>(It.IsAny<Book>())).Returns(_bookDM);
            _mockBookRepo.Setup(x => x.DeleteBook(It.IsAny<int>())).ReturnsAsync(true);

            var response = await _bookLogic.DeleteBook(bookId);

            Assert.IsNotNull(response);
            Assert.AreEqual(response, true);
        }
    }
}
