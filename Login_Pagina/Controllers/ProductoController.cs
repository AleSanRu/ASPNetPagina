using Login_Pagina.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Login_Pagina.Servicios.Contrato;

namespace Login_Pagina.Controllers
{
    [Authorize]
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET: Producto/Index
        public async Task<IActionResult> Index()
        {
            var productos = await _productoService.GetProductos();
            return View(productos);
        }

        // GET: Producto/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var producto = await _productoService.GetProductoById(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // GET: Producto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto modelo)
        {
            if (ModelState.IsValid)
            {
                await _productoService.SaveProducto(modelo);
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        // GET: Producto/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var producto = await _productoService.GetProductoById(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producto modelo)
        {
            if (id != modelo.Idproducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _productoService.UpdateProducto(modelo);
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        // GET: Producto/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _productoService.GetProductoById(id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productoService.DeleteProducto(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
