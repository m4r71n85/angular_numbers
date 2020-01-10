using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace numbers.Repositories
{
    public class NumbersRepository : INumbersRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public NumbersRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetSum()
        {
            var numbersSerialized = _httpContextAccessor.HttpContext.Session.GetString("numbers");
            var numbers = new List<int>();
            int sum = 0;
            if (!string.IsNullOrEmpty(numbersSerialized))
            {
                var allNumbers = JsonConvert.DeserializeObject<List<int>>(numbersSerialized);
                sum = allNumbers.Sum();
            }

            return sum;
        }

        public string GetStored()
        {
            return _httpContextAccessor.HttpContext.Session.GetString("numbers");
        }

        public void ClearNumbers()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }

        public int GetRandomNumber()
        {
            var r = new Random();
            int randomNumber = r.Next(0, 1000);

            SaveNumberToMemory(randomNumber);
            return randomNumber;
        }

        public void SaveNumberToMemory(int randomNumber)
        {
            var numbersSerialized = _httpContextAccessor.HttpContext.Session.GetString("numbers");
            var allNumbers = new List<int>();
            if (!string.IsNullOrEmpty(numbersSerialized))
            {
                allNumbers = JsonConvert.DeserializeObject<List<int>>(numbersSerialized);
            }

            allNumbers.Add(randomNumber);
            _httpContextAccessor.HttpContext.Session.SetString("numbers", JsonConvert.SerializeObject(allNumbers));
        }
    }
}
