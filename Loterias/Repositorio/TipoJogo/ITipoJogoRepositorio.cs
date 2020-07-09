using Loteria.Model;
using System.Collections.Generic;

namespace Loterias.Repositorio
{
    public interface ITipoJogoRepositorio
    {
        public List<TipoJogo> GetTiposJogo();
        void AdicionarTipoJogo(TipoJogo tipoJogo);
        void AtualizaTipoJogo(TipoJogo tipoJogo);
        void ExcluirTipoJogo(string id);
        TipoJogo GetTipoJogo(string id);
        bool NomeJogoJaUtilizado(string nomeJogo);
    }
}