using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpTestTipo : DtoParserSqlOracle
    {
        private int _ordTptId;
        private int _ordTptDescripcion;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordTptId = reader.GetOrdinal("tptId");
            _ordTptDescripcion = reader.GetOrdinal("tptDescripcion");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var testTipo = new TestTipoDto();
            // 
            if (!reader.IsDBNull(_ordTptId)) { testTipo.TptId = reader.GetInt32(_ordTptId); }
            // 
            if (!reader.IsDBNull(_ordTptDescripcion)) { testTipo.TptDescripcion = reader.GetString(_ordTptDescripcion); }
            // IsNew
            testTipo.IsNew = false;

            return testTipo;
        }
    }
}