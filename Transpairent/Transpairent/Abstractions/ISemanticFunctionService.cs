using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace Transpairent.Core;

public interface ISemanticFunctionService
{
    Task<TU?> TryGenerateByExampleAsync<T, TU>(
        string systemMessage,
        T input,
        IReadOnlyList<SemanticExample<T, TU>> semanticExamples,
        OpenAIPromptExecutionSettings? settings = null,
        CancellationToken cancellationToken = default);
}
