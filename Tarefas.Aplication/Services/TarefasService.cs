using Tarefas.Aplication.DTOs;
using Tarefas.Aplication.Services.Interfaces;
using Tarefas.Domain.Entities;
using Tarefas.Domain.Interfaces;

namespace Tarefas.Aplication.Services
{
    public class TarefasService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefasService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }
        public async Task<IEnumerable<TarefaDto>> GetAllAsync()
        {
            var tarefasEntidades = await _tarefaRepository.GetAllAsync();

            var tarefasDtos = tarefasEntidades.Select(tarefa => new TarefaDto
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                EstaCompleta = tarefa.EstaCompleta,
                DataDeCriacao = tarefa.DataDeCriacao,
            });
            return tarefasDtos;

        }
        public async Task<Tarefa> GetByIdAsync(int id)
        {
            var tarefa = await _tarefaRepository.GetByIdAsync(id);
            if (tarefa == null)
            {
                throw new Exception("Tarefa não  encontrada");
            }
            return tarefa;
        }
        public async Task<TarefaDto> CreateAsync(CriarTarefaDTO tarefaDto)
        {
            // convertendo dto para a entidade
            var tarefaEntidade = new Tarefa
            {
                Titulo = tarefaDto.Titulo,
                Descricao = tarefaDto.Descricao
            };

            tarefaEntidade.DataDeCriacao = DateTime.Now;
            tarefaEntidade.EstaCompleta = false;

            // chama o repositorio com a entidade
            var novaTarefa = await _tarefaRepository.CreateAsync(tarefaEntidade);

            // converte a entidade em um DTO 
            var dto = new TarefaDto
            {
                Id = novaTarefa.Id,
                Titulo = novaTarefa.Titulo,
                Descricao = novaTarefa.Descricao,
                EstaCompleta = novaTarefa.EstaCompleta,
                DataDeCriacao = novaTarefa.DataDeCriacao
            };



            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var tarefa = await _tarefaRepository.GetByIdAsync(id);
            if (tarefa == null)
            {
                throw new Exception("Tarefa não  encontrada");
            }
            await _tarefaRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(Tarefa tarefa)
        {
            var tarefaOriginal = await _tarefaRepository.GetByIdAsync(tarefa.Id);
            if (tarefaOriginal == null)
            {
                throw new Exception("Tarefa não encontrada");
            }
            await _tarefaRepository.UpdateAsync(tarefa);
        }

        public async Task MarkAsCompletedAsync(int id)
        {
            var tarefa = await _tarefaRepository.GetByIdAsync(id);
            if (tarefa == null)
            {
                throw new Exception("Tarefa não encontrada.");
            }
            tarefa.EstaCompleta = true;
            await _tarefaRepository.UpdateAsync(tarefa);
        }
    }
}
