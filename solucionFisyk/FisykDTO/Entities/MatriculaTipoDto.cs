using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class MatriculaTipoDto :DtoBase
    {
        public int MttId { get; set; }
        public string MttDescripcion { get; set; }

        public MatriculaTipoDto()
        {
            MttId = IntNullValue;
            MttDescripcion = StringNullValue;
            IsNew = true;
        }
    }
}