using OnionTemplate.Persistence;
using OnionTemplate.Application;
using OnionTemplate.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrations
builder.Services.AddApplicationRegistration();
builder.Services.AddPersistenceRegistration(builder.Configuration);
builder.Host.AddLoggingRegisteration(builder.Configuration);

builder.Services.AddLogging(logger => 
{
    logger.AddConsole();
    logger.AddDebug();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
