using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class EspecialidadesDto : DtoBase
    {
        public int EspId { get; set; }
        public string EspDescripcion { get; set; }

        public EspecialidadesDto()
        {
            EspId = IntNullValue;
            EspDescripcion = StringNullValue;
            IsNew = true;
        }
    }

}
