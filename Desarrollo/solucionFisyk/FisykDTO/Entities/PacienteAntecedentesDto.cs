using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class PacienteAntecedentesDto : DtoBase
    {
        public int ApaId { get; set; }
        public int ApaPaeId { get; set; }
        public int ApaAmeId { get; set; }

        public PacienteAntecedentesDto()
        {
            ApaId = IntNullValue;
            ApaPaeId = IntNullValue;
            ApaAmeId = IntNullValue;
            IsNew = true;
        }
    }
}

