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
    public class ReceitasService
    {
        private readonly IReceitasRepositorio _receitasRepositorio;

        public ReceitasService(IReceitasRepositorio receitasRepositorio)
        {
            _receitasRepositorio = receitasRepositorio;
        }

        public async Task Delete(int id)
        {
            await _receitasRepositorio.Delete(id);
        }

        public async Task<ActionResult<IEnumerable<ReceitasViewModel>>> GetAll()
        {
            var receitas = await _receitasRepositorio.GetAll().ToListAsync();
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
            return receitasvw;
        }

        public async Task<Receitas> GetById(int id)
        {
            return await _receitasRepositorio.GetById(id);
        }

        public async Task Insert(Receitas receita)
        {
            await _receitasRepositorio.Insert(receita);
        }

        public async Task Update(Receitas receita)
        {
            await _receitasRepositorio.Update(receita);
        }
    }
}
