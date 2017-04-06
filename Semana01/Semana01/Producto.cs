using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Semana01
{
    public class Producto
    {
        public int numero { get; set; }
        public String codigoLab { get; set; }
        public String desProd { get; set; }
        public String present { get; set; }
        public Decimal precioVentaFarm { get; set; }
        public int cantidad { get; set; }
        public DateTime fechaProduccion { get; set; }
        public DateTime fechaVencimiento { get; set; }

    }
}
