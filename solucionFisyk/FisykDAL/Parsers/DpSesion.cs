using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpSesion : DtoParserSqlOracle
    {
        private int _ordSesId;
        private int _ordSesNumero;
        private int _ordSesObservacion;
        private int _ordSesFecha;
        private int _ordSesHoraInicio;
        private int _ordSesHoraFin;
        private int _ordSesUltima;
        private int _ordSesHcaId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordSesId = reader.GetOrdinal("sesId");
            _ordSesNumero = reader.GetOrdinal("sesNumero");
            _ordSesObservacion = reader.GetOrdinal("sesObservacion");
            _ordSesFecha = reader.GetOrdinal("sesFecha");
            _ordSesHoraInicio = reader.GetOrdinal("sesHoraInicio");
            _ordSesHoraFin = reader.GetOrdinal("sesHoraFin");
            _ordSesUltima = reader.GetOrdinal("sesUltima");
            _ordSesHcaId = reader.GetOrdinal("ses_hcaId");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var sesion = new SesionDto();
            // 
            if (!reader.IsDBNull(_ordSesId)) { sesion.SesId = reader.GetInt32(_ordSesId); }
            // 
            if (!reader.IsDBNull(_ordSesNumero)) { sesion.SesNumero = reader.GetInt32(_ordSesNumero); }
            // 
            if (!reader.IsDBNull(_ordSesObservacion)) { sesion.SesObservacion = reader.GetString(_ordSesObservacion); }
            // 
            if (!reader.IsDBNull(_ordSesFecha)) { sesion.SesFecha = reader.GetString(_ordSesFecha); }
            // 
            if (!reader.IsDBNull(_ordSesHoraInicio)) { sesion.SesHoraInicio = reader.GetString(_ordSesHoraInicio); }
            // 
            if (!reader.IsDBNull(_ordSesHoraFin)) { sesion.SesHoraFin = reader.GetString(_ordSesHoraFin); }
            // 
            if (!reader.IsDBNull(_ordSesUltima)) { sesion.SesUltima = reader.GetString(_ordSesUltima); }
            // 
            if (!reader.IsDBNull(_ordSesHcaId)) { sesion.SesHcaId = reader.GetInt32(_ordSesHcaId); }
            // IsNew
            sesion.IsNew = false;

            return sesion;
        }
    }
}