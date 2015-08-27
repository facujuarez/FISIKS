using System.Collections.Generic;

namespace FisiksAppWeb.Entities
{
    public class ProfesionalDto :PersonaDto
    {
        public int ProId { get; set; }
        public string ProActivo { get; set; }//1
        public int ProPsnId { get; set; }

        
        public List<ProfesionalMatriculaDto> ProListMatriculas { get; set; }
        public List<ProfesionalEspecialidadesDto> ProListEspecialidades { get; set; }
        public List<AgendaDto> ProListAgenda { get; set; }


        public ProfesionalDto()
        {
        }
    }
}
