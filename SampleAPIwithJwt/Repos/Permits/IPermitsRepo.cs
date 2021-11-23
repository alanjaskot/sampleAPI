using SampleAPIwithJwt.Entities.UserPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Repos.Permits
{
    public interface IPermitsRepo
    {
        public List<UserPermissionEntityModel> GetByUser(Guid id);
    }
}
