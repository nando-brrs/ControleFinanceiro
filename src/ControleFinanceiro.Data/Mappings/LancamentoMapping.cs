using ControleFinanceiro.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Data.Mappings
{
    public class LancamentoMapping : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Valor)
                .IsRequired();

            builder.Property(p => p.Data)
                .IsRequired();

            builder.Property(p => p.DataVencimento);

            builder.Property(p => p.Pago);

            builder.Property(p => p.Recorrente);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.HasOne(s => s.SubCategoria)
                .WithMany(c => c.Lancamentos)
                .HasForeignKey(s => s.IdSubCategoria);

            builder.HasOne(s => s.Usuario)
                .WithMany(c => c.Lancamentos)
                .HasForeignKey(s => s.IdUsuario);

            builder.ToTable("SUBCATEGORIAS");
        }
    }
}
