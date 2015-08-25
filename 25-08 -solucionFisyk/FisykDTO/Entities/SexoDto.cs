using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class SexoDto : DtoBase
    {
        //sexId INT NOT NULL,
        //sexDescripcion VARCHAR(45) NULL,
        public int SexId { get; set; }
        public string SexDescripcion { get; set; }

        public SexoDto(int sexId, string sexDescripcion)
        {
            SexId = sexId;
            SexDescripcion = sexDescripcion;
            IsNew = true;
        }

        public SexoDto()
        {
            SexId = IntNullValue;
            SexDescripcion = StringNullValue;
            IsNew = true;
        }
    }
}
