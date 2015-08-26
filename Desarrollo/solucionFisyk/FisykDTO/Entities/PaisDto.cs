using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class PaisDto : DtoBase
    {
        public int PasId { get; set; }
        public string PasDescripcion { get; set; }//45

        public PaisDto()
        {
            PasId = IntNullValue;
            PasDescripcion = StringNullValue;
            IsNew = true;
        }
    }
}
