using System;
using System.Collections.Generic;
using System.Text;
using ExamenBotTelegram.Modelos;
using ExamenBotTelegram.Implementaciones;


namespace ExamenBotTelegram.Interfaces
{
    interface InterfaceConsultas
    {
        public PacienteModelo consultaPaciente(long dpi);
        public List<string> obtenerVacunas();
        public void guardarConsultaBd(ConsultaModelo consulta);
    }
}
