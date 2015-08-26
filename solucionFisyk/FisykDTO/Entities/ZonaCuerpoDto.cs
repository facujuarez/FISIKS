using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class ZonaCuerpoDto : DtoBase
    {
        public int ZcuId { get; set; }
        public string ZcuDescripcion { get; set; }//45
        public int ZcuNivel { get; set; }
        public int ZcuIdPadre { get; set; }

        public ZonaCuerpoDto()
        {
            ZcuId = IntNullValue;
            ZcuDescripcion = StringNullValue;
            ZcuNivel = IntNullValue;
            ZcuIdPadre = IntNullValue;
            IsNew = true;
        }
    }
}
