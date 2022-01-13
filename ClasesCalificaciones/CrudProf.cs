using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Linq;

namespace ClasesCalificaciones
{
    static public class CrudProf
    {

        public static string directorio = $"{Archivos.DIRECTORIO}\\{Archivos.ARCHIVO_PROFESORES}";
        static public void Crear(Profesor profesor)
        {

            var archivo_profesor = new StreamWriter(directorio, true);
            archivo_profesor.WriteLine($"{profesor. Id},{profesor.Nombre},{profesor.Apellido}");
            archivo_profesor.Close();

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

        static public void Modificar(Profesor profesor)
        {
            List<string> lineas = File.ReadAllLines(directorio).ToList();

            // indice de la linea que contenga alguno de los datos proporcionados

            int index = lineas.FindIndex(s => s.Contains(Convert.ToString(profesor.Id)) || s.Contains(profesor.Nombre) || s.Contains(profesor.Id.ToString()));
            //sobreescribir la entrada de la lista en el indice que se encontro la linea que contenia los datos
            lineas[index] = profesor.ToString();

            File.WriteAllLines(directorio, lineas);
        }
        static public DataTable CrearGridView()
        {
            DataTable TableProf = new DataTable();



            TableProf.Columns.Add("Id").Unique = true;
            TableProf.Columns.Add("Nombre");
            TableProf.Columns.Add("Apellidos");



            string[] lineas = File.ReadAllLines($"{Archivos.DIRECTORIO}\\{Archivos.ARCHIVO_PROFESORES}");
            string[] valores;

            for (int i = 0; i < lineas.Length; i++)
            {
                valores = lineas[i].Split(',');
                string[] fila = new string[valores.Length];

                for (int j = 0; j < TableProf.Columns.Count; j++)
                {
                    fila[j] = valores[j];

                }
                TableProf.Rows.Add(fila);
            }

            return TableProf;
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

        public static string[] GetProfesoresID()
        {
            string[] IDs = File.ReadAllLines(directorio).Select((s) => s.Split(',')[0]).ToArray();

            return IDs;
        }

    }
}
