using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithAspnet_Udemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
       

        // GET api/values/5/5
        [HttpGet("{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());

            }
            return BadRequest( "Invalid input");
        }

        private decimal ConvertToDecimal(string vNumber)
        {
            try
            {
                decimal decimalValue;
                if (decimal.TryParse(vNumber, out decimalValue))
                {
                    return decimalValue;
                }
                return 0;
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
        }

        private bool IsNumeric(string vNumber)
        {
            double number;
            bool isNumber = double.TryParse(vNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }
    }
}
