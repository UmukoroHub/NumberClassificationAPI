namespace NumberClassificationAPI.Service.HttpService
{
    public interface IRestHelper
    {
        Task<string> GetFunFact(int number);
    }
}
