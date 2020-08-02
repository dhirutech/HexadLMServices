using HexadLMServices.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HexadLMServices.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers(string searchText);
    }
}
