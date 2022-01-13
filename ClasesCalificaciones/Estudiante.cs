using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ClasesCalificaciones
{
    public class Estudiante
    {
        private string id;

        public Estudiante(string id, string nombre, string apellido, string carrera)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Carrera = carrera;
        }

        public string Id { get; set; }
        public string Nombre { get;set; }
        public string Apellido { get; set; }
        public byte CreditosAprovados { get; set; }
        public string Carrera { get;  set; }
        public string[] Secciones { get; set; } //La clave de las secciones
        public byte Indicetrimestral { get; set; }
        public byte IndiceGeneral { get;  set; }

        public override string ToString()
        {
            return $"{Id},{Nombre},{Apellido},{Carrera}";
        }


       



        /*
       Samuel, Garcia, ing. software , 3.9
        Luis, Rosa, ing. civil, 3.5

        */
    }
}
