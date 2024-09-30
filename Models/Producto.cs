using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_scan_codigo_barras.Logica
{
    public class Producto
    {
        public int id_producto { get; set; }
        public string codigoBarras { get; set; }
        public string descripcion { get; set; }
        public string categoriaProducto { get; set; }
        public float precio { get; set; }
        public string marcaProducto { get; set; }
        public byte[] imagenBytes { get; set; }

        public override string ToString()
        {
            return codigoBarras + " " + descripcion + " " + categoriaProducto + " " + precio + " " + marcaProducto + " " + imagenBytes;
        }
    }
}
