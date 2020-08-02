using HexadLMServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HexadLMServices.Interfaces
{
    public interface IUserLogic
    {
        Task<List<User>> GetUsers(string searchText);
    }
}
