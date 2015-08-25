using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpAntecedenteMedico : DtoParserSqlOracle
    {
        private int _ordAmeId;
        private int _ordAmeDescripcion;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordAmeId = reader.GetOrdinal("ameId");
            _ordAmeDescripcion = reader.GetOrdinal("ameDescripcion");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var antecedenteMedico = new AntecedenteMedicoDto();
            // 
            if (!reader.IsDBNull(_ordAmeId)) { antecedenteMedico.AmeId = reader.GetInt32(_ordAmeId); }
            // 
            if (!reader.IsDBNull(_ordAmeDescripcion)) { antecedenteMedico.AmeDescripcion = reader.GetString(_ordAmeDescripcion); }
            // IsNew
            antecedenteMedico.IsNew = false;

            return antecedenteMedico;
        }
    }
}
