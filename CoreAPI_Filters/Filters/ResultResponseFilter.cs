using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreAPI_Filters.Filters
{
    public class ResultResponseFilter:ResultFilterAttribute
    {
        public override void OnResultExecuting(
            ResultExecutingContext context)
        {
            Console.Write("result filter  called");


            if(context.Result is ObjectResult objresult)
            context.Result = new ObjectResult(new
            { message = "the resulting filter", 
                data = objresult.Value })
            { StatusCode = StatusCodes.Status200OK };



        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Console.Write("result filter exceuted called");

        }


    }
}
