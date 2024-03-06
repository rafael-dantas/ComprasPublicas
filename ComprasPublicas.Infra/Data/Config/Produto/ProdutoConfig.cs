using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComprasPublicas.Infra.Data.Config.Produto
{
    public class ProdutoConfig : IEntityTypeConfiguration<Dominio.Entidades.Produto>
    {
        public void Configure(EntityTypeBuilder<Dominio.Entidades.Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).HasColumnName("Descricao").IsRequired().HasMaxLength(255);
            builder.Property(x => x.DataPregao).HasColumnName("DataPregao").IsRequired().HasColumnType("DATETIME");
            builder.Property(x => x.ValorLicitacao).HasColumnName("ValorLicitacao").IsRequired().HasColumnType("MONEY");
        }
    }
}
