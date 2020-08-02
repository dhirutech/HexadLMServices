using HexadLMServices.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HexadLMServices.Utilities
{
    public static class Helper
    {
        public static ObjectResult CreateApiError(Exception ex)
        {
            return new ObjectResult(new ApiResponse()
            {
                Status = "Error",
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                ResponseCode = new int?(500),
                Data = null
            });
        }
    }
}
