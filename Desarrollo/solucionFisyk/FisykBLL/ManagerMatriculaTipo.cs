using System;
using System.Collections.Generic;
using FisiksAppWeb.Entities;
using FisykDAL.DAL;

namespace FisykBLL
{
    public class ManagerMatriculaTipo
    {
        //________________________________________________________________________________________________________
        //  Lista de Matricula Tipo
        public static List<MatriculaTipoDto> ListMatriculaTipo()
        {
            try
            {
                return MatriculaTipoDb.ListMatriculaTipo();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}