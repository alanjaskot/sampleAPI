using SampleAPIwithJwt.Jwt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Jwt.Interface
{
    public interface IJwtService
    {
        Task<JwtAuthenticationTokenModel> CreateToken(Guid userId);
    }
}
