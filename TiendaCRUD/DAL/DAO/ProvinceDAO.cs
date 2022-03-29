using MisDTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class ProvinceDAO : TiendaContext, IDAO<Provincia, ProvinceDetailDTO>
    {
        public bool Delete(Provincia entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Provincia entity)
        {
            throw new NotImplementedException();
        }

        public List<ProvinceDetailDTO> Select()
        {
            try
            {
                List<ProvinceDetailDTO> provincias = new List<ProvinceDetailDTO>();
                var list = db.Provincias.ToList();
                foreach (var item in list)
                {
                    ProvinceDetailDTO dto = new ProvinceDetailDTO();
                    dto.IdProvincia = item.IdProvincia;
                    dto.Descripcion = item.Descripcion;
                    provincias.Add(dto);
                }
                return provincias;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(Provincia entity)
        {
            throw new NotImplementedException();
        }
    }
}
