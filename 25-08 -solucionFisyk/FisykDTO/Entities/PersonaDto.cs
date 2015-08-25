using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public abstract class PersonaDto : DtoBase
    {

        public int PsnId { get; set; }
        public int PsnTpdId { get; set; }
        public string PsnNroDcto { get; set; }//10
        public string PsnNombre { get; set; }//45
        public string PsnApellido { get; set; }//45
        public string PsnFechaNac { get; set; }//12
        public string PsnTelefono { get; set; }//20
        public string PsnSexo { get; set; }//1
        public int PsnDomId { get; set; }
        public string PsnEmail { get; set; }

        public string PsnDomicilio { get; set; }//50 -------------------------------------SACAR
        
        public PersonaDto()
        {
            IsNew = true;
        }
    }
}
