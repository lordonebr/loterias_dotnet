using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Loteria.Model
{
    public class TipoJogo
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do tipo de jogo")]
        [StringLength(50)]
        [Display(Name = "Nome do tipo de jogo")]
        [Remote("JogoDuplicado", "TipoJogo", ErrorMessage = "Jogo j� cadastrado")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Informe o n�mero de dezenas")]
        [Display(Name = "Quantidade de dezenas do jogo")]
        public int Quantity { get; set; }
    }
}