using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ClasesCalificaciones
{
    static public class AsignaturasCRUD
    {
        public static string directorio = $"{Archivos.DIRECTORIO}\\{Archivos.ARCHIVO_ASIGNATURAS}";
        static public void Crear(Asignatura asignatura)
        {

            var archivo_asignatura = new StreamWriter(directorio, true);
            archivo_asignatura.WriteLine($"{asignatura.Clave},{asignatura.Nombre},{asignatura.Creditos}");
            archivo_asignatura.Close();

        }
        static public bool Borrar(string clave)
        {
            List<string> lineas = File.ReadAllLines(directorio).ToList(); //Leer lineas del archivo y obtenerlas en una lista

            int index = lineas.FindIndex(s => s.Contains(clave)); // Conseguir el indice de la lista donde se encuentra la asignatura mediante la clave.
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

        static public void Modificar(Asignatura asignatura)
        {
            List<string> lineas = File.ReadAllLines(directorio).ToList();

            // indice de la linea que contenga alguno de los datos proporcionados

            int index = lineas.FindIndex(s => s.Contains(asignatura.Clave) || s.Contains(asignatura.Nombre) || s.Contains(asignatura.Clave.ToString()));
            //sobreescribir la entrada de la lista en el indice que se encontro la linea que contenia los datos
            lineas[index] = asignatura.ToString();

            File.WriteAllLines(directorio, lineas);
        }
        static public DataTable CrearGridView()
        {
            DataTable tableAsignaturas = new DataTable();



            tableAsignaturas.Columns.Add("Clave");
            tableAsignaturas.Columns.Add("Nombre");
            tableAsignaturas.Columns.Add("Creditos");

            tableAsignaturas.Columns[0].Unique = true;



            string[] lineas = File.ReadAllLines($"{Archivos.DIRECTORIO}\\{Archivos.ARCHIVO_ASIGNATURAS}");
            string[] valores;

            for (int i = 0; i < lineas.Length; i++)
            {
                valores = lineas[i].Split(',');
                string[] fila = new string[valores.Length];

                for (int j = 0; j < tableAsignaturas.Columns.Count; j++)
                {
                    fila[j] = valores[j];

                }
                tableAsignaturas.Rows.Add(fila);
            }

            return tableAsignaturas;
        }

        public static string[] GetAsignaturas()
        {
            string[] lineas = File.ReadAllLines($"{Archivos.DIRECTORIO}\\{Archivos.ARCHIVO_ASIGNATURAS}");
            string[] materias = new string[lineas.Length];

            for (int i = 0; i < materias.Length; i++)
            {
                materias[i] = lineas[i].Split(',')[0];
            }

            return materias;
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
