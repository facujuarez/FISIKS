using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class SesionDetalleDto : DtoBase
    {
        public int DesId { get; set; }
        public string DesObservacion { get; set; }//200
        public int DesTraId { get; set; }
        public int DesSesId { get; set; }
        public int DseTraId { get; set; }
        public int DseAfnId { get; set; }

        public SesionDetalleDto()
        {
            DesId = IntNullValue;
            DesObservacion = StringNullValue;
            DesTraId = IntNullValue;
            DesSesId = IntNullValue;
            DseTraId = IntNullValue;
            DseAfnId = IntNullValue;
            IsNew = true;
        }
    }
}