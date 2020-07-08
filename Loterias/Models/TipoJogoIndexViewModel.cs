using Loteria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loterias.Models
{
    public class TipoJogoIndexViewModel
    {
        public List<TipoJogo> TipoJogos { get; set; }

        public int QtTiposJogos { get; set; }

        public int QtJogosMenos10Dezenas { get; set; }
    }
}
