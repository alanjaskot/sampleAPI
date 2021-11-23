using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Entities.Figure
{
    public class FigureEntityModel
    {
        public Guid Id { get; set; }
        public decimal SideOne { get; set; }
        public string FigureName { get; set; }
#nullable enable
        public decimal? SideTwo { get; set; }
        public decimal? Heigh { get; set; }
#nullable disable
    }
}
