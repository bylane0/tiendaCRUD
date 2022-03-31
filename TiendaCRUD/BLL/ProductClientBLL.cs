using DAL;
using DAL.DAO;
using MisDTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIENDACRUD.BLL
{

    public class ProductClientBLL : IBLL<ProductClientDetailDTO, ProductClientDTO>
    {
        public bool Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ProductClientDetailDTO entity)
        {
            ProductoCliente procli = new ProductoCliente();
            procli.IdCliente = entity.IdCliente;
            procli.IdProducto = entity.IdProducto;
            procli.Cantidad = entity.Cantidad;
            if (!dao.Select(entity)) // Si NO existe la relación la crea
            {
                return dao.Insert(procli); //Si se pudo crear la relación, devuelve True
            }
            return false; // Si existe la relación devuelve devuelve false al UI
        }
        ProductClientDAO dao = new ProductClientDAO();
        public ProductClientDTO Select()
        {
            ProductClientDTO dto = new ProductClientDTO();
            dto.productsclient = dao.Select();
            return dto;
        }

        public bool Update(ProductClientDetailDTO entity)
        {
            ProductoCliente procli = new ProductoCliente();
            procli.IdCliente = entity.IdCliente;
            procli.IdProducto = entity.IdProducto;
            procli.Cantidad = entity.Cantidad;
            return dao.Update(procli);
        }

        public bool Delete(ProductClientDetailDTO entity)
        {
            ProductoCliente procli = new ProductoCliente();
            procli.IdCliente = entity.IdCliente;
            procli.IdProducto = entity.IdProducto;

            if (dao.Delete(procli))
                return true;
            else
                return false;
       
           
        }
    }
}

