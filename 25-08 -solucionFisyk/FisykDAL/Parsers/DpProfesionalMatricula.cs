using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpProfesionalMatricula : DtoParserSqlOracle
    {
        private int _ordPmtId;
        private int _ordPmtProId;
        private int _ordPmtMttId;
        private int _ordPmtNro;

        private int _ordMttDescripcion;
        
        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordPmtId = reader.GetOrdinal("PMTID");
            _ordPmtProId = reader.GetOrdinal("PMT_PROID");
            _ordPmtMttId = reader.GetOrdinal("PMT_MTTID");
            _ordPmtNro = reader.GetOrdinal("PMTNRO");

            _ordMttDescripcion = reader.GetOrdinal("MTTDESCRIPCION");
        }
        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var proMat = new ProfesionalMatriculaDto();
            // 
            if (!reader.IsDBNull(_ordPmtId)) { proMat.PmtId = reader.GetInt32(_ordPmtId); }
            // 
            if (!reader.IsDBNull(_ordPmtProId)) { proMat.PmtProId = reader.GetInt32(_ordPmtProId); }
            // 
            if (!reader.IsDBNull(_ordPmtMttId)) { proMat.PmtMttId = reader.GetInt32(_ordPmtMttId); }
            // 
            if (!reader.IsDBNull(_ordPmtNro)) { proMat.PmtNro = reader.GetString(_ordPmtNro); }

            // 
            if (!reader.IsDBNull(_ordMttDescripcion)) { proMat.MttDescripcion = reader.GetString(_ordMttDescripcion); }

            // IsNew
            proMat.IsNew = false;

            return proMat;
        }
    }
}