using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeTarefas.ViewModels
{
    public class CriarTarefaViewModel
    {
        [Required]
        public string? Titulo { get; set; }
    }
}