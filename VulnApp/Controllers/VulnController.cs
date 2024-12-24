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
            int count = 100_000;
            var numbers = new int[count];

            Parallel.For(0, count, x =>
            {
                numbers[x] = rng.Next();
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
