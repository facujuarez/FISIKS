using System;
using System.Collections.Generic;
using FisiksAppWeb.Entities;
using FisykDAL.DAL;

namespace FisykBLL
{
    public class ManagerProfesional
    {
        //__________________________________________________________________________
        //  Insertar Profesional
        public static void GrabarProfesionalInsert(ref ProfesionalDto profesional)
        {
            try
            {
                ProfesionalDb.GrabarProfesionalInsert(ref profesional);
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        //__________________________________________________________________________
        //  Update Paciente
        public static void GrabarProfesionalUpdate(ref ProfesionalDto profesional)
        {
            try
            {
                ProfesionalDb.GrabarProfesionalUpdate(ref profesional);
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        //__________________________________________________________________________
        //  Existe Profesional
        public static ProfesionalDto ExisteProfesional(string nroDoc)
        {
            try
            {
                return ProfesionalDb.ConsultoUnProfesional(nroDoc);
            }
            catch (Exception e)
            {
                throw e;
            }                  
        }

        //__________________________________________________________________________
        //  Lista Profesional
        public static List<ProfesionalDto> ListProfesional()
        {
            try
            {
                return ProfesionalDb.ProfesionalLista();
            }
            catch (Exception e)
            {
                throw e;
            }                  
        }

        public static void BloquearProfesional(int idProfeisonal)
        {
            try
            {
                ProfesionalDb.BloquearProfesional(idProfeisonal);
            }
            catch (Exception e)
            {
                throw e;
            }      
        }
    }
}
