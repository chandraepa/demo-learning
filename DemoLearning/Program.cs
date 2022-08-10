var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Use(async (contect, next) =>
{
    var timer = System.Diagnostics.Stopwatch.StartNew();
    Console.WriteLine("Begining request in " + app.Environment.EnvironmentName);
    await next();
    Console.WriteLine("Request completed in " + timer.ElapsedMilliseconds);
});

app.UseMiddleware<CustomMiddleware>();

//app.Use(async (contect, next) =>
//{
//    await next();
//    throw new Exception();
//});

//app.Use(async (contect, next) =>
//{
//    var timer = System.Diagnostics.Stopwatch.StartNew();
//    Console.WriteLine("Begining request in " + app.Environment.EnvironmentName);
//    await next();
//    Console.WriteLine("Request completed in " + timer.ElapsedMilliseconds);
//});


app.Run();
