using ControleFinanceiro.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Data.Mappings
{
    public class SubCategoriaMapping : IEntityTypeConfiguration<SubCategoria>
    {
        public void Configure(EntityTypeBuilder<SubCategoria> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.HasOne(s => s.Categoria)
                .WithMany(c => c.SubCategorias)
                .HasForeignKey(s => s.Id_Categoria);

            builder.Property(p => p.Ativo);

            builder.ToTable("SUBCATEGORIAS");
        }
    }
}
