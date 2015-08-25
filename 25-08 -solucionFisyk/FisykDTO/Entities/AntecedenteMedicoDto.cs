using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class AntecedenteMedicoDto : DtoBase
    {
        public int AmeId { get; set; }
        public string AmeDescripcion { get; set; }//45

        public AntecedenteMedicoDto()
        {
            AmeId = IntNullValue;
            AmeDescripcion = StringNullValue;
            IsNew = true;
        }
    }
}
