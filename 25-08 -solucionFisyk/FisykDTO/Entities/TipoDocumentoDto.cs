using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class TipoDocumentoDto : DtoBase
    {
        public int TpdId { get; set; }
        public string TpdDescripcion { get; set; }//20
       
        public TipoDocumentoDto()
        {
            TpdId = IntNullValue;
            TpdDescripcion = StringNullValue;
            IsNew = true;
        }
    }
}