using System;
using System.Collections.Generic;
using System.Data;
using FisiksAppWeb.Entities;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.DAL
{
    public class AntecendenteMedicoDb : DalBase
    {
        //________________________________________________________________________________________________________
        public static List<AntecedenteMedicoDto> ListAntecedenteMedico()
        {
            try
            {
                var cmd = GetDbSprocCommand("PRC_ANTECEDENTESMEDICOS_SELECT");
                cmd.Parameters.Add("oCursorAteMed", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
                return GetDtoList<AntecedenteMedicoDto>(ref cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //________________________________________________________________________________________________________
        public static List<AntecedenteMedicoDto> ListAntecedenteMedicoPaciente(int paeId)
        {
            try
            {
                var cmd = GetDbSprocCommand("PRC_PACIENTEANT_PK");
                cmd.Parameters.Add(CreateParameter("iAPA_PAEID", paeId));//VARCHAR
                cmd.Parameters.Add("oCursor", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
                return GetDtoList<AntecedenteMedicoDto>(ref cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}