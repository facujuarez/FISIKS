using System;
using System.Collections.Generic;
using FisiksAppWeb.Entities;
using FisykDAL.DAL;

namespace FisykBLL
{
    public class ManagerPacientes
    {
        //__________________________________________________________________________
        //  Insertar Paciente
        public static void GrabarPacienteInsert(ref PacienteDto paciente, ref string error, ref int errorNro)
        {
            try
            {
                var objPac = PacienteDb.ConsultoUnPaciente(paciente.PsnNroDcto);

                if (objPac == null)
                {
                    PacienteDb.GrabarPacienteInsert(ref paciente);
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
        public static void GrabarPacienteUpdate(ref PacienteDto paciente, ref string error, ref int errorNro)
        {

            try
            {
                var newDoc = paciente.PsnNroDcto;
                var objPac = PacienteDb.ConsultoUnPacientePk(paciente.PaeId);

                if (newDoc != objPac.PsnNroDcto)
                {
                    var objPacNew = PacienteDb.ConsultoUnPaciente(newDoc);
                    if (objPacNew == null)
                    {
                        PacienteDb.GrabarPacienteUpdate(ref paciente);
                    }
                    else if (objPac.PaeId == objPacNew.PaeId)
                    {
                        PacienteDb.GrabarPacienteUpdate(ref paciente);
                    }
                    else
                    {
                        errorNro = -2;
                        error = " Verifique el DOCUMENTO, ya existe!";
                    }
                }
                else
                {
                    PacienteDb.GrabarPacienteUpdate(ref paciente);
                }
            }
            catch (Exception e)
            {
                errorNro = -1;
                error = " Error Grabar.(Editado)";
            }
        }

        //__________________________________________________________________________
        //  Existe Paciente DOCUMENTO
        public static PacienteDto ExistePacienteDoc(string nroDoc)
        {
            try
            {
                return PacienteDb.ConsultoUnPaciente(nroDoc);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        //__________________________________________________________________________
        //  Existe Paciente ID
        public static PacienteDto ExistePacientePk(int idPac)
        {
            try
            {
                return PacienteDb.ConsultoUnPacientePk(idPac);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        //__________________________________________________________________________
        //  Lista Pacientes
        public static List<PacienteDto> ListPaciente()
        {
            try
            {
                return PacienteDb.PacienteLista();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
