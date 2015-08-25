using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class OcupacionesDto : DtoBase
    {
        public int OcuId { get; set; }
        public string OcuDescripcion { get; set; }//45
        public int OcuOptId { get; set; }

        public OcupacionesDto()
        {
            OcuId = IntNullValue;
            OcuDescripcion = StringNullValue;
            OcuOptId = IntNullValue;
            IsNew = true;
        }
    }
}
