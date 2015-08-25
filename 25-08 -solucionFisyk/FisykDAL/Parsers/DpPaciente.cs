using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpPaciente : DtoParserSqlOracle
    {
        private int _ordPaeId;
        private int _ordPaePeso;
        private int _ordPaeAltura;
        private int _ordPaeTensionMax;
        private int _ordPaeTensionMin;
        private int _ordPaeActFisica;
        private int _ordPaePeriodicidad;
        private int _ordPaeOcuId;
        private int _ordPaePsnId;

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
            _ordPaeId = reader.GetOrdinal("paeId");
            _ordPaePeso = reader.GetOrdinal("paePeso");
            _ordPaeAltura = reader.GetOrdinal("paeAltura");
            _ordPaeTensionMax = reader.GetOrdinal("paeTensionMax");
            _ordPaeTensionMin = reader.GetOrdinal("paeTensionMin");
            _ordPaeActFisica = reader.GetOrdinal("paeActFisica");
            _ordPaePeriodicidad = reader.GetOrdinal("paePeriodicidad");
            _ordPaeOcuId = reader.GetOrdinal("pae_OcuId");
            
            _ordPaePsnId = reader.GetOrdinal("pae_psnId");
            
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
            var paciente = new PacienteDto();
            // 
            if (!reader.IsDBNull(_ordPaeId)) { paciente.PaeId = reader.GetInt32(_ordPaeId); }
            // 
            if (!reader.IsDBNull(_ordPaePeso)) { paciente.PaePeso = reader.GetInt32(_ordPaePeso); }
            // 
            if (!reader.IsDBNull(_ordPaeAltura)) { paciente.PaeAltura = reader.GetInt32(_ordPaeAltura); }
            // 
            if (!reader.IsDBNull(_ordPaeTensionMax)) { paciente.PaeTensionMax = reader.GetInt32(_ordPaeTensionMax); }
            // 
            if (!reader.IsDBNull(_ordPaeTensionMin)) { paciente.PaeTensionMin = reader.GetInt32(_ordPaeTensionMin); }
            // 
            if (!reader.IsDBNull(_ordPaeActFisica)) { paciente.PaeActFisica = reader.GetString(_ordPaeActFisica); }
            //
            if (!reader.IsDBNull(_ordPaeOcuId)) { paciente.PaeOcuId = reader.GetInt32(_ordPaeOcuId); }
            // 
            if (!reader.IsDBNull(_ordPaePeriodicidad)) { paciente.PaePeriodicidad = reader.GetInt32(_ordPaePeriodicidad); }
            // 
            if (!reader.IsDBNull(_ordPaePsnId)) { paciente.PaePsnId = reader.GetInt32(_ordPaePsnId); }
            //
            if (!reader.IsDBNull(_ordPsnId)) { paciente.PsnId = reader.GetInt32(_ordPsnId); }
            // 
            if (!reader.IsDBNull(_ordPsnTpdId)) { paciente.PsnTpdId = reader.GetInt32(_ordPsnTpdId); }
            // 
            if (!reader.IsDBNull(_ordPsnNroDcto)) { paciente.PsnNroDcto = reader.GetString(_ordPsnNroDcto); }
            // 
            if (!reader.IsDBNull(_ordPsnNombre)) { paciente.PsnNombre = reader.GetString(_ordPsnNombre); }
            // 
            if (!reader.IsDBNull(_ordPsnApellido)) { paciente.PsnApellido = reader.GetString(_ordPsnApellido); }
            // 
            if (!reader.IsDBNull(_ordPsnFechaNac)) { paciente.PsnFechaNac = reader.GetString(_ordPsnFechaNac); }
            // 
            if (!reader.IsDBNull(_ordPsnTelefono)) { paciente.PsnTelefono = reader.GetString(_ordPsnTelefono); }
            // 
            if (!reader.IsDBNull(_ordPsnEmail)) { paciente.PsnEmail = reader.GetString(_ordPsnEmail); }
            //
            if (!reader.IsDBNull(_ordPsnSexo)) { paciente.PsnSexo = reader.GetString(_ordPsnSexo); }
            // 
            if (!reader.IsDBNull(_ordPsnDomId)) { paciente.PsnDomId = reader.GetInt32(_ordPsnDomId); }
            // 
            if (!reader.IsDBNull(_ordPsnDomicilio)) { paciente.PsnDomicilio = reader.GetString(_ordPsnDomicilio); }
            // IsNew
            paciente.IsNew = false;
 
            return paciente;
        }
    }
}