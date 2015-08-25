using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpProvincia : DtoParserSqlOracle
    {
        private int _ordPvcId;
        private int _ordPvcDescripcion;
        private int _ordPvcPasId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordPvcId = reader.GetOrdinal("pvcId");
            _ordPvcDescripcion = reader.GetOrdinal("pvcDescripcion");
            _ordPvcPasId = reader.GetOrdinal("pvc_pasId");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var provincia = new ProvinciaDto();
            // 
            if (!reader.IsDBNull(_ordPvcId)) { provincia.PvcId = reader.GetInt32(_ordPvcId); }
            // 
            if (!reader.IsDBNull(_ordPvcDescripcion)) { provincia.PvcDescripcion = reader.GetString(_ordPvcDescripcion); }
            // 
            if (!reader.IsDBNull(_ordPvcPasId)) { provincia.PvcPasId = reader.GetInt32(_ordPvcPasId); }
            // IsNew
            provincia.IsNew = false;

            return provincia;
        }
    }
}