using SampleAPIwithJwt.DTO.UserPermission;
using SampleAPIwithJwt.Mapper.UserPermission;
using SampleAPIwithJwt.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Services.Permits
{
    public class PermitService: IPermitService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermitService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<UserPermissionDTO> GetPermissionsByUser(Guid userId)
        {
            var result = default(List<UserPermissionDTO>);
            try
            {
                var permissions = _unitOfWork.PermitsRepository.GetByUser(userId);
                if(permissions != null)
                {
                    foreach(var permit in permissions)
                    {
                        result.Add(UserPermissionMapper.MapToUserPermissionDTO(permit));
                    }
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
