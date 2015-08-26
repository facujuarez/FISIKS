using System.Collections.Generic;
using System.Data;
using FisiksAppWeb.Entities;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.DAL
{
    public class PersonaDb : DalBase
    {
        //________________________________________________________________________________________________________
        // GetAll
        public static List<PersonaDto> GetAll()
        {
            //OracleCommand cmd = new OracleCommand();
            //cmd.Connection = GetConn();
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "PKG_PERSONA.InsertPersona";
                    
            //cmd.Parameters.Add(new OracleParameter(
            //    "c_per", OracleDbType.RefCursor, ParameterDirection.Output);

            //Datardr = cmd.ExecuteReader();
            //While (rdr.Read())
            //    REM do something with the values
            //End While

            //rdr.Close()
            
            var clientList = new List<PersonaDto>();
            //try
            //{
            //    command.Connection.Open();
            //    OracleDataReader rd = cmd.ExecuteReader();
            //    SqlDataReader reader = command.ExecuteReader();
            //    PersonaDTO ObjClient;
            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            PersonaDTO = new PersonaDTO();
            //            ObjClient.IDClient = reader.GetInt32(0);
            //            ObjClient.FirstName = reader.GetString(1);
            //            ObjClient.LastName = reader.GetString(2);
            //            ObjClient.IsNew = false;
            //            ClientList.Add(ObjClient);
            //        }
            //        reader.Close();
            //    }
            //    else
            //    {
            //        // Whenver there's no data, we return null.
            //        //dtoList = null;
            //    }
            //}
            //catch (Exception e)
            //{
            //    throw new Exception("Error populating data", e);
            //}
            //finally
            //{
            //    command.Connection.Close();
            //    command.Connection.Dispose();
            //}
            return clientList;
        }
        
        //________________________________________________________________________________________________________
        // GetPersonaByID
        public static PersonaDto GetPersonaById(string psnId)
        {
            var cmd = GetDbSprocCommand("usp_Persona_GetByID");
            cmd.Parameters.Add(CreateParameter("@psnId", psnId, 15));
            return GetSingleDto<PersonaDto>(ref cmd);
        }

        //________________________________________________________________________________________________________
        // GetPersonaByDNI
        public static PersonaDto GetPersonaByDni(int psnNroDcto)
        {
            var cmd = GetDbSprocCommand("usp_Persona_GetPersonaByDNI");
            cmd.Parameters.Add(CreateParameter("@psnNroDcto", psnNroDcto));
            return GetSingleDto<PersonaDto>(ref cmd);
        }

        //________________________________________________________________________________________________________
        // ExistByID
        public static bool ExistById(int psnId)
        {
            var cmd = GetDbSprocCommand("usp_Persona_ExistByID");
            cmd.Parameters.Add(CreateParameter("@psnId", psnId));
            cmd.Parameters.Add(CrearParametroSalida("@Exist", OracleDbType.Byte));

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            if ((bool)cmd.Parameters["@Exist"].Value )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //________________________________________________________________________________________________________
        // SavePersona
        public static void GrabarPersonas(ref PersonaDto persona)
        {

            //#region Insert New Persona
            //OracleCommand cmd = new OracleCommand();
            //try
            //{
            //    ------------------------------------------------------------------------------
            //     Consulta Text
            //    ------------------------------------------------------------------------------
                var querystring = "INSERT INTO PERSONA ( psnNombre) VALUES (:psnNombre)";
                var cmd = new OracleCommand(querystring);
                cmd.Connection = GetConn();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new OracleParameter(":psnNombre", persona.PsnNombre));

                //------------------------------------------------------------------------------
                // Consulta StoredProcedure
                //------------------------------------------------------------------------------
                //cmd.Connection = GetConn();
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "PKG_PERSONA.InsertPersona";

                //cmd.Parameters.Add(CreateParameter("psn_tpdId", Persona.psn_tpdId));//NUMBER
                //cmd.Parameters.Add(CreateParameter("psnNroDcto", Persona.psnNroDcto));//NUMBER
                //cmd.Parameters.Add(CreateParameter("psnNombre", Persona.psnNombre, 45));//VARCHAR
                //cmd.Parameters.Add(CreateParameter("psnApellido", Persona.psnApellido, 45));//VARCHAR
                //cmd.Parameters.Add(CreateParameter("psnFechaNac", Persona.psnFechaNac, 12));//VARCHAR
                //cmd.Parameters.Add(CreateParameter("psnTelefono", Persona.psnTelefono, 20));//VARCHAR
                //cmd.Parameters.Add(CreateParameter("psnSexo", Persona.psnSexo, 1));//VARCHAR
                //cmd.Parameters.Add(CreateParameter("psn_domId", Persona.psn_domId));//NUMBER
                
                // Run the command.
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            //}
            //catch(Exception ex)
            //{ 
            //    throw ex; 
            //}
            //finally
            //{
            //    cmd.Connection.Close();
            //}
            //#endregion

            /*
            if (Persona.IsNew)
            {
                cmd = GetDbSprocCommand("usp_Persona_Insert");
                cmd.Parameters.Add(CreateOutputParameter("@psnId", OracleDbType.Int16));
            }
            else
            {
                cmd = GetDbSprocCommand("usp_Persona_Update");
                cmd.Parameters.Add(CreateParameter("@psnId", Persona.psnId));
            }

            cmd.Parameters.Add(CreateParameter("@psn_tpdId", Persona.psn_tpdId));//NUMBER
            cmd.Parameters.Add(CreateParameter("@psnNroDcto", Persona.psnNroDcto));//NUMBER
            cmd.Parameters.Add(CreateParameter("@psnNombre", Persona.psnNombre,45));//VARCHAR
            cmd.Parameters.Add(CreateParameter("@psnApellido", Persona.psnApellido, 45));//VARCHAR
            cmd.Parameters.Add(CreateParameter("@psnFechaNac", Persona.psnFechaNac, 12));//VARCHAR
            cmd.Parameters.Add(CreateParameter("@psnTelefono", Persona.psnTelefono, 20));//VARCHAR
            cmd.Parameters.Add(CreateParameter("@psn_sexId", Persona.psn_sexId, 1));//VARCHAR
            cmd.Parameters.Add(CreateParameter("@psn_domId", Persona.psn_domId));//NUMBER
            
            // Run the command.
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
 * */
        }
    }
   
}

