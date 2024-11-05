namespace StudentTeacherManagement.API
{
    public class MyMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine($"My class middleware: {context.Request.Host}:{context.Request.Host.Port}");
            await next.Invoke(context);
        }
    }
}
