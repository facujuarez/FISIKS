using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpObraSocial : DtoParserSqlOracle
    {
        private int _ordOsoId;
        private int _ordOsoDescripcion;
        private int _ordOsoCoseguro;
        private int _ordOsoContacto;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordOsoId = reader.GetOrdinal("osoId");
            _ordOsoDescripcion = reader.GetOrdinal("osoDescripcion");
            _ordOsoCoseguro = reader.GetOrdinal("osoCoseguro");
            _ordOsoContacto = reader.GetOrdinal("osoContacto");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var obraSocial = new ObraSocialDto();
            // 
            if (!reader.IsDBNull(_ordOsoId)) { obraSocial.OsoId = reader.GetInt32(_ordOsoId); }
            // 
            if (!reader.IsDBNull(_ordOsoDescripcion)) { obraSocial.OsoDescripcion = reader.GetString(_ordOsoDescripcion); }
            // 
            if (!reader.IsDBNull(_ordOsoCoseguro)) { obraSocial.OsoCoseguro = reader.GetInt32(_ordOsoCoseguro); }
            // 
            if (!reader.IsDBNull(_ordOsoContacto)) { obraSocial.OsoContacto = reader.GetString(_ordOsoContacto); }
            // IsNew
            obraSocial.IsNew = false;

            return obraSocial;
        }
    }
}