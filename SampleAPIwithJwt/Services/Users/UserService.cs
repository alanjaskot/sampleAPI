using SampleAPIwithJwt.DTO.User;
using SampleAPIwithJwt.Mapper.User;
using SampleAPIwithJwt.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Services.Users
{
    public class UserService: IUserService
    {
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<UserDTO> GetAllUsers()
        {
            var result = new List<UserDTO>();
            try
            {
                var list = _unitOfWork.UserRepository.GetAll();
                if(list != null)
                {
                    foreach(var user in list)
                    {
                        result.Add(UserMapper.MapToUserDTO(user));
                    }
                }
            }
            catch
            {
                throw;
            }
            return result;
        }

        public UserDTO Login(string login, string password)
        {
            var result = default(UserDTO);
            try
            {
                var user = _unitOfWork.UserRepository.Login(login, password);
                if(user != null)
                {
                    result = UserMapper.MapToUserDTO(user);
                }
            }
            catch
            {
                throw;
            }
            return result;
        }
    }
}
