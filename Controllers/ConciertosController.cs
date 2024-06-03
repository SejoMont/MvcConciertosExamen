using Microsoft.AspNetCore.Mvc;
using MvcConciertosExamen.Models;
using MvcConciertosExamen.Services;

namespace MvcConciertosExamen.Controllers
{
    public class ConciertosController : Controller
    {
        private ServiceApiConciertos service;

        public ConciertosController(ServiceApiConciertos service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Evento> eventos = await this.service.GetEventosAsync();
            List<CategoriaEvento> categorias = await this.service.GetCategoriasAsync();

            ViewData["CATEGORIAS"] = categorias;

            return View(eventos);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int idcategoria)
        {
            List<Evento> eventos = await this.service.GetEventosCategoriaAsync(idcategoria);
            List<CategoriaEvento> categorias = await this.service.GetCategoriasAsync();

            ViewData["CATEGORIAS"] = categorias;

            return View(eventos);
        }

    }
}
