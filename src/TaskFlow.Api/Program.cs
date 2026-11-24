using TaskFlow.Api.Data;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Api.Services;

var builder = WebApplication.CreateBuilder(args);
/*
AddCors: ativa a configuração de CORS.
AddPolicy: cria uma política chamada AllowAngular.
WithOrigins: autoriza pedidos vindos do Angular.
AllowAnyHeader: permite diferentes cabeçalhos HTTP.
AllowAnyMethod: permite GET, POST, PUT e DELETE.
UseCors: aplica a política aos pedidos recebidos.
*/ 
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
    .AllowAnyHeader()
    .AllowAnyMethod();
    });
});

//ITaskService -> instañcia de TaskService 
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddDbContext<DataBaseCtx>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors("AllowAngular"); 
app.UseHttpsRedirection();

app.MapControllers();

app.Run();