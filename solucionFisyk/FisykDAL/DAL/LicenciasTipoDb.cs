using System;
using System.Collections.Generic;
using System.Data;
using FisiksAppWeb.Entities;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.DAL
{

    public class LicenciasTipoDb : DalBase
    {
        //________________________________________________________________________________________________________
        public static List<LicenciasTipoDto> ListLicenciasTipo()
        {
            try
            {
                var cmd = GetDbSprocCommand("PRC_LICENCIATIPO_SELECT");
                cmd.Parameters.Add("oCursor", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
                return GetDtoList<LicenciasTipoDto>(ref cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
