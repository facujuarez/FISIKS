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
        public static void GrabarProfesionalInsert(ref ProfesionalDto profesional, ref string error, ref int errorNro)
        {
            try
            {
                var objPac = ProfesionalDb.ConsultoUnProfesional(profesional.PsnNroDcto);

                if (objPac == null)
                {
                    ProfesionalDb.GrabarProfesionalInsert(ref profesional);
                }
                else
                {
                    errorNro = -2;
                    error = " Verifique el DOCUMENTO, ya existe!";
                }
            }
            catch (Exception e)
            {
                errorNro = -1;
                error = " Error Grabar.(Nuevo)";
            }
        }

        //__________________________________________________________________________
        //  Update Paciente
        public static void GrabarProfesionalUpdate(ref ProfesionalDto profesional, ref string error, ref int errorNro)
        {               
           try
            {
                var newDoc = profesional.PsnNroDcto;
                var objPro = ProfesionalDb.ConsultoUnProfesionalPk(profesional.ProId);

                if (newDoc != objPro.PsnNroDcto)
                {
                    var objPacNew = ProfesionalDb.ConsultoUnProfesional(newDoc);//Funciona pancientes y profesional ya busca DNI de personas
                    if (objPacNew == null)
                    {
                        ProfesionalDb.GrabarProfesionalUpdate(ref profesional);
                    }
                    else if (objPro.ProId == objPacNew.ProId)
                    {
                        ProfesionalDb.GrabarProfesionalUpdate(ref profesional);
                    }
                    else
                    {
                        errorNro = -2;
                        error = " Verifique el DOCUMENTO, ya existe!";
                    }
                }
                else
                {
                    ProfesionalDb.GrabarProfesionalUpdate(ref profesional);
                }


                var objPac = PacienteDb.ConsultoUnPaciente(profesional.PsnNroDcto);

                if (objPac == null)
                {
                   ProfesionalDb.GrabarProfesionalUpdate(ref profesional);
                }
                else
                {
                    errorNro = -2;
                    error = " Verifique el DOCUMENTO, ya existe!";
                }
            }
            catch (Exception e)
            {
                errorNro = -1;
                error = " Error Grabar.(Editado)";
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
