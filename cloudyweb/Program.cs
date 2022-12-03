using cloudyweb.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCloudy(cloudy => cloudy
  .AddAdmin(admin => admin.Unprotect())   // NOTE: Admin UI will be publicly available!
  .AddContext<Context>()                // Adds EF Core context with your content types
);

builder.Services.AddDbContext<Context>(options => options
  .UseCosmos(builder.Configuration["CosmosConnectionString"] ?? throw new Exception("CosmosEndpoint needed"), builder.Configuration["CosmosDatabase"] ?? throw new Exception("CosmosDatabase needed"))
);

var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions().MustValidate());

app.MapRazorPages();
app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();
