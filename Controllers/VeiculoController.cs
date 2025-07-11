using EstacionamentoMVC.Context;
using EstacionamentoMVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace EstacionamentoMVC.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly EstacionamentoContext _context;

        public VeiculoController(EstacionamentoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var veiculos = _context.Veiculos.ToList();
            return View(veiculos);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Veiculos.Add(veiculo);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(veiculo);
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            var v = _context.Veiculos.Find(id);
            _context.Remove(v);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Editar(Veiculo v)
        {
            var vBanco = _context.Veiculos.Find(v.Id);

            if (vBanco == null)
            {
                return NotFound();
            }

            vBanco.Marca = v.Marca;
            vBanco.Modelo = v.Modelo;
            vBanco.Placa = v.Placa;

            _context.Veiculos.Update(vBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}