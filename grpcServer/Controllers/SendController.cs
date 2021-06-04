using System.Threading.Tasks;
using grpcServer.Infrastructure.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace grpcServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendController : ControllerBase
    {
        private readonly IMessagesRepository _messagesRepository;
        private readonly ILogger<SendController> _logger;

        public SendController(ILogger<SendController> logger, IMessagesRepository messagesRepository)
        {
            _logger = logger;
            _messagesRepository = messagesRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            _logger.Log(LogLevel.Error,"Joke");
            return Ok(await _messagesRepository.GetMessages());
        }
    }
}