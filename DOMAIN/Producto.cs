using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DOMAIN
{
    public class Producto
    {
        public const string DefaultPictureName = "dummy.png";

        public Producto()
        {
            pictureName = DefaultPictureName;
            //precio = 12450;
        }

        public int idProducto { get; set; }
        public int SKU { get; set; }

        [Range(0, 10000000, ErrorMessage = "El campo tiene que estar entre 0 y 10 millones.")]
        [Display(Name = "Stock")]
        public int stock { get; set; }

        [Display(Name = "Nombre Foto")]
        public string pictureName { get; set; }

        [Display(Name = "Ruta Foto")]
        public string picturePath { get; set; }

        [RegularExpression(@"^\d+(\.\d{0,2})*$", ErrorMessage = "Positivo con 2 decimales")]
        [Range(0, 9999999999999999.99)]
        [DataType(DataType.Currency)]
        public decimal precio { get; set; }

        [Display(Name = "Producto Activo")]
        public string activo { get; set; }

        public string nombre { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string genero { get; set; }
        public string descripcion { get; set; }
        public int idPrecio { get; set; }
        public int idProveedor { get; set; }
        public int idCategoria { get; set; }
        public DateTime createdOn { get; set; }
        public string createdBy { get; set; }
        public DateTime changedOn { get; set; }
        public string changedBy { get; set; }
        public string ranking { get; set; }
        public string observaciones { get; set; }
        public string color { get; set; }
        public string talle { get; set; }

        [Display(Name = "Descuento")]
        public int idDescuento { get; set; }

        public string picturePath1 { get; set; }
        public string picturePath2 { get; set; }
        public string picturePath3 { get; set; }





    }


}