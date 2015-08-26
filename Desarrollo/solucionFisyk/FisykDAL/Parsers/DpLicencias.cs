using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpLicencias : DtoParserSqlOracle
    {
        private int _ordLicId;
        private int _ordLicFechaDesde;
        private int _ordLicFechaHasta;
        private int _ordLicLctId;
        private int _ordLicProId;

        
        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordLicId = reader.GetOrdinal("LICID");
            _ordLicFechaDesde = reader.GetOrdinal("LICFECHADESDE");
            _ordLicFechaHasta = reader.GetOrdinal("LICFECHAHASTA");
            _ordLicLctId = reader.GetOrdinal("LIC_LCTID");
            _ordLicProId = reader.GetOrdinal("LIC_PROID");
        }
        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var lic = new LicenciasDto();
            // 
            if (!reader.IsDBNull(_ordLicId)) { lic.LicId = reader.GetInt32(_ordLicId); }
            // 
            if (!reader.IsDBNull(_ordLicFechaDesde)) { lic.LicFechaDesde = reader.GetDateTime(_ordLicFechaDesde); }
            // 
            if (!reader.IsDBNull(_ordLicFechaHasta)) { lic.LicFechaHasta = reader.GetDateTime(_ordLicFechaHasta); }
            // 
            if (!reader.IsDBNull(_ordLicLctId)) { lic.LicLctId = reader.GetInt32(_ordLicLctId); }
            // 
            if (!reader.IsDBNull(_ordLicProId)) { lic.LicProId = reader.GetInt32(_ordLicProId); }
            // IsNew
            lic.IsNew = false;

            return lic;
        }
    }
}