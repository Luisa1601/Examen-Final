using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenBotTelegram.Modelos
{
    class ConsultaModelo
    {
        private int id;
        private String usuario;
        private String tipoConsulta;
        private DateTime fechaHora;
        private String consultaBd;

        static ConsultaModelo() { }
        public ConsultaModelo(string usuario, string tipoConsulta, DateTime fechaHora)
        {
            this.Usuario = usuario;
            this.TipoConsulta = tipoConsulta;
            this.FechaHora = fechaHora;
        }

        public int Id { get => id; set => id = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string TipoConsulta { get => tipoConsulta; set => tipoConsulta = value; }
        public DateTime FechaHora { get => fechaHora; set => fechaHora = value; }
    }
}
