
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisDTO.DTO;
namespace DAL.DAO
{

    public class ClientDAO : DataContext, IDAO<Cliente, ClientDetailDTO>
    {
        public bool Delete(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public List<ClientDetailDTO> Select()
        {
            throw new NotImplementedException();
        }

        public bool Update(Cliente entity)
        {
            throw new NotImplementedException();
        }
    }
}
