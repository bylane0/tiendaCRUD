using DAL.DAO;
using MisDTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIENDACRUD.BLL
{
    public class ProductBLL : IBLL<ProductDetailDTO, ProductDTO>
    {

        public bool Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ProductDetailDTO entity)
        {
            throw new NotImplementedException();
        }
        ProductDAO dao = new ProductDAO();
        public ProductDTO Select()
        {
            ProductDTO dto = new ProductDTO();
            dto.Productos = dao.Select();
            return dto;
        }

        public bool Update(ProductDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ProductDetailDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
