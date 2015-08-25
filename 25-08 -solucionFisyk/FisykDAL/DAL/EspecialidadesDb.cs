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
            var cmd = GetDbSprocCommand("PRC_ESPECIALIDADES_SELECT");
            cmd.Parameters.Add("oCursorEspecialidades", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
            return GetDtoList<EspecialidadesDto>(ref cmd);
        }

        //________________________________________________________________________________________________________
    }

}
