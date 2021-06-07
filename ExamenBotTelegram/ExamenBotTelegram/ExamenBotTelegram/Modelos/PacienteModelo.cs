using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenBotTelegram.Modelos
{
    class PacienteModelo
    {
        private int id;
        private String nombres;
        private String apellidos;
        private DateTime fechaNac;
        private String vacuna;
        private int ndosis;
        private string direccion;
        private String tel;
        private String cel;
        private long dpi;


        public PacienteModelo() { }
        public PacienteModelo(int id, string nombres, string apellidos, DateTime fechaNac, string vacuna, int ndosis, string direccion, string tel, string cel, long dpi)
        {
            this.id = id;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.fechaNac = fechaNac;
            this.vacuna = vacuna;
            this.ndosis = ndosis;
            this.direccion = direccion;
            this.tel = tel;
            this.cel = cel;
            this.dpi = dpi;
        }

        public int Id { get => id; set => id = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public string Vacuna { get => vacuna; set => vacuna = value; }
        public int Ndosis { get => ndosis; set => ndosis = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Cel { get => cel; set => cel = value; }
        public long Dpi { get => dpi; set => dpi = value; }
    }
}
