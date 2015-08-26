using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpTurno : DtoParserSqlOracle
    {
        private int _ordTurId;
        private int _ordTurTitulo;
        private int _ordTurDescripcion;
        private int _ordTurFechaIni;
        private int _ordTurFechaFin;
        private int _ordTurTodoDia;
        private int _ordTurPae;
        private int _ordTurPro;
        private int _ordTurMonto;
        private int _ordTurOspId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordTurId = reader.GetOrdinal("TurId");
            _ordTurTitulo = reader.GetOrdinal("TurTitulo");
            _ordTurDescripcion = reader.GetOrdinal("TurDescrip");
            _ordTurFechaIni = reader.GetOrdinal("TurFechaIni");
            _ordTurFechaFin = reader.GetOrdinal("TurFechaFin");
            _ordTurTodoDia = reader.GetOrdinal("TurTodoDia");
            _ordTurPae = reader.GetOrdinal("Tur_PaeId");
            _ordTurPro = reader.GetOrdinal("Tur_ProId");
            _ordTurMonto = reader.GetOrdinal("TurMonto");
            _ordTurOspId = reader.GetOrdinal("Tur_OspId");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var turno = new TurneroDto();
            // 
            if (!reader.IsDBNull(_ordTurId)) { turno.TurId = reader.GetInt32(_ordTurId); }
            // 
            if (!reader.IsDBNull(_ordTurTitulo)) { turno.TurTitulo = reader.GetString(_ordTurTitulo); }
            // 
            if (!reader.IsDBNull(_ordTurDescripcion)) { turno.TurDescripcion = reader.GetString(_ordTurDescripcion); }
            // 
            if (!reader.IsDBNull(_ordTurFechaIni)) { turno.TurFechaIni = reader.GetDateTime(_ordTurFechaIni); }
            // 
            if (!reader.IsDBNull(_ordTurFechaFin)) { turno.TurFechaFin = reader.GetDateTime(_ordTurFechaFin); }
            // 
            if (!reader.IsDBNull(_ordTurTodoDia)) { turno.TurTodoDia = reader.GetString(_ordTurTodoDia); }
            // 
            if (!reader.IsDBNull(_ordTurPae)) { turno.TurPae = reader.GetInt32(_ordTurPae); }
            // 
            if (!reader.IsDBNull(_ordTurPro)) { turno.TurPro= reader.GetInt32(_ordTurPro); }
            // 
            if (!reader.IsDBNull(_ordTurMonto)) { turno.TurMonto = reader.GetDecimal(_ordTurMonto); }
            // 
            if (!reader.IsDBNull(_ordTurOspId)) { turno.TurOspId = reader.GetInt32(_ordTurOspId); }
            // IsNew
            turno.IsNew = false;

            return turno;
        }
    }
}