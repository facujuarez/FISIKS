using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class DiaAtencionDto : DtoBase
    {
        public int DatId { get; set; }
        public int DatTdaId { get; set; }

        public DiaAtencionDto()
        {
            DatId = IntNullValue;
            DatTdaId = IntNullValue;
            IsNew = true;
        }
    }
}
