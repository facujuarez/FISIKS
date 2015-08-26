using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class AfeccionesTratamientosDto : DtoBase
    {
        public int AtsId { get; set; }
        public int AtsTraId { get; set; }
        public int AtsAfnId { get; set; }

        public AfeccionesTratamientosDto()
        {
            AtsId = IntNullValue;
            AtsTraId = IntNullValue;
            AtsAfnId = IntNullValue;

            IsNew = true;
        }
    }
}
