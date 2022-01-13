using ClasesCalificaciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calificaciones_UniversitariasTests
{
    [TestClass]
    public class ReporteWriteTests
    {
        [TestMethod]
        public void indice_mayor_o_igual_a_3_punto_8()
            {
            string honores = ReporteWrite.conseguirHonores(3.9);
            Assert.AreEqual("Summa Cum Laude", honores);
            }
        [TestMethod]
        public void indice_mayor_o_igual_a_3_punto_5()
        {
            string honores = ReporteWrite.conseguirHonores(3.5);
            Assert.AreEqual("Magna Cum Laude", honores);
        }
        [TestMethod]
        public void indice_mayor_o_igual_a_3_punto_2()
        {
            string honores = ReporteWrite.conseguirHonores(3.3);
            Assert.AreEqual("Cum Laude", honores);
        }
        [TestMethod]
        public void indice_menor_a_3_punto_2()
        {
            string honores = ReporteWrite.conseguirHonores(3);
            Assert.AreEqual("Sin honor", honores);
        }
    }
}
