
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ApiEscuela.Clases;

public class AccesoDatos
{
    public static string cadenaConexion = "";

    /// <summary>
    /// Ejecuta una consulta SQL en la base de datos, y devuelve los resultados obtenidos en un objeto DataTable.
    /// Este método es vulnerable a inyección de dependencias, por lo que debe usarse sólamente de forma interna.
    /// Para consultas que vengan desde fuera, usar GetDataTable.
    /// </summary>
    /// <param name="SQL"></param>
    /// <param name="parametros">Array de string con formato: nombre:valor</param>
    /// <returns>Devuelve un objeto DataTable con los resultados obtenidos tras ejecución de la consulta.</returns>
    public static DataTable GetTmpDataTable(string SQL)
    {
        try
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand comando = new SqlCommand(SQL, conexion);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conexion.Close();
            da.Dispose();
            conexion.Dispose();
            return ds.Tables[0];
        }
        catch (Exception)
        {
            throw;
        }
    }
}
