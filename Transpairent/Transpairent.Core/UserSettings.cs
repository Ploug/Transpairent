namespace Transpairent.Core;

public class UserSettings
{
    public UserSettings(string openApiKey, string modelName)
    {
        OpenApiKey = openApiKey;
        ModelName = modelName;
    }

    public string OpenApiKey { get; }
    public string ModelName { get; }
}