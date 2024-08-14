using OpenAI.Chat;

namespace ChatWithOpenAi.Services
{
    public interface IOpenAIService
    {
        IAsyncEnumerable<string> GetChatCompletionAsync(string userMessage);
    }
}
