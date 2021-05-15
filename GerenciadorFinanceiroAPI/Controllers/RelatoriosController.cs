using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GerenciadorFinanceiroBLL.Entitys;
using GerenciadorFinanceiroDAL;
using GerenciadorFinanceiroDAL.Interfaces;
using GerenciadorFinanceiroAPI.ViewModels;
using GerenciadorFinanceiroAPI.Services;
using GerenciadorFinanceiroBLL.Entitys.Enums;

namespace GerenciadorFinanceiroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {
        private readonly IReceitasRepositorio _receitasRepositorio;
        private readonly IDespesasRepositorio _despesasRepositorio;

        public RelatoriosController(IReceitasRepositorio receitasRepositorio, IDespesasRepositorio despesasRepositorio)
        {
            _receitasRepositorio = receitasRepositorio;
            _despesasRepositorio = despesasRepositorio;
        }

        // GET: api/Relatorios
        [HttpGet("{minDate}/{maxDate}")]
        public async Task<ActionResult<RelatorioViewModel>> GetReceitas(DateTime? minDate, DateTime? maxDate)
        {
            {
                var receitas = _receitasRepositorio.GetAll();
                var despesas = _despesasRepositorio.GetAll();
                if (minDate.HasValue)
                {
                    receitas = receitas.Where(r => r.Referencia >= minDate || r.Tipo == 0);
                    despesas = despesas.Where(d => d.Referencia >= minDate || d.Tipo == 0);
                }
                if (maxDate.HasValue)
                {
                    receitas = receitas.Where(r => r.Referencia <= maxDate || r.Tipo == 0);
                    despesas = despesas.Where(d => d.Referencia <= maxDate || d.Tipo == 0);
                }

                List<ReceitasViewModel> receitasvw = new List<ReceitasViewModel>();
                foreach (var r in receitas)
                {
                    ReceitasViewModel vw = new ReceitasViewModel
                    {
                        Id = r.Id,
                        Descricao = r.Descricao,
                        Valor = r.Valor,
                        Referencia = r.Referencia,
                        Tipo = Enum<Tipo>.GetDescriptionOf(r.Tipo),
                    };
                    receitasvw.Add(vw);
                }

                List<DespesasViewModel> despesasvw = new List<DespesasViewModel>();
                foreach (var d in despesas)
                {
                    DespesasViewModel vw = new DespesasViewModel
                    {
                        Id = d.Id,
                        Descricao = d.Descricao,
                        Valor = d.Valor,
                        Referencia = d.Referencia,
                        Tipo = Enum<Tipo>.GetDescriptionOf(d.Tipo),
                    };
                    despesasvw.Add(vw);
                }

                var valorTotalReceitas = receitas.Sum(r => r.Valor);
                var valorTotalDespesas = despesas.Sum(d => d.Valor);
                var resultado = valorTotalReceitas - valorTotalDespesas;

                RelatorioViewModel relatoriovw = new RelatorioViewModel(receitasvw.ToList(), despesasvw.ToList(), valorTotalReceitas, valorTotalDespesas, resultado);
                return relatoriovw;

            }
        }
    }
}
