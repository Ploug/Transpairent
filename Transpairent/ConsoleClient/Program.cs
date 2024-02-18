using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Transpairent.Core.Abstractions;
using Transpairent.Core;
using Transpairent.Core.Contracts;

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
serviceCollection.AddScoped<IDataService, DataService>();

var serviceProvider = serviceCollection.BuildServiceProvider();

Console.WriteLine("Hello, World!");

await ExecuteAsync(serviceProvider);

async Task ExecuteAsync(IServiceProvider serviceProvider)
{
    var dataService = serviceProvider.GetRequiredService<IDataService>();

    await dataService.AddDataAsync(new []{new TruthContract("I mine bitcoin")}, "I dont mind bitcoin");
}