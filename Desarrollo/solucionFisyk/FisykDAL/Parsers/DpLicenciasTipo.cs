using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpLicenciasTipo : DtoParserSqlOracle
    {
        private int _ordLctId;
        private int _ordLctDescripcion;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordLctId = reader.GetOrdinal("lctId");
            _ordLctDescripcion = reader.GetOrdinal("lctDescripcion");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var licTipo = new LicenciasTipoDto();
            // 
            if (!reader.IsDBNull(_ordLctId)) { licTipo.LctId = reader.GetInt32(_ordLctId); }
            // 
            if (!reader.IsDBNull(_ordLctDescripcion)) { licTipo.LctDescripcion = reader.GetString(_ordLctDescripcion); }
            // IsNew
            licTipo.IsNew = false;

            return licTipo;
        }
    }
}