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
                .IsRequired()
                .HasColumnType("decimal(19,2)");

            builder.Property(p => p.Data)
                .IsRequired();

            builder.Property(p => p.DataVencimento);

            builder.Property(p => p.Pago);

            builder.Property(p => p.Recorrente);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(p => p.TipoLancamento)
                .HasColumnName("ID_TIPOLANCAMENTO");

            builder.HasOne(p => p.SubCategoria)
                .WithMany(s => s.Lancamentos)
                .HasForeignKey(l => l.Id_SubCategoria);


            builder.HasOne(s => s.Usuario)
                .WithMany(c => c.Lancamentos)
                .HasForeignKey(s => s.Id_Usuario);

            builder.ToTable("LANCAMENTOS");
        }
    }
}
