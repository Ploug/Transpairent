using Microsoft.SemanticKernel;

namespace Transpairent.Abstractions;

public interface IKernelFactory
{
    Task<Kernel> CreateOrGetKernelAsync();
    Task UpdateKernelAsync();
}