using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpAfeccionesTratamientos : DtoParserSqlOracle
    {
        private int _ordAtsId;
        private int _ordAtsTraId;
        private int _ordAtsAfnId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordAtsId = reader.GetOrdinal("atsId");
            _ordAtsTraId = reader.GetOrdinal("ats_traId");
            _ordAtsAfnId = reader.GetOrdinal("ats_afnId");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var afeccionesTratamientos = new AfeccionesTratamientosDto();
            // 
            if (!reader.IsDBNull(_ordAtsId)) { afeccionesTratamientos.AtsId = reader.GetInt32(_ordAtsId); }
            // 
            if (!reader.IsDBNull(_ordAtsTraId)) { afeccionesTratamientos.AtsTraId = reader.GetInt32(_ordAtsTraId); }
            // 
            if (!reader.IsDBNull(_ordAtsAfnId)) { afeccionesTratamientos.AtsAfnId = reader.GetInt32(_ordAtsAfnId); }
            // IsNew
            afeccionesTratamientos.IsNew = false;

            return afeccionesTratamientos;
        }
    }
}
