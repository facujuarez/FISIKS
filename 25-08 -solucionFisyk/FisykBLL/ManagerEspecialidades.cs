using System.Collections.Generic;
using FisiksAppWeb.Entities;
using FisykDAL.DAL;

namespace FisykBLL
{
    public class ManagerEspecialidades
    {
        //________________________________________________________________________________________________________
        //  Lista de Especialidades 
        public static List<EspecialidadesDto> ListEspecialidades()
        {
            return EspecialidadesDb.ListEspecialidades();
        }

    }
}
