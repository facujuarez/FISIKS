using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpPais : DtoParserSqlOracle
    {
        private int _ordPasId;
        private int _ordPasDescripcion;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordPasId = reader.GetOrdinal("pasId");
            _ordPasDescripcion = reader.GetOrdinal("pasDescripcion");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var pais = new PaisDto();
            // 
            if (!reader.IsDBNull(_ordPasId)) { pais.PasId = reader.GetInt32(_ordPasId); }
            // 
            if (!reader.IsDBNull(_ordPasDescripcion)) { pais.PasDescripcion = reader.GetString(_ordPasDescripcion); }
            // IsNew
            pais.IsNew = false;

            return pais;
        }
    }
}