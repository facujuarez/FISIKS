using System;
using System.Collections.Generic;
using FisiksAppWeb.Entities;
using FisykDAL.DAL;

namespace FisykBLL
{
    public class ManagerAntecedentesMedicos
    {
        //________________________________________________________________________________________________________
        //  Lista de Antecedentes Medicos
        public static List<AntecedenteMedicoDto> ListAntecedenteMedico()
        {
            try
            {
                return AntecendenteMedicoDb.ListAntecedenteMedico();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        //________________________________________________________________________________________________________
        //  Lista de Antecedentes Medicos pro Paciente
        public static List<AntecedenteMedicoDto> ListAntecedenteMedicoPaciente(int paeId)
        {
            try
            {
                return AntecendenteMedicoDb.ListAntecedenteMedicoPaciente(paeId);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
