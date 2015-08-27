using System;
using System.Collections.Generic;
using FisiksAppWeb.Entities;
using FisykDAL;
using FisykDAL.DAL;

namespace FisykBLL
{
    public class ManagerTurnero
    {
        //__________________________________________________________________________
        //  Lista de Turnos
        public static List<TurneroDto> ListTurnero(DateTime inicio, DateTime fin)
        {
            try
            {
                return TurneroDb.ListaTurnos(inicio, fin);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //__________________________________________________________________________
        //  Update de Turnos (Others)
        public static void UpdateTurnero(TurneroDto turno)
        {
            try
            {
                TurneroDb.UpdateTurno(turno);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //__________________________________________________________________________
        //  Update de Turnos (Times)
        public static void UpdateTurneroTime(TurneroDto turno)
        {
            try
            {
                TurneroDb.UpdateTurnoTime(turno);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //__________________________________________________________________________
        //  Eliminar un Turnos
        public static void DeleteTurnero(int idTurno)
        {
            try
            {
                TurneroDb.DeleteTurno(idTurno);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //__________________________________________________________________________
        //  Insertar Paciente
        public static int InsertaTurnero(TurneroDto turno)
        {
            try
            {
                return TurneroDb.InsertTurno(turno);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
