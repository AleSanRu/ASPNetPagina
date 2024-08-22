using System.Collections.Generic;
using System.Threading.Tasks;
using Login_Pagina.Models;
using System.Threading.Tasks;

namespace Login_Pagina.Servicios.Contrato
{
    public interface ICompraService
    {
        Task<IEnumerable<Compra>> GetCompras();
        Task<Compra> GetCompraById(int id);
        Task SaveCompra(Compra modelo);
        Task UpdateCompra(Compra modelo);
        Task DeleteCompra(int id);
    }
}
