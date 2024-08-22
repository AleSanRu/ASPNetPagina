namespace Login_Pagina.Models
{
    public class Producto
    {
        public int Idproducto { get; set; }

        public string? NombreProducto { get; set; }

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

        // Propiedad de navegación para las compras asociadas a este producto
        public virtual ICollection<Compra>? Compras { get; set; }
    }
}
