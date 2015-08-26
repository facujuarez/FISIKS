using System;
using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class TurneroDto : DtoBase
    {
        public int TurId { set; get; }
        public string TurTitulo { set; get; }
        public string TurDescripcion { set; get; }
        public DateTime TurFechaIni { set; get; }
        public DateTime TurFechaFin { set; get; }
        public String TurTodoDia { set; get; }
        public int TurPae { get; set; }
        public int TurPro { get; set; }
        public decimal TurMonto { get; set; }
        public int TurOspId { get; set; }
        


        public TurneroDto(int id,string tit, string descr, DateTime ini,DateTime fin,
            String allDay, int pac, int kine, decimal monto, int ospId)
        {

            TurId = id;
            TurTitulo = tit;
            TurDescripcion = descr;
            TurFechaIni = ini;
            TurFechaFin = fin;
            TurTodoDia = allDay;
            TurPae = pac;
            TurPro = kine;
            TurMonto = monto;
            TurOspId = ospId;
            
        }


        public TurneroDto ()
        {
        }
    }
}
