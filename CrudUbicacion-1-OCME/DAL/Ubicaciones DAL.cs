using System;
using System.Data;
using System.Data.SqlClient;
using BLL;

namespace DAL
{
    public class ubicaciones_DAL
    {
        SQLDBHelper oConexion;

        public ubicaciones_DAL()
        {
            oConexion = new SQLDBHelper();
        }

        public bool Agregar(Ubicaciones_BLL OubicacionesBLL)
        {
            SqlCommand cmdComando = new SqlCommand();

            cmdComando.CommandText = "INSERT INTO Direcciones (Ubicaciones, Latitud, Longitud) VALUES (@Ubicaciones, @Latitud, @Longitud)";
            cmdComando.Parameters.Add("@Ubicaciones", SqlDbType.VarChar).Value = OubicacionesBLL.Ubicaciones;
            cmdComando.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = OubicacionesBLL.Latitud;
            cmdComando.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = OubicacionesBLL.Longitud;

            return oConexion.EjecutarComandosSQL(cmdComando);
        }

        public bool Eliminar(Ubicaciones_BLL oUbicacionesBLL)
        {
            SqlCommand cmdComando = new SqlCommand();
            cmdComando.CommandText = "DELETE FROM Direcciones WHERE ID = @ID ";
            cmdComando.Parameters.Add("@ID", SqlDbType.Int).Value = oUbicacionesBLL.ID;
            return oConexion.EjecutarComandosSQL(cmdComando);

        }
        public bool Modificar(Ubicaciones_BLL oubicacionesBLL)
        {
            SqlCommand cmdComando = new SqlCommand();
            cmdComando.CommandText = "UPDATE Direcciones SET Ubicaciones = @Ubicaciones, Latitud = @Latitud, Longitud = @Longitud WHERE ID = @ID";

            cmdComando.Parameters.Add("@ID", SqlDbType.Int).Value = oubicacionesBLL.ID;
            cmdComando.Parameters.Add("@Ubicaciones", SqlDbType.VarChar).Value = oubicacionesBLL.Ubicaciones; // Corrige el nombre del parámetro
            cmdComando.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = oubicacionesBLL.Latitud;
            cmdComando.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = oubicacionesBLL.Longitud;

            return oConexion.EjecutarComandosSQL(cmdComando);
        }

        public DataTable Listar()
        {
            SqlCommand cmdComando = new SqlCommand();
            cmdComando.CommandText = "SELECT * FROM Direcciones ORDER BY ID";

            cmdComando.CommandType = CommandType.Text;

            DataTable tableResultado = oConexion.EjecutarSentenciasSQL(cmdComando);

            return tableResultado;
        }
    }
}