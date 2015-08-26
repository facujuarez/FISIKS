using System;
using System.Collections.Generic;
using FisiksAppWeb.Entities;
using FisykDAL.DAL;

namespace FisykBLL
{
    public class ManagerObraSociales
    {
        //________________________________________________________________________________________________________
        //  Lista de Obras Sociales
        public static List<ObraSocialDto> ListObraSociales()
        {
            try
            {
                return ObraSocialDb.ListObraSociales();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //________________________________________________________________________________________________________
        //  Lista de Obras Sociales por Paciente
        public static List<PacienteOsDto> ListObraSocialesPaciente(int paeId)
        {
            try
            {
                return ObraSocialDb.ListObraSocialesPaciente(paeId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
