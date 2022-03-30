using MisDTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class ProductDAO : TiendaContext, IDAO<Producto, ProductDetailDTO>
    {
        public bool Delete(Producto entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Producto entity)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDTO> Select()
        {
            try
            {
                List<ProductDetailDTO> productos = new List<ProductDetailDTO>();
                var list = db.Productoes.ToList();
                foreach (var item in list)
                {
                    ProductDetailDTO dto = new ProductDetailDTO();
                    dto.IdProducto = item.IdProducto;
                    dto.Descripcion = item.Descripcion;
                    productos.Add(dto);
                }
                return productos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(Producto entity)
        {
            throw new NotImplementedException();
        }
    }
}
