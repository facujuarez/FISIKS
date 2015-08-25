using System;
using System.Data;
using FisiksAppWeb.Entities;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using FisykDAL.Util;

namespace FisykDAL.DAL
{
    public class AgendaDb : DalBase
    {
        // Lista Agenda x Profecional
        public static List<AgendaDto> ListAgendaProfesional(int proId)
        {
            try
            {
                var cmd = GetDbSprocCommand("PRC_PROFESIONALAGE_SELECT");
                cmd.Parameters.Add(CreateParameter("iProId", proId));
                cmd.Parameters.Add("oCursor", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
                return GetDtoList<AgendaDto>(ref cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}