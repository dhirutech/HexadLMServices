using FizzWare.NBuilder;
using HexadLMServices.Controllers;
using HexadLMServices.Interfaces;
using HexadLMServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HexadLMServices.Test.Controllers
{
    [TestClass]
    public class LibraryControllerTest
    {
        private readonly Mock<ILibraryLogic> _mockLibraryLogic = new Mock<ILibraryLogic>();
        private readonly Mock<HttpRequest> _req = new Mock<HttpRequest>();
        private LibraryController _controller;
        private List<Book> _bookVMList;

        [TestInitialize]
        public void TestInitialization()
        {
            var httpContext = new DefaultHttpContext();
            var controllerContext = new ControllerContext() { HttpContext = httpContext };
            _controller = new LibraryController(_mockLibraryLogic.Object) { ControllerContext = controllerContext };

            _bookVMList = Builder<Book>.CreateListOfSize(2).Build().ToList();
        }

        [TestMethod]
        public async Task GetBooks_ReturnsBooks()
        {
            _mockLibraryLogic.Setup(x => x.GetBooks(It.IsAny<string>())).ReturnsAsync(_bookVMList);

            var resultRes = await _controller.GetBooks(null);

            Assert.IsNotNull(((ObjectResult)resultRes).Value);
            Assert.AreEqual((int)HttpStatusCode.OK, ((ObjectResult)resultRes).StatusCode);
        }

        [TestMethod]
        public async Task GetBooks_ReturnsNull()
        {
            _bookVMList = null;
            _mockLibraryLogic.Setup(x => x.GetBooks(It.IsAny<string>())).ReturnsAsync(_bookVMList);

            var resultRes = await _controller.GetBooks(null);

            Assert.IsNull(((ObjectResult)resultRes).Value);
            Assert.AreEqual((int)HttpStatusCode.OK, ((ObjectResult)resultRes).StatusCode);
        }
    }
}
