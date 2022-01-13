using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Linq;

namespace ClasesCalificaciones
{
   static public class CrudCal
    {


        public static string directorio = $"{Archivos.DIRECTORIO}\\{Archivos.ARCHIVO_CALIFICACIONES}";
        static public bool Crear(Calificacion calificacion)
        {
            var lineasCalif = File.ReadAllLines(directorio).ToList();
            var lineasEstudianteConAsignatura = lineasCalif.Where(s => s.Contains(calificacion.Asignatura) && s.Contains(calificacion.Estudiante));

            foreach(var linea in lineasEstudianteConAsignatura)
            {
                string[] datos = linea.Split(',');
                string letra = datos[3];

                if(letra.Equals("A") || letra.Equals("B") || letra.Equals("C"))
                {
                    return false;
                }
            }

           
                var archivo_calificaciones = new StreamWriter(directorio, true);
                archivo_calificaciones.WriteLine($"{calificacion.Estudiante},{calificacion.Nota},{calificacion.Asignatura},{calificacion.Letra}");
                archivo_calificaciones.Close();
                return true;
            
            

        }

        static public bool Borrar(string calificacion)
        {
            List<string> lineas = File.ReadAllLines(directorio).ToList(); //Leer lineas del archivo y obtenerlas en una lista

            int index = lineas.FindIndex(s => s.Contains(calificacion)); // Conseguir el indice de la lista donde se encuentra la asignatura mediante la clave.
            try
            {
                lineas.RemoveAt(index);
                File.WriteAllLines(directorio, lineas); // Sobreescribir el archivo.
            }
            catch
            {
                return false;
            }

            return true;

        }

        static public void BorrarTodasCalificacionesSegunID(string ID)
        {
            List<string> lineas = File.ReadAllLines(directorio).ToList();

            int[] indexes = lineas.Select((s, i) => new { Str = s, Index = i })
                .Where(x => x.Str.Contains(ID))
                .Select(x => x.Index).ToArray();

            for (int index =indexes.Length-1; index >= 0; index--)
            {
                int currentIndexToErase = indexes[index];
                lineas.RemoveAt(currentIndexToErase);
            }
               
            
            File.WriteAllLines(directorio, lineas);
            
        }

        static public void Modificar(Calificacion calificacion)
        {
            List<string> lineas = File.ReadAllLines(directorio).ToList();

            // indice de la linea que contenga alguno de los datos proporcionados

            int index = lineas.FindIndex(s => s.Contains(Convert.ToString(calificacion.Estudiante)) || s.Contains(calificacion.Nota) || s.Contains(calificacion.Asignatura) || s.Contains(calificacion.Letra));
            //sobreescribir la entrada de la lista en el indice que se encontro la linea que contenia los datos
            lineas[index] = calificacion.ToString();

            File.WriteAllLines(directorio, lineas);
        }
        static public DataTable CrearGridView()
        {
            DataTable tableCal = new DataTable();



            tableCal.Columns.Add("Id");
            tableCal.Columns.Add("Nota");
            tableCal.Columns.Add("Asignatura");
            tableCal.Columns.Add("Letra");


            string[] lineas = File.ReadAllLines($"{Archivos.DIRECTORIO}\\{Archivos.ARCHIVO_CALIFICACIONES}");
            string[] valores;

            for (int i = 0; i < lineas.Length; i++)
            {
                valores = lineas[i].Split(',');
                string[] fila = new string[valores.Length];

                for (int j = 0; j < tableCal.Columns.Count; j++)
                {
                    fila[j] = valores[j];

                }
                tableCal.Rows.Add(fila);
            }

            return tableCal;
        }

        public static int TotalLines(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                int i = 0;
                while (r.ReadLine() != null) { i++; }
                return i;
            }
        }
    }
}
