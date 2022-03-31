using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;
using MisDTO.DTO;

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
            Cliente cli = new Cliente();
            cli.Nombre = entity.NombreCliente;
            cli.Direccion = entity.Direccion;
            cli.Provincia = entity.Provincia;
            cli.TipoDoc = entity.TipoDoc;
            cli.NroDoc = entity.NroDoc;
             
            return daoclientes.Insert(cli);
        }

        ClientDAO daoclientes = new ClientDAO();
        DocTypeDAO daodocs = new DocTypeDAO();
        ProvinceDAO daoprovincia = new ProvinceDAO();
       
        public ClientDTO Select()
        {
            ClientDTO dto = new ClientDTO();
            dto.TipoDocs = daodocs.Select();
            dto.Clientes = daoclientes.Select();
            dto.Provincias = daoprovincia.Select();
            return dto;
        }

        public bool Update(ClientDetailDTO entity)
        {
            Cliente cli = new Cliente();
            cli.IdCliente = entity.IdCliente;
            cli.Nombre = entity.NombreCliente;
            cli.Direccion = entity.Direccion;
            cli.Provincia = entity.Provincia;
            cli.TipoDoc = entity.TipoDoc;
            cli.NroDoc = entity.NroDoc;
            return daoclientes.Update(cli);
        }

        public bool Delete(ClientDetailDTO entity)
        {
            Cliente cli = new Cliente();
            cli.IdCliente = entity.IdCliente;
            if (daoclientes.Delete(cli))
                return true;
            else
                return false;
        }
    }
}
