using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstacionamentoMVC.Context;
using EstacionamentoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace EstacionamentoMVC.Controllers
{
    public class RegistroEstacionamentoController : Controller
    {
        private readonly EstacionamentoContext _context;

        public RegistroEstacionamentoController(EstacionamentoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var veiculos = _context.Veiculos.AsQueryable();
            ViewBag.Veiculos = _context.Veiculos.ToList();
            var estacionamento = _context.RegistroEstacionamento.ToList();
            return View(estacionamento);
        }

        [HttpPost]
        public IActionResult Index(int? veiculoId)
        {
            var v = _context.Veiculos.Find(veiculoId);

            if (ModelState.IsValid && v != null)
            {
                var registro = new RegistroEstacionamento
                {
                    VeiculoId = v.Id,
                    DataEntrada = DateTime.Now
                };

                _context.RegistroEstacionamento.Add(registro);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Validar()
        {
            return View();
        }

        public IActionResult PesquisarPorPlaca(string placa)
        {
            var veiculo = _context.Veiculos
                .FirstOrDefault(p => p.Placa.Contains(placa));

            if (veiculo != null)
            {
                return RedirectToAction("ValidarEstacionamento", new { veiculoId = veiculo.Id });
            }

            return RedirectToAction("Index");
        }

        public IActionResult ValidarEstacionamento(int veiculoId)
        {
            var registro = _context.RegistroEstacionamento
            .Where(r => r.VeiculoId == veiculoId)
            .FirstOrDefault();

            if (registro == null) return NotFound();

            var configuracao = _context.ConfiguracaoEstacionamentos.FirstOrDefault();

            if (configuracao == null) return NotFound();

            TimeSpan tempoEstacionado = DateTime.Now - registro.DataEntrada;
            int horas = (int)tempoEstacionado.TotalHours;

            registro.Valor = horas * configuracao.ValorPorHora + configuracao.ValorInicial;

            return View("Validar", registro);
        }

    }
}