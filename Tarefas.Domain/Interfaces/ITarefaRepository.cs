using Tarefas.Domain.Entities;

namespace Tarefas.Domain.Interfaces
{
    public interface ITarefaRepository
    {
        Task<Tarefa?> GetByIdAsync(int id);
        Task<List<Tarefa>> GetAllAsync();
        Task<Tarefa> CreateAsync(Tarefa tarefa);
        Task<Tarefa> UpdateAsync(Tarefa tarefa);
        Task<Tarefa?> DeleteAsync(int id);
    }
}
