using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasesCalificaciones;
using System.IO;

namespace Calificaciones_Universitarias
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Archivos.crearArchivos();
            
            
        }

        private void Label4_MouseHover(object sender, EventArgs e)
        {
            label4.ForeColor = Color.DarkBlue;
        }

        private void Label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
