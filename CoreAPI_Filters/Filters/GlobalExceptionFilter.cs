using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Mime;

namespace CoreAPI_Filters.Filters
{
    public class GlobalExceptionFilter:ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            Console.WriteLine(context.Exception.Message);


            context.Result = new ObjectResult(
                new { message = "hi", help = context.Exception.Message }) 
            { StatusCode = StatusCodes.Status200OK } 
            ;


            //context.Result = new ObjectResult(new
            //{ 
            
            //message="an unexpected messsage occured",
            //details = context.Exception.Message
            //})
            //{ StatusCode= StatusCodes.Status500InternalServerError};


            //context.ExceptionHandled = true;
        }
    }
}
