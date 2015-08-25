using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class LocalidadDto : DtoBase
    {
        public int LocId { get; set; }
        public string LocDescripcion { get; set; }//45
        public int LocPvcId { get; set; }

        public LocalidadDto()
        {
            LocId = IntNullValue;
            LocDescripcion = StringNullValue;
            LocPvcId = IntNullValue;
            IsNew = true;
        }
    }
}
