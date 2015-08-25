using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpAfeccionesTipos : DtoParserSqlOracle
    {
        private int _ordTafId;
        private int _ordTafDescripcion;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordTafId = reader.GetOrdinal("tafId");
            _ordTafDescripcion = reader.GetOrdinal("tafDescripcion");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var afeccionesTipos = new AfeccionesTiposDto();
            // 
            if (!reader.IsDBNull(_ordTafId)) { afeccionesTipos.TafId = reader.GetInt32(_ordTafId); }
            // 
            if (!reader.IsDBNull(_ordTafDescripcion)) { afeccionesTipos.TafDescripcion = reader.GetString(_ordTafDescripcion); }
            // IsNew
            afeccionesTipos.IsNew = false;

            return afeccionesTipos;
        }
    }
}
