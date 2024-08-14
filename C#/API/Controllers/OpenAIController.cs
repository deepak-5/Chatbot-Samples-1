using ChatWithOpenAi.Services;
using System.ClientModel;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ChatApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OpenAIController : ControllerBase
    {
        private readonly IOpenAIService _openAIService;

        public OpenAIController(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        [HttpPost("chat")]
        public async Task Chat([FromBody] ChatRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Message))
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid request.");
                return;
            }

            // Set the response content type to text/event-stream for streaming
            Response.ContentType = "text/event-stream";

            var writer = Response.BodyWriter;
            await foreach (var response in _openAIService.GetChatCompletionAsync(request.Message))
            {
                // Write each response part directly to the response stream
                var data = Encoding.UTF8.GetBytes($"{response}");
                await writer.WriteAsync(data);
                await writer.FlushAsync();
            }

            // Close the writer to finish the response
            await writer.CompleteAsync();
        }

    }




    public class ChatRequest
    {
        public string? Message { get; set; }
    }
}
