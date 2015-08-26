using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpMatriculaTipo : DtoParserSqlOracle
    {
        private int _mtTId;
        private int _mtTDescripcion;
        
        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _mtTId = reader.GetOrdinal("MTTID");
            _mtTDescripcion = reader.GetOrdinal("MTTDESCRIPCION");
        }
        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var matriculaTipo = new MatriculaTipoDto();
            // 
            if (!reader.IsDBNull(_mtTId)) { matriculaTipo.MttId = reader.GetInt32(_mtTId); }
            // 
            if (!reader.IsDBNull(_mtTDescripcion)) { matriculaTipo.MttDescripcion = reader.GetString(_mtTDescripcion); }
            // IsNew
            matriculaTipo.IsNew = false;

            return matriculaTipo;
        }
    }
}
