using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.Adapters;
using FisiksAppWeb.Entities;
using FisykBLL;

namespace FisiksAppWeb
{
    public partial class Turn : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        [System.Web.Services.WebMethod(true)]
        public static string UpdateEvent(CalendarEvent pagTurnero)
        {
            List<int> idList = (List<int>)HttpContext.Current.Session["idList"];
            if (idList != null && idList.Contains(pagTurnero.id))
            {
                if (CheckAlphaNumeric(pagTurnero.title) && CheckAlphaNumeric(pagTurnero.description))
                {
                    TurneroDto turno = new TurneroDto();

                    turno.TurId = pagTurnero.id;
                    turno.TurTitulo = pagTurnero.title;
                    turno.TurDescripcion = pagTurnero.description;
                    turno.TurPae = Convert.ToInt32(pagTurnero.pae);
                    turno.TurPro = Convert.ToInt32(pagTurnero.pro);
                    turno.TurMonto = Convert.ToDecimal(pagTurnero.monto);
                    turno.TurOspId = Convert.ToInt32(pagTurnero.osp);




                    ManagerTurnero.UpdateTurnero(turno);

                    return "Se actualizo el Turno Nro:" + pagTurnero.id;
                }
            }
            return "No se puede actualizar el Turno Nro:" + pagTurnero.id;

        }


        [System.Web.Services.WebMethod(true)]
        public static string UpdateEventTime(ImproperCalendarEvent pagTurnero)
        {
            List<int> idList = (List<int>)HttpContext.Current.Session["idList"];
            if (idList != null && idList.Contains(pagTurnero.id))
            {
                TurneroDto turno = new TurneroDto();
                turno.TurId = pagTurnero.id;
                turno.TurFechaIni = Convert.ToDateTime(pagTurnero.start).ToUniversalTime();
                turno.TurFechaFin = Convert.ToDateTime(pagTurnero.end).ToUniversalTime();
                if (pagTurnero.allDay)
                    turno.TurTodoDia = "S";
                else
                    turno.TurTodoDia = "N";


                ManagerTurnero.UpdateTurneroTime(turno);

                return "Se actualizo el Turno Nro:" + pagTurnero.id;
            }
            return "No se puede actualizar el Turno Nro:" + pagTurnero.id;
        }


        [System.Web.Services.WebMethod(true)]
        public static string deleteEvent(int id)
        {
            List<int> idList = (List<int>)HttpContext.Current.Session["idList"];
            if (idList != null && idList.Contains(id))
            {
                ManagerTurnero.DeleteTurnero(id);
                return "Se el elimino el Turno Nro:" + id;
            }
            return "No se puede eliminar el Turno Nro: " + id;
        }


        [System.Web.Services.WebMethod(true)]
        public static int AddEvent(ImproperCalendarEvent pagTurnero)
        {
            TurneroDto turno = new TurneroDto();
            turno.TurTitulo = pagTurnero.title;
            turno.TurDescripcion = pagTurnero.description;
            turno.TurFechaIni = Convert.ToDateTime(pagTurnero.start).ToUniversalTime();
            turno.TurFechaFin = Convert.ToDateTime(pagTurnero.end).ToUniversalTime();
            if (pagTurnero.allDay)
                turno.TurTodoDia = "S";
            else
                turno.TurTodoDia = "N";
            turno.TurPae = Convert.ToInt32(pagTurnero.pae);
            turno.TurPro = Convert.ToInt32(pagTurnero.pro);
            turno.TurMonto = Convert.ToDecimal(pagTurnero.monto);
            turno.TurOspId = Convert.ToInt32(pagTurnero.osp);


            if (CheckAlphaNumeric(turno.TurTitulo) && CheckAlphaNumeric(turno.TurDescripcion))
            {
                int key = ManagerTurnero.InsertaTurnero(turno);

                List<int> idList = (List<int>)HttpContext.Current.Session["idList"];

                if (idList != null)
                {
                    idList.Add(key);
                }
                return key; //return the primary key of the added cevent object
            }
            else
                return -1; //return a negative number just to signify nothing has been added



        }


        private static bool CheckAlphaNumeric(string str)
        {
            return Regex.IsMatch(str, @"^[a-zA-Z0-9 ]*$");
        }


        [System.Web.Services.WebMethod(true)]
        public static PacienteDto buscarPac(String doc)
        {
            if (!string.IsNullOrEmpty(doc))
            {
                PacienteDto pac = new PacienteDto();
                pac = ManagerPacientes.ExistePaciente(doc);
                
                return pac;
            }
            else { return null; }
            
        }



        //public static Turn Instance
        //{
        //    get { return instance; }
        //}

        //private static Turn instance = new Turn();

    }
}