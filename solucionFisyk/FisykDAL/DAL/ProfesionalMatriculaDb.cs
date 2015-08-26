using System;
using System.Data;
using FisiksAppWeb.Entities;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using FisykDAL.Util;

namespace FisykDAL.DAL
{
    public class ProfesionalMatriculaDb : DalBase
    {
        // Lista ProfesionalMatricula
        public static List<ProfesionalMatriculaDto> ListProfesionalMatricula(int proId)
        {
            try
            {
                var cmd = GetDbSprocCommand("PRC_PROFESIONALMAT_SELECT");
                cmd.Parameters.Add(CreateParameter("iProId", proId));
                cmd.Parameters.Add("oCursor", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
                return GetDtoList<ProfesionalMatriculaDto>(ref cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}