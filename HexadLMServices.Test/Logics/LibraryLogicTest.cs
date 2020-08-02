using AutoMapper;
using FizzWare.NBuilder;
using HexadLMServices.Logics;
using HexadLMServices.Models;
using HexadLMServices.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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

        [TestInitialize]
        public void TestInitialization()
        {
            _libraryLogic = new LibraryLogic(_mockMapper.Object, _mockLibraryRepo.Object);
            _bookDMList = Builder<DataModel.Book>.CreateListOfSize(2).Build().ToList();
            _bookVMList = Builder<Book>.CreateListOfSize(2).Build().ToList();
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
    }
}
