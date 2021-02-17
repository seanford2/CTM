using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FizzBuzzController : ControllerBase
    {
        private readonly ILogger<FizzBuzzController> _logger;

        public FizzBuzzController(ILogger<FizzBuzzController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/FizzBuzz")]
        public IEnumerable<string> Get()
        {
            return GetFizzBuzz(10);
        }

        [HttpGet]
        [Route("/FizzBuzz/{value}")]        
        public IEnumerable<string> Get(string value = "10")
        {
            if (!Int32.TryParse(value, out int val) || (val < 1))
            {
                throw new ArgumentException(
                    $"Value argument must be a whole number greater than 0. {value} is an unacceptable value or format.");
            }

            return GetFizzBuzz(val);
        }

        private List<string> GetFizzBuzz(int val)
        {
            var output = new List<string>();

            for (int i = 1; i <= val; i++)
            {
                var outStr = i.ToString();

                if (i % 3 == 0)
                    outStr = "Fizz";

                if (i % 5 == 0)
                    outStr = "Buzz";

                if ((i % 3 == 0) && (i % 5 == 0))
                    outStr = "FizzBuzz";

                output.Add(outStr);
            }

            return output;
        }

    }
}
