using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorFinanceiroAPI.ViewModels
{
    public class DespesasViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime? Referencia { get; set; }
        public string Tipo { get; set; }
    }
}
