using SampleAPIwithJwt.DTO.UserPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Services.Permits
{
    public interface IPermitService
    {
        public List<UserPermissionDTO> GetPermissionsByUser(Guid userId);
    }
}
