using System;
using System.Collections.Generic;
using System.Data;
using FisiksAppWeb.Entities;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.DAL
{
    public class OcupacionesDb : DalBase
    {
        //________________________________________________________________________________________________________
        public static List<OcupacionesDto> ListOcupaciones()
        {
            try
            {
                var cmd = GetDbSprocCommand("PRC_OCUPACIONES_SELECT");
                cmd.Parameters.Add("oCursorOcupaciones", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
                return GetDtoList<OcupacionesDto>(ref cmd);
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }

        //________________________________________________________________________________________________________
    }
}
