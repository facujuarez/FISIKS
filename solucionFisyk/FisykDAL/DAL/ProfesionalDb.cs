using System;
using System.Collections.Generic;
using System.Data;
using FisiksAppWeb.Entities;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.DAL
{
    public class ProfesionalDb : DalBase
    {
        //________________________________________________________________________________________________________
        // Insert Profesional
        public static void GrabarProfesionalInsert(ref ProfesionalDto profesional)
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

                cmdPer.Parameters.Add(CreateParameter("iPSNNRODCTO", profesional.PsnNroDcto, 9));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNNOMBRE", profesional.PsnNombre, 45));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNAPELLIDO", profesional.PsnApellido, 45));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNFECHANAC", profesional.PsnFechaNac, 12));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNTELEFONO", profesional.PsnTelefono, 20));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNSEXO", profesional.PsnSexo, 1));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNEMAIL", profesional.PsnEmail, 100));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNDOMICILIO", profesional.PsnDomicilio, 50));//VARCHAR
                cmdPer.Parameters.Add(CrearParametroSalida("oPSNID", OracleDbType.Int32));//NUMBER

                cmdPer.Transaction = tran;
                cmdPer.ExecuteNonQuery();

                var varPsnid = cmdPer.Parameters["oPSNID"].Value;
                profesional.ProPsnId = Convert.ToInt16(varPsnid.ToString());

                #endregion

                #region INSERT PROFESIONAL ----------------------------------------------------------------

                var cmdPro = new OracleCommand("PRC_PROFESIONAL_INSERT");
                cmdPro.CommandType = CommandType.StoredProcedure;
                cmdPro.Connection = con;

                cmdPro.Parameters.Add(CreateParameter("iPRO_PSNID", profesional.ProPsnId));//NUMBER
                cmdPro.Parameters.Add(CrearParametroSalida("oPROID", OracleDbType.Int32));//NUMBER

                cmdPro.Transaction = tran;
                cmdPro.ExecuteNonQuery();//EJECUTO CONSULTA

                var varProid = cmdPro.Parameters["oPROID"].Value;
                profesional.ProId = Convert.ToInt16(varProid.ToString());

                #endregion

                #region INSERT ESPECIALIDADES -------------------------------------------------------------
                OracleCommand cmdEsp = null;
                foreach (var oPe in profesional.ProListEspecialidades)
                {
                    cmdEsp = new OracleCommand("PRC_PROFESIONALESP_INSERT")
                    {
                        CommandType = CommandType.StoredProcedure,
                        Connection = con
                    };
                    cmdEsp.Parameters.Add(CreateParameter("iPEP_PROID", profesional.ProId));//NUMBER
                    cmdEsp.Parameters.Add(CreateParameter("iPEP_ESPID", oPe.PepEpcId));//NUMBER 

                    cmdEsp.Transaction = tran;
                    cmdEsp.ExecuteNonQuery();//EJECUTO CONSULTA
                }
                #endregion

                #region INSERT MATRICULAS -----------------------------------------------------------------
                OracleCommand cmdMat = null;
                foreach (var oPm in profesional.ProListMatriculas)
                {
                    cmdMat = new OracleCommand("PRC_PROFESIONALMAT_INSERT")
                    {
                        CommandType = CommandType.StoredProcedure,
                        Connection = con
                    };
                    cmdMat.Parameters.Add(CreateParameter("iPMT_PROID", profesional.ProId));//NUMBER
                    cmdMat.Parameters.Add(CreateParameter("iPMT_MTTID", oPm.PmtMttId));//NUMBER
                    cmdMat.Parameters.Add(CreateParameter("iPMTNRO", oPm.PmtNro, 45));//VARCHAR

                    cmdMat.Transaction = tran;
                    cmdMat.ExecuteNonQuery();
                }
                #endregion

                #region INSERT AGENDA ---------------------------------------------------------------------
                OracleCommand cmdAge = null;
                foreach (var oPa in profesional.ProListAgenda)
                {
                    cmdAge = new OracleCommand("PRC_PROFESIONALAGE_INSERT")
                    {
                        CommandType = CommandType.StoredProcedure,
                        Connection = con
                    };
                    cmdAge.Parameters.Add(CreateParameter("iAGE_PROID", profesional.ProId));//NUMBER
                    cmdAge.Parameters.Add(CreateParameter("iAGE_DIAID", oPa.AgeDiaId));//NUMBER
                    cmdAge.Parameters.Add(CreateParameter("iAGEHORADESDE", oPa.AgeHoraDesde,15));//DATETIME
                    cmdAge.Parameters.Add(CreateParameter("iAGEHORAHASTA", oPa.AgeHoraHasta,15));//

                    cmdAge.Transaction = tran;
                    cmdAge.ExecuteNonQuery();
                }
                #endregion

                tran.Commit();//COMMIT LA TRANSACCION

                #region Cerrar Conexiones
                cmdPer.Connection.Close();//CERRAR
                cmdPer.Connection.Dispose();

                cmdPro.Connection.Close();//CERRAR
                cmdPro.Connection.Dispose();

                if (cmdEsp != null)
                {
                    cmdEsp.Connection.Close();//CERRAR
                    cmdEsp.Connection.Dispose();
                }
                if (cmdMat != null)
                {
                    cmdMat.Connection.Close();//CERRAR
                    cmdMat.Connection.Dispose();
                }
                if (cmdAge != null)
                {
                    cmdAge.Connection.Close();//CERRAR
                    cmdAge.Connection.Dispose();
                }                
                #endregion
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //________________________________________________________________________________________________________
        // Update Profesional
        public static void GrabarProfesionalUpdate(ref ProfesionalDto profesional)
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
                cmdPer.Parameters.Add(CreateParameter("iPSNID", profesional.PsnId));//NUMBER
                cmdPer.Parameters.Add(CreateParameter("iPSNNRODCTO", profesional.PsnNroDcto, 9));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNNOMBRE", profesional.PsnNombre, 45));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNAPELLIDO", profesional.PsnApellido, 45));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNFECHANAC", profesional.PsnFechaNac, 12));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNTELEFONO", profesional.PsnTelefono, 20));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNSEXO", profesional.PsnSexo, 1));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNEMAIL", profesional.PsnEmail, 100));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNDOMICILIO", profesional.PsnDomicilio, 50));//VARCHAR

                cmdPer.Transaction = tran;
                cmdPer.ExecuteNonQuery();

                #endregion

                #region UPDATE PROFESIONAL ----------------------------------------------------------------

                /*NADA PARA ACTUALIZAR*/

                #endregion

                #region UPDATE ESPECIALIDADES -------------------------------------------------------------
                OracleCommand cmdEsp = null;
                //---------------------------------------------------------
                cmdEsp = new OracleCommand("PRC_PROFESIONALESP_DELETE")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmdEsp.Parameters.Add(CreateParameter("iPEP_PROID", profesional.ProId));//NUMBER
                cmdEsp.Transaction = tran;
                cmdEsp.ExecuteNonQuery();//EJECUTO CONSULTA
                //---------------------------------------------------------
                foreach (var oPe in profesional.ProListEspecialidades)
                {
                    cmdEsp = new OracleCommand("PRC_PROFESIONALESP_INSERT")
                    {
                        CommandType = CommandType.StoredProcedure,
                        Connection = con
                    };
                    cmdEsp.Parameters.Add(CreateParameter("iPEP_PROID", profesional.ProId));//NUMBER
                    cmdEsp.Parameters.Add(CreateParameter("iPEP_EPCID", oPe.PepEpcId));//NUMBER 

                    cmdEsp.Transaction = tran;
                    cmdEsp.ExecuteNonQuery();//EJECUTO CONSULTA
                }
                #endregion

                #region UPDATE MATRICULAS -----------------------------------------------------------------
                OracleCommand cmdMat = null;
                //---------------------------------------------------------
                cmdMat = new OracleCommand("PRC_PROFESIONALMAT_DELETE")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmdMat.Parameters.Add(CreateParameter("iPMT_PROID", profesional.ProId));//NUMBER
                cmdMat.Transaction = tran;
                cmdMat.ExecuteNonQuery();//EJECUTO CONSULTA
                //---------------------------------------------------------
                foreach (var oPm in profesional.ProListMatriculas)
                {
                    cmdMat = new OracleCommand("PRC_PROFESIONALMAT_INSERT")
                    {
                        CommandType = CommandType.StoredProcedure,
                        Connection = con
                    };
                    cmdMat.Parameters.Add(CreateParameter("iPMT_PROID", profesional.ProId));//NUMBER
                    cmdMat.Parameters.Add(CreateParameter("iPMT_MTTID", oPm.PmtMttId));//NUMBER
                    cmdMat.Parameters.Add(CreateParameter("iPMTNRO", oPm.PmtNro, 45));//VARCHAR

                    cmdMat.Transaction = tran;
                    cmdMat.ExecuteNonQuery();
                }
                #endregion

                #region UPDATE AGENDA ---------------------------------------------------------------------
                OracleCommand cmdAge = null;
                //---------------------------------------------------------
                cmdAge = new OracleCommand("PRC_PROFESIONALAGE_DELETE")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmdAge.Parameters.Add(CreateParameter("iAGE_PROID", profesional.ProId));//NUMBER
                cmdAge.Transaction = tran;
                cmdAge.ExecuteNonQuery();//EJECUTO CONSULTA
                //---------------------------------------------------------
                foreach (var oPa in profesional.ProListAgenda)
                {
                    cmdAge = new OracleCommand("PRC_PROFESIONALAGE_INSERT")
                    {
                        CommandType = CommandType.StoredProcedure,
                        Connection = con
                    };
                    cmdAge.Parameters.Add(CreateParameter("iAGE_PROID", profesional.ProId));//NUMBER
                    cmdAge.Parameters.Add(CreateParameter("iAGE_DIAID", oPa.AgeDiaId));//NUMBER
                    cmdAge.Parameters.Add(CreateParameter("iAGEHORADESDE", oPa.AgeHoraDesde, 15));//DATETIME
                    cmdAge.Parameters.Add(CreateParameter("iAGEHORAHASTA", oPa.AgeHoraHasta, 15));//DATETIME

                    cmdAge.Transaction = tran;
                    cmdAge.ExecuteNonQuery();
                }
                #endregion

                tran.Commit();//COMMIT LA TRANSACCION

                #region Cerrar Conexiones
                cmdPer.Connection.Close();//CERRAR
                cmdPer.Connection.Dispose();

                cmdEsp.Connection.Close();//CERRAR
                cmdEsp.Connection.Dispose();

                cmdMat.Connection.Close();//CERRAR
                cmdMat.Connection.Dispose();

                cmdAge.Connection.Close();//CERRAR
                cmdAge.Connection.Dispose();
                #endregion
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //________________________________________________________________________________________________________
        // Consulto Un Profesional DOCUMENTO
        public static ProfesionalDto ConsultoUnProfesional(string nroDoc)
        {
            try
            {
                var cmd = GetDbSprocCommand("PRC_PROFESIONAL_SELECT");
                cmd.Parameters.Add(CreateParameter("iPsnnrodcto", nroDoc, 9));//VARCHAR
                cmd.Parameters.Add("oCursorProfesional", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
                return GetSingleDto<ProfesionalDto>(ref cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //________________________________________________________________________________________________________
        // Consulto Un Profesional ID
        public static ProfesionalDto ConsultoUnProfesionalPk(int proId)
        {
            try
            {
                var cmd = GetDbSprocCommand("PRC_PROFESIONAL_PK");
                cmd.Parameters.Add(CreateParameter("iPROID", proId));//VARCHAR
                cmd.Parameters.Add("oCursor", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
                return GetSingleDto<ProfesionalDto>(ref cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //________________________________________________________________________________________________________
        // Lista Profesional
        public static List<ProfesionalDto> ProfesionalLista()
        {
            try
            {
                var cmd = GetDbSprocCommand("PRC_PROFESIONAL_SELECT_TODOS");
                cmd.Parameters.Add("oCursorPersona", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
                return GetDtoList<ProfesionalDto>(ref cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void BloquearProfesional(int idProfesional)
        {
            var con = GetConn();
            con.Open();

            var cmdPro = new OracleCommand("PRC_PROFESIONAL_BLOQUEAR");
            cmdPro.CommandType = CommandType.StoredProcedure;
            cmdPro.Connection = con;

            cmdPro.Parameters.Add(CreateParameter("PROID", idProfesional));//NUMBER
            cmdPro.ExecuteNonQuery();
            cmdPro.Connection.Close();//CERRAR
            cmdPro.Connection.Dispose();
        }


    }


}
