using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Transpairent.Core.Abstractions;
using Transpairent.Core;

public class SemanticFunctionService(IKernelFactory kernelFactory) : ISemanticFunctionService
{
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        WriteIndented = true,
        IncludeFields = true
    };

    public async Task<TU?> TryGenerateByExampleAsync<T, TU>(
        string systemMessage,
        T input,
        IReadOnlyList<SemanticExample<T, TU>> semanticExamples,
        OpenAIPromptExecutionSettings? settings = null,
        CancellationToken cancellationToken = default)
    {
        var semanticFunctionChat = GetSemanticFunctionChat(systemMessage, semanticExamples, input);

        var outputJson = await GetChatBasedSemanticFunctionOutputAsync(
            semanticFunctionChat,
            settings,
            cancellationToken);

        return JsonSerializer.Deserialize<TU>(outputJson, SerializerOptions);
    }

    private async Task<string> GetChatBasedSemanticFunctionOutputAsync(
        ChatHistory semanticFunctionChat,
        OpenAIPromptExecutionSettings? settings = null,
        CancellationToken cancellationToken = default)
    {
        settings ??= new OpenAIPromptExecutionSettings { ChatSystemPrompt = "", Temperature = 0, TopP = 0 };

        var result = await GetResultStreamingAsync(semanticFunctionChat, settings, cancellationToken);

        return result.Trim().Trim('"', '\'', '.');
    }

    private async Task<string> GetResultStreamingAsync(
        ChatHistory chat,
        OpenAIPromptExecutionSettings settings,
        CancellationToken cancellationToken)
    {
        var result = new StringBuilder();

        var kernel = await kernelFactory.CreateOrGetKernelAsync();

        var chatPrompt = GetChatPrompt(chat);
        
        var function = kernel.CreateFunctionFromPrompt(chatPrompt, settings);
        
        await foreach (var message in kernel.InvokeStreamingAsync<string>(function, cancellationToken: cancellationToken))
        {
            result.Append(message);
        }

        return result.ToString();
    }

    private static string GetChatPrompt(ChatHistory chat)
    {
        var sb = new StringBuilder();
        foreach (var message in chat)
        {
            var content = System.Security.SecurityElement.Escape(message.Content);

            sb.AppendLine($"<message role=\"{message.Role.ToString()}\">{content}</message>");
        }

        return sb.ToString();
    }

    private static ChatHistory GetSemanticFunctionChat<T, TU>(
        string systemMessage,
        IReadOnlyList<SemanticExample<T, TU>> semanticExamples,
        T input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        if (!semanticExamples.Any())
        {
            throw new ArgumentNullException(nameof(semanticExamples), "Requires examples.");
        }


        var semanticFunctionChat = new ChatHistory();

        semanticFunctionChat.AddSystemMessage(
            "You produce serializable JSON output based on JSON input intelligently.");

        semanticFunctionChat.AddSystemMessage(systemMessage);

        semanticFunctionChat.AddSystemMessage("[[[EXAMPLES START]]]");

        foreach (var inputOutputExample in semanticExamples)
        {
            if (inputOutputExample.Input == null)
            {
                throw new ArgumentNullException(nameof(semanticExamples));
            }

            if (inputOutputExample.ExpectedOutput == null)
            {
                throw new ArgumentNullException(nameof(semanticExamples));
            }

            semanticFunctionChat.AddUserMessage(JsonSerializer.Serialize(inputOutputExample.Input, SerializerOptions));
            semanticFunctionChat.AddAssistantMessage(JsonSerializer.Serialize(inputOutputExample.ExpectedOutput, SerializerOptions));
        }

        semanticFunctionChat.AddSystemMessage("[[[EXAMPLES END]]]");

        semanticFunctionChat.AddSystemMessage(
            @"
View the examples as blueprints for the kind of interaction expected; they are foundational principles, not precise steps.
Your responses should extrapolate intelligently from these principles when faced with inputs that diverge from the examples.
While adaptability in content is encouraged, maintain the JSON output format meticulously as it is crucial for deserializing it.

Anticipate variations in the forthcoming real input and respond with the core principles in mind, not the specific details of the examples provided.

The real input is coming now - take a deep breath and do your best.
");
        semanticFunctionChat.AddUserMessage(JsonSerializer.Serialize(input, SerializerOptions));

        return semanticFunctionChat;
    }
}
