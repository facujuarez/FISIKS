using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpDiaAtencion : DtoParserSqlOracle
    {
        private int _ordDatId;
        private int _ordDatTdaId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordDatId = reader.GetOrdinal("datId");
            _ordDatTdaId = reader.GetOrdinal("dat_tdaId");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var diaAtencion = new DiaAtencionDto();
            // 
            if (!reader.IsDBNull(_ordDatId)) { diaAtencion.DatId = reader.GetInt32(_ordDatId); }
            // 
            if (!reader.IsDBNull(_ordDatTdaId)) { diaAtencion.DatTdaId = reader.GetInt32(_ordDatTdaId); }
            // IsNew
            diaAtencion.IsNew = false;

            return diaAtencion;
        }
    }
}
