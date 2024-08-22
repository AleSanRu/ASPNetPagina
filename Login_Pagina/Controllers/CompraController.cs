using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Login_Pagina.Servicios.Contrato;
using Login_Pagina.Models;
namespace Login_Pagina.Controllers
{
  
    public class CompraController : Controller
    {
        
        private readonly ICompraService _compraService;

        public CompraController(ICompraService compraService)
        {
            _compraService = compraService;
        }

        // GET: Compra/Index
        public async Task<IActionResult> Index()
        {
            var compras = await _compraService.GetCompras();
            return View(compras);
        }

        // GET: Compra/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var compra = await _compraService.GetCompraById(id);
            if (compra == null)
            {
                return NotFound();
            }
            return View(compra);
        }

        // GET: Compra/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Compra/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Compra modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _compraService.SaveCompra(modelo);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging framework)
                    ModelState.AddModelError("", "Error al guardar la compra: " + ex.Message);
                }
            }
            return View(modelo);
        }

        // GET: Compra/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var compra = await _compraService.GetCompraById(id);
            if (compra == null)
            {
                return NotFound();
            }
            return View(compra);
        }

        // POST: Compra/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Compra modelo)
        {
            if (id != modelo.Idcompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _compraService.UpdateCompra(modelo);
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        // GET: Compra/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var compra = await _compraService.GetCompraById(id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _compraService.DeleteCompra(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
