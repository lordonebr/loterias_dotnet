using Loteria.Model;
using Loterias.Repositorio;
using Loterias.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loterias.Controllers
{
    [Authorize]
    public class TipoJogoController : Controller
    {
        [AllowAnonymous]
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
        [Authorize(Roles = "Manager")]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult Adicionar(TipoJogo tipoJogo, [FromServices] ITipoJogoRepositorio tipoJogoRepositorio)
        {
            tipoJogoRepositorio.AdicionarTipoJogo(tipoJogo);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult Editar(string id, [FromServices] ITipoJogoRepositorio tipoJogoRepositorio)
        {
            TipoJogo tipoJogo = tipoJogoRepositorio.GetTipoJogo(id);
            return View(tipoJogo);
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult Editar(TipoJogo tipoJogo, [FromServices] ITipoJogoRepositorio tipoJogoRepositorio)
        {
            tipoJogoRepositorio.AtualizaTipoJogo(tipoJogo);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Excluir(string id, [FromServices] ITipoJogoRepositorio tipoJogoRepositorio)
        {
            tipoJogoRepositorio.ExcluirTipoJogo(id);
            return RedirectToAction("Index");
        }

        public ActionResult JogoDuplicado(string name, [FromServices] ITipoJogoRepositorio tipoJogoRepositorio)
        {
            bool nomeValido = false;

            nomeValido = !tipoJogoRepositorio.NomeJogoJaUtilizado(name);

            return Json(nomeValido);
        }
    }

}
