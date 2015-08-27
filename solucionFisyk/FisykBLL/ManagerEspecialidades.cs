using System;
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
            try
            {
                return EspecialidadesDb.ListEspecialidades();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        //________________________________________________________________________________________________________
        //  Lista de Antecedentes Medicos pro Paciente
        public static List<EspecialidadesDto> ListEspecialidadProfesional(int proId)
        {
            try
            {
                return EspecialidadesDb.ListEspecialidadProfesional(proId);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
