using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class LicenciasTipoDto : DtoBase
    {
        public int LctId { get; set; }
        public string LctDescripcion { get; set; }//45

        public LicenciasTipoDto()
        {
            LctId = IntNullValue;
            LctDescripcion = StringNullValue;
            IsNew = true;
        }
    }
}

