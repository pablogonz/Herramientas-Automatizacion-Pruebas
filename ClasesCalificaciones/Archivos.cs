using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClasesCalificaciones
{
    public static class Archivos
    {
        public static readonly string ARCHIVO_ESTUDIANTES = "estudiantes.csv";
        public static readonly string ARCHIVO_PROFESORES = "profesores.csv";
        public static readonly string ARCHIVO_ASIGNATURAS = "asignaturas.csv";
        public static readonly string ARCHIVO_CALIFICACIONES = "calificaciones.csv";
        public static readonly string ARCHIVO_SECCIONES = "secciones.csv";
        public static readonly string ARCHIVO_REPORTE = "reporte.csv";
        public  static string DIRECTORIO = Directory.GetCurrentDirectory();

        public static void crearArchivos()
        {
            
            if (!FileExists(ARCHIVO_ESTUDIANTES))
            {
                var archivo = File.Create($"{DIRECTORIO}\\{ARCHIVO_ESTUDIANTES}");
                archivo.Close();
            }

            if (!FileExists(ARCHIVO_PROFESORES))
            {
                var archivo = File.Create($"{DIRECTORIO}\\{ARCHIVO_PROFESORES}");
                archivo.Close();
            }

            if (!FileExists(ARCHIVO_ASIGNATURAS))
            {
                var archivo = File.Create($"{DIRECTORIO}\\{ARCHIVO_ASIGNATURAS}");
                archivo.Close();
            }

            if (!FileExists(ARCHIVO_CALIFICACIONES))
            {

                var archivo = File.Create($"{DIRECTORIO}\\{ARCHIVO_CALIFICACIONES}");
                archivo.Close();
            }

            if (!FileExists(ARCHIVO_SECCIONES))
            {
                var archivo = File.Create($"{DIRECTORIO}\\{ARCHIVO_SECCIONES}");
                archivo.Close();
            }


        }
        private static bool FileExists(string file)
        {
            return File.Exists($"{DIRECTORIO}\\{file}");
        }
    }
}
