using ExamenBotTelegram.Conexion;
using ExamenBotTelegram.Interfaces;
using ExamenBotTelegram.Modelos;
using System;
using System.Collections.Generic;
using System.Text;


namespace ExamenBotTelegram.Implementaciones
{
    class ClsPaciente : InterfaceConsultas
    {
        private Consultas con = new Consultas();

        public PacienteModelo consultaPaciente(long dpi)
        {
            return con.consultaPaciente(dpi);
        }

        public void guardarConsultaBd(ConsultaModelo consulta)
        {
            con.ingresarConsultaBd(consulta);
        }

        public List<string> obtenerVacunas()
        {
            return con.listarVacunas();
        }
    }
}
