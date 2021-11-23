using SampleAPIwithJwt.Entities.Figure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Repos.Figure
{
    public interface IFigureRepo
    {
        public List<FigureEntityModel> GetAllSquares();
        public List<FigureEntityModel> GetAllRectangles();
        public List<FigureEntityModel> GetAllTriangles();
        public List<FigureEntityModel> GetAllTrapezes();
        public FigureEntityModel GetById(Guid id);
        public Guid Add(FigureEntityModel figure);
        public Guid Delete(FigureEntityModel figure);
    }
}
