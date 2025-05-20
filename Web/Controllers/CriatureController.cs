using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                await Service.AddCriature(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        // Acción GET para editar una criatura existente
        public async Task<IActionResult> Edit(Guid id)
        {
            var criatureList = await Service.GetAllCriatures();
            var criature = criatureList.FirstOrDefault(c => c.Id == id);

            if (criature == null)
            {
                return NotFound();
            }

            return View("EditCriature", criature); // Asegúrate de tener una vista llamada EditCriature.cshtml
        }

        // Acción POST para actualizar una criatura existente
        [HttpPost]
        public async Task<IActionResult> Edit(CriatureModel model)
        {
            if (ModelState.IsValid)
            {
                await Service.UpdateCriature(model);
                return RedirectToAction("Index");
            }

            return View("EditCriature", model);
        }

        // Acción para eliminar una criatura
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await Service.DeleteCriature(id);
            return RedirectToAction("Index");
        }
        
        // Acción GET para ver los detalles de una criatura
        [HttpGet]
        public async Task<IActionResult> VerMas(Guid id)
        {
            var criatureList = await Service.GetAllCriatures();
            var criature = criatureList.FirstOrDefault(c => c.Id == id);

            if (criature == null)
            {
                return NotFound();
            }

            return View("VerMas", criature); // Asegúrate de crear la vista VerMas.cshtml
        }





    }
}
