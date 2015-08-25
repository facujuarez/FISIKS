using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class AfeccionesTiposDto : DtoBase
    {
        public int TafId { get; set; }
        public string TafDescripcion { get; set; }//45

        public AfeccionesTiposDto()
        {
            TafId = IntNullValue;
            TafDescripcion = StringNullValue;
            IsNew = true;
        }
    }
}
