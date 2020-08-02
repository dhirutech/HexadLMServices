using FizzWare.NBuilder;
using HexadLMServices.Controllers;
using HexadLMServices.Interfaces;
using HexadLMServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HexadLMServices.Test.Controllers
{
    [TestClass]
    public class BooksControllerTest
    {
        private readonly Mock<IBooksLogic> _mockBooksLogic = new Mock<IBooksLogic>();
        private readonly Mock<HttpRequest> _req = new Mock<HttpRequest>();
        private BooksController _controller;
        private Book _bookVM;

        [TestInitialize]
        public void TestInitialization()
        {
            var httpContext = new DefaultHttpContext();
            var controllerContext = new ControllerContext() { HttpContext = httpContext };
            _controller = new BooksController(_mockBooksLogic.Object) { ControllerContext = controllerContext };

            _bookVM = Builder<Book>.CreateNew().Build();
        }

        [TestMethod]
        public async Task AddBook_True()
        {
            _mockBooksLogic.Setup(x => x.AddBook(It.IsAny<Book>())).ReturnsAsync(true);

            var resultRes = await _controller.AddBook(_bookVM);

            Assert.AreEqual(((ObjectResult)resultRes).Value, true);
            Assert.AreEqual((int)HttpStatusCode.OK, ((ObjectResult)resultRes).StatusCode);
        }

        [TestMethod]
        public async Task AddBook_Exception()
        {
            _mockBooksLogic.Setup(x => x.AddBook(It.IsAny<Book>())).ThrowsAsync(new Exception());

            var resultRes = await _controller.AddBook(_bookVM);

            Assert.IsNotNull(((ObjectResult)resultRes).Value);
            Assert.AreEqual(((ApiResponse)((ObjectResult)resultRes).Value).ResponseCode, 500);
        }

        [TestMethod]
        public async Task EditBook_True()
        {
            _mockBooksLogic.Setup(x => x.EditBook(It.IsAny<Book>())).ReturnsAsync(true);

            var resultRes = await _controller.EditBook(_bookVM);

            Assert.AreEqual(((ObjectResult)resultRes).Value, true);
            Assert.AreEqual((int)HttpStatusCode.OK, ((ObjectResult)resultRes).StatusCode);
        }

        [TestMethod]
        public async Task DeleteBook_True()
        {
            int bookId = 1;
            _mockBooksLogic.Setup(x => x.DeleteBook(It.IsAny<int>())).ReturnsAsync(true);

            var resultRes = await _controller.DeleteBook(bookId);

            Assert.AreEqual(((ObjectResult)resultRes).Value, true);
            Assert.AreEqual((int)HttpStatusCode.OK, ((ObjectResult)resultRes).StatusCode);
        }
    }
}
