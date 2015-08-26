using System;
using System.Collections;

namespace FisiksAppWeb.Clases
{
    public class PublicData
    {
        //________________________________________________________________________________________________________
        //  Genero ArrayList de Altura
        public static ArrayList ArrayAltura()
        {
            var altura = new ArrayList();
            altura.Add("Elegir...");
            for ( var i = 50 ; i <=  250 ; i++)
            {
                altura.Add(i + " cm");
            }
            return altura;
        }

        //________________________________________________________________________________________________________
        //  Genero ArrayList de Peso
        public static ArrayList ArrayPeso()
        {
            var peso = new ArrayList();
            peso.Add("Elegir...");
            for (var i = 2; i <= 200; i++)
            {
                peso.Add(i + " Kg");
            }
            return peso;
        }

        //________________________________________________________________________________________________________
        //  Genero ArrayList de Pesion Maxima y Minima
        public static ArrayList ArrayMaxMin()
        {
            var maxMin = new ArrayList();
            maxMin.Add("Elegir...");
            maxMin.Add("");
            for (var i = 5; i <= 20; i++)
            {
                maxMin.Add(i);
            }
            return maxMin;
        }

        //________________________________________________________________________________________________________
        //  Genero ArrayList de días Laborables
        public static ArrayList ArrayDiasLaborales()
        {
            ArrayList diaLaborales = new ArrayList();
            diaLaborales.Add("Elegir...");
            diaLaborales.Add("LUNES");
            diaLaborales.Add("MARTES");
            diaLaborales.Add("MIERCOLES");
            diaLaborales.Add("JUEVES");
            diaLaborales.Add("VIERNES");
            diaLaborales.Add("TODOS");
            return diaLaborales;
        }

        //________________________________________________________________________________________________________
        public static ArrayList ArrayListaDeHoras()
        {
            ArrayList listaHoras = new ArrayList();
            string xhorainicio = "07:30";
            DateTime xhora = DateTime.Parse(xhorainicio);
            listaHoras.Add("Elegir...");
            for (int i = 1; i <= 20; i++)
            {
                xhora = xhora.AddMinutes(30);
                listaHoras.Add(xhora.ToString("HH:mm"));
            }
            return listaHoras;
        }

        //________________________________________________________________________________________________________

    }
}
