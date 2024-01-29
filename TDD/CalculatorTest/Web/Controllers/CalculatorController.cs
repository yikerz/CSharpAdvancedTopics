using Domain;
using Microsoft.AspNetCore.Mvc;
// 5. Add Domain to project reference
namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        // 6. Implement the API GET method
        [HttpGet(Name = "Add/{left}/{right}")]
        public int Get(int left, int right)
        {
            var calculator = new Calculator();
            return calculator.Sum(left, right);
        }
    }
}
