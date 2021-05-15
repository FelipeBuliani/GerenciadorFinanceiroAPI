using GerenciadorFinanceiroBLL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorFinanceiroAPI.ViewModels
{
    public class RelatorioViewModel
    {
        public List<ReceitasViewModel> Receitas { get; set; }
        public List<DespesasViewModel> Despesas { get; set; }
        public double ValorTotalReceitas { get; set; }
        public double ValorTotalDespesas { get; set; }
        public double Resultado { get; set; }

        public RelatorioViewModel(List<ReceitasViewModel> receitas, List<DespesasViewModel> despesas, double valorTotalReceitas, double valorTotalDespesas, double resultado)
        {
            Receitas = receitas;
            Despesas = despesas;
            ValorTotalReceitas = valorTotalReceitas;
            ValorTotalDespesas = valorTotalDespesas;
            Resultado = resultado;
        }
    }
}
