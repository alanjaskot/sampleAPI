using SampleAPIwithJwt.Repos.Figure;
using SampleAPIwithJwt.Repos.Permits;
using SampleAPIwithJwt.Repos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.UnitsOfWork
{
    public interface IUnitOfWork
    {
        public IUserRepo UserRepository { get; }
        public IPermitsRepo PermitsRepository { get; }
        public IFigureRepo FigureRepository { get; }
        public int SaveChanges();
    }
}
