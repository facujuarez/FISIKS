using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpMatricula : DtoParserSqlOracle
    {
        private int _mtrId;
        private int _mtrDescripcion;
        private int _mtrMttId;

        private int _mttId;
        private int _mttDescripcion;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _mtrId = reader.GetOrdinal("MTRID");
            _mtrDescripcion = reader.GetOrdinal("MTRDESCRIPCION");
            _mtrMttId = reader.GetOrdinal("MTR_MTTID");

            _mttId = reader.GetOrdinal("MTTID");
            _mttDescripcion = reader.GetOrdinal("MTTDESCRIPCION");
            
        }
        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var matricula = new MatriculaDto();
            // 
            if (!reader.IsDBNull(_mtrId)) { matricula.MtrId = reader.GetInt32(_mtrId); }
            // 
            if (!reader.IsDBNull(_mtrDescripcion)) {matricula.MtrDescripcion = reader.GetString(_mtrDescripcion); }
            // 
            if (!reader.IsDBNull(_mttId)) { matricula.MtrTipo.MttId = reader.GetInt32(_mttId); }

            if (!reader.IsDBNull(_mttDescripcion)) { matricula.MtrTipo.MttDescripcion = reader.GetString(_mttDescripcion); }
            
            // IsNew
            matricula.IsNew = false;

            return matricula;
        }
    }
}