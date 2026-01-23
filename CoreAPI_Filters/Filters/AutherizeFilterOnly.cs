using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CoreAPI_Filters.Filters
{
    public class AutherizeFilterOnly:IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {

          context.HttpContext.Request.Headers.TryGetValue("X-API-KEY", out var APIKEy);

            if (APIKEy == "Secret")
            {
                //context.Result = new ObjectResult(new { message = "autheriztaion done", data = " api key" }) { StatusCode = StatusCodes.Status401Unauthorized };

            }
            else
            {
                context.Result= new ObjectResult(new { message="unautheriztaion",data="invalid api key" }){ StatusCode =StatusCodes.Status401Unauthorized};


            }

                Console.WriteLine("authization here");
        }
    }
}
