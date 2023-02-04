using DesafioAutoglass.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Infra.Data.EntitiesConfiguration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Descricao).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Situacao).IsRequired();
            builder.Property(p => p.DataFabricacao).IsRequired();
            builder.Property(p => p.DataValidade).IsRequired();
            builder.Property(p => p.CodigoFornecedor);
            builder.Property(p => p.DescricaoFornecedor).HasMaxLength(200);
            builder.Property(p => p.CnpjFornecedor).HasMaxLength(18);            
        }
    }
}
