using System.Collections.Generic;
using FisiksAppWeb.Entities;
using FisykDAL.DAL;

namespace FisykBLL
{
    public class PersonaManager
    {
        //________________________________________________________________________________________________________
        public static List<PersonaDto> GetPersona()
        {
            return PersonaDb.GetAll();
        }

        //________________________________________________________________________________________________________
        public static void SavePersona(PersonaDto persona)
        {
            PersonaDb.GrabarPersonas(ref persona);
        }
    }
}
