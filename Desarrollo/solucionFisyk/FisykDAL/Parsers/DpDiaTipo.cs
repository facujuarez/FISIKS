using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpDiaTipo : DtoParserSqlOracle
    {
        private int _ordTdaId;
        private int _ordTdaDescripcion;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordTdaId = reader.GetOrdinal("tdaId");
            _ordTdaDescripcion = reader.GetOrdinal("tdaDescripcion");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var diaTipo = new DiaTipoDto();
            // 
            if (!reader.IsDBNull(_ordTdaId)) { diaTipo.TdaId = reader.GetInt32(_ordTdaId); }
            // 
            if (!reader.IsDBNull(_ordTdaDescripcion)) { diaTipo.TdaDescripcion = reader.GetString(_ordTdaDescripcion); }
            // IsNew
            diaTipo.IsNew = false;

            return diaTipo;
        }
    }
}