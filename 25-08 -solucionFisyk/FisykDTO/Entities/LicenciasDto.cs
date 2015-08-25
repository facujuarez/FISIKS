using System;
using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class LicenciasDto : DtoBase
    {
        public int LicId { get; set; }
        public DateTime LicFechaDesde { get; set; }//12
        public DateTime LicFechaHasta { get; set; }//12
        public int LicProId { get; set; }
        public int LicLctId { get; set; }

        public LicenciasDto()
        {
            LicId = IntNullValue;
            LicFechaDesde = DateTimeNullValue;
            LicFechaHasta = DateTimeNullValue;
            LicProId = IntNullValue;
            LicLctId = IntNullValue;
            IsNew = true;
        }
    }
}
