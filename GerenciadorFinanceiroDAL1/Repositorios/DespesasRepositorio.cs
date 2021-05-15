using GerenciadorFinanceiroBLL.Entitys;
using GerenciadorFinanceiroDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorFinanceiroDAL.Repositorios
{
    public class DespesasRepositorio : RepositorioGenerico<Despesas>, IDespesasRepositorio
    {
        private readonly Context _context;

        public DespesasRepositorio(Context context) : base(context)
        {
            _context = context;
        }
    }
}
