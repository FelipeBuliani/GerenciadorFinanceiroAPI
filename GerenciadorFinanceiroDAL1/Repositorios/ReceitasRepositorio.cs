using GerenciadorFinanceiroBLL.Entitys;
using GerenciadorFinanceiroDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorFinanceiroDAL.Repositorios
{
    public class ReceitasRepositorio : RepositorioGenerico<Receitas>, IReceitasRepositorio
    {
        private readonly Context _context;

        public ReceitasRepositorio(Context context) : base(context)
        {
            _context = context;
        }
    }
}
