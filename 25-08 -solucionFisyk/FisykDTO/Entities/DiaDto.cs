using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class DiaDto : DtoBase
    {
        public int DiaId { get; set; }
        public string DiaDescripcion { get; set; }//45

        public DiaDto()
        {
            DiaId = IntNullValue;
            DiaDescripcion = StringNullValue;
            IsNew = true;
        }
    }
}
