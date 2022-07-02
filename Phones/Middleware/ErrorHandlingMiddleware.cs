using Phones.Exceptions;

namespace Phones.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
       
        public ErrorHandlingMiddleware()
        {
          
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            
            catch (NotFoundException notFoundException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch (Exception e)
            {
               
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }


        }
    }
}
