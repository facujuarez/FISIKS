using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpPacienteAntecedentes : DtoParserSqlOracle
    {
        private int _ordApaId;
        private int _ordApaPaeId;
        private int _ordApaAmeId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordApaId = reader.GetOrdinal("apaId");
            _ordApaPaeId = reader.GetOrdinal("apa_paeId");
            _ordApaAmeId = reader.GetOrdinal("apa_ameId");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var pacienteAntecedentes = new PacienteAntecedentesDto();
            // 
            if (!reader.IsDBNull(_ordApaId)) { pacienteAntecedentes.ApaId = reader.GetInt32(_ordApaId); }
            // 
            if (!reader.IsDBNull(_ordApaPaeId)) { pacienteAntecedentes.ApaPaeId = reader.GetInt32(_ordApaPaeId); }
            // 
            if (!reader.IsDBNull(_ordApaAmeId)) { pacienteAntecedentes.ApaAmeId = reader.GetInt32(_ordApaAmeId); }
            // IsNew
            pacienteAntecedentes.IsNew = false;

            return pacienteAntecedentes;
        }
    }
}