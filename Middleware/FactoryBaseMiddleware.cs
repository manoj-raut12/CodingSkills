
namespace CodingSkills.Middleware
{
    public class FactoryBaseMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine("Started executing the Middleware");

            await next(context);
            Console.WriteLine("After executing the Middleware");
        }
    }

    //Register service and use it
    //builder.Services.AddTransient<FactoryMiddleware>();
    //app.UseMiddleware<FactoryBaseMiddleware>();
}
