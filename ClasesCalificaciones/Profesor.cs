using System;
using System.Collections.Generic;
using System.Text;

namespace ClasesCalificaciones
{
    public class Profesor
    {
        private string id;

        public Profesor(string id, string nombre, string apellido)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
        }

        public string Id { get;  set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string[] Secciones { get; set; } //La clave de las secciones

        public override string ToString()
        {
            return $"{Id},{Nombre},{Apellido}";
        }




    }
}
