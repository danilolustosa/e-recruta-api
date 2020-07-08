using erecruta.Dto;
using erecruta.Interface;
using erecruta.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace erecruta.Controllers
{
    [Route("[controller]")]
    public class OportunidadeController : ControllerBase
    {
        private IOportunidadeService _service;
        public OportunidadeController(IOportunidadeService service)
        {
            _service = service;
        }

        [HttpPost("salvar")]
        public IActionResult Salvar([FromBody] Oportunidade request)
        {
            try
            {
                var resultado = _service.Salvar(request);
                return new ObjectResult(resultado) { StatusCode = resultado.StatusCode };
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse { StatusCode = StatusCodes.Status500InternalServerError, Mensagem = ex.Message });
            }
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try
            {
                var resultado = _service.Listar();
                return new ObjectResult(resultado) { StatusCode = resultado.StatusCode };
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse { StatusCode = StatusCodes.Status500InternalServerError, Mensagem = ex.Message });
            }
        }

        [HttpGet("obter")]
        public IActionResult Obter([FromQuery] int id)
        {
            try
            {
                var resultado = _service.Obter(id);
                return new ObjectResult(resultado) { StatusCode = resultado.StatusCode };
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse { StatusCode = StatusCodes.Status500InternalServerError, Mensagem = ex.Message });
            }
        }

    }
}
