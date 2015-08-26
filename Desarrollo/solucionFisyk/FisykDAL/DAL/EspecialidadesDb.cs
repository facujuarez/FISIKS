using System;
using System.Collections.Generic;
using System.Data;
using FisiksAppWeb.Entities;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.DAL
{
    public class EspecialidadesDb : DalBase
    {
        //________________________________________________________________________________________________________
        public static List<EspecialidadesDto> ListEspecialidades()
        {
            try
            {
                var cmd = GetDbSprocCommand("PRC_ESPECIALIDADES_SELECT");
                cmd.Parameters.Add("oCursorEspecialidades", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
                return GetDtoList<EspecialidadesDto>(ref cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //________________________________________________________________________________________________________
        public static List<EspecialidadesDto> ListEspecialidadProfesional(int proId)
        {
            try
            {
                var cmd = GetDbSprocCommand("PRC_PROFESIONALESP_PK");
                cmd.Parameters.Add(CreateParameter("iPEP_PROID", proId));//VARCHAR
                cmd.Parameters.Add("oCursor", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
                return GetDtoList<EspecialidadesDto>(ref cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

}
