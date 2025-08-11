using Microsoft.EntityFrameworkCore;
using Tarefas.Aplication.DTOs;
using Tarefas.Aplication.Services;
using Tarefas.Aplication.Services.Interfaces;
using Tarefas.Domain.Entities;
using Tarefas.Domain.Interfaces;
using Tarefas.Infrastructure.Data.Context;
using Tarefas.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TarefasDB;Trusted_Connection=True;TrustServerCertificate=True;")
    );

builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
builder.Services.AddScoped<ITarefaService, TarefasService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//endpoints:

// LISTAR TODAS TAREFAS:
app.MapGet("/tarefas", async (ITarefaService tarefaService) =>
{
    var tarefas = await tarefaService.GetAllAsync();
    return Results.Ok(tarefas);
});

// GET BY ID
app.MapGet("/tarefas/{id}", async (ITarefaService tarefaService, int id) =>
{
    var tarefa = await tarefaService.GetByIdAsync(id);
    return tarefa is not null ? Results.Ok(tarefa) : Results.NotFound();
});

// CREATE   
app.MapPost("/tarefas", async (ITarefaService tarefaService, CriarTarefaDTO tarefaDto) =>
{
    var novaTarefa = await tarefaService.CreateAsync(tarefaDto);
    return Results.Created($"/tarefas/{novaTarefa.Id}", novaTarefa);
});

// DELETE
app.MapDelete("/tarefas/{id}", async (ITarefaService tarefaService, int id) =>
{
    await tarefaService.DeleteAsync(id);
    return Results.NoContent();
});

// UPDATE
app.MapPatch("/tarefas/{id}", async (ITarefaService tarefaService, Tarefa tarefa, int id) =>
{
    if(id != tarefa.Id)
    {
        return Results.NoContent();
    }
    await tarefaService.UpdateAsync(tarefa);
    return Results.Ok();
});

// MARK AS COMPLETED
app.MapPut("/tarefas/{id}/concluir", async (int id, ITarefaService tarefaService) =>
{
    await tarefaService.MarkAsCompletedAsync(id);
    return Results.NoContent();
});

app.Run();


