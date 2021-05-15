using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GerenciadorFinanceiroBLL.Entitys;
using GerenciadorFinanceiroAPI.ViewModels;
using GerenciadorFinanceiroBLL.Entitys.Enums;
using GerenciadorFinanceiroAPI.Services;

namespace GerenciadorFinanceiroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly ReceitasService _receitasService;

        public ReceitasController(ReceitasService receitasService)
        {
            _receitasService = receitasService;
        }

        // GET: api/Receitas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceitasViewModel>>> GetReceita()
        {
            return await _receitasService.GetAll();
        }

        // GET: api/Receitas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Receitas>> GetReceita(int id)
        {
            var receita = await _receitasService.GetById(id);

            if (receita == null)
            {
                return NotFound();
            }

            return receita;
        }

        // PUT: api/Receitas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceita(int id, Receitas receita)
        {
            if (id != receita.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _receitasService.Update(receita);
                return Ok(new
                {
                    messagem = $"Receita {receita.Descricao} alterado com sucesso"
                });
            }
            return BadRequest(ModelState);
        }

        // POST: api/Receitas
        [HttpPost]
        public async Task<ActionResult<ReceitasViewModel>> PostReceita(Receitas receita)
        {
            if (ModelState.IsValid)
            {
                await _receitasService.Insert(receita);
                return Ok(new
                {
                    messagem = $"Receita {receita.Descricao} cadastrada com sucesso"
                });
            }
            return BadRequest(receita);
        }

        // DELETE: api/Receitas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Receitas>> DeleteReceita(int id)
        {
            var receita = await _receitasService.GetById(id);
            if (receita == null)
            {
                return NotFound();
            }

            await _receitasService.Delete(id);

            return Ok(new
            {
                messagem = $"Receita {receita.Descricao} excluida com sucesso"
            });
        }
    }
}
