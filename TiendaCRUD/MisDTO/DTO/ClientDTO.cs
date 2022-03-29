using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisDTO.DTO
{
    public class ClientDTO
    {
        public List<ClientDetailDTO> Clientes { get; set; }
        public List<DocTypeDetailDTO> TipoDocs { get; set; } // Tipo de documentos DNI, Pasaporte, Libreta (...)

        //Agregar una lista de los n productos vinculados a un cliente. ProductClientDetailDTO
    }
}
