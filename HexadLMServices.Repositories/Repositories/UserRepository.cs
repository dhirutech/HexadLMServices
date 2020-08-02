using HexadLMServices.Repositories.Interfaces;
using HexadLMServices.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HexadLMServices.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<List<User>> GetUsers(string searchText)
        {
            try
            {
                using (var context = new HDBContext())
                {
                    return await context.User
                        .Include(u => u.UserRole)
                        .Where(u => u.Isactive == true
                            && (String.IsNullOrEmpty(searchText) || (u.FirstName + u.LasName).ToLower().Contains(searchText.ToLower()))
                            )
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
