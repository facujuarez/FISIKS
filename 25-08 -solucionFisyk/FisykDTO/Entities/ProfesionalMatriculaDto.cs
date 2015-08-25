using System;
using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class ProfesionalMatriculaDto : DtoBase
    {
        public int PmtId { get; set; }
        public int PmtProId { get; set; }
        public int PmtMttId { get; set; }
        public string PmtNro { get; set; }

        public string MttDescripcion { get; set; }//45

        public ProfesionalMatriculaDto()
        {
            PmtId = IntNullValue;
            PmtProId = IntNullValue;
            PmtMttId = IntNullValue;
            PmtNro = StringNullValue;

            MttDescripcion = StringNullValue;

            IsNew = true;
        }
    }
}