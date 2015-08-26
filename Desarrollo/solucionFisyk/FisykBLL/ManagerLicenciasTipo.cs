using System;
using System.Collections.Generic;
using FisiksAppWeb.Entities;
using FisykDAL.DAL;

namespace FisykBLL
{
    public class ManagerLicenciasTipo
    {
        //__________________________________________________________________________
        //  Lista Pacientes
        public static List<LicenciasTipoDto> ListLicenciasTipo()
        {
            try
            {
                return LicenciasTipoDb.ListLicenciasTipo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
