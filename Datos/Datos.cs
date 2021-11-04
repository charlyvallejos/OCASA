using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Ocasa.Datos
{
    public partial class Datos
    {
        public static Entidades.Cliente getCliente()
        {
            Entidades.Cliente oCliente = new Entidades.Cliente();
            SqlConnection connDB = new SqlConnection ("Data Source=CHARLY;Initial Catalog=Test1;User=sa;Password=");
            
            if (connDB.State != System.Data.ConnectionState.Open)
                connDB.Open();

            SqlCommand oSqlCmd = new SqlCommand();
            oSqlCmd.Connection = connDB;
            oSqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            oSqlCmd.CommandText = "SP_Cliente_Cons";
            try
            {
                SqlDataReader oReader = oSqlCmd.ExecuteReader();
                while (oReader.Read() == true)
                {
                    oCliente.IdCliente = Convert.ToInt32(oReader.GetValue(oReader.GetOrdinal("IdCliente")).ToString());
                    oCliente.RazonSocial = oReader.GetValue(oReader.GetOrdinal("RazonSocial")).ToString();
                    oCliente.Direccion = oReader.GetValue(oReader.GetOrdinal("Direccion")).ToString();
                }

                return oCliente;

            }
            catch
            {
                return null;
            }
            finally
            {
                if (connDB.State == ConnectionState.Open)
                    connDB.Close();
            }
        }

        public static Entidades.Cliente getClientexId(int idCliente)
        {
            Entidades.Cliente oCliente = new Entidades.Cliente();
            SqlConnection connDB = new SqlConnection("Data Source=CHARLY;Initial Catalog=Test1;User=sa;Password=");

            if (connDB.State != System.Data.ConnectionState.Open)
                connDB.Open();

            SqlCommand oSqlCmd = new SqlCommand();
            oSqlCmd.Connection = connDB;
            oSqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            oSqlCmd.CommandText = "SP_Cliente_ConsxIdCliente";
            SqlParameter oSqlParam = new SqlParameter();
            oSqlParam = new SqlParameter("@IdCliente", SqlDbType.Int);
            oSqlParam.Value = idCliente;
            oSqlParam.Direction = ParameterDirection.Input;

            oSqlCmd.Parameters.Add(oSqlParam);
            try
            {
                SqlDataReader oReader = oSqlCmd.ExecuteReader();
                while (oReader.Read() == true)
                {
                    oCliente.IdCliente = Convert.ToInt32(oReader.GetValue(oReader.GetOrdinal("IdCliente")).ToString());
                    oCliente.RazonSocial = oReader.GetValue(oReader.GetOrdinal("RazonSocial")).ToString();
                    oCliente.Direccion = oReader.GetValue(oReader.GetOrdinal("Direccion")).ToString();
                }

                return oCliente;

            }
            catch
            {
                return null;
            }
            finally
            {
                if (connDB.State == ConnectionState.Open)
                    connDB.Close();
            }
        }

        public static int AltaCliente(Entidades.Cliente oCliente)
        {
            int ok = 0;
            SqlConnection connDB = new SqlConnection("Data Source=CHARLY;Initial Catalog=Test1;User=sa;Password=");

            if (connDB.State != System.Data.ConnectionState.Open)
                connDB.Open();

            SqlCommand oSqlCmd = new SqlCommand();
            oSqlCmd.Connection = connDB;
            oSqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            oSqlCmd.CommandText = "SP_Cliente_Alta";
            SqlParameter[] oSqlParam = new SqlParameter[3];
            oSqlParam[0] = new SqlParameter("@IdCliente", SqlDbType.Int);
            oSqlParam[0].Value = oCliente.IdCliente;
            oSqlParam[0].Direction = ParameterDirection.Input;
            oSqlParam[1] = new SqlParameter("@RazonSocial", SqlDbType.NVarChar, 50);
            oSqlParam[1].Value = oCliente.RazonSocial;
            oSqlParam[1].Direction = ParameterDirection.Input;
            oSqlParam[2] = new SqlParameter("@Direccion", SqlDbType.NVarChar, 200);
            oSqlParam[2].Value = oCliente.Direccion;
            oSqlParam[2].Direction = ParameterDirection.Input;

            oSqlCmd.Parameters.AddRange(oSqlParam);
            try
            {
                ok = oSqlCmd.ExecuteNonQuery();
                return ok;
            }
            catch
            {
                return 0;
            }
            finally
            {
                if (connDB.State == ConnectionState.Open)
                    connDB.Close();
            }
        }

        public static int UpdateCliente(Entidades.Cliente oCliente)
        {
            int ok = 0;
            SqlConnection connDB = new SqlConnection("Data Source=CHARLY;Initial Catalog=Test1;User=sa;Password=");

            if (connDB.State != System.Data.ConnectionState.Open)
                connDB.Open();

            SqlCommand oSqlCmd = new SqlCommand();
            oSqlCmd.Connection = connDB;
            oSqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            oSqlCmd.CommandText = "SP_Cliente_Update";
            SqlParameter[] oSqlParam = new SqlParameter[3];
            oSqlParam[0] = new SqlParameter("@IdCliente", SqlDbType.Int);
            oSqlParam[0].Value = oCliente.IdCliente;
            oSqlParam[0].Direction = ParameterDirection.Input;
            oSqlParam[1] = new SqlParameter("@RazonSocial", SqlDbType.NVarChar,50);
            oSqlParam[1].Value = oCliente.RazonSocial;
            oSqlParam[1].Direction = ParameterDirection.Input;
            oSqlParam[2] = new SqlParameter("@Direccion", SqlDbType.NVarChar, 200);
            oSqlParam[2].Value = oCliente.Direccion;
            oSqlParam[2].Direction = ParameterDirection.Input;

            oSqlCmd.Parameters.AddRange(oSqlParam);
            try
            {
                ok = oSqlCmd.ExecuteNonQuery();
                return ok;
            }
            catch
            {
                return 0;
            }
            finally
            {
                if (connDB.State == ConnectionState.Open)
                    connDB.Close();
            }
        }
        
    }
}
