using MySql.Data.MySqlClient;
using System;


namespace ExamenBotTelegram.Conexion
{
    class ClsConexion
    {
        private static string server = "localhost";
        private static string database = "bd_vacunas";
        private static string userId = "root";
        private static string pass = "root";
        public static MySqlConnection conexion()
        {
            string cadenaConexion = "Database=" + database + "; Data Source=" + server + "; User Id=" + userId + "; Password=" + pass + "; Convert Zero Datetime=True";

            try
            {
                MySqlConnection connection = new MySqlConnection(cadenaConexion);
                return connection;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
    }
}
