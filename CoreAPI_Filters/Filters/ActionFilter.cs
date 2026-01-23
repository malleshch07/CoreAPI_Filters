using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreAPI_Filters.Filters
{
    public class CustomActionFilter:ActionFilterAttribute
    {


        public override void OnActionExecuting
            (ActionExecutingContext context)
        {
            Console.WriteLine(" 1::::::::::::::action filter before called");
        }

        public override void OnActionExecuted
            (ActionExecutedContext context)
        {
            Console.WriteLine("3::::::::::::action filter after called"
                + context.Exception?.Message);
        }
    }
}
