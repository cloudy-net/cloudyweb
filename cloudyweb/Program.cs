using cloudyweb.Models;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCloudy(cloudy => cloudy
  .AddAdmin()
  .AddContext<Context>()                // Adds EF Core context with your content types
);

builder.Services.AddDbContext<Context>(options => options
  .UseCosmos(
    builder.Configuration.GetConnectionString("CosmosConnectionString") ?? throw new Exception("CosmosEndpoint needed"),
    builder.Configuration["CosmosDatabase"] ?? throw new Exception("CosmosDatabase needed"))
);

builder.Services.Configure<AuthorizationOptions>(o => o.AddPolicy("adminarea", builder => builder.RequireAuthenticatedUser()));

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration);

var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions().MustValidate());

app.MapRazorPages();
app.MapControllers();
app.MapControllerRoute("startpage", "/", new { controller = "Page", action = "StartPage" });

app.Run();
