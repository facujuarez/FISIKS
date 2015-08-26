
using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class AfeccionesDto : DtoBase
    {
        public int AfnId { get; set; }
        public string AfnDescripcion { get; set; }//
        public int AfnTafId { get; set; }
        public int AfnZcuId { get; set; }

        public AfeccionesDto()
        {
            AfnId = IntNullValue;
            AfnDescripcion = StringNullValue;
            AfnTafId = IntNullValue;
            AfnZcuId = IntNullValue;
            IsNew = true;
        }
    }
}
