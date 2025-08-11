namespace Tarefas.Domain.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool EstaCompleta { get; set; }
        public DateTime DataDeCriacao { get; set; }
    }
}
