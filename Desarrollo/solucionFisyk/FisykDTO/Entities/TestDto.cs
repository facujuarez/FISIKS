using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class TestDto : DtoBase
    {
        public int TstId { get; set; }
        public string TstObservacion { get; set; }//45
        public int TstZcuId { get; set; }
        public int TstTptId { get; set; }

        public TestDto()
        {
            TstId = IntNullValue;
            TstObservacion = StringNullValue;
            TstZcuId = IntNullValue;
            TstTptId = IntNullValue;
            IsNew = true;
        }
    }
}

