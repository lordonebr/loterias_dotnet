using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loteria.Model;
using Loterias.Extensions;
using Loterias.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Loterias.Controllers
{
    public class ApiController : Controller
    {
        private ITipoJogoRepositorio _tipoJogoRepositorio;

        public ApiController(ITipoJogoRepositorio tipoJogoRepositorio)
        {
            _tipoJogoRepositorio = tipoJogoRepositorio;
        }

        public IEnumerable<TipoJogo> GetListaTipoJogos()
        {
            return _tipoJogoRepositorio.GetTiposJogo();
        }

        public IEnumerable<string> GetTipoJogos()
        {
            List<TipoJogo> tipoJogos = _tipoJogoRepositorio.GetTiposJogo();
            return tipoJogos.Select(tj => tj.TipoJogoFormated()).ToList();
        }
    }
}
