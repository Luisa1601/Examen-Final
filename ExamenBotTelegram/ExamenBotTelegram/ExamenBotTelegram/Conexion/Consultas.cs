
using ExamenBotTelegram.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ExamenBotTelegram.Conexion
{
    class Consultas
    {


        public PacienteModelo consultaPaciente(long dpi)
        {
            string query = "SELECT * FROM bd_vacunas.pacientes where vac_DPI = "+ dpi.ToString() +";";
            PacienteModelo paciente = new PacienteModelo();

            MySqlConnection conexionBd = ClsConexion.conexion();
            conexionBd.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexionBd);
                //comando.ExecuteNonQuery();

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        paciente.Nombres = reader["vac_nombres"].ToString();
                        paciente.Apellidos = reader["vac_apellidos"].ToString();
                        paciente.Dpi = Convert.ToInt64(reader["vac_dpi"].ToString());
                        paciente.Vacuna = reader["vac_vacuna"].ToString();
                        paciente.Ndosis = int.Parse(reader["vac_dosis"].ToString());     
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            finally
            {
                conexionBd.Close();
            }

            return paciente;
        }

        public void ingresarConsultaBd(ConsultaModelo consulta)
        {
            try
            {
                string query = "INSERT INTO CONSULTAS (usuario, tipo_consulta, fecha_hora) " +
                "VALUES ('" + consulta.Usuario +
                "', '" + consulta.TipoConsulta +
                "', '" + consulta.FechaHora + "')";

                MySqlConnection conexionBd = ClsConexion.conexion();
                conexionBd.Open();

                //MySqlConnector.MySqlCommand comando = new MySqlConnector.MySqlCommand(query, conexionBd);
                MySqlCommand ejecutar = new MySqlCommand(query, conexionBd);
                ejecutar.ExecuteNonQuery();
                conexionBd.Close();

            }
            catch (Exception error)
            {
                Console.WriteLine("Error::::" + error);

            }

        }

        public List<String> listarVacunas()
        {
            string query = "SELECT * FROM vacunas";
            List<String> vacunas = new List<String>();

            MySqlConnection conexionBd = ClsConexion.conexion();
            conexionBd.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexionBd);
                //comando.ExecuteNonQuery();

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vacunas.Add(reader["nombre_vacuna"].ToString());
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            finally
            {
                conexionBd.Close();
            }

            return vacunas;
        }

    }

}
