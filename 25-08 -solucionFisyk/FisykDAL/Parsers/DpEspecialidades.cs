using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpEspecialidades :DtoParserSqlOracle
    {
        private int _ordEspId;
        private int _ordEspDescripcion;
        
        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordEspId = reader.GetOrdinal("EPCID");
            _ordEspDescripcion = reader.GetOrdinal("EPCDESCRIPCION");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var especialidades = new EspecialidadesDto();
            // 
            if (!reader.IsDBNull(_ordEspId)) { especialidades.EspId = reader.GetInt32(_ordEspId); }
            // 
            if (!reader.IsDBNull(_ordEspDescripcion)) { especialidades.EspDescripcion = reader.GetString(_ordEspDescripcion); }
            // IsNew
            especialidades.IsNew = false;

            return especialidades;
        }
    }
}
   