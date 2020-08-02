using HexadLMServices.Interfaces;
using HexadLMServices.Models;
using HexadLMServices.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HexadLMServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryLogic _libraryLogic;
        public LibraryController(ILibraryLogic libraryLogic)
        {
            _libraryLogic = libraryLogic;
        }

        [HttpGet("getbooks")]
        public async Task<ActionResult> GetBooks([FromQuery] string searchText)
        {
            try
            {
                var result = await _libraryLogic.GetBooks(searchText);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Helper.CreateApiError(ex);
            }
        }

        [HttpPost("borrowbooks")]
        public async Task<ActionResult> BorrowBooks(BorrowBook borrowBooks)
        {
            try
            {
                var result = await _libraryLogic.BorrowBooks(borrowBooks);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Helper.CreateApiError(ex);
            }
        }
    }
}
