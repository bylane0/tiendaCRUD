using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisDTO.DTO
{
    public class ProductClientDetailDTO
    {
        public int IdCliente { get; set; }
        public int IdProducto { get; set; }
        public string NombreCliente { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
    }
}
