using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpProfesionalEspecialidades : DtoParserSqlOracle
    {
        private int _ordPepId;
        private int _ordPepProId;
        private int _ordPepEcpId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordPepId = reader.GetOrdinal("pepId");
            _ordPepProId = reader.GetOrdinal("pep_proId");
            _ordPepEcpId = reader.GetOrdinal("pep_espId");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var profesionalEspecialidades = new ProfesionalEspecialidadesDto();
            // 
            if (!reader.IsDBNull(_ordPepId)) { profesionalEspecialidades.PepId = reader.GetInt32(_ordPepId); }
            // 
            if (!reader.IsDBNull(_ordPepProId)) { profesionalEspecialidades.PepProId = reader.GetInt32(_ordPepProId); }
            // 
            if (!reader.IsDBNull(_ordPepEcpId)) { profesionalEspecialidades.PepEpcId = reader.GetInt32(_ordPepEcpId); }
            // IsNew
            profesionalEspecialidades.IsNew = false;

            return profesionalEspecialidades;
        }
    }
}