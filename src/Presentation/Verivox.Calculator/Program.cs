using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Verivox.Application;
using Verivox.Application.Interfaces;
using Verivox.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddHttpContextAccessor()
    .AddHttpClient()
    .AddControllers();

builder.Services
    .AddApplication();

builder.Services
    .AddSingleton<ITariffProvider, TariffProvider>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(configuration =>
{
    configuration.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Verivox Electricity Calculator!",
        Version = "v1"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(configure =>
{
    configure.SwaggerEndpoint("/swagger/v1/swagger.json", "Verivox Electricity Calculator v1");
    configure.RoutePrefix = string.Empty;

    configure.InjectStylesheet("../swagger-ui/swagger.css");
    configure.InjectJavascript("../swagger-ui/swaggerinit.js");

    configure.DocumentTitle = "Verivox API Calculator";

});
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

app.Run();