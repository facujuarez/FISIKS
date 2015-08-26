using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpSesionDetalle : DtoParserSqlOracle
    {
        private int _ordDesId;
        private int _ordDesObservacion;
        private int _ordDesTraId;
        private int _ordDesSesId;
        private int _ordDseTraId;
        private int _ordDseAfnId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordDesId = reader.GetOrdinal("desId");
            _ordDesObservacion = reader.GetOrdinal("desObservacion");
            _ordDesTraId = reader.GetOrdinal("des_traId");
            _ordDesSesId = reader.GetOrdinal("des_sesId");
            _ordDseTraId = reader.GetOrdinal("dse_traId");
            _ordDseAfnId = reader.GetOrdinal("dse_afnId");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var sesionDetalle = new SesionDetalleDto();
            // 
            if (!reader.IsDBNull(_ordDesId)) { sesionDetalle.DesId = reader.GetInt32(_ordDesId); }
            // 
            if (!reader.IsDBNull(_ordDesObservacion)) { sesionDetalle.DesObservacion = reader.GetString(_ordDesObservacion); }
            // 
            if (!reader.IsDBNull(_ordDesTraId)) { sesionDetalle.DesTraId = reader.GetInt32(_ordDesTraId); }
            // 
            if (!reader.IsDBNull(_ordDesSesId)) { sesionDetalle.DesSesId = reader.GetInt32(_ordDesSesId); }
            // 
            if (!reader.IsDBNull(_ordDseTraId)) { sesionDetalle.DseTraId = reader.GetInt32(_ordDseTraId); }
            // 
            if (!reader.IsDBNull(_ordDseAfnId)) { sesionDetalle.DseAfnId = reader.GetInt32(_ordDseAfnId); }
            // IsNew
            sesionDetalle.IsNew = false;

            return sesionDetalle;
        }
    }
}