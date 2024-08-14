using Azure;
using Azure.AI.OpenAI;
using Azure.Identity;
using ChatWithOpenAi.Services;
using OpenAI.Chat;
using System.ClientModel;
using System.Threading.Tasks;

public class OpenAIService : IOpenAIService
{
    private readonly AzureOpenAIClient _client;
    private readonly ChatClient _chatClient;

    public OpenAIService()
    {
        _client = new AzureOpenAIClient(
            new Uri("https://your-end-point.openai.azure.com/"),
            new AzureKeyCredential("key-value-here"));
        _chatClient = _client.GetChatClient("your-model-name");
    }

    public async IAsyncEnumerable<string> GetChatCompletionAsync(string userMessage)
    {
        ResultCollection<StreamingChatCompletionUpdate> completionUpdates = _chatClient.CompleteChatStreaming(
        [
            new SystemChatMessage("You are a AI Assistant Who helps People in Solving thier Problems"),
        new UserChatMessage("Who Founded Microsoft"),
        new AssistantChatMessage("Bill Gates"),
        new UserChatMessage(userMessage)
        ]);

        foreach (StreamingChatCompletionUpdate completionUpdate in completionUpdates)
        {
            foreach (ChatMessageContentPart contentPart in completionUpdate.ContentUpdate)
            {
                yield return contentPart.Text;
            }
        }
    }
}
