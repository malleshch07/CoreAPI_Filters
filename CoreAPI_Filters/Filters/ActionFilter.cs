using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreAPI_Filters.Filters
{
    public class CustomActionFilter:ActionFilterAttribute
    {


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine(" 1::::::::::::::hellow im invoked before action method called before");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("3::::::::::::hellow im excuted after action method" +context.Exception?.Message);
        }
    }
}
