using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class SesionDto : DtoBase
    {
        public int SesId { get; set; }
        public int SesNumero { get; set; }
        public string SesObservacion { get; set; }//500
        public string SesFecha { get; set; }//12
        public string SesHoraInicio { get; set; }//5
        public string SesHoraFin { get; set; }//5
        public string SesUltima { get; set; }//1
        public int SesHcaId { get; set; }

        public SesionDto()
        {
            SesId = IntNullValue;
            SesNumero = IntNullValue;
            SesObservacion = StringNullValue;
            SesFecha = StringNullValue;
            SesHoraInicio = StringNullValue;
            SesHoraFin = StringNullValue;
            SesUltima = StringNullValue;
            SesHcaId = IntNullValue;
            IsNew = true;
        }
    }
}
