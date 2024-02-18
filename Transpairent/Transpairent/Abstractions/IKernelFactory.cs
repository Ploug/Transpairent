using Microsoft.SemanticKernel;

namespace Transpairent.Core.Abstractions;

public interface IKernelFactory
{
    Task<Kernel> CreateOrGetKernelAsync();
    Task UpdateKernelAsync();
}