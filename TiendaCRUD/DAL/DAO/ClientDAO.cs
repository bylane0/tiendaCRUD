
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisDTO.DTO;
namespace DAL.DAO
{

    public class ClientDAO : TiendaContext, IDAO<Cliente, ClientDetailDTO>
    {
        public bool Delete(Cliente entity)
        {
            try
            {
                db.Delete_Cliente(entity.IdCliente); // Stored procedure
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Cliente entity)
        {
            try
            {
                db.Clientes.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ClientDetailDTO> Select()
        {
            try
            {
                List<ClientDetailDTO> clientes = new List<ClientDetailDTO>();
                var list = (from c in db.Clientes
                            join p in db.Provincias on c.Provincia equals p.IdProvincia
                            join t in db.TipoDocumentoes on c.TipoDoc equals t.IdTipoDoc

                            select new
                            {
                                IdCliente = c.IdCliente,
                                Nombre = c.Nombre,
                                Direccion = c.Direccion,
                                IdProvincia = c.Provincia,
                                NombreProvincia = p.Descripcion,
                                IdTipoDoc = c.TipoDoc,
                                NombreTipoDoc = t.Descripcion,
                                NumeroDoc = c.NroDoc

                            }).OrderBy(x => x.Nombre).ToList();

                foreach (var item in list)
                {
                    ClientDetailDTO dto = new ClientDetailDTO
                    {
                        IdCliente = item.IdCliente,
                        NombreCliente = item.Nombre,
                        Direccion = item.Direccion,
                        Provincia = item.IdProvincia,
                        NombreProvincia = item.NombreProvincia,
                        TipoDoc = item.IdTipoDoc,
                        NombreTipoDoc = item.NombreTipoDoc,
                        NroDoc = item.NumeroDoc

                    };

                    clientes.Add(dto);
                }
                return clientes;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(Cliente entity)
        {
            try
            {
                Cliente cli = db.Clientes.First(x => x.IdCliente == entity.IdCliente);
                cli.Nombre = entity.Nombre;
                cli.Direccion = entity.Direccion;
                cli.Provincia = entity.Provincia;
                cli.TipoDoc = entity.TipoDoc;
                cli.NroDoc = entity.NroDoc;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
