using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpVacaciones : DtoParserSqlOracle
    {
        private int _ordVacId;
        private int _ordVacFechaDesde;
        private int _ordVacFechaHasta;
        private int _ordVacProId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordVacId = reader.GetOrdinal("vacId");
            _ordVacFechaDesde = reader.GetOrdinal("vacFechaDesde");
            _ordVacFechaHasta = reader.GetOrdinal("vacFechaHasta");
            _ordVacProId = reader.GetOrdinal("vac_proId");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var vacaciones = new VacacionesDto();
            // 
            if (!reader.IsDBNull(_ordVacId)) { vacaciones.VacId = reader.GetInt32(_ordVacId); }
            // 
            if (!reader.IsDBNull(_ordVacFechaDesde)) { vacaciones.VacFechaDesde = reader.GetString(_ordVacFechaDesde); }
            // 
            if (!reader.IsDBNull(_ordVacFechaHasta)) { vacaciones.VacFechaHasta = reader.GetString(_ordVacFechaHasta); }
            // 
            if (!reader.IsDBNull(_ordVacProId)) { vacaciones.VacProId = reader.GetInt32(_ordVacProId); }
            // IsNew
            vacaciones.IsNew = false;

            return vacaciones;
        }
    }
} 