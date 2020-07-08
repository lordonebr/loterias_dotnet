
using System;
using System.ComponentModel.DataAnnotations;

namespace Loteria.Model
{
    public class Jogo
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public TipoJogo TipoJogo { get; set; }

        [Required]
        [Display(Name = "Data do concurso")]
        public DateTime DataConcurso { get; set; }

        [Required]
        [Display(Name = "Número do concurso")]
        public int NumeroConcurso { get; set; }

        [Display(Name = "Dezenas sorteadas do concurso")]
        public string DezenasSorteadas { get; set; }

        [Display(Name = "O prêmio foi acumulado?")]
        public PremioAcumulado PremioAcumulado { get; set; }
    }
}
