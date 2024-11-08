using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SQLDBHelper
    {
        DataTable Tabla;
        SqlConnection strConexion = new SqlConnection("Data Source=DESKTOP-B9PIMFJ;Initial Catalog=BDUbicaciones;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        public bool EjecutarComandosSQL(SqlCommand strSQLCommand)
        {

            bool Respuesta = true;

            cmd = strSQLCommand;
            cmd.Connection = strConexion;
            strConexion.Open();
            Respuesta = (cmd.ExecuteNonQuery() <= 0) ? false : true;
            strConexion.Close();
            return Respuesta;
        }

        public DataTable EjecutarSentenciasSQL(SqlCommand strSQLCommand)
        {
            cmd = strSQLCommand;
            cmd.Connection= strConexion;
            strConexion.Open();
            Tabla = new DataTable();
            Tabla.Load(cmd.ExecuteReader());
            return Tabla;
        }
    }
}
