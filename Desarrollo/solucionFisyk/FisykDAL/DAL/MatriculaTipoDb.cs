using System;
using System.Collections.Generic;
using System.Data;
using FisiksAppWeb.Entities;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.DAL
{
    public class MatriculaTipoDb : DalBase
    {
        //________________________________________________________________________________________________________
        public static List<MatriculaTipoDto> ListMatriculaTipo()
        {
            try
            {
                OracleCommand cmd = GetDbSprocCommand("PRC_MATRICULATIPO_SELECT");
                cmd.Parameters.Add("oCursorMatriculaTipo", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
                return GetDtoList<MatriculaTipoDto>(ref cmd);
            }
            catch (Exception e)
            {                
                throw e;
            }
        }

        //________________________________________________________________________________________________________

    }
}
