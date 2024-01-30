using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Transpairent.Abstractions;

namespace Transpairent.Core;

public class KernelFactory(UserSettings userSettings) : IKernelFactory
{
    private Kernel? _kernel;

    public async Task UpdateKernelAsync()
    {
        _kernel = await BuildKernelAsync();
    }
    
    public async Task<Kernel> CreateOrGetKernelAsync()
    {
        return _kernel ??= await BuildKernelAsync();
    }

    private async Task<Kernel> BuildKernelAsync()
    {
        var kernelBuilder = Kernel.CreateBuilder();
        
        var kernel = kernelBuilder
            .AddOpenAIChatCompletion(userSettings.ModelName, userSettings.OpenApiKey)
            .Build(); 

        return kernel;
    }

}