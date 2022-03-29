
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisDTO.DTO;
namespace DAL.DAO
{

    public class DocTypeDAO : TiendaContext, IDAO<TipoDocumento, DocTypeDetailDTO>
    {
        public bool Delete(TipoDocumento entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(TipoDocumento entity)
        {
            throw new NotImplementedException();
        }

        public List<DocTypeDetailDTO> Select()
        {
            try
            {
                List<DocTypeDetailDTO> tipodocs = new List<DocTypeDetailDTO>();
                var list = db.TipoDocumentoes.ToList();
                foreach (var item in list)
                {
                    DocTypeDetailDTO dto = new DocTypeDetailDTO();
                    dto.IdTipoDoc = item.IdTipoDoc;
                    dto.NombreTipoDoc = item.Descripcion;
                    tipodocs.Add(dto);
                }
                return tipodocs;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(TipoDocumento entity)
        {
            throw new NotImplementedException();
        }
    }
}
