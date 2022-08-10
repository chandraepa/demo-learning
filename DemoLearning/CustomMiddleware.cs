using Microsoft.AspNetCore.Http;
using System.Diagnostics;

internal class CustomMiddleware
{
    public CustomMiddleware(RequestDelegate next, IHostEnvironment env)
    {
        this.Next = next;
        this.Env = env;
    }

    public RequestDelegate Next { get; private set; }
    public IHostEnvironment Env { get; private set; }

    public async Task Invoke(HttpContext context)
    {
        var timer = Stopwatch.StartNew();
        Console.WriteLine("Begining request in " + Env.EnvironmentName + " for custom middleware");
        await Next(context);
        Console.WriteLine("Request completed in " + timer.ElapsedMilliseconds + " for custom middleware");
    }
}