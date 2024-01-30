namespace Transpairent.Abstractions;

public interface IDataService
{
    public void AddData(string statement, string data);
    public string RetrieveData(string statement); 
    //TODO Should be able to retrieve and add data while ensuring data is safe. Such ash retrieving aggregate data etc. 
}