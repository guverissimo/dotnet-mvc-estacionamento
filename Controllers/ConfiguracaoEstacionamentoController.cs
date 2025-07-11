using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstacionamentoMVC.Context;
using EstacionamentoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoMVC.Controllers
{
    public class ConfiguracaoEstacionamentoController : Controller
    {
        private readonly EstacionamentoContext _context;

        public ConfiguracaoEstacionamentoController(EstacionamentoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var configuracao = _context.ConfiguracaoEstacionamentos.FirstOrDefault();
            return View(configuracao);
        }

        [HttpPost]
        public IActionResult Atualizar(ConfiguracaoEstacionamento configuracao)
        {
            if (ModelState.IsValid)
            {
                var c = _context.ConfiguracaoEstacionamentos.Find(configuracao.Id);
                c.ValorInicial = configuracao.ValorInicial;
                c.ValorPorHora = configuracao.ValorPorHora;
                c.ValorMensalidade = configuracao.ValorMensalidade;

                _context.ConfiguracaoEstacionamentos.Update(c);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}