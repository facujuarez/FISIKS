using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using FisiksAppWeb.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Util
{
    public abstract class DalBase
    {
        ///////////////////////////////////////////////////////////////////////////////////
        //Connecction CHAPA
        public static OracleConnection GetConn()
        {
            string conString;
            OracleConnection objCon;

            conString = ConfigurationManager.ConnectionStrings["DefConf"].ConnectionString;
            objCon = new OracleConnection(conString);

            return objCon;
        }
        protected static OracleCommand CHAPA_GetDbSprocCommand(string sprocName)
        {
            var cmd = new OracleCommand(sprocName);
            cmd.Connection = GetConn();
            cmd.CommandType = CommandType.Text;
            return cmd;
        }
        ///////////////////////////////////////////////////////////////////////////////////
        // ConnectionString
        protected static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DefConf"].ConnectionString; 
        }

        // ConnectionString - ConnectionName
        protected static string ConnectionString(string strConnectionName)
        {
            return ConfigurationManager.ConnectionStrings[strConnectionName].ConnectionString;
        }

        // GetDbConnection
        protected static OracleConnection GetDbConnection()
        {
            return new OracleConnection(ConnectionString());
        }

        // GetDbConnection - ConnectionName
        protected static OracleConnection GetDbConnection(string strConnectionName)
        {
            return new OracleConnection(ConnectionString(strConnectionName));
        }

        // GetDbOracleCommand
        protected static OracleCommand GetDbOracleCommand(string sqlQuery)
        {
            var command = new OracleCommand();
            command.Connection = GetDbConnection();
            command.CommandType = CommandType.Text;
            command.CommandText = sqlQuery;
            return command;
        }

        // GetDbOracleCommand - ConnectionName
        protected static OracleCommand GetDbOracleCommand(string sqlQuery, string strConnectionName)
        {
            var command = new OracleCommand();
            command.Connection = GetDbConnection(strConnectionName);
            command.CommandType = CommandType.Text;
            command.CommandText = sqlQuery;
            return command;
        }

        // GetDbSprocCommand
        protected static OracleCommand GetDbSprocCommand(string sprocName)
        {
            var command = new OracleCommand(sprocName);
            command.Connection = GetDbConnection();
            command.CommandType = CommandType.StoredProcedure;
            return command;
        } 

        // GetDbSprocCommand - ConnectionName
        protected static OracleCommand GetDbSprocCommand(string sprocName, string strConnectionName)
        {
            var command = new OracleCommand(sprocName);
            command.Connection = GetDbConnection(strConnectionName);
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        // CreateNullParameter
        protected static OracleParameter CreateNullParameter(string name, OracleDbType paramType)
        {
            var parameter = new OracleParameter();
            parameter.OracleDbType = paramType;
            parameter.ParameterName = name;
            parameter.Value = null;
            parameter.Direction = ParameterDirection.Input;
            return parameter;
        }

        // CreateNullParameter - with size for nvarchars
        protected static OracleParameter CreateNullParameter(string name, OracleDbType paramType, int size)
        {
            var parameter = new OracleParameter();
            parameter.OracleDbType = paramType; 
            parameter.ParameterName = name;
            parameter.Size = size;
            parameter.Value = null;
            parameter.Direction = ParameterDirection.Input;
            return parameter;
        }

        // CrearParametroSalida
        protected static OracleParameter CrearParametroSalida(string name, OracleDbType paramType)
        {
            var parameter = new OracleParameter();
            parameter.OracleDbType = paramType;
            parameter.ParameterName = name;
            parameter.Direction = ParameterDirection.Output;
            return parameter;
        }

        // CrearParametroSalida - with size for Varchar2
        protected static OracleParameter CrearParametroSalida(string name, OracleDbType paramType, int size)
        {
            var parameter = new OracleParameter();
            parameter.OracleDbType = paramType;
            parameter.Size = size;
            parameter.ParameterName = name;
            parameter.Direction = ParameterDirection.Output;
            return parameter;
        }

        // CreateParameter - uniqueidentifier
        //protected static OracleParameter CreateParameter(string name, Guid value)
        //{
        //    if (value.Equals(DTOBase.Guid_NullValue))
        //    {
        //        // If value is null then create a null parameter
        //        return CreateNullParameter(name, OracleDbType.UniqueIdentifier);
        //    }
        //    else
        //    {
        //        OracleParameter parameter = new OracleParameter();
        //        parameter.OracleDbType = OracleDbType.UniqueIdentifier;
        //        parameter.ParameterName = name;
        //        parameter.Value = value;
        //        parameter.Direction = ParameterDirection.Input;
        //        return parameter;
        //    }
        //}

        // CreateParameter - int
        protected static OracleParameter CreateParameter(string name, int value)
        {
            if (value == DtoBase.IntNullValue)
            {
                // If value is null then create a null parameter
                return CreateNullParameter(name, OracleDbType.Int16);
            }
            else
            {
                var parameter = new OracleParameter();
                parameter.OracleDbType = OracleDbType.Int32;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
        }

        // CreateParameter - datetime
        protected static OracleParameter CreateParameter(string name, DateTime value)
        {
            if (value == DtoBase.DateTimeNullValue)
            {
                // If value is null then create a null parameter
                return CreateNullParameter(name, OracleDbType.Date);
            }
            else
            {
                var parameter = new OracleParameter();
                parameter.OracleDbType = OracleDbType.Date;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
        }

        // CreateParameter - varchar
        protected static OracleParameter CreateParameter(string name, string value, int size)
        {
            if (value == DtoBase.StringNullValue)
            {
                // If value is null then create a null parameter
                return CreateNullParameter(name, OracleDbType.Varchar2);
            }
            else
            {
                var parameter = new OracleParameter();
                parameter.OracleDbType = OracleDbType.Varchar2;
                parameter.Size = size;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
        }

        // CreateParameter - float
        protected static OracleParameter CreateParameter(string name, float value)
        {
            if (value == DtoBase.FloatNullValue)
            {
                // If value is null then create a null parameter
                return CreateNullParameter(name, OracleDbType.Decimal);
            }
            else
            {
                var parameter = new OracleParameter();
                parameter.OracleDbType = OracleDbType.Decimal;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
        }

        // CreateParameter - decimal
        protected static OracleParameter CreateParameter(string name, decimal value)
        {
            if (value == DtoBase.DecimalNullValue)
            {
                // If value is null then create a null parameter
                return CreateNullParameter(name, OracleDbType.Decimal);
            }
            else
            {
                var parameter = new OracleParameter();
                parameter.OracleDbType = OracleDbType.Decimal;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
        }

        // GetSingleDTO
        protected static T GetSingleDto<T>(ref OracleCommand command) where T : DtoBase
        {
            T dto = null;
            try
            {
                command.Connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    var parser = DtoParserFactory.GetParserOracleClient(typeof(T));
                    parser.PopulateOrdinals(reader);
                    dto = (T)parser.PopulateDto(reader);
                    reader.Close();
                }
                else
                {
                    // Whever there's no data, we return null.
                    dto = null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error populating data", e);
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
            }
            // return the DTO, it's either populated with data or null.
            return dto;
        }

        // GetDTOList
        protected static List<T> GetDtoList<T>(ref OracleCommand command) where T : DtoBase
        {
            var dtoList = new List<T>();
            try
            {
                command.Connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    // Get a parser for this DTO type and populate
                    // the ordinals.
                    var parser = DtoParserFactory.GetParserOracleClient(typeof(T));
                    parser.PopulateOrdinals(reader);
                    // Use the parser to build our list of DTOs.
                    while (reader.Read())
                    {
                        T dto = null;
                        dto = (T)parser.PopulateDto(reader);
                        dtoList.Add(dto);
                    }
                    reader.Close();
                }
                else
                {
                    // Whenver there's no data, we return null.
                    //dtoList = null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error populating data", e);
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
            }
            return dtoList;
        }


    }
}
