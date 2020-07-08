using erecruta.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace erecruta.Controllers
{
    [ApiController]
    [Produces("application/json")]

    public class BaseController : ControllerBase
    {
        private readonly string PrefixoLog = "E-recruta -";
        protected readonly ILogger _logger;
        private readonly string MensagemErroPadrao = "Ocorreu um erro ao processar a solicitação. Por favor, tente novamente mais tarde.";

        protected BaseController(ILogger logger) => _logger = logger;

        protected async Task<IActionResult> TratarResultadoAsync(Func<Task<IActionResult>> servico)
        {
            try
            {
                return await servico();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $" {PrefixoLog} {ex.Message} {ex.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse { Mensagem = MensagemErroPadrao });
            }
        }
    }
}
