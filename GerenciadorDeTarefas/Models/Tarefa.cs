using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeTarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        [Required]
        public string? Titulo { get; set; }
        [Required]
        public bool Feito { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
    }
}