using System;
using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class MatriculaDto : DtoBase
    {
        public int MtrId { get; set; }
        public string MtrDescripcion { get; set; }
        public MatriculaTipoDto MtrTipo { get; set; }

        public MatriculaDto(MatriculaTipoDto mtrTipo)
        {
            MtrId = IntNullValue;
            MtrDescripcion = StringNullValue;
            MtrTipo = mtrTipo;
            IsNew = true;
        }
        public MatriculaDto()
        {
            MtrId = IntNullValue;
            MtrDescripcion = StringNullValue;
            MtrTipo = new MatriculaTipoDto();
            IsNew = true;
        }
    }
}
