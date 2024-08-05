using GerenciadorDeTarefas.Data;
using GerenciadorDeTarefas.Models;
using GerenciadorDeTarefas.Services;
using GerenciadorDeTarefas.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.Controllers
{
    [ApiController]
    [Route("v1/usuarios")]
    public class UsuariosController : ControllerBase
    {
        [HttpPost]
        [Route("autenticar")]
        public async Task<ActionResult<dynamic>> AutenticarAsync(
            [FromServices] AppDbContext context,
            [FromServices] TokenService tokenService,
            [FromBody] CriarUsuarioViewModel model)
        {
            var usuario = await context
                .Usuarios!
                .FirstOrDefaultAsync(x => x.Nome == model.Nome && x.Senha == model.Senha);

            if (usuario == null)
                return NotFound(new { message = "Usuário ou senha inválidos." });
        
            var token = tokenService.GenerateToken(usuario);

            return new
            {
                usuario = new { id = usuario.Id, nome = usuario.Nome },
                token = token
            };
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDbContext context,
            [FromBody] CriarUsuarioViewModel model)
        {
            if (string.IsNullOrEmpty(model.Nome) || string.IsNullOrEmpty(model.Senha))
            {
                return BadRequest(new { message = "Nome ou senha não podem ser vazios." });
            }

            var usuario = new Usuario
            {
                Nome = model.Nome,
                Senha = model.Senha
            };

            try
            {
                await context.Usuarios!.AddAsync(usuario);
                await context.SaveChangesAsync();
                return Created($"v1/usuarios/{usuario.Id}", usuario);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}