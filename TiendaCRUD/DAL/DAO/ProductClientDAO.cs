using MisDTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class ProductClientDAO : TiendaContext, IDAO<ProductoCliente, ProductClientDetailDTO>
    {
        public bool Delete(ProductoCliente entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ProductoCliente entity)
        {
            try
            {
                db.ProductoClientes.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Select(ProductClientDetailDTO entity)
        {
            try
            {

                List<ProductClientDetailDTO> procli = new List<ProductClientDetailDTO>();
                var list = (from pc in db.ProductoClientes.Where(x => x.IdCliente == entity.IdCliente && x.IdProducto == entity.IdProducto)
                    select new
                    {
                        IdCliente = pc.IdCliente,
                        IdProducto = pc.IdProducto,
                        cantidad = pc.Cantidad

                    }).ToList();
                if (list.Count > 0)
                    return true;
                else
                    return false;

            }


            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<ProductClientDetailDTO> Select()
        {
            try
            {
                List<ProductClientDetailDTO> procli = new List<ProductClientDetailDTO>();
                var list = (from pc in db.ProductoClientes
                            join c in db.Clientes on pc.IdCliente equals c.IdCliente
                            join p in db.Productoes on pc.IdProducto equals p.IdProducto
                            select new
                            {
                                IdCliente = pc.IdCliente,
                                IdProducto = pc.IdProducto,
                                Cantidad = pc.Cantidad,
                                NombreCliente = c.Nombre,
                                NombreProducto = p.Descripcion

                            }).ToList();

                foreach (var item in list)
                {
                    ProductClientDetailDTO dto = new ProductClientDetailDTO
                    {
                        IdCliente = item.IdCliente,
                        IdProducto = item.IdProducto,
                        Cantidad = item.Cantidad,
                        NombreCliente = item.NombreCliente,
                        NombreProducto = item.NombreProducto
                    };
                    procli.Add(dto);
                }
                return procli;
            }


            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(ProductoCliente entity)
        {
            try
            {
                ProductoCliente procli = db.ProductoClientes.First(x => x.IdCliente == entity.IdCliente && x.IdProducto == x.IdProducto);
                procli.Cantidad = entity.Cantidad;
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
