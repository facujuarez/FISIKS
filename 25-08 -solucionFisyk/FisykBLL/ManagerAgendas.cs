using System;
using System.Collections.Generic;
using FisiksAppWeb.Entities;
using FisykDAL.DAL;

namespace FisykBLL
{
    public class ManagerAgendas
    {
        //________________________________________________________________________________________________________
        //  Lista Agenda para un Profecional
        public static List<AgendaDto> ListAgendaProfesional(int proId)
        {
            try
            {
                return AgendaDb.ListAgendaProfesional(proId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}