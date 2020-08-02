using HexadLMServices.Interfaces;
using HexadLMServices.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HexadLMServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserLogic _userLogic;
        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [HttpGet("getusers")]
        public async Task<ActionResult> GetUsers([FromQuery] string searchText)
        {
            try
            {
                var result = await _userLogic.GetUsers(searchText);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Helper.CreateApiError(ex);
            }
        }
    }
}
