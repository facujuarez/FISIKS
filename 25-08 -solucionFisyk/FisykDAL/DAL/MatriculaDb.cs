using System;
using System.Data;
using FisiksAppWeb.Entities;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.DAL
{
    public class MatriculaDb : DalBase
    {
        public static void GrabarMatriculaInsert(ref MatriculaDto mat, ref OracleConnection con, ref OracleTransaction tran)
        {
            #region INSERT Matricula del profesional  -------------------------------------------------------------------

            var cmdMat = new OracleCommand("PRC_MATRICULA_INSERT");
            cmdMat.CommandType = CommandType.StoredProcedure;
            cmdMat.Connection = con;

            cmdMat.Parameters.Add(CreateParameter("iMTRDESCRIPCION", mat.MtrDescripcion, 45));//VARCHAR
            cmdMat.Parameters.Add(CreateParameter("iMTR_MTTID", mat.MtrTipo.MttId));//NUMBER
            cmdMat.Parameters.Add(CrearParametroSalida("oMTRID", OracleDbType.Int32));//NUMBER

            cmdMat.Transaction = tran;
            cmdMat.ExecuteNonQuery();

            var varMtrId = cmdMat.Parameters["oMTRID"].Value;
            mat.MtrId = Convert.ToInt16(varMtrId.ToString());

            #endregion

        }
         public static MatriculaDto ConsultoUnaMatricula(int nroMat)
         {
            var cmd = GetDbSprocCommand("PRC_MATRICULA_SELECT");
            cmd.Parameters.Add(CreateParameter("iMatId", nroMat));
            cmd.Parameters.Add("oCursorMatricula", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
            return GetSingleDto<MatriculaDto>(ref cmd);

         }
      
         public static void GrabarMatriculaUpdate(ref MatriculaDto mat, ref OracleConnection con, ref OracleTransaction tran)
         {
             var cmdPro = new OracleCommand("PRC_MATRICULA_UPDATE");
             cmdPro.CommandType = CommandType.StoredProcedure;
             cmdPro.Connection = con;

             cmdPro.Parameters.Add(CreateParameter("iMTRID", mat.MtrId));//NUMBER
             cmdPro.Parameters.Add(CreateParameter("iMTRDESCRIPCION", mat.MtrDescripcion, 45));//NUMBER
             
             cmdPro.Transaction = tran;
             cmdPro.ExecuteNonQuery();//EJECUTO CONSULTA
         }
    }
}