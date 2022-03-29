using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisDTO.DTO
{
    public class ClientDetailDTO
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Direccion { get; set; }
        public int Provincia { get; set; }
        public string NombreProvincia { get; set; }
        public int TipoDoc { get; set; }
        public string NombreTipoDoc { get; set; }
        public string NroDoc { get; set; }

    }
}
