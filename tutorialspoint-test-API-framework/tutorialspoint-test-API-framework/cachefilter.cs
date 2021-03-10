using System;
using System.Net.Http.Headers;
using System.Web.Http.Filters;

namespace Caching
{
    public class cacheFilter : ActionFilterAttribute
    {
        public int duration { get; set; }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response.Headers.CacheControl = new CacheControlHeaderValue
            {
                MaxAge = TimeSpan.FromSeconds(duration),
                MustRevalidate = true,
                NoStore = true,
                Public = true,
                NoTransform = false
            };
            
        }

    }
}