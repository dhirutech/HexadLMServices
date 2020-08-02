using HexadLMServices.Interfaces;
using HexadLMServices.Models;
using HexadLMServices.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HexadLMServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksLogic _booksLogic;
        public BooksController(IBooksLogic booksLogic)
        {
            _booksLogic = booksLogic;
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddBook(Book book)
        {
            try
            {
                var result = await _booksLogic.AddBook(book);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Helper.CreateApiError(ex);
            }
        }

        [HttpPost("edit")]
        public async Task<ActionResult> EditBook(Book book)
        {
            try
            {
                var result = await _booksLogic.EditBook(book);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Helper.CreateApiError(ex);
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            try
            {
                var result = await _booksLogic.DeleteBook(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Helper.CreateApiError(ex);
            }
        }
    }
}
