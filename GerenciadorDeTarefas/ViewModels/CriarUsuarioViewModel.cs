using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeTarefas.ViewModels
{
    public class CriarUsuarioViewModel
    {
        public string? Nome { get; set; } 
        public string? Senha { get; set; } 
    }
}