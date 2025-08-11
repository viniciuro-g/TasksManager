using Tarefas.Aplication.DTOs;
using Tarefas.Domain.Entities;

namespace Tarefas.Aplication.Services.Interfaces
{
    public interface ITarefaService
    {
        Task<IEnumerable<TarefaDto>> GetAllAsync();
        Task<Tarefa> GetByIdAsync(int id);
        Task<TarefaDto> CreateAsync(CriarTarefaDTO tarefaDto);
        Task UpdateAsync(Tarefa tarefa);
        Task DeleteAsync(int id);
        Task MarkAsCompletedAsync(int id);
    }
}
