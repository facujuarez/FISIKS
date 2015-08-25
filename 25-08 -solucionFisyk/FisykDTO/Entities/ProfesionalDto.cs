using System.Collections.Generic;

namespace FisiksAppWeb.Entities
{
    public class ProfesionalDto :PersonaDto
    {
        public int ProId { get; set; }
        public string ProActivo { get; set; }//1
        public int ProPsnId { get; set; }

        
        public List<ProfesionalMatriculaDto> ProListMatriculas = new List<ProfesionalMatriculaDto>();
        public List<ProfesionalEspecialidadesDto> ProListEspecialidades = new List<ProfesionalEspecialidadesDto>();
        public List<AgendaDto> ProListAgenda = new List<AgendaDto>();
        public List<LicenciasDto> ProListLicencias = new List<LicenciasDto>();

        public ProfesionalDto()
        {
        }
    }
}
