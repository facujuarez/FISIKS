using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpLocalidad : DtoParserSqlOracle
    {
        private int _ordLocId;
        private int _ordLocDescripcion;
        private int _ordLocPvcId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordLocId = reader.GetOrdinal("locId");
            _ordLocDescripcion = reader.GetOrdinal("locDescripcion");
            _ordLocPvcId = reader.GetOrdinal("loc_pvcId");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var localidad = new LocalidadDto();
            // 
            if (!reader.IsDBNull(_ordLocId)) { localidad.LocId = reader.GetInt32(_ordLocId); }
            // 
            if (!reader.IsDBNull(_ordLocDescripcion)) { localidad.LocDescripcion = reader.GetString(_ordLocDescripcion); }
            // 
            if (!reader.IsDBNull(_ordLocPvcId)) { localidad.LocPvcId = reader.GetInt32(_ordLocPvcId); }
            // IsNew
            localidad.IsNew = false;

            return localidad;
        }
    }
}