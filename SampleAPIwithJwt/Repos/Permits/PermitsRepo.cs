using SampleAPIwithJwt.Context.Interaface;
using SampleAPIwithJwt.Entities.UserPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Repos.Permits
{
    public class PermitsRepo: IPermitsRepo
    {
        private readonly IAppDataBaseContext _context;

        public PermitsRepo(IAppDataBaseContext context)
        {
            _context = context;
        }

        public List<UserPermissionEntityModel> GetByUser(Guid id)
        {
            var result = default(List<UserPermissionEntityModel>);
            try
            {
                result = _context.Permits
                    .Where(p => p.UserId == id).ToList();
            }
            catch
            {
                throw;
            }
            return result;
        }
    }
}
