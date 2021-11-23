using Microsoft.EntityFrameworkCore;
using SampleAPIwithJwt.Context.Interaface;
using SampleAPIwithJwt.Entities.Figure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Repos.Figure
{
    public class FigureRepo: IFigureRepo
    {
        private readonly IAppDataBaseContext _context;

        public FigureRepo(IAppDataBaseContext context)
        {
            _context = context;
        }

        public Guid Add(FigureEntityModel figure)
        {
            if (figure.Id == Guid.Empty)
                figure.Id = Guid.NewGuid();

            try
            {
                var added = _context.Figures.Add(figure);
                if (added.State == EntityState.Added)
                    return figure.Id;
            }
            catch
            {
                throw;
            }
            return Guid.Empty;
        }

        public Guid Delete(FigureEntityModel figure)
        {
            if (figure.Id == Guid.Empty)
                return Guid.Empty;

            try
            {
                var deleted = _context.Figures.Remove(figure);
                if (deleted.State == EntityState.Deleted)
                    return figure.Id;

            }
            catch
            {
                throw;
            }
            return Guid.Empty;
        }

        public List<FigureEntityModel> GetAllSquares()
        {
            var result = default(List<FigureEntityModel>);
            try
            {
                result = _context.Figures
                    .Where(f => f.FigureName == "kwadrat").ToList();
            }
            catch
            {
                throw;
            }
            return result;
        }

        public List<FigureEntityModel> GetAllRectangles()
        {
            var result = default(List<FigureEntityModel>);
            try
            {
                result = _context.Figures
                    .Where(f => f.FigureName == "prostokąt").ToList();
            }
            catch
            {
                throw;
            }
            return result;
        }

        public List<FigureEntityModel> GetAllTriangles()
        {
            var result = default(List<FigureEntityModel>);
            try
            {
                result = _context.Figures
                    .Where(f => f.FigureName == "trójkąt").ToList();
            }
            catch
            {
                throw;
            }
            return result;
        }

        public List<FigureEntityModel> GetAllTrapezes()
        {
            var result = default(List<FigureEntityModel>);
            try
            {
                result = _context.Figures
                    .Where(f => f.FigureName == "trapez").ToList();
            }
            catch
            {
                throw;
            }
            return result;
        }

        public FigureEntityModel GetById(Guid id)
        {
            var result = default(FigureEntityModel);
            try
            {
                result = _context.Figures
                    .Where(f => f.Id == id)
                    .FirstOrDefault();
            }
            catch
            {
                throw;
            }
            return result;
        }
    }
}
