using System.Text.Json.Serialization;
using Artisan.III.Server.Fakers;
using Artisan.III.Server.Middlewares;
using Artisan.III.Server.Services;
using Artisan.III.Shared.JsonConverters;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.Converters.Add(new HexCoordinatesJsonConverter());
    });
builder.Services.AddRazorPages();
builder.Services.AddFakers();
builder.Services.AddErrorHandling();
builder.Services.AddServices();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Artisan III API",
        Version = "v1"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Artisan III api v1");
    });
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseErrorHandling();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();