using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class DomicilioDto : DtoBase
    {
        public int DomId { get; set; }
        public string DomCalle { get; set; }//45
        public int DomNumero { get; set; }
        public string DomPiso { get; set; }//5
        public string DomDpto { get; set; }//5
        public int DomLocId { get; set; }

        public DomicilioDto()
        {
            DomId = IntNullValue;
            DomCalle = StringNullValue;
            DomNumero = IntNullValue;
            DomPiso = StringNullValue;
            DomDpto = StringNullValue;
            DomLocId = IntNullValue;
            IsNew = true;
        }
    }
}
