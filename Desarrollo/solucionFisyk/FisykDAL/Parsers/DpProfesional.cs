using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpProfesional : DtoParserSqlOracle
    {
        private int _ordProId;
        private int _ordProPsnId;
        private int _ordProActivo;
        
        private int _ordPsnId;
        private int _ordPsnTpdId;
        private int _ordPsnNroDcto;
        private int _ordPsnNombre;
        private int _ordPsnApellido;
        private int _ordPsnFechaNac;
        private int _ordPsnTelefono;
        private int _ordPsnSexo;
        private int _ordPsnDomId;
        private int _ordPsnDomicilio;
        private int _ordPsnEmail;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordProId = reader.GetOrdinal("proId");
            _ordProPsnId = reader.GetOrdinal("pro_psnId");
            _ordProActivo = reader.GetOrdinal("proActivo");

            _ordPsnId = reader.GetOrdinal("psnId");
            _ordPsnTpdId = reader.GetOrdinal("psn_tpdId");
            _ordPsnNroDcto = reader.GetOrdinal("psnNroDcto");
            _ordPsnNombre = reader.GetOrdinal("psnNombre");
            _ordPsnApellido = reader.GetOrdinal("psnApellido");
            _ordPsnFechaNac = reader.GetOrdinal("psnFechaNac");
            _ordPsnTelefono = reader.GetOrdinal("psnTelefono");
            _ordPsnSexo = reader.GetOrdinal("psnSexo");
            _ordPsnDomId = reader.GetOrdinal("psn_domId");
            _ordPsnDomicilio = reader.GetOrdinal("psnDomicilio");
            _ordPsnEmail = reader.GetOrdinal("psnEmail");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var profesional = new ProfesionalDto();
            // 
            if (!reader.IsDBNull(_ordProId)) { profesional.ProId = reader.GetInt32(_ordProId); }
            // 
            if (!reader.IsDBNull(_ordProPsnId)) { profesional.ProPsnId = reader.GetInt32(_ordProPsnId); }
            // 
            if (!reader.IsDBNull(_ordProActivo)) { profesional.ProActivo = reader.GetString(_ordProActivo); }
            // Profesional - Persona
            if (!reader.IsDBNull(_ordPsnId)) { profesional.PsnId = reader.GetInt32(_ordPsnId); }
            // 
            if (!reader.IsDBNull(_ordPsnTpdId)) { profesional.PsnTpdId = reader.GetInt32(_ordPsnTpdId); }
            // 
            if (!reader.IsDBNull(_ordPsnNroDcto)) { profesional.PsnNroDcto = reader.GetString(_ordPsnNroDcto); }
            // 
            if (!reader.IsDBNull(_ordPsnNombre)) { profesional.PsnNombre = reader.GetString(_ordPsnNombre); }
            // 
            if (!reader.IsDBNull(_ordPsnApellido)) { profesional.PsnApellido = reader.GetString(_ordPsnApellido); }
            // 
            if (!reader.IsDBNull(_ordPsnFechaNac)) { profesional.PsnFechaNac = reader.GetString(_ordPsnFechaNac); }
            // 
            if (!reader.IsDBNull(_ordPsnTelefono)) { profesional.PsnTelefono = reader.GetString(_ordPsnTelefono); }
            // 
            if (!reader.IsDBNull(_ordPsnEmail)) { profesional.PsnEmail = reader.GetString(_ordPsnEmail); }
            // 
            if (!reader.IsDBNull(_ordPsnSexo)) { profesional.PsnSexo = reader.GetString(_ordPsnSexo); }
            // 
            if (!reader.IsDBNull(_ordPsnDomId)) { profesional.PsnDomId = reader.GetInt32(_ordPsnDomId); }
            // 
            if (!reader.IsDBNull(_ordPsnDomicilio)) { profesional.PsnDomicilio = reader.GetString(_ordPsnDomicilio); }
            // IsNew
            profesional.IsNew = false;

            return profesional;
        }
    }
}