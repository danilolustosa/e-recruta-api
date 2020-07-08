using erecruta.Dto;
using erecruta.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace erecruta.Controllers
{
    [Route("[controller]")]
    public class OportunidadeController : BaseController
    {
        private IOportunidadeService _service;
        public OportunidadeController(ILogger<OportunidadeController> logger, IOportunidadeService service) : base(logger) 
        {
            _service = service;
        }

        [HttpPost("incluir")]
        public async Task<IActionResult> Incluir([FromBody] Oportunidade request) => await TratarResultadoAsync(async () =>
        {
            _service.Incluir(request);
            return new ObjectResult(new object()) { StatusCode = 200 };
        });

        [HttpPost("listar")]
        public async Task<IActionResult> Listar() => await TratarResultadoAsync(async () =>
        {
            var resultado = _service.Listar();
            return new ObjectResult(resultado) { StatusCode = 200 };
        });

    }
}
