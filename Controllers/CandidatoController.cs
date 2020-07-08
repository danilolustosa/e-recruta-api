using erecruta.Dto;
using erecruta.Interface;
using erecruta.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace erecruta.Controllers
{
    [Route("[controller]")]
    public class CandidatoController : ControllerBase
    {
        private ICandidatoService _service;
        public CandidatoController(ICandidatoService candidatoService) => _service = candidatoService;

        [HttpPost("salvar")]
        public IActionResult Salvar([FromBody] Candidato request)
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
        public IActionResult Listar([FromQuery] int oportunidadeId)
        {
            try
            {
                var resultado = _service.Listar(oportunidadeId);
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
