using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ClasesCalificaciones
{
    public static class ReporteWrite
    {
        public static string directorioReporte = $"{Archivos.DIRECTORIO}\\{Archivos.ARCHIVO_REPORTE}";

        public static string conseguirHonores(double indice)
        {
            if (indice >= 3.8)
            {
                return "Summa Cum Laude";
            }
            else if (indice >= 3.5)
            {
                return "Magna Cum Laude";
            }
            else if (indice >= 3.2)
            {
                return "Cum Laude";
            }
            else
            {
                return "Sin honor";
            }

            
        }

        public static void generarReporte()
        {
            
            var lineasCalif = File.ReadAllLines($"{Archivos.DIRECTORIO}\\{Archivos.ARCHIVO_CALIFICACIONES}");
            var lineasAsign = File.ReadAllLines($"{Archivos.DIRECTORIO}\\{Archivos.ARCHIVO_ASIGNATURAS}");
            
            
            var reporte = new StreamWriter(directorioReporte);
            string[] idEstudiantes = CrudEst.GetEstudiantesID();

            reporte.WriteLine("ID,Indice Total,Honores");
            Dictionary<string, double> EstudianteIndice = new Dictionary<string, double>();

            foreach(var id in idEstudiantes)
            {
                string[] lineasCalifEstudiante = lineasCalif.Where(s => s.Contains(id)).ToArray();
                double totalCreditos = 0;
                double[] calificaciones = new double[lineasCalifEstudiante.Length];


                for (int i = 0; i < calificaciones.Length; i++)
                {
                    string letra = lineasCalifEstudiante[i].Split(',')[3].Trim();
                    string asignatura = lineasCalifEstudiante[i].Split(',')[2].Trim();
                    int creditos = Asignatura.getCreditos(asignatura);
                    totalCreditos += creditos;
                    
                    calificaciones[i] = Calificacion.ConvertirLetra(letra) * creditos;
                }
                double promedio = Math.Round(calificaciones.Sum()/totalCreditos,1);

                EstudianteIndice.Add(id, promedio);
                
               

                
            }
            var rankedEstudiantes = from entry in EstudianteIndice orderby entry.Value descending select entry;
            foreach(var item in rankedEstudiantes)
            {
                reporte.WriteLine($"{item.Key},{item.Value},{conseguirHonores(item.Value)}");
            }
            reporte.Close();
            Process.Start(directorioReporte);
        }
    }
}
