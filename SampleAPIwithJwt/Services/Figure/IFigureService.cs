using SampleAPIwithJwt.Entities.Figure;
using SampleAPIwithJwt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Services.Figure
{
    public interface IFigureService
    {
        public List<FigureResponseModel> GetAllSquares();
        public List<FigureResponseModel> GetAllRectangles();
        public List<FigureResponseModel> GetAllTriangles();
        public List<FigureResponseModel> GetAllTrapezes();
        public FigureResponseModel Add(FigureEntityModel figure);
        public Guid Delete(FigureEntityModel figure);
    }
}
