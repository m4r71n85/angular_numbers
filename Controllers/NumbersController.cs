using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using numbers.Repositories;

namespace numbers.Controllers
{
    [Route("api/[controller]")]
    public class NumbersController : Controller
    {
        private readonly NumbersRepository numbersRepository;

        public NumbersController(NumbersRepository numbersRepository)
        {
            this.numbersRepository = numbersRepository;
        }

        [HttpGet("[action]")]
        public IActionResult GetStored()
        {
            var numbersSerialized = numbersRepository.GetStored();
            return Ok(numbersSerialized);
        }

        [HttpGet("[action]")]
        public IActionResult GetRandom()
        {
            var randomNumber = numbersRepository.GetRandomNumber();
            return Ok(randomNumber);
        }


        [HttpGet("[action]")]
        public IActionResult GetSum()
        {
            int sum = numbersRepository.GetSum();

            return Ok(sum);
        }

        [HttpGet("[action]")]
        public IActionResult ClearNumbers()
        {
            numbersRepository.ClearNumbers();

            return Ok();
        }
    }
}