using System;
using System.Collections.Generic;
using FisiksAppWeb.Entities;
using FisykDAL;

namespace FisykBLL
{
    public class ManagerTurnero
    {
        //__________________________________________________________________________
        //  Lista de Turnos
        public static List<TurneroDto> ListTurnero(DateTime inicio, DateTime fin)
        {
            return TurneroDb.ListaTurnos(inicio, fin);
            
        }
        //__________________________________________________________________________
        //  Update de Turnos (Others)
        public static void UpdateTurnero(TurneroDto turno)
        {
            TurneroDb.UpdateTurno(turno);
        }
        //__________________________________________________________________________
        //  Update de Turnos (Times)
        public static void UpdateTurneroTime(TurneroDto turno)
        {
            TurneroDb.UpdateTurnoTime(turno);
        }
        //__________________________________________________________________________
        //  Eliminar un Turnos
        public static void DeleteTurnero(int idTurno)
        {
            TurneroDb.DeleteTurno(idTurno);
        }
        //__________________________________________________________________________
        //  Insertar Paciente
        public static int InsertaTurnero(TurneroDto turno)
        {
            return TurneroDb.InsertTurno(turno);
        }
    }
}
