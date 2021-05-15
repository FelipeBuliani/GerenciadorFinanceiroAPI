using GerenciadorFinanceiroBLL.Entitys;
using GerenciadorFinanceiroDAL.Mapeamentos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorFinanceiroDAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Receitas> Receitas { get; set; }
        public DbSet<Despesas> Despesas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ReceitasMap());
            builder.ApplyConfiguration(new DespesasMap());
            base.OnModelCreating(builder);

        }
    }
}
