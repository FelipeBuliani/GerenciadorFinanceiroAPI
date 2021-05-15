using GerenciadorFinanceiroBLL.Entitys.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorFinanceiroBLL.Entitys
{
    public class Receitas
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public Nullable<DateTime> Referencia { get; set; }
        public Tipo Tipo { get; set; }
    }
}
