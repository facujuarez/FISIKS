using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class TratamientoDto :DtoBase
    {
        public int TraId { get; set; }
        public string TraDescripcion { get; set; }//45

        public TratamientoDto()
        {
            TraId = IntNullValue;
            TraDescripcion = StringNullValue;
            IsNew = true;
        }
    }
}
