using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class DiaTipoDto : DtoBase
    {
        public int TdaId { get; set; }
        public string TdaDescripcion { get; set; }//45

        public DiaTipoDto()
        {
            TdaId = IntNullValue;
            TdaDescripcion = StringNullValue;
            IsNew = true;
        }
    }
}

