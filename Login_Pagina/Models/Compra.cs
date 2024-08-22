using System.ComponentModel.DataAnnotations.Schema;

namespace Login_Pagina.Models
{
    public class Compra
    {
        public int Idcompra { get; set; }

        public int Idusuario { get; set; }

        public int Idproducto { get; set; }

        public DateTime FechaCompra { get; set; }

        public int Cantidad { get; set; }

        // Relaciones con las otras tablas
        [ForeignKey("Idproducto")]
        public virtual Producto Producto { get; set; }

        [ForeignKey("Idusuario")]
        public virtual Usuario Usuario { get; set; }
    }
}
