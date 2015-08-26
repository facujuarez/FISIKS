using System;
using System.Collections.Generic;
using FisiksAppWeb.Entities;
using FisykDAL;
using FisykDAL.DAL;

namespace FisykBLL
{
    public class ManagerOcupaciones
    {
        //________________________________________________________________________________________________________
        //  Lista de Ocupaciones
        public static List<OcupacionesDto> ListOcupaciones()
        {
            try
            {
                return OcupacionesDb.ListOcupaciones();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
