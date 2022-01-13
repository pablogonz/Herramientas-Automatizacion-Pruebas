using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ClasesCalificaciones
{
    public class Calificacion
    {
        private string calificacion;

        public Calificacion(string estudiante, string calificacion, string asignatura, string letra)
        {
            Estudiante = estudiante;
            Nota = calificacion;
            Asignatura = asignatura;
            Letra = letra;
        }
        public Calificacion()
        {

        }
        public string Estudiante { get; set; }
        public string Nota { get; set; }
        public string Asignatura { get; set; }
        public string Letra { get; set; }


        public static string RecibirNota(float n)

        {
            if (n <= 100 && n >= 90)
            {
                return "A";

            }

            else if (n >= 80)
            {
                return "B";
            }
            

            else if (n >= 70)
            {
                return "C";
            }
            else if (n >= 60)
            {
                return "D";
            }
            else
            {
                return "F";
            }

        }

        public static int ConvertirLetra(string letra)
        {
            if (letra.Equals("A"))
            {
                return 4;
            }

            else if (letra.Equals("B"))
            {
                return 3;
            }

            else if (letra.Equals("C"))
            {
                return 2;
            }
            else if (letra.Equals("D"))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

       

        /*
       Luis, "esp-222-01, ids-322-05" , "B+, C"

        Samuel, "ing-548-01, ins-322-05" , "A, B"

       */
    }
}
