using System;
using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class AgendaDto : DtoBase
    {
        public int AgeId { get; set; }
        public string AgeHoraDesde { get; set; }
        public string AgeHoraHasta { get; set; }
        public int AgeProId { get; set; }
        public int AgeDiaId { get; set; }

        public string DiaDescripcion { get; set; }

        public AgendaDto()
        {
            AgeId = IntNullValue;
            AgeHoraDesde = StringNullValue;
            AgeHoraHasta = StringNullValue;
            AgeProId = IntNullValue;
            AgeDiaId = IntNullValue;
            DiaDescripcion = StringNullValue;
            IsNew = true;
        }
    }
}

