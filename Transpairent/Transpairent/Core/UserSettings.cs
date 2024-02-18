namespace Transpairent.Core;

public class UserSettings(string modelName, string openApiKey)
{

    public string OpenApiKey { get; } = openApiKey;
    public string ModelName { get; } = modelName;
}