using Transpairent.Abstractions.Contracts;

namespace Transpairent.Abstractions;

public interface IDataService
{
    public VerificationDetailedResponse AddData(IReadOnlyList<IContract> contracts, string data);
    public string RetrieveData(string statement); 
    //TODO Should be able to retrieve and add data while ensuring data is safe. Such as retrieving aggregate data etc. 
}