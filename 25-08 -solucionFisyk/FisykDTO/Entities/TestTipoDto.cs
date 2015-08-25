using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class TestTipoDto : DtoBase
    {
        public int TptId { get; set; }
        public string TptDescripcion { get; set; }//45
       
        public TestTipoDto()
        {
            TptId = IntNullValue;
            TptDescripcion = StringNullValue;
            IsNew = true;
        }
    }
}
