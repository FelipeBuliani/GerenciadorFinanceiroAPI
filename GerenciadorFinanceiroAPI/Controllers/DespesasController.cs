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
using GerenciadorFinanceiroBLL.Entitys.Enums;
using GerenciadorFinanceiroAPI.Services;

namespace GerenciadorFinanceiroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespesasController : ControllerBase
    {
        private readonly DespesasService _despesasService;

        public DespesasController(DespesasService despesasService)
        {
            _despesasService = despesasService;
        }

        // GET: api/Despesas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DespesasViewModel>>> GetDespesa()
        {
            return await _despesasService.GetAll();
        }

        // GET: api/Despesas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Despesas>> GetDespesa(int id)
        {
            var despesa = await _despesasService.GetById(id);

            if (despesa == null)
            {
                return NotFound();
            }

            return despesa;
        }

        // PUT: api/Despesas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDespesa(int id, Despesas despesa)
        {
            if (id != despesa.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                await _despesasService.Update(despesa);
                return Ok(new
                {
                    messagem = $"Despesa {despesa.Descricao} alterada com sucesso"
                });
            }
            
            return BadRequest(ModelState);
        }

        // POST: api/Despesas
        [HttpPost]
        public async Task<ActionResult<Despesas>> PostDespesa(Despesas despesa)
        {
            if (ModelState.IsValid)
            {
                await _despesasService.Insert(despesa);
                return Ok(new
                {
                    messagem = $"Despesa {despesa.Descricao} criada com sucesso"
                });
            }
            return BadRequest(despesa);
        }

        // DELETE: api/Despesas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Despesas>> DeleteDespesa(int id)
        {
            var despesa = await _despesasService.GetById(id);
            if (despesa == null)
            {
                return NotFound();
            }

            await _despesasService.Delete(id);

            return Ok(new
            {
                messagem = $"Despesa {despesa.Descricao} excluida com sucesso"
            });
        }
    }
}
