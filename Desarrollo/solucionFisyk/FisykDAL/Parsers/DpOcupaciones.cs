using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpOcupaciones : DtoParserSqlOracle
    {
        private int _ordOcuId;
        private int _ordOcuDescripcion;
        private int _ordOcuOptId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordOcuId = reader.GetOrdinal("ocuId");
            _ordOcuDescripcion = reader.GetOrdinal("ocuDescripcion");
            _ordOcuOptId = reader.GetOrdinal("ocu_optId");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var ocupaciones = new OcupacionesDto();
            // 
            if (!reader.IsDBNull(_ordOcuId)) { ocupaciones.OcuId = reader.GetInt32(_ordOcuId); }
            // 
            if (!reader.IsDBNull(_ordOcuDescripcion)) { ocupaciones.OcuDescripcion = reader.GetString(_ordOcuDescripcion); }
            // 
            if (!reader.IsDBNull(_ordOcuOptId)) { ocupaciones.OcuOptId = reader.GetInt32(_ordOcuOptId); }
            // IsNew
            ocupaciones.IsNew = false;

            return ocupaciones;
        }
    }
}

