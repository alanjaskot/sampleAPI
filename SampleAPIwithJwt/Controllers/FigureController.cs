using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAPIwithJwt.Entities.Figure;
using SampleAPIwithJwt.Models;
using SampleAPIwithJwt.Services.Figure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FigureController : ControllerBase
    {
        private IFigureService _service;

        public FigureController(IFigureService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet("GetGuid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetGuid()
        {
            return await Task.FromResult(Ok(Guid.NewGuid().ToString()));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetAllFromFigure")]
        public async Task<IActionResult> GetAllFromFigure(string figureName)
        {
            try
            {
                if (figureName == "kwadrat")
                    return await Task.FromResult(Ok(_service.GetAllSquares()));

                if (figureName == "prostokąt")
                    return await Task.FromResult(Ok(_service.GetAllRectangles()));

                if (figureName == "trójkąt")
                    return await Task.FromResult(Ok(_service.GetAllTriangles()));

                if (figureName == "trapez")
                    return await Task.FromResult(Ok(_service.GetAllTrapezes()));                
            }
            catch
            {
                throw;
            }
            return await Task.FromResult(BadRequest("nie ma takiej figury w systemie"));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("Add")]
        public async Task<IActionResult> Add(FigureEntityModel figure)
        {
            try
            {
                var figureResponse = _service.Add(figure);
                return await Task.FromResult(Created("dodano figure", figure.Id));
            }
            catch
            {
                throw;
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(FigureEntityModel figure)
        {
            try
            {
                var figureResponse = _service.Delete(figure);
                return await Task.FromResult(Ok(figureResponse));
            }
            catch
            {
                throw;
            }
        }
    }
}
