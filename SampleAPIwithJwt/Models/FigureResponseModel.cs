using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Models
{
    public class FigureResponseModel
    {
        public Guid Id { get; set; }
        public string FigureName { get; set; }
        public decimal? Area { get; set; }
    }
}
