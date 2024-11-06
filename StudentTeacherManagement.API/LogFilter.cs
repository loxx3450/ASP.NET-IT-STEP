using Microsoft.AspNetCore.Mvc.Filters;
using StudentTeacherManagement.API.Controllers;

namespace StudentTeacherManagement.API
{
    public class LogFilter : IAsyncActionFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.Controller.GetType() == typeof(StudentController))
            {
                Console.WriteLine("---- Incoming Request ----");

                Console.WriteLine("\nAction Arguments:");

                foreach (var key in context.ActionArguments.Keys)
                {
                    Console.WriteLine($"-  {key}");
                }

                var request = context.HttpContext.Request;

                Console.WriteLine($"\nRequest: {request.Method} {request.Scheme}://{request.Host}{request.Path}");

                if (request.RouteValues.Count > 0)
                {
                    Console.WriteLine("\nRoute values:");

                    foreach (var routeValue in request.RouteValues)
                    {
                        Console.WriteLine($"-  {routeValue.Key}: {routeValue.Value}");
                    }
                }

                if (request.Query.Count > 0)
                {
                    Console.WriteLine("\nQuery params:");

                    foreach (var param in request.Query)
                    {
                        Console.WriteLine($"- {param.Key}: {param.Value}");
                    }
                }                

                Console.WriteLine($"\nContent's length: {request.ContentLength} && Content's type: {request.ContentType}");

                Console.WriteLine("\nHeaders:");

                foreach (var header in request.Headers)
                {
                    Console.WriteLine($"-  {header.Key}: {header.Value}");
                }

                Console.WriteLine($"\nAuthentication: {context.HttpContext.User.Identity?.IsAuthenticated}\n");
            }

            return next.Invoke();
        }
    }
}
