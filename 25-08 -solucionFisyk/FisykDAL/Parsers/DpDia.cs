using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpDia : DtoParserSqlOracle
    {
        private int _ordDiaId;
        private int _ordDiaDescripcion;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordDiaId = reader.GetOrdinal("diaId");
            _ordDiaDescripcion = reader.GetOrdinal("diaDescripcion");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var dia = new DiaDto();
            // 
            if (!reader.IsDBNull(_ordDiaId)) { dia.DiaId = reader.GetInt32(_ordDiaId); }
            // 
            if (!reader.IsDBNull(_ordDiaDescripcion)) { dia.DiaDescripcion = reader.GetString(_ordDiaDescripcion); }
            // IsNew
            dia.IsNew = false;

            return dia;
        }
    }
}
