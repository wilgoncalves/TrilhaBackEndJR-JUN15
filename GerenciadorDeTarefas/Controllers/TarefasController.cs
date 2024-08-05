using System;
using System.Threading.Tasks;
using GerenciadorDeTarefas.Data;
using GerenciadorDeTarefas.Models;
using GerenciadorDeTarefas.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.Controllers
{
    [ApiController]
    [Route("v1")]
    public class TarefasController : ControllerBase
    {
        [HttpGet]
        [Route("tarefas")]
        [Authorize]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context)
        {
            var tarefas = await context
                .Tarefas!
                .AsNoTracking()
                .ToListAsync();
            return Ok(tarefas);
        }

        [HttpGet]
        [Route("tarefas/{id}")]
        [Authorize]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var tarefa = await context
                .Tarefas!
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return tarefa == null ? NotFound() : Ok(tarefa);
        }

        [HttpPost]
        [Route("tarefas")]
        [Authorize]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDbContext context,
            [FromBody] CriarTarefaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tarefa = new Tarefa
            {
                Data = DateTime.Now,
                Feito = false,
                Titulo = model.Titulo
            };

            try
            {
                await context.Tarefas!.AddAsync(tarefa);
                await context.SaveChangesAsync();
                return Created($"v1/tarefas/{tarefa.Id}", tarefa);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("tarefas/{id}")]
        [Authorize]
        public async Task<IActionResult> PutAsync(
            [FromServices] AppDbContext context,
            [FromBody] Tarefa model,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tarefa =  await context
                .Tarefas!
                .FirstOrDefaultAsync(x => x.Id == id);
            
            if (tarefa == null)
                return NotFound();
            
            try
            {
                tarefa.Titulo = model.Titulo;
                tarefa.Feito = model.Feito;

                context.Tarefas!.Update(tarefa);
                await context.SaveChangesAsync();
                return Ok(tarefa);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }    

        [HttpDelete]
        [Route("tarefas/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var tarefa = await context
                .Tarefas!
                .FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                context.Tarefas!.Remove(tarefa!);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }
    }
}