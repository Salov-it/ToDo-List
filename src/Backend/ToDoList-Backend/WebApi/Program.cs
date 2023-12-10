using UserServices.Application;
using DatabasePostgres.Persistance;


var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

//UserServices
builder.Services.AddUserServices();

//Infrastructure
builder.Services.AddDatabasePostgres();

//TaskListServices
builder.Services.AddTaskListServices();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
