using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpTratamiento : DtoParserSqlOracle
    {
        private int _ordTraId;
        private int _ordTraDescripcion;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordTraId = reader.GetOrdinal("traId");
            _ordTraDescripcion = reader.GetOrdinal("traDescripcion");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var tratamiento = new TratamientoDto();
            // 
            if (!reader.IsDBNull(_ordTraId)) { tratamiento.TraId = reader.GetInt32(_ordTraId); }
            // 
            if (!reader.IsDBNull(_ordTraDescripcion)) { tratamiento.TraDescripcion = reader.GetString(_ordTraDescripcion); }
            // IsNew
            tratamiento.IsNew = false;

            return tratamiento;
        }
    }
}