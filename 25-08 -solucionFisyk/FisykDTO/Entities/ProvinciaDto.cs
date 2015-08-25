using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class ProvinciaDto : DtoBase
    {
        public int PvcId { get; set; }
        public string PvcDescripcion { get; set; }
        public int PvcPasId { get; set; }

        public ProvinciaDto()
        {
            PvcId = IntNullValue;
            PvcDescripcion = StringNullValue;
            PvcPasId = IntNullValue;
            IsNew = true;
        }
    }
}
