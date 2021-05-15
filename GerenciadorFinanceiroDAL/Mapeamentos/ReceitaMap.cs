using GerenciadorFinanceiroBLL.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorFinanceiroDAL.Mapeamentos
{
    public class ReceitaMap : IEntityTypeConfiguration<Receita>
    {
        public void Configure(EntityTypeBuilder<Receita> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Descricao).IsRequired();
            builder.Property(r => r.Valor).IsRequired();
            builder.Property(r => r.Referencia).IsRequired();
            builder.Property(r => r.Tipo).IsRequired();
            builder.ToTable("receitas");
        }
    }
}
