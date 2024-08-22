using Login_Pagina.Models;

namespace Login_Pagina.Servicios.Contrato
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> GetProductos();  // Obtener todos los productos
        Task<Producto> GetProductoById(int id);      // Obtener un producto por su ID
        Task SaveProducto(Producto modelo);          // Guardar un nuevo producto
        Task UpdateProducto(Producto modelo);        // Actualizar un producto existente
        Task DeleteProducto(int id);
    }
}
