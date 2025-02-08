
using NumberClassificationAPI.Controllers;
using NumberClassificationAPI.Models;
using NumberClassificationAPI.Service.HttpService;

namespace NumberClassificationAPI.Service
{
    public class NumberFact : INumberFact
    {
        private readonly IRestHelper _restHelper;
        private readonly ILogger<NumberFact> _logger;
        public NumberFact(IRestHelper restHelper, ILogger<NumberFact> logger)
        {
            _restHelper = restHelper;
            _logger = logger;
        }
        public async Task<NumberClassifier> GenerateNumberFact(int number)
        {
            _logger.LogInformation($"Entered into {nameof(GenerateNumberFact)} method");
            var result = new NumberClassifier
            {
                Number = number,
                IsPrime = IsPrime(number),
                IsPerfect = IsPerfect(number),
                Properties = GetProperties(number),
                DigitSum = GetDigitSum(number),
                FunFact = await _restHelper.GetFunFact(number)
            };

            return result;
        }

        private bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        private bool IsPerfect(int number)
        {
            int sum = 1;
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                    if (i != number / i)
                        sum += number / i;
                }
            }
            return sum == number && number != 1;
        }

        private List<string> GetProperties(int number)
        {
            var properties = new List<string>();

            if (IsArmstrong(number))
                properties.Add("armstrong");

            properties.Add(number % 2 == 0 ? "even" : "odd");

            return properties;
        }

        private bool IsArmstrong(int number)
        {
            int sum = 0, temp = number, digits = number.ToString().Length;
            while (temp > 0)
            {
                int digit = temp % 10;
                sum += (int)Math.Pow(digit, digits);
                temp /= 10;
            }
            return sum == number;
        }

        private int GetDigitSum(int number)
        {
            return Math.Abs(number).ToString().Select(c => c - '0').Sum();
        }



    }
}
