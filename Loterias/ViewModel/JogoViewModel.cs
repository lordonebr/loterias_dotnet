using Loteria.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Loterias.ViewModel
{
    public class JogoViewModel
    {
        [Required]
        [Display(Name = "Tipo de jogo")]
        public string CodigoTipoJogo { get; set; }

        public JogoViewModel()
        {
            OptionsPremioAcumulado = new Dictionary<int, string>();
            OptionsPremioAcumulado.Add((int)PremioAcumulado.Sim, "Sim");
            OptionsPremioAcumulado.Add((int)PremioAcumulado.Nao, "Não");
            OptionsPremioAcumulado.Add((int)PremioAcumulado.NA, "N/A");

            OptionsTipoJogo = new Dictionary<string, string>();
        }

        public Jogo Jogo { get; set; }

        public Dictionary<int, string> OptionsPremioAcumulado { get; set; }

        public Dictionary<string, string> OptionsTipoJogo { get; set; }

    }
}
