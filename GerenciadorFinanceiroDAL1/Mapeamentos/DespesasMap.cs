using GerenciadorFinanceiroBLL.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorFinanceiroDAL.Mapeamentos
{
    public class DespesasMap : IEntityTypeConfiguration<Despesas>
    {
        public void Configure(EntityTypeBuilder<Despesas> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Descricao).IsRequired();
            builder.Property(d => d.Valor).IsRequired();
            builder.Property(d => d.Referencia).IsRequired(false);
            builder.Property(d => d.Tipo).IsRequired();
        }
    }
}
