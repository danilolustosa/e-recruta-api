using erecruta.Interface;
using erecruta.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace erecruta.Controllers
{
    [Route("[controller]")]
    public class IBGEController : ControllerBase
    {
        private IIBGEService _service;
        public IBGEController(IIBGEService service) => _service = service;

        [HttpGet("listarEstado")]
        public IActionResult ListarEstado()
        {
            try
            {
                var resultado = _service.ListarEstado();
                return new ObjectResult(resultado) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse { StatusCode = StatusCodes.Status500InternalServerError, Mensagem = ex.Message });
            }
        }

        [HttpGet("listarCidade")]
        public IActionResult ListarCidade([FromQuery] long estadoId)
        {
            try
            {
                var resultado = _service.ListarCidade(estadoId);
                return new ObjectResult(resultado) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse { StatusCode = StatusCodes.Status500InternalServerError, Mensagem = ex.Message });
            }
        }


    }
}
