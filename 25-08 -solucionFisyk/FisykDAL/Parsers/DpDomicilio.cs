using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpDomicilio : DtoParserSqlOracle
    {
        private int _ordDomId;
        private int _ordDomCalle;
        private int _ordDomNumero;
        private int _ordDomPiso;
        private int _ordDomDpto;
        private int _ordDomLocId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordDomId = reader.GetOrdinal("domId");
            _ordDomCalle = reader.GetOrdinal("domCalle");
            _ordDomNumero = reader.GetOrdinal("domNumero");
            _ordDomPiso = reader.GetOrdinal("domPiso");
            _ordDomDpto = reader.GetOrdinal("domDpto");
            _ordDomLocId = reader.GetOrdinal("dom_locId");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var domicilio = new DomicilioDto();
            // 
            if (!reader.IsDBNull(_ordDomId)) { domicilio.DomId = reader.GetInt32(_ordDomId); }
            // 
            if (!reader.IsDBNull(_ordDomCalle)) { domicilio.DomCalle = reader.GetString(_ordDomCalle); }
            // 
            if (!reader.IsDBNull(_ordDomNumero)) { domicilio.DomNumero = reader.GetInt32(_ordDomNumero); }
            // 
            if (!reader.IsDBNull(_ordDomPiso)) { domicilio.DomPiso = reader.GetString(_ordDomPiso); }
            // 
            if (!reader.IsDBNull(_ordDomDpto)) { domicilio.DomDpto = reader.GetString(_ordDomDpto); }
            // 
            if (!reader.IsDBNull(_ordDomLocId)) { domicilio.DomLocId = reader.GetInt32(_ordDomLocId); }
            // IsNew
            domicilio.IsNew = false;

            return domicilio;
        }
    }
}
