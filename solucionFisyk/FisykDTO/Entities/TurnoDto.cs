using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class TurnoDto : DtoBase
    {
        public int TrnId { get; set; }
        public string TrnFecha { get; set; }//12
        public string TrnHora { get; set; }//5
        public float TrnMontoCobrado { get; set; }//6,2
        public int TrnEstId { get; set; }
        public int TrnProId { get; set; }
        public int TrnSesId { get; set; }
        public int TrnPaeId { get; set; }
        public int TrnDatId { get; set; }
        public int TrnOspId { get; set; }

        public TurnoDto()
        {
            TrnId = IntNullValue;
            TrnFecha = StringNullValue;
            TrnHora = StringNullValue;
            TrnMontoCobrado = FloatNullValue;
            TrnEstId = IntNullValue;
            TrnProId = IntNullValue;
            TrnSesId = IntNullValue;
            TrnPaeId = IntNullValue;
            TrnDatId = IntNullValue;
            TrnOspId = IntNullValue;
            IsNew = true;
        }
    }
}