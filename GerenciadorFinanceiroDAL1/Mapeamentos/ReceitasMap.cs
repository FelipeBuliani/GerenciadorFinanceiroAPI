using GerenciadorFinanceiroBLL.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorFinanceiroDAL.Mapeamentos
{
    public class ReceitasMap : IEntityTypeConfiguration<Receitas>
    {
        public void Configure(EntityTypeBuilder<Receitas> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Descricao).IsRequired();
            builder.Property(r => r.Valor).IsRequired();
            builder.Property(r => r.Referencia).IsRequired(false);
            builder.Property(r => r.Tipo).IsRequired();
        }
    }
}
