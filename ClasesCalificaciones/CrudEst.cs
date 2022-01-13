using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Linq;

namespace ClasesCalificaciones
{
    static public class CrudEst
    {
        public static string directorio = $"{Archivos.DIRECTORIO}\\{Archivos.ARCHIVO_ESTUDIANTES}";
        static public void Crear(Estudiante estudiante)
        {

            var archivo_estudiantes = new StreamWriter(directorio, true);
            archivo_estudiantes.WriteLine($"{estudiante.Id},{estudiante.Nombre},{estudiante.Apellido}, {estudiante.Carrera}");
            archivo_estudiantes.Close();

        }
        static public bool Borrar(string Id)
        {
            List<string> lineas = File.ReadAllLines(directorio).ToList(); //Leer lineas del archivo y obtenerlas en una lista

            int index = lineas.FindIndex(s => s.Contains(Id)); // Conseguir el indice de la lista donde se encuentra la asignatura mediante la clave.
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

        static public void Modificar(Estudiante estudiante)
        {
            List<string> lineas = File.ReadAllLines(directorio).ToList();

            // indice de la linea que contenga alguno de los datos proporcionados

            int index = lineas.FindIndex(s => s.Contains(Convert.ToString(estudiante.Id)) || s.Contains(estudiante.Nombre) || s.Contains(estudiante.Id.ToString()));
            //sobreescribir la entrada de la lista en el indice que se encontro la linea que contenia los datos
            lineas[index] = estudiante.ToString();

            File.WriteAllLines(directorio, lineas);
        }
        static public DataTable CrearGridView()
        {
            DataTable tableEst = new DataTable();



            tableEst.Columns.Add("Id").Unique = true;
            tableEst.Columns.Add("Nombre");
            tableEst.Columns.Add("Apellido");
            tableEst.Columns.Add("Carrera");




            string[] lineas = File.ReadAllLines($"{Archivos.DIRECTORIO}\\{Archivos.ARCHIVO_ESTUDIANTES}");
            string[] valores;

            for (int i = 0; i < lineas.Length; i++)
            {
                valores = lineas[i].Split(',');
                string[] fila = new string[valores.Length];

                for (int j = 0; j < tableEst.Columns.Count; j++)
                {
                    fila[j] = valores[j];

                }
                tableEst.Rows.Add(fila);
            }

            return tableEst;
        }

        public static string[] GetEstudiantesID()
        {
            string[] IDs = File.ReadAllLines(directorio).Select((s) => s.Split(',')[0]).ToArray();

            return IDs;
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

