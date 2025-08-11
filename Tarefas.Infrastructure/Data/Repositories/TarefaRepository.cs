using Microsoft.EntityFrameworkCore;
using Tarefas.Domain.Entities;
using Tarefas.Domain.Interfaces;
using Tarefas.Infrastructure.Data.Context;

namespace Tarefas.Infrastructure.Data.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {

        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tarefa>> GetAllAsync()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public async Task<Tarefa> GetByIdAsync(int id)
        {
            return await _context.Tarefas.FindAsync(id);
        }
        public async Task<Tarefa> CreateAsync(Tarefa tarefa)
        {

            await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();

            return tarefa;
        }
        public async Task<Tarefa?> UpdateAsync(Tarefa tarefa)
        {
            var tarefaOriginal = await _context.Tarefas.FindAsync(tarefa.Id);
            if (tarefaOriginal != null)
            {
                tarefaOriginal.Titulo = tarefa.Titulo;
                tarefaOriginal.Descricao = tarefa.Descricao;
                tarefaOriginal.EstaCompleta = tarefa.EstaCompleta;
            }
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task<Tarefa> DeleteAsync(int id)
        {
            var tarefa = await GetByIdAsync(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();
            }
            return tarefa;
        }



    }
}
