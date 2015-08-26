using System;
using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class ProfesionalEspecialidadesDto : DtoBase
    {
        public int PepId { get; set; }
        public int PepProId { get; set; }
        public int PepEpcId { get; set; }

        public ProfesionalEspecialidadesDto()
        {
            PepEpcId = IntNullValue;
            PepProId = IntNullValue;
            PepEpcId = IntNullValue;
        }
    }
}
