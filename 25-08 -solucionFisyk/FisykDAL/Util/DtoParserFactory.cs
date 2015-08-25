using System;
using FisykDAL.Parsers;
using FisykDAL.Util;

namespace FisykDAL
{
    internal static class DtoParserFactory
    {
        // GetParser
        internal static DtoParserSqlOracle GetParserOracleClient(Type dtoType)
        {
            switch (dtoType.Name)
            {
                case "PacienteDto":
                    return new DpPaciente();
                case "PacienteOsDto":
                    return new DpPacienteOs();
                case "ObraSocialDto":
                    return new DpObraSocial();
                case "OcupacionesDto":
                   return new DpOcupaciones();
                case "AntecedenteMedicoDto":
                   return new DpAntecedenteMedico();
                case "EspecialidadesDto":
                   return new DpEspecialidades();
                case "MatriculaTipoDto":
                   return new DpMatriculaTipo();
                case "ProfesionalDto":
                   return new DpProfesional();
                case "ProfesionalMatriculaDto":
                   return new DpProfesionalMatricula();
                case "MatriculaDto":
                   return new DpMatricula();
                case "AgendaDto":
                   return new DpAgenda();
                case "LicenciasTipoDto":
                   return new DpLicenciasTipo();
                case "TurneroDto":
                   return new DpTurno();

            }

            throw new Exception("Unknown Type");
        }
    }
}
