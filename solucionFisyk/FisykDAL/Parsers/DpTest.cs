using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpTest : DtoParserSqlOracle
    {
        private int _ordTstId;
        private int _ordTstObservacion;
        private int _ordTstZcuId;
        private int _ordTstTptId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordTstId = reader.GetOrdinal("tstId");
            _ordTstObservacion = reader.GetOrdinal("tstObservacion");
            _ordTstZcuId = reader.GetOrdinal("tst_zcuId");
            _ordTstTptId = reader.GetOrdinal("tst_tptId");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var test = new TestDto();
            // 
            if (!reader.IsDBNull(_ordTstId)) { test.TstId = reader.GetInt32(_ordTstId); }
            // 
            if (!reader.IsDBNull(_ordTstObservacion)) { test.TstObservacion = reader.GetString(_ordTstObservacion); }
            // 
            if (!reader.IsDBNull(_ordTstZcuId)) { test.TstZcuId = reader.GetInt32(_ordTstZcuId); }
            // 
            if (!reader.IsDBNull(_ordTstTptId)) { test.TstTptId = reader.GetInt32(_ordTstTptId); }
            // IsNew
            test.IsNew = false;

            return test;
        }
    }
}