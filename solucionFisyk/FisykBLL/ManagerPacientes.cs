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
        public static void GrabarPacienteInsert(ref PacienteDto paciente,ref String error)
        {
            try
            {
                PacienteDb.GrabarPacienteInsert(ref paciente);
            }
            catch (Exception e)
            {

                //throw e;
                error = "Error al grabar";
            }
        }

        //__________________________________________________________________________
        //  Update Paciente
        public static void GrabarPacienteUpdate(ref PacienteDto paciente)
        {
            try
            {
                PacienteDb.GrabarPacienteUpdate(ref paciente);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        //__________________________________________________________________________
        //  Existe Paciente
        public static PacienteDto ExistePaciente(string nroDoc)
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
        public static PacienteDto ExistePacienteId(int idPac)
        {
            try
            {
                return PacienteDb.ConsultoUnPacientePorId(idPac);
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
