using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarefas.Domain.Entities;

namespace Tarefas.Infrastructure.Data.Configurations
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefas");

            builder.HasKey(t => t.Id);


            builder.Property(t => t.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Titulo)
                .HasColumnName("Titulo")
                .HasColumnType("NVARCHAR(200)")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("NVARCHAR(1000)")
                .HasMaxLength(1000);

            builder.Property(t => t.EstaCompleta)
                .HasColumnName("EstaCompleta")
                .HasDefaultValue(false);


            builder.Property(t => t.DataDeCriacao)
                .HasColumnName("DataCriacao")
                .HasColumnType("DATETIME2")
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();


        }
    }
}
