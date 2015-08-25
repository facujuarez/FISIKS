using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class VacacionesDto : DtoBase
    {
        public int VacId { get; set; }
        public string VacFechaDesde { get; set; }//12
        public string VacFechaHasta { get; set; }//12
        public int VacProId { get; set; }

        public VacacionesDto()
        {
            VacId = IntNullValue;
            VacFechaDesde = StringNullValue;
            VacFechaHasta = StringNullValue;
            VacProId = IntNullValue;
            IsNew = true;
        }
    }
}