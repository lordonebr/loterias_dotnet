using Loteria.Model;
using Loterias.Models;
using Loterias.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loterias.Controllers
{
    public class TipoJogoController : Controller
    {
        public IActionResult Index([FromServices] ITipoJogoRepositorio tipoJogoRepositorio)
        {
            TipoJogoIndexViewModel model = new TipoJogoIndexViewModel();
            model.TipoJogos = tipoJogoRepositorio.GetTiposJogo();
            model.QtTiposJogos = model.TipoJogos.Count();
            model.QtJogosMenos10Dezenas = model.TipoJogos.Where(tj => tj.Quantity < 10).Count();

            //List<TipoJogo> tipoJogos = tipoJogoRepositorio.GetTiposJogo();
            return View(model);
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(TipoJogo tipoJogo, [FromServices] ITipoJogoRepositorio tipoJogoRepositorio)
        {
            tipoJogoRepositorio.AdicionarTipoJogo(tipoJogo);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(string id, [FromServices] ITipoJogoRepositorio tipoJogoRepositorio)
        {
            TipoJogo tipoJogo = tipoJogoRepositorio.GetTipoJogo(id);
            return View(tipoJogo);
        }

        [HttpPost]
        public IActionResult Editar(TipoJogo tipoJogo, [FromServices] ITipoJogoRepositorio tipoJogoRepositorio)
        {
            tipoJogoRepositorio.AtualizaTipoJogo(tipoJogo);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(string id, [FromServices] ITipoJogoRepositorio tipoJogoRepositorio)
        {
            tipoJogoRepositorio.ExcluirTipoJogo(id);
            return RedirectToAction("Index");
        }
    }

}
