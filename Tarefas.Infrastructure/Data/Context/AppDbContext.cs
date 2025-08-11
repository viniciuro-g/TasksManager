using Microsoft.EntityFrameworkCore;
using Tarefas.Domain.Entities;
using Tarefas.Infrastructure.Data.Configurations;

namespace Tarefas.Infrastructure.Data.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TarefaConfiguration());

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                //aplica o nome das tabelas
                entityType.SetTableName(entityType.DisplayName());
                //aplica as propriedades
                foreach(var property in entityType.GetProperties())
                {
                    if(property.ClrType == typeof(string) && property.GetMaxLength() == null)
                    {
                        property.SetMaxLength(255);
                    }
                }

            }
        }
    }
}
