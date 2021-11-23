using SampleAPIwithJwt.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Services.Users
{
    public interface IUserService
    {
        public List<UserDTO> GetAllUsers();
        public UserDTO Login(string login, string password);
    }
}
