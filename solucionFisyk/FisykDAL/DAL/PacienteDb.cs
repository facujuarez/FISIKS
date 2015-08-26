using System;
using System.Collections.Generic;
using System.Data;
using FisiksAppWeb.Entities;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.DAL
{
    public class PacienteDb : DalBase
    {
        //________________________________________________________________________________________________________
        // Insert Paciente
        public static void GrabarPacienteInsert(ref PacienteDto paciente)
        {
            try
            {
                var con = GetConn();
                con.Open();
                var tran = con.BeginTransaction();

                #region INSERT PERSONA  -------------------------------------------------------------------

                var cmdPer = new OracleCommand("PRC_PERSONA_INSERT")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };

                cmdPer.Parameters.Add(CreateParameter("iPSNNRODCTO", paciente.PsnNroDcto, 9));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNNOMBRE", paciente.PsnNombre, 45));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNAPELLIDO", paciente.PsnApellido, 45));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNFECHANAC", paciente.PsnFechaNac, 12));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNTELEFONO", paciente.PsnTelefono, 20));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNSEXO", paciente.PsnSexo, 1));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNEMAIL", paciente.PsnEmail, 100));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNDOMICILIO", paciente.PsnDomicilio, 50));//VARCHAR
                cmdPer.Parameters.Add(CrearParametroSalida("oPSNID", OracleDbType.Int32));//NUMBER

                cmdPer.Transaction = tran;
                cmdPer.ExecuteNonQuery();

                var varPsnid = cmdPer.Parameters["oPSNID"].Value;
                paciente.PsnId = Convert.ToInt16(varPsnid.ToString());

                #endregion

                #region INSERT PACIENTE -------------------------------------------------------------------

                var cmdPac = new OracleCommand("PRC_PACIENTE_INSERT")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };

                cmdPac.Parameters.Add(CreateParameter("iPAEPESO", paciente.PaePeso));//NUMBER
                cmdPac.Parameters.Add(CreateParameter("iPAEALTURA", paciente.PaeAltura));//NUMBER
                cmdPac.Parameters.Add(CreateParameter("iPAETENSIONMAX", paciente.PaeTensionMax));//NUMBER
                cmdPac.Parameters.Add(CreateParameter("iPAETENSIONMIN", paciente.PaeTensionMin));//NUMBER
                cmdPac.Parameters.Add(CreateParameter("iPAEACTFISICA", paciente.PaeActFisica, 1));//VARCHAR
                cmdPac.Parameters.Add(CreateParameter("iPAEPERIODICIDAD", paciente.PaePeriodicidad));//NUMBER
                cmdPac.Parameters.Add(CreateParameter("iPAE_OCUID", paciente.PaeOcuId));//NUMBER
                cmdPac.Parameters.Add(CreateParameter("iPAE_PSNID", paciente.PsnId));//NUMBER
                cmdPac.Parameters.Add(CrearParametroSalida("oPAEID", OracleDbType.Int32));//NUMBER

                cmdPac.Transaction = tran;
                cmdPac.ExecuteNonQuery();//EJECUTO CONSULTA

                var varPaeid = cmdPac.Parameters["oPAEID"].Value;
                paciente.PaeId = Convert.ToInt16(varPaeid.ToString());
                
                #endregion

                #region INSERT OBRAS SOCIALES -------------------------------------------------------------

                OracleCommand cmdObSoc = null;
                foreach (var oPos in paciente.PaeListObraSocial)
                {
                    //    ------------------------------------------------------------------------------
                    //     Consulta Text
                    //    ------------------------------------------------------------------------------

                    var querystring = "INSERT INTO PACIENTEOS ( OSP_PAEID,    OSP_OSOID,   OSPNROSOCIO) " +
                                                        " VALUES (:iOSP_PAEID, :iOSP_OSOID, :iOSPNROSOCIO) ";
                    cmdObSoc = new OracleCommand(querystring)
                    {
                        Connection = con,
                        CommandType = CommandType.Text
                    };

                    cmdObSoc.Parameters.Add(CreateParameter(":iOSP_PAEID", paciente.PaeId));//NUMBER
                    cmdObSoc.Parameters.Add(CreateParameter(":iOSP_OSOID", oPos.OspOsoId));//NUMBER
                    cmdObSoc.Parameters.Add(new OracleParameter(":iOSPNROSOCIO", oPos.OspNroSocio));//NUMBER        

                    cmdObSoc.Transaction = tran;
                    cmdObSoc.ExecuteNonQuery();//EJECUTO CONSULTA

                    //cmdObSoc = new OracleCommand("PRC_PACIENTEOS_INSERT");
                    //cmdObSoc.CommandType = CommandType.StoredProcedure;
                    //cmdObSoc.Connection = con;
                }

                #endregion

                #region INSERT ANTECEDENTES MEDICOS -------------------------------------------------------
                OracleCommand cmdAteMed = null;
                foreach (var oPam in paciente.PaeListAntecedentes)
                {
                    cmdAteMed = new OracleCommand("PRC_PACIENTEANT_INSERT")
                    {
                        CommandType = CommandType.StoredProcedure,
                        Connection = con
                    };
                    cmdAteMed.Parameters.Add(CreateParameter("iAPA_PAEID", paciente.PaeId));//NUMBER
                    cmdAteMed.Parameters.Add(CreateParameter("iAPA_AMEID", oPam.ApaAmeId));//NUMBER 

                    cmdAteMed.Transaction = tran;
                    cmdAteMed.ExecuteNonQuery();//EJECUTO CONSULTA
                }
                #endregion

                tran.Commit();//COMMIT LA TRANSACCION

                #region Cerrar Conexiones
                cmdPer.Connection.Close();//CERRAR
                cmdPer.Connection.Dispose();

                cmdPac.Connection.Close();//CERRAR
                cmdPac.Connection.Dispose();

                if (cmdObSoc != null)
                {
                    cmdObSoc.Connection.Close(); //CERRAR
                    cmdObSoc.Connection.Dispose();
                }

                if (cmdAteMed != null)
                {
                    cmdAteMed.Connection.Close(); //CERRAR
                    cmdAteMed.Connection.Dispose();
                }
                #endregion
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //________________________________________________________________________________________________________
        // Update Paciente
        public static void GrabarPacienteUpdate(ref PacienteDto paciente)
        {
            try
            {
                var con = GetConn();
                con.Open();
                var tran = con.BeginTransaction();

                #region UPDATE PERSONA  -------------------------------------------------------------------

                var cmdPer = new OracleCommand("PRC_PERSONA_UPDATE")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };

                cmdPer.Parameters.Add(CreateParameter("iPSNID", paciente.PsnId));//NUMBER
                cmdPer.Parameters.Add(CreateParameter("iPSNNRODCTO", paciente.PsnNroDcto, 9));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNNOMBRE", paciente.PsnNombre, 45));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNAPELLIDO", paciente.PsnApellido, 45));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNFECHANAC", paciente.PsnFechaNac, 12));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNTELEFONO", paciente.PsnTelefono, 20));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNSEXO", paciente.PsnSexo, 1));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNEMAIL", paciente.PsnEmail, 100));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNDOMICILIO", paciente.PsnDomicilio, 50));//VARCHAR

                cmdPer.Transaction = tran;
                cmdPer.ExecuteNonQuery();

                #endregion

                #region UPDATE PACIENTE -------------------------------------------------------------------

                var cmdPac = new OracleCommand("PRC_PACIENTE_UPDATE")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };

                cmdPac.Parameters.Add(CreateParameter("iPAEID", paciente.PaeId));//NUMBER
                cmdPac.Parameters.Add(CreateParameter("iPAEPESO", paciente.PaePeso));//NUMBER
                cmdPac.Parameters.Add(CreateParameter("iPAEALTURA", paciente.PaeAltura));//NUMBER
                cmdPac.Parameters.Add(CreateParameter("iPAETENSIONMAX", paciente.PaeTensionMax));//NUMBER
                cmdPac.Parameters.Add(CreateParameter("iPAETENSIONMIN", paciente.PaeTensionMin));//NUMBER
                cmdPac.Parameters.Add(CreateParameter("iPAEACTFISICA", paciente.PaeActFisica, 1));//VARCHAR
                cmdPac.Parameters.Add(CreateParameter("iPAEPERIODICIDAD", paciente.PaePeriodicidad));//NUMBER
                cmdPac.Parameters.Add(CreateParameter("iPAE_OCUID", paciente.PaeOcuId));//NUMBER
                cmdPac.Parameters.Add(CreateParameter("iPAE_PSNID", paciente.PsnId));//NUMBER

                cmdPac.Transaction = tran;
                cmdPac.ExecuteNonQuery();//EJECUTO CONSULTA

                #endregion

                #region INSERT OBRAS SOCIALES -------------------------------------------------------------

                //OracleCommand cmdObSoc = null;
                //foreach (PacienteOsDto oPos in paciente.PaeListObraSocial)
                //{
                //    //    ------------------------------------------------------------------------------
                //    //     Consulta Text
                //    //    ------------------------------------------------------------------------------

                //    string querystring = "INSERT INTO PACIENTEOS ( OSP_PAEID,    OSP_OSOID,   OSPNROSOCIO) " +
                //                                        " VALUES (:iOSP_PAEID, :iOSP_OSOID, :iOSPNROSOCIO) ";
                //    cmdObSoc = new OracleCommand(querystring);
                //    cmdObSoc.Connection = con;
                //    cmdObSoc.CommandType = CommandType.Text;

                //    cmdObSoc.Parameters.Add(CreateParameter(":iOSP_PAEID", paciente.PaeId));//NUMBER
                //    cmdObSoc.Parameters.Add(CreateParameter(":iOSP_OSOID", oPos.OspOsoId));//NUMBER
                //    cmdObSoc.Parameters.Add(new OracleParameter(":iOSPNROSOCIO", oPos.OspNroSocio));//NUMBER        

                //    cmdObSoc.Transaction = tran;
                //    cmdObSoc.ExecuteNonQuery();//EJECUTO CONSULTA

                //    //cmdObSoc = new OracleCommand("PRC_PACIENTEOS_INSERT");
                //    //cmdObSoc.CommandType = CommandType.StoredProcedure;
                //    //cmdObSoc.Connection = con;
                //}

                #endregion

                #region INSERT ANTECEDENTES MEDICOS -------------------------------------------------------

                //---------------------------------------------------------
                // Elimino los registros para un paciente en particular
                var cmdAteMed = new OracleCommand("PRC_PACIENTEANT_DELETE")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmdAteMed.Parameters.Add(CreateParameter("iAPA_PAEID", paciente.PaeId));//NUMBER
                cmdAteMed.Transaction = tran;
                cmdAteMed.ExecuteNonQuery();//EJECUTO CONSULTA
                //---------------------------------------------------------
                foreach (var oPam in paciente.PaeListAntecedentes)
                {
                    cmdAteMed = new OracleCommand("PRC_PACIENTEANT_INSERT")
                    {
                        CommandType = CommandType.StoredProcedure,
                        Connection = con
                    };

                    cmdAteMed.Parameters.Add(CreateParameter("iAPA_PAEID", paciente.PaeId));//NUMBER
                    cmdAteMed.Parameters.Add(CreateParameter("iAPA_AMEID", oPam.ApaAmeId));//NUMBER 

                    cmdAteMed.Transaction = tran;
                    cmdAteMed.ExecuteNonQuery();//EJECUTO CONSULTA
                }

                #endregion

                tran.Commit();//COMMIT LA TRANSACCION

                cmdPer.Connection.Close();//CERRAR
                cmdPer.Connection.Dispose();

                cmdPac.Connection.Close();//CERRAR
                cmdPac.Connection.Dispose();

                //if (cmdObSoc != null)
                //{
                //    cmdObSoc.Connection.Close();//CERRAR
                //    cmdObSoc.Connection.Dispose();
                //}
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        //________________________________________________________________________________________________________
        // Consulto un Paciente
        public static PacienteDto ConsultoUnPaciente(string nroDoc)
        {
            try
            {
                var cmd = GetDbSprocCommand("PRC_PACIENTE_SELECT");
                cmd.Parameters.Add(CreateParameter("iPsnnrodcto", nroDoc, 9));//VARCHAR
                cmd.Parameters.Add("oCursorPersona", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
                return GetSingleDto<PacienteDto>(ref cmd);
            }
            catch (Exception e)
            {

                throw e;
            }

        }
            //________________________________________________________________________________________________________
        // Consulto un Paciente por id
        public static PacienteDto ConsultoUnPacientePorId(int idPac)
        {
            try
            {
                var cmd = GetDbSprocCommand("PRC_PACIENTE_PK");
                cmd.Parameters.Add(CreateParameter("iPAEID", idPac));//VARCHAR
                cmd.Parameters.Add("oCursor", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
                return GetSingleDto<PacienteDto>(ref cmd);
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        //________________________________________________________________________________________________________
        // Lista Pacientes
        public static List<PacienteDto> PacienteLista()
        {
            try
            {
                var cmd = GetDbSprocCommand("PRC_PACIENTE_SELECT_TODOS");
                cmd.Parameters.Add("oCursorPersona", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
                return GetDtoList<PacienteDto>(ref cmd);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
