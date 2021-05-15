using GerenciadorFinanceiroAPI.ViewModels;
using GerenciadorFinanceiroBLL.Entitys;
using GerenciadorFinanceiroBLL.Entitys.Enums;
using GerenciadorFinanceiroDAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorFinanceiroAPI.Services
{
    public class DespesasService
    {
        private readonly IDespesasRepositorio _despesasRepositorio;

        public DespesasService(IDespesasRepositorio despesasRepositorio)
        {
            _despesasRepositorio = despesasRepositorio;
        }

        public async Task Delete(int id)
        {
            await _despesasRepositorio.Delete(id);
        }

        public async Task<ActionResult<IEnumerable<DespesasViewModel>>> GetAll()
        {
            var despesas = await _despesasRepositorio.GetAll().ToListAsync();
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
            return despesasvw;
        }

        public async Task<Despesas> GetById(int id)
        {
            return await _despesasRepositorio.GetById(id);
        }

        public async Task Insert(Despesas despesa)
        {
            await _despesasRepositorio.Insert(despesa);
        }

        public async Task Update(Despesas despesa)
        {
            await _despesasRepositorio.Update(despesa);
        }
    }
}
