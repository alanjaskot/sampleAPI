using SampleAPIwithJwt.Context.Interaface;
using SampleAPIwithJwt.Repos.Figure;
using SampleAPIwithJwt.Repos.Permits;
using SampleAPIwithJwt.Repos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.UnitsOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IAppDataBaseContext _context;

        private IUserRepo _userRepo;
        private IPermitsRepo _permitsRepo;
        private IFigureRepo _figureRepo;

        public UnitOfWork(IAppDataBaseContext context,
            IUserRepo userRepo,
            IPermitsRepo permitsRepo,
            IFigureRepo figureRepo)
        {
            _context = context;
            _userRepo = userRepo;
            _permitsRepo = permitsRepo;
            _figureRepo = figureRepo;
        }

        public IUserRepo UserRepository
        {
            get
            {
                if (_userRepo == null)
                    _userRepo = new UserRepo(_context);

                return _userRepo;
            }
        }

        public IPermitsRepo PermitsRepository
        {
            get
            {
                if (_permitsRepo == null)
                    _permitsRepo = new PermitsRepo(_context);

                return _permitsRepo;
            }
        }

        public IFigureRepo FigureRepository
        {
            get
            {
                if (_figureRepo == null)
                    _figureRepo = new FigureRepo(_context);

                return _figureRepo;
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
