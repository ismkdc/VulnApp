using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VulnApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VulnController : ControllerBase
    {
        [HttpGet]
        public string Get(string input)
        {
            if (input.Length != 34)
            {
                return "Invalid input";
            }

            Random rng = new();
            var numbers = new int[100_000];
            Parallel.For(0, 10, x =>
            {
                for (int i = 0; i < 10_000; ++i)
                {
                    numbers[i * x] = rng.Next();
                }
            });

            var numbersStr = string.Join(string.Empty, numbers.Select(x => x.ToString()));

            if (numbersStr.Contains(input))
            {
                return "You win!";
            }

            return "You lose!";
        }
    }
}