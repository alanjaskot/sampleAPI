using SampleAPIwithJwt.Entities.Figure;
using SampleAPIwithJwt.Logic;
using SampleAPIwithJwt.Models;
using SampleAPIwithJwt.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Services.Figure
{
    public class FigureService: IFigureService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FigureService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public FigureResponseModel Add(FigureEntityModel figure)
        {
            if (figure.Id == Guid.Empty)
                figure.Id = Guid.NewGuid();

            try
            {
                var adding = _unitOfWork.FigureRepository.Add(figure);
                if(adding != Guid.Empty)
                {
                    var save = _unitOfWork.SaveChanges();
                    if(save > -1)
                    {
                        if(figure.FigureName == "kwadrat")
                        {
                            return new FigureResponseModel
                            {
                                Id = adding,
                                FigureName = figure.FigureName,
                                Area = Calculations.SquareAreaCalculation(figure)
                            };
                        }

                        if (figure.FigureName == "prostokąt")
                        {
                            return new FigureResponseModel
                            {
                                Id = adding,
                                FigureName = figure.FigureName,
                                Area = Calculations.RectangleAreaCalculation(figure)
                            };
                        }

                        if(figure.FigureName == "trójkąt")
                        {
                            return new FigureResponseModel
                            {
                                Id = adding,
                                FigureName = figure.FigureName,
                                Area = Calculations.TriangleAreaCalculation(figure)
                            };
                        }

                        if(figure.FigureName == "trapez")
                        {
                            return new FigureResponseModel
                            {
                                Id = adding,
                                FigureName = figure.FigureName,
                                Area = Calculations.TrapezeAreaCalculation(figure)
                            };
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            return new FigureResponseModel
            {
                Id = Guid.Empty,
                FigureName = "podana figura nie istnieje w systemie"
            };
        }

        public Guid Delete(FigureEntityModel figure)
        {
            if (figure.Id == Guid.Empty)
                return Guid.Empty;

            try
            {
                var deleted = _unitOfWork.FigureRepository.Delete(figure);
                if(deleted != Guid.Empty)
                {
                    var save = _unitOfWork.SaveChanges();
                    if (save > -1)
                        return figure.Id;
                }

            }
            catch
            {
                throw;
            }
            return Guid.Empty;
        }

        public List<FigureResponseModel> GetAllRectangles()
        {
            var list = default(List<FigureResponseModel>);
            try
            {
                var responses = _unitOfWork.FigureRepository.GetAllRectangles();
                foreach (var rectangle in responses)
                    list.Add(new FigureResponseModel
                    {
                        Id = rectangle.Id,
                        FigureName = rectangle.FigureName,
                        Area = Calculations.RectangleAreaCalculation(rectangle)
                    });

                if (list != null)
                    return list;
            }
            catch
            {
                throw;
            }
            return null;
        }

        public List<FigureResponseModel> GetAllSquares()
        {
            var list = new List<FigureResponseModel>();
            try
            {
                var responses = _unitOfWork.FigureRepository.GetAllSquares();
                foreach (var rectangle in responses)
                    list.Add(new FigureResponseModel
                    {
                        Id = rectangle.Id,
                        FigureName = rectangle.FigureName,
                        Area = Calculations.SquareAreaCalculation(rectangle)
                    });

                if (list != null)
                    return list;
            }
            catch
            {
                throw;
            }
            return null;
        }

        public List<FigureResponseModel> GetAllTrapezes()
        {
            var list = default(List<FigureResponseModel>);
            try
            {
                var responses = _unitOfWork.FigureRepository.GetAllTrapezes();
                foreach (var rectangle in responses)
                    list.Add(new FigureResponseModel
                    {
                        Id = rectangle.Id,
                        FigureName = rectangle.FigureName,
                        Area = Calculations.RectangleAreaCalculation(rectangle)
                    });

                if (list != null)
                    return list;
            }
            catch
            {
                throw;
            }
            return null;
        }

        public List<FigureResponseModel> GetAllTriangles()
        {
            var list = default(List<FigureResponseModel>);
            try
            {
                var responses = _unitOfWork.FigureRepository.GetAllTriangles();
                foreach (var rectangle in responses)
                    list.Add(new FigureResponseModel
                    {
                        Id = rectangle.Id,
                        FigureName = rectangle.FigureName,
                        Area = Calculations.RectangleAreaCalculation(rectangle)
                    });

                if (list != null)
                    return list;
            }
            catch
            {
                throw;
            }
            return null;
        }
    }
}
