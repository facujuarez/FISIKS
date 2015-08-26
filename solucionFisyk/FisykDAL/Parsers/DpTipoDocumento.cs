using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpTipoDocumento : DtoParserSqlOracle
    {
        private int _ordTpdId;
        private int _ordTpdDescripcion;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordTpdId = reader.GetOrdinal("tpdId");
            _ordTpdDescripcion = reader.GetOrdinal("tpdDescripcion");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var tipoDocumento = new TipoDocumentoDto();
            // 
            if (!reader.IsDBNull(_ordTpdId)) { tipoDocumento.TpdId = reader.GetInt32(_ordTpdId); }
            // 
            if (!reader.IsDBNull(_ordTpdDescripcion)) { tipoDocumento.TpdDescripcion = reader.GetString(_ordTpdDescripcion); }
            // IsNew
            tipoDocumento.IsNew = false;

            return tipoDocumento;
        }
    }
}