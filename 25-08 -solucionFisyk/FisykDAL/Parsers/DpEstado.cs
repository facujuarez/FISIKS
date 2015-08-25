using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpEstado : DtoParserSqlOracle
    {
        private int _ordEstId;
        private int _ordEstDescripcion;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordEstId = reader.GetOrdinal("estId");
            _ordEstDescripcion = reader.GetOrdinal("estDescripcion");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var estado = new EstadoDto();
            // 
            if (!reader.IsDBNull(_ordEstId)) { estado.EstId = reader.GetInt32(_ordEstId); }
            // 
            if (!reader.IsDBNull(_ordEstDescripcion)) { estado.EstDescripcion = reader.GetString(_ordEstDescripcion); }
            // IsNew
            estado.IsNew = false;

            return estado;
        }
    }
}

