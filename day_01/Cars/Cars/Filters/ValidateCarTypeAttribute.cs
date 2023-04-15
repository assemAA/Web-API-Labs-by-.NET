using Cars.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace Cars.Filters
{
    public class ValidateCarTypeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Car car = context.ActionArguments["car"] as Car;
            Regex regex = new Regex("^(Electric|Gas|Diesel|Hybrid)$",
            RegexOptions.IgnoreCase,
            TimeSpan.FromSeconds(2));

            if (car is null || !regex.IsMatch(car.type))
            {
                context.ModelState.AddModelError("car type ", "The car type is not valid or coverd");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
