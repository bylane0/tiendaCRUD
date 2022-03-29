using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IBLL<T, K> where T : class where K : class
    {
        //T = ProductDetailDTO
        //K = ProductDTO
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(int ID);
        K Select();
    }
}
