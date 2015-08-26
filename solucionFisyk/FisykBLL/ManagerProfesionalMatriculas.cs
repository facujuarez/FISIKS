using System;
using System.Collections.Generic;
using FisiksAppWeb.Entities;
using FisykDAL.DAL;

namespace FisykBLL
{
    public class ManagerProfesionalMatriculas
    {
        //________________________________________________________________________________________________________
        //  Lista de Matriculas x Profecional
        public static List<ProfesionalMatriculaDto> ListProfesionalMatricula(int pro)
        {
            try
            {
                return ProfesionalMatriculaDb.ListProfesionalMatricula(pro);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        //________________________________________________________________________________________________________
    }
}
