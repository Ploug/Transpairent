using Microsoft.Extensions.DependencyInjection;
using Transpairent;
using Transpairent.Core.Abstractions;
using Transpairent.Core;

var serviceCollection = new ServiceCollection();

Console.WriteLine("Please enter your OpenAI API key:");
var apiKey = Console.ReadLine();

if (string.IsNullOrWhiteSpace(apiKey))
{
    Console.WriteLine("API Key is required to proceed.");
    return;
}

var userSettings = new UserSettings("gpt-4-0125-preview", apiKey);

serviceCollection.AddSingleton<UserSettings>(userSettings);
serviceCollection.AddScoped<IKernelFactory, KernelFactory>();
serviceCollection.AddScoped<ISemanticFunctionService, SemanticFunctionService>();
serviceCollection.AddScoped<ITrustedDataService, TrustedDataService>();

var serviceProvider = serviceCollection.BuildServiceProvider();

await ExecuteAsync(serviceProvider);

async Task ExecuteAsync(IServiceProvider serviceProvider)
{
    var trustedDataService = serviceProvider.GetRequiredService<ITrustedDataService>();

    await CasinoAppExample.ExecuteAsync(trustedDataService);
    //await BitcoinExample.ExecuteAsync(trustedDataService);
    //await PositionOfTrustExample.ExecuteAsync(trustedDataService);
}