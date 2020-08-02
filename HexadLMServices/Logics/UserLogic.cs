using AutoMapper;
using HexadLMServices.Interfaces;
using HexadLMServices.Models;
using HexadLMServices.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HexadLMServices.Logics
{
    public class UserLogic : IUserLogic
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepo;
        public UserLogic(IMapper mapper, IUserRepository userRepo)
        {
            _mapper = mapper;
            _userRepo = userRepo;
        }

        public async Task<List<User>> GetUsers(string searchText)
        {
            var resUsers = await _userRepo.GetUsers(searchText);
            var resBook = _mapper.Map<List<User>>(resUsers);
            return resBook;
        }
    }
}
