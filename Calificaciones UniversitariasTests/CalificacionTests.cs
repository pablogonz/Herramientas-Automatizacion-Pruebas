using System;
using System.Collections.Generic;
using System.Text;
using ClasesCalificaciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calificaciones_UniversitariasTests
{
    [TestClass]
    public class CalificacionTests
    {
        [TestMethod]
        public void nota_mayor_a_90 ()
        {
            string nota = Calificacion.RecibirNota(95);
            Assert.AreEqual("A", nota);
        }
        [TestMethod]
        public void nota_mayor_a_80()
        {
            string nota = Calificacion.RecibirNota(83);
            Assert.AreEqual("B", nota);
        }

        [TestMethod]
        public void nota_mayor_a_70()
        {
            string nota = Calificacion.RecibirNota(72);
            Assert.AreEqual("C", nota);
        }
        [TestMethod]
        public void nota_mayor_a_60()
        {
            string nota = Calificacion.RecibirNota(67);
            Assert.AreEqual("D", nota);
        }
        [TestMethod]
        public void nota_menor_a_60()
        {
            string nota = Calificacion.RecibirNota(59);
            Assert.AreEqual("F", nota);
        }

    }
}