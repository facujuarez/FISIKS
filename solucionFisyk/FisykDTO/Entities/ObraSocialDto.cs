using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class ObraSocialDto : DtoBase
    {
        public int OsoId { get; set; }
        public string OsoDescripcion { get; set; }//45
        public int OsoCoseguro { get; set; }
        public string OsoContacto { get; set; }//20

        public ObraSocialDto()
        {
            OsoId = IntNullValue;
            OsoDescripcion = StringNullValue;
            OsoCoseguro = IntNullValue;
            OsoContacto = StringNullValue;
            IsNew = true;
        }
    }
}
