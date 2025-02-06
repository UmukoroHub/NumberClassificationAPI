using NumberClassificationAPI.Models;

namespace NumberClassificationAPI.Service
{
    public interface INumberFact
    {
        Task<NumberClassifier> GenerateNumberFact(int number);
    }
}
