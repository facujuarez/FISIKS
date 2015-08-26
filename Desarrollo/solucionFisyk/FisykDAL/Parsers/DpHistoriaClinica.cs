using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpHistoriaClinica : DtoParserSqlOracle
    {
        private int _ordHcaId;
        private int _ordHcaNroSesiones;
        private int _ordHcaFecha;
        private int _ordHcaAfnId;
        private int _ordHcaPaeId;
        private int _ordHcaCantEvaluaciones;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordHcaId = reader.GetOrdinal("hcaId");
            _ordHcaNroSesiones = reader.GetOrdinal("hcaNroSesiones");
            _ordHcaFecha = reader.GetOrdinal("hcaFecha");
            _ordHcaAfnId = reader.GetOrdinal("hca_afnId");
            _ordHcaPaeId = reader.GetOrdinal("hca_paeId");
            _ordHcaCantEvaluaciones = reader.GetOrdinal("hcaCantEvaluaciones");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var historiaClinica = new HistoriaClinicaDto();
            // 
            if (!reader.IsDBNull(_ordHcaId)) { historiaClinica.HcaId = reader.GetInt32(_ordHcaId); }
            // 
            if (!reader.IsDBNull(_ordHcaNroSesiones)) { historiaClinica.HcaNroSesiones = reader.GetInt32(_ordHcaNroSesiones); }
            // 
            if (!reader.IsDBNull(_ordHcaFecha)) { historiaClinica.HcaFecha = reader.GetDateTime(_ordHcaFecha); }
            // 
            if (!reader.IsDBNull(_ordHcaAfnId)) { historiaClinica.HcaAfnId = reader.GetInt32(_ordHcaAfnId); }
            // 
            if (!reader.IsDBNull(_ordHcaPaeId)) { historiaClinica.HcaPaeId = reader.GetInt32(_ordHcaPaeId); }
            // 
            if (!reader.IsDBNull(_ordHcaCantEvaluaciones)) { historiaClinica.HcaCantEvaluaciones = reader.GetInt32(_ordHcaCantEvaluaciones); }
            // IsNew
            historiaClinica.IsNew = false;

            return historiaClinica;
        }
    }
}

