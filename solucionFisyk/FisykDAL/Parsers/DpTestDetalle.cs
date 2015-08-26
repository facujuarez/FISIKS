using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpTestDetalle : DtoParserSqlOracle
    {
        private int _ordDetId;
        private int _ordDetTstId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordDetId = reader.GetOrdinal("detId");
            _ordDetTstId = reader.GetOrdinal("det_tstId");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var testDetalle = new TestDetalleDto();
            // 
            if (!reader.IsDBNull(_ordDetId)) { testDetalle.DetId = reader.GetInt32(_ordDetId); }
            // 
            if (!reader.IsDBNull(_ordDetTstId)) { testDetalle.DetTstId = reader.GetInt32(_ordDetTstId); }
            // IsNew
            testDetalle.IsNew = false;

            return testDetalle;
        }
    }
}

