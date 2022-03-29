using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;
using DAL;
using MisDTO.DTO;
using BLL;

namespace TIENDACRUD.BLL
{
    public class ClientBLL : IBLL<ClientDetailDTO, ClientDTO>
    {
        public bool Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ClientDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        ClientDAO daoclientes = new ClientDAO();
        DocTypeDAO daodocs = new DocTypeDAO();
        // daoclientes = new ClientDAO();
        public ClientDTO Select()
        {
            ClientDTO dto = new ClientDTO();
            dto.TipoDocs = daodocs.Select();
            //dto.Clientes = daoclientes.Select();
            //dto.Products = dao.Select(); tipo de doc
            return dto;
        }

        public bool Update(ClientDetailDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
