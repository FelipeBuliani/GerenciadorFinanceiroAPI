using GerenciadorFinanceiroBLL.Entitys;
using GerenciadorFinanceiroDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFinanceiroServices
{
    public class ReceitasService : IReceitasRepositorio
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

        public IQueryable<ReceitasViewModel> GetAll()
        {
            var receitas = await _receitasService.GetAll().ToListAsync();
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

        public Task<ReceitasViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(ReceitasViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(ReceitasViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
