using System;
using System.Collections.Generic;
using System.Data;
using FisiksAppWeb.Entities;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    public class TurneroDb : DalBase
    {
        public static List<TurneroDto> ListaTurnos(DateTime pStart, DateTime pEnd)
        {
            OracleCommand cmd = GetDbSprocCommand("PRC_TURNERO_SELECT");
           
            cmd.Parameters.Add(new OracleParameter(":pStart", pStart));
            cmd.Parameters.Add(new OracleParameter(":pEnd", pEnd));
            cmd.Parameters.Add("oCursorTurnero", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
            return GetDtoList<TurneroDto>(ref cmd);


        }

        public static void UpdateTurno(TurneroDto turno)
        {
            OracleCommand cmd = GetDbSprocCommand("PRC_TURNERO_UPDATE");
            cmd.Parameters.Add(CreateParameter("iTURID", turno.TurId));//NUMBER
            cmd.Parameters.Add(CreateParameter("iTURTITULO", turno.TurTitulo, 45));//VARCHAR
            cmd.Parameters.Add(CreateParameter("iTURDESCRIP", turno.TurDescripcion, 255));//VARCHAR
            cmd.Parameters.Add(CreateParameter("iTURFECHAINI", turno.TurFechaIni));//DATETIME
            cmd.Parameters.Add(CreateParameter("iTURFECHAFIN", turno.TurFechaFin));//DATETIME
            cmd.Parameters.Add(new OracleParameter("iTURTODODIA", turno.TurTodoDia));//BOOL
            cmd.Parameters.Add(CreateParameter("iTUR_PAEID", turno.TurPae));//NUMBER
            cmd.Parameters.Add(CreateParameter("iTUR_PROID", turno.TurPro));//NUMBER
            cmd.Parameters.Add(CreateParameter(":iTURMONTO", turno.TurMonto));//NUMBER
            cmd.Parameters.Add(CreateParameter(":iTUR_OSPID", turno.TurOspId));//NUMBER

            cmd.Connection.Open();//ABRO
            cmd.ExecuteNonQuery();//EJECUTO CONSULTA
            cmd.Connection.Close();//CERRAR
            cmd.Dispose();
        }

        public static void UpdateTurnoTime(TurneroDto turno)
        {
            OracleCommand cmd = GetDbSprocCommand("PRC_TURNERO_UPDATE");
            cmd.Parameters.Add(CreateParameter("iTURID", turno.TurId));//NUMBER
            cmd.Parameters.Add(CreateParameter("iTURTITULO", turno.TurTitulo, 45));//VARCHAR
            cmd.Parameters.Add(CreateParameter("iTURDESCRIP", turno.TurDescripcion, 255));//VARCHAR
            cmd.Parameters.Add(CreateParameter("iTURFECHAINI", turno.TurFechaIni));//DATETIME
            cmd.Parameters.Add(CreateParameter("iTURFECHAFIN", turno.TurFechaFin));//DATETIME
            cmd.Parameters.Add(new OracleParameter("iTURTODODIA", turno.TurTodoDia));//BOOL
            cmd.Parameters.Add(CreateParameter("iTUR_PAEID", turno.TurPae));//NUMBER
            cmd.Parameters.Add(CreateParameter("iTUR_PROID", turno.TurPro));//NUMBER
            cmd.Parameters.Add(CreateParameter(":iTURMONTO", turno.TurMonto));//NUMBER
            cmd.Parameters.Add(CreateParameter(":iTUR_OSPID", turno.TurOspId));//NUMBER

            cmd.Connection.Open();//ABRO
            cmd.ExecuteNonQuery();//EJECUTO CONSULTA
            cmd.Connection.Close();//CERRAR
            cmd.Dispose();
        }

        public static void DeleteTurno(int idTurno)
        {
            OracleCommand cmd = GetDbSprocCommand("PRC_TURNERO_DELETE");
            cmd.Parameters.Add(CreateParameter("iTURID", idTurno));//NUMBER

            cmd.Connection.Open();//ABRO
            cmd.ExecuteNonQuery();//EJECUTO CONSULTA
            cmd.Connection.Close();//CERRAR
        }

        public static int InsertTurno(TurneroDto turno)
        {
            
            OracleCommand cmd = GetDbSprocCommand("PRC_TURNERO_INSERT");

            cmd.Parameters.Add(CreateParameter(":iTURTITULO", turno.TurTitulo, 45));//VARCHAR
            cmd.Parameters.Add(CreateParameter(":iTURDESCRIP", turno.TurDescripcion, 45));//VARCHAR
            cmd.Parameters.Add(CreateParameter(":iTURFECHAINI", turno.TurFechaIni));//DATETIME
            cmd.Parameters.Add(CreateParameter(":iTURFECHAFIN", turno.TurFechaFin));//DATETIME
            cmd.Parameters.Add(new OracleParameter(":iTURTODODIA", turno.TurTodoDia));//BOOL
            cmd.Parameters.Add(new OracleParameter(":iTUR_PAEID", turno.TurPae));//NUMBER
            cmd.Parameters.Add(CreateParameter(":iTUR_PROID", turno.TurPro));//NUMBER
            cmd.Parameters.Add(CreateParameter(":iTURMONTO", turno.TurMonto));//NUMBER
            cmd.Parameters.Add(CreateParameter(":iTUR_OSPID", turno.TurOspId));//NUMBER

            cmd.Parameters.Add(CrearParametroSalida("oTURID", OracleDbType.Int32));//NUMBER

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();

            object xxxx = cmd.Parameters["oTURID"].Value;
            turno.TurId = Convert.ToInt16(xxxx.ToString());
            int key = 0;
            key = turno.TurId;

            cmd.Connection.Close();
            cmd.Dispose();

            return key;
        }
    }
}
