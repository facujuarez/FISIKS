<%@ WebHandler Language="C#" Class="JsonResponse" %>

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using FisiksAppWeb.Entities;
using FisykBLL;

public class JsonResponse : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        DateTime inicio = Convert.ToDateTime(context.Request.QueryString["start"]);
        DateTime fin = Convert.ToDateTime(context.Request.QueryString["end"]);

        List<int> idList = new List<int>();
        List<ImproperCalendarEvent> tasksList = new List<ImproperCalendarEvent>();

        //Generate JSON serializable events
        foreach (TurneroDto turno in ManagerTurnero.ListTurnero(inicio, fin))
        {
            ImproperCalendarEvent imEvent = new ImproperCalendarEvent();
            
                imEvent.id = turno.TurId;
                //imEvent.title = Convert.ToString(turno.TurPae); 
                imEvent.title = "";
                // FullCalendar 1.x
                //start = ConvertToTimestamp(Convert.ToDateTime(turno.start).ToUniversalTime()).ToString(),
                //end = ConvertToTimestamp(Convert.ToDateTime(turno.end).ToUniversalTime()).ToString(),

                // FullCalendar 2.x
                
                imEvent.start = String.Format("{0:s}", turno.TurFechaIni);
                imEvent.end = String.Format("{0:s}", turno.TurFechaFin);
                
                imEvent.description = turno.TurDescripcion;

                if (turno.TurTodoDia == "S")
                    imEvent.allDay = true;
                else
                    imEvent.allDay = false;
                
                imEvent.pae= turno.TurPae;
                imEvent.osp= turno.TurOspId;
                imEvent.pro = turno.TurPro;
                imEvent.monto= turno.TurMonto;
            
            tasksList.Add(imEvent);
                
            idList.Add(turno.TurId);
        }
        

        context.Session["idList"] = idList;

        //Serialize events to string
        JavaScriptSerializer oSerializer = new JavaScriptSerializer();
        string sJSON = oSerializer.Serialize(tasksList);

        //Write JSON to response object
        context.Response.Write(sJSON);
    }

    public bool IsReusable
    {
        get { return false; }
    }
}