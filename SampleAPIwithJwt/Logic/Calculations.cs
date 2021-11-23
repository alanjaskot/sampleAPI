using SampleAPIwithJwt.Entities.Figure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Logic
{
    public static class Calculations
    {
        public static decimal SquareAreaCalculation(FigureEntityModel figure)
        {
            decimal firstSide = figure.SideOne;

            return firstSide * firstSide;
        }

        public static decimal? RectangleAreaCalculation(FigureEntityModel figure)
        { 
            if (figure.FigureName != "prostokąt")
                return -1;


            return figure.SideOne * figure.SideTwo;
        }

        public static decimal? TriangleAreaCalculation(FigureEntityModel figure)
        {
            if (figure.FigureName != "trójkąt")
                return -1;

            return (figure.SideOne * figure.Heigh) / 2;
        }

        public static decimal? TrapezeAreaCalculation(FigureEntityModel figure)
        {
            if (figure.FigureName != "trapez")
                return -1;

            return ((figure.SideOne + figure.SideTwo) * figure.Heigh) / 2;
        }
    }
}
