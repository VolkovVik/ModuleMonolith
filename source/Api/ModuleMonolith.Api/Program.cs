using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using ModuleMonolith.Api.Extensions;
using ModuleMonolith.Api.Middleware;
using ModuleMonolith.Common.Application;
using ModuleMonolith.Common.Infrastructure;
using ModuleMonolith.Modules.Codes.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(t => t.FullName?.Replace("+", "."));
});

builder.Services.AddApplication([ModuleMonolith.Modules.Codes.Application.AssemblyReference.Assembly]);

var databaseConnectionString = builder.Configuration.GetConnectionString("Database")!;
var CacheConnectionString = builder.Configuration.GetConnectionString("Cache")!;
builder.Services.AddInfrastructure(databaseConnectionString, CacheConnectionString);

builder.Configuration.AddModuleConfiguration(["codes"]);

builder.Services.AddHealthChecks()
    .AddNpgSql(databaseConnectionString)
    .AddRedis(CacheConnectionString);

builder.Services.AddCodesModule(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ApplyMigrations();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

CodesModule.MapEndpoints(app);

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

await app.RunAsync();
