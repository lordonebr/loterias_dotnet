using Loteria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loterias.Extensions
{
    public static class JogoExtension
    {
        public static List<int> DezenasJogo(this Jogo jogo)
        {
            List<int> lst = jogo.DezenasSorteadas.Split("-").ToList().Select(int.Parse).ToList();
            return lst;
        }
    }
}
