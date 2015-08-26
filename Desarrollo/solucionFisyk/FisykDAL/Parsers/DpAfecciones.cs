using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpAfecciones : DtoParserSqlOracle
    {
        private int _ordAfnId;
        private int _ordAfnDescripcion;
        private int _ordAfnTafId;
        private int _ordAfnZcuId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordAfnId = reader.GetOrdinal("afnId");
            _ordAfnDescripcion = reader.GetOrdinal("afnDescripcion");
            _ordAfnTafId = reader.GetOrdinal("afn_tafId");
            _ordAfnZcuId = reader.GetOrdinal("afn_zcuId");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var afecciones = new AfeccionesDto();
            // 
            if (!reader.IsDBNull(_ordAfnId)) { afecciones.AfnId = reader.GetInt32(_ordAfnId); }
            // 
            if (!reader.IsDBNull(_ordAfnDescripcion)) { afecciones.AfnDescripcion = reader.GetString(_ordAfnDescripcion); }
            // 
            if (!reader.IsDBNull(_ordAfnTafId)) { afecciones.AfnTafId = reader.GetInt32(_ordAfnTafId); }
            // 
            if (!reader.IsDBNull(_ordAfnZcuId)) { afecciones.AfnZcuId = reader.GetInt32(_ordAfnZcuId); }
            // IsNew
            afecciones.IsNew = false;

            return afecciones;
        }
    }
}
