using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace CoreAPI_Filters.Filters
{
    public class CacheFilter : IResourceFilter
    {

        private readonly IMemoryCache _MCache;
        public CacheFilter(IMemoryCache cache)
        {
            _MCache = cache;
        }
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var cachekey = context.HttpContext.Request.Path.ToString();

            if (_MCache.TryGetValue(cachekey, out object chchedobject))
                {
                Console.WriteLine("data came from cache");

                context.Result = new OkObjectResult(chchedobject);
            
            }

        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            //

            var cachekey = context.HttpContext.Request.Path.ToString();

            if (!_MCache.TryGetValue(cachekey, out object chchedobject))
            {
                Console.WriteLine("data read to save in  cache");

                if(context.Result is ObjectResult result)
                _MCache.Set(cachekey, result.Value, TimeSpan.FromMinutes(5));    


            }
        }
    }
}
