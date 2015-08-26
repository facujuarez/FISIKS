using System.Collections.Generic;

namespace FisiksAppWeb.Entities
{
    public class PacienteDto : PersonaDto
    {
        public int PaeId { get; set; }
        public int PaePeso { get; set; }
        public int PaeAltura { get; set; }
        public int PaeTensionMax { get; set; }
        public int PaeTensionMin { get; set; }
        public string PaeActFisica { get; set; }//1
        public int PaePeriodicidad { get; set; }
        public int PaeOcuId { get; set; }
        public int PaePsnId { get; set; }
        
        public List<PacienteOsDto> PaeListObraSocial { get; set; }
        public List<PacienteAntecedentesDto> PaeListAntecedentes { get; set; }
        
        public PacienteDto()
        {
        }
    }
}
