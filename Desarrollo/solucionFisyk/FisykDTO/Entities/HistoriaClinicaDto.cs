using System;
using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class HistoriaClinicaDto : DtoBase
    {
        public int HcaId { get; set; }
        public int HcaNroSesiones { get; set; }
        public DateTime HcaFecha { get; set; }
        public int HcaAfnId { get; set; }
        public int HcaPaeId { get; set; }
        public int HcaCantEvaluaciones { get; set; }

        public HistoriaClinicaDto()
        {
            HcaId = IntNullValue;
            HcaNroSesiones = IntNullValue;
            HcaFecha = DateTimeNullValue;
            HcaAfnId = IntNullValue;
            HcaPaeId = IntNullValue;
            HcaCantEvaluaciones = IntNullValue;
            IsNew = true;
        }
    }
}
