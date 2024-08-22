using Login_Pagina.Models;
using Login_Pagina.Servicios.Contrato;
using Microsoft.EntityFrameworkCore;

namespace Login_Pagina.Servicios.Implementacion
{
    public class ProductoService : IProductoService
    {
        private readonly DbloginUserContext _dbContext;

        public ProductoService(DbloginUserContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Producto>> GetProductos()
        {
            return await _dbContext.Productos.ToListAsync();
        }

        public async Task<Producto> GetProductoById(int id)
        {
            return await _dbContext.Productos.FindAsync(id);
        }

        public async Task SaveProducto(Producto producto)
        {
            _dbContext.Productos.Add(producto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProducto(Producto producto)
        {
            _dbContext.Productos.Update(producto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProducto(int id)
        {
            var producto = await _dbContext.Productos.FindAsync(id);
            if (producto != null)
            {
                _dbContext.Productos.Remove(producto);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
