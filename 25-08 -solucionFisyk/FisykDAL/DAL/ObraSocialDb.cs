using System;
using System.Collections.Generic;
using System.Data;
using FisiksAppWeb.Entities;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.DAL
{
    public class ObraSocialDb : DalBase
    {
        //________________________________________________________________________________________________________
        public static List<ObraSocialDto> ListObraSociales()
        {
            try
            {
                var cmd = GetDbSprocCommand("PRC_OBRASOCIALES_SELECT");
                cmd.Parameters.Add("oCursorOSocial", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
                return GetDtoList<ObraSocialDto>(ref cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //________________________________________________________________________________________________________
        public static List<PacienteOsDto> ListObraSocialesPaciente(int paeId)
        {
            try
            {
                var cmd = GetDbSprocCommand("PRC_PACIENTEOS_SELECT");
                cmd.Parameters.Add(CreateParameter("iPAEID", paeId));//VARCHAR
                cmd.Parameters.Add("oCursor", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
                return GetDtoList<PacienteOsDto>(ref cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
