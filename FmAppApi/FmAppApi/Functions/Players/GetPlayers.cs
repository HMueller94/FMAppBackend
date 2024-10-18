using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FmAppApi.Functions.Players
{
    public class GetPlayers
    {
        private readonly ILogger<GetPlayers> _logger;

        public GetPlayers(ILogger<GetPlayers> logger)
        {
            _logger = logger;
        }

        [Function("GetPlayers")]
        public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
        ILogger log)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var players = new[]
            {
            new { Id = 1, Name = "John Doe", Position = "Midfielder", Age = 24 },
            new { Id = 2, Name = "Jane Smith", Position = "Defender", Age = 22 },
            new { Id = 3, Name = "Tom Brown", Position = "Forward", Age = 27 }
        };

            var response = new OkObjectResult(players);
            return response;
        }
    }
}
