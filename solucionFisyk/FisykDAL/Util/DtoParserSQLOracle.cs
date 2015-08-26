using System;
using FisiksAppWeb.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Util
{
    internal abstract class DtoParserSqlOracle : DtoParser
    {
        abstract internal DtoBase PopulateDto(OracleDataReader reader);

        abstract internal void PopulateOrdinals(OracleDataReader reader);

        internal int GetOrdinalOrThrow(OracleDataReader reader, string columnName)
        {
            try
            {
                return reader.GetOrdinal(columnName);
            }
            catch (IndexOutOfRangeException)
            {
                return -1;
            }
        }
    }
}
