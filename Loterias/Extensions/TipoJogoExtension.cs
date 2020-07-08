using Loteria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loterias.Extensions
{
    public static class TipoJogoExtension
    {
        public static string TipoJogoFormated(this TipoJogo tipoJogo)
        {
            return String.Format("{0} tem {1} dezenas", tipoJogo.Name, tipoJogo.Quantity);
        }
    }
}
