using TaskFlow.Api.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();

var app = builder.Build();

// Configurar Http request ao Taskitem.cs , é aqui que tudo começa


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
TaskItem task = new TaskItem();

task.UpdateDescription ("Design and implement a scalable RESTful Web API using C# and ASP.NET Core \n" +
        " applying Object-Oriented Programming (OOP) principles such as encapsulation, abstraction, inheritance, and polymorphism. \n" +
        "Implement backend architecture using Models, Controllers, Services, and Dependency Injection (DI). Develop CRUD operations (Create, Read, Update, Delete),\n" +
       " handle HTTP requests and responses, implement data validation, exception handling, and asynchronous programming with async/await. \n" +
       "Integrate Entity Framework Core (EF Core) with SQL Server for database management, entity relationships, LINQ queries, and database migrations.");
        task.Priority = 1;
        task.IsCompleted = true;

// 1- implementar a lógica de negócio (Services)
//  2-configurar EFW e SQL!!!!! com CRUD , e API rest comuniccacao com frontend ...
// 3- adicionar autenticação e autorização (JWT)
// 4- Sistema de Registo e login prevenindo vulnerabilidades de codigo 


Console.WriteLine(task.Title);
Console.WriteLine(task.Description);
Console.WriteLine(task.Priority);
Console.WriteLine(task.IsCompleted);
Console.WriteLine(task.CreatedAt);
app.Run();

