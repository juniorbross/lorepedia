using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.IServices;

namespace MvcTemplate.Controllers
{
    [Authorize]
    public class CriatureController : Controller
    {
        private IService Service { get; set; }

        public CriatureController(IService service)
        {
            Service = service;
        }

        // Acción para mostrar todas las criaturas
        public async Task<IActionResult> Index()
        {
            // Obtener todas las criaturas desde el servicio
            CriatureModels model = new CriatureModels();
            model.Criatures = await Service.GetAllCriatures();
            return View(model);
        }

        // Acción GET para mostrar el formulario de agregar criatura
        public IActionResult AddCriature()
        {
            CriatureModel model = new CriatureModel();
            return View(model);
        }

        // Acción POST para agregar una nueva criatura
        [HttpPost]
        public async Task<IActionResult> AddCriature(CriatureModel model)
        {
            if (ModelState.IsValid)
            {
                // Llamar al servicio para agregar la nueva criatura
                await Service.AddCriature(model.Nombre, model.NombreCientifico, model.Tipo, model.Habitat, model.Alimentacion, model.Descripcion, model.ImagenUrl);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
