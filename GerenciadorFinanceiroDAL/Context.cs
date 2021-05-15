using GerenciadorFinanceiroBLL.models;
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

        public DbSet<Receita> Receita { get; set; }
        public DbSet<Despesa> Despesa { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ReceitaMap());
            builder.ApplyConfiguration(new DespesaMap());
        }
    }
}
