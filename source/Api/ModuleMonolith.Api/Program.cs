using ModuleMonolith.Api.Extensions;
using ModuleMonolith.Common.Application;
using ModuleMonolith.Common.Infrastructure;
using ModuleMonolith.Modules.Codes.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication([ModuleMonolith.Modules.Codes.Application.AssemblyReference.Assembly]);

builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("Database")!);

builder.Configuration.AddModuleConfiguration(["events"]);

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

await app.RunAsync();
