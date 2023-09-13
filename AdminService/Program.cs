using AdminService.BL;
using AdminService.Services;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configure dependencyInjection

//builder.Services.AddSingleton<IDbConnection,((contex) => new SqlConnection()) >; 
builder.Services.AddSingleton<IDbConnection>(new SqlConnection(builder.Configuration.GetConnectionString("dbContext")));
builder.Services.AddScoped<ITareasServices, TareaService>();

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
