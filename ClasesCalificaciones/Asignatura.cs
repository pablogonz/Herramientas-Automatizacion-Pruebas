using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ClasesCalificaciones
{
    public class Asignatura
    {

        public string Clave { get; private set; }
        public string Nombre { get; private set; }
        public byte Creditos { get; private set; }
        public string[] Secciones { get; private set; }

        public Asignatura(string clave, string nombre, byte creditos)
        {
            Clave = clave;
            Nombre = nombre;
            Creditos = creditos;
        }

        public override string ToString()
        {
            return $"{Clave},{Nombre},{Creditos}";
        }

        public static int getCreditos(string codigo)
        {
            var lineas = File.ReadAllLines($"{Archivos.DIRECTORIO}\\{Archivos.ARCHIVO_ASIGNATURAS}");
            string[] asignatura = lineas.Where(s => s.Contains(codigo)).ToArray();
            int creditos = int.Parse(asignatura[0].Split(',')[2]);

            return creditos;
        }






    }
}