using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpZonaCuerpo : DtoParserSqlOracle
    {
        private int _ordZcuId;
        private int _ordZcuDescripcion;
        private int _ordZcuNivel;
        private int _ordZcuIdPadre;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordZcuId = reader.GetOrdinal("zcuId");
            _ordZcuDescripcion = reader.GetOrdinal("zcuDescripcion");
            _ordZcuNivel = reader.GetOrdinal("zcuNivel");
            _ordZcuIdPadre = reader.GetOrdinal("zcuIdPadre");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var zonaCuerpo = new ZonaCuerpoDto();
            // 
            if (!reader.IsDBNull(_ordZcuId)) { zonaCuerpo.ZcuId = reader.GetInt32(_ordZcuId); }
            // 
            if (!reader.IsDBNull(_ordZcuDescripcion)) { zonaCuerpo.ZcuDescripcion = reader.GetString(_ordZcuDescripcion); }
            // 
            if (!reader.IsDBNull(_ordZcuNivel)) { zonaCuerpo.ZcuNivel = reader.GetInt32(_ordZcuNivel); }
            // 
            if (!reader.IsDBNull(_ordZcuIdPadre)) { zonaCuerpo.ZcuIdPadre = reader.GetInt32(_ordZcuIdPadre); }
            // IsNew
            zonaCuerpo.IsNew = false;

            return zonaCuerpo;
        }
    }
}