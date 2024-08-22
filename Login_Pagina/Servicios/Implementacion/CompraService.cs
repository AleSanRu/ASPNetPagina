using Login_Pagina.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Login_Pagina.Servicios.Contrato;


namespace Login_Pagina.Servicios.Implementacion
{
    public class CompraService : ICompraService
    {
        private readonly DbloginUserContext _dbContext;

        public CompraService(DbloginUserContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Compra>> GetCompras()
        {
            return await _dbContext.Compras.Include(c => c.Producto).Include(c => c.Usuario).ToListAsync();
        }

        public async Task<Compra> GetCompraById(int id)
        {
            return await _dbContext.Compras.Include(c => c.Producto).Include(c => c.Usuario)
                .FirstOrDefaultAsync(c => c.Idcompra == id);
        }

        public async Task SaveCompra(Compra modelo)
        {
            _dbContext.Compras.Add(modelo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCompra(Compra modelo)
        {
            _dbContext.Compras.Update(modelo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCompra(int id)
        {
            var compra = await _dbContext.Compras.FindAsync(id);
            if (compra != null)
            {
                _dbContext.Compras.Remove(compra);
                await _dbContext.SaveChangesAsync();
            }
        }
    }

}
