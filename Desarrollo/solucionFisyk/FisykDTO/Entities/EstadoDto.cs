using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class EstadoDto : DtoBase
    {
        public int EstId { get; set; }
        public string EstDescripcion { get; set; }//45

        public EstadoDto()
        {
            EstId = IntNullValue;
            EstDescripcion = StringNullValue;
            IsNew = true;
        }
    }
}
