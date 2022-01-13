using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ClasesCalificaciones;
using System.CodeDom;
using System.Threading;

namespace Calificaciones_Universitarias
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }
        private void RecargarDropdown()
        {
           CalificacionesAsignaturas.Items.Clear();
            CalificacionesEstudiantes.Items.Clear();
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                CalificacionesAsignaturas.Items.Add($"{dataGridView3.Rows[i].Cells[0].Value}");


            }

            for (int i = 0; i < EstudiantesTabla.Rows.Count; i++)
            {
                CalificacionesEstudiantes.Items.Add($"{EstudiantesTabla.Rows[i].Cells[0].Value}");
            }

        }

        DataTable tableEstudiantes; 
        DataTable tableProf;
        DataTable tableAsignaturas;
        DataTable tableCal;
        #region Diseño

        #region Menu Color
        private void Panel5_MouseHover(object sender, EventArgs e)
        {
            label6.ForeColor = Color.FromArgb(190, 0, 0);
        }

        private void Panel5_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Black;
        }

        private void Panel2_MouseHover(object sender, EventArgs e)
        {
            panel2.ForeColor = Color.FromArgb(190, 0, 0);
        }

        private void Panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.ForeColor = Color.Black;
        }

        private void Panel6_MouseHover(object sender, EventArgs e)
        {
            panel6.ForeColor = Color.FromArgb(190, 0, 0);
        }

        private void Panel6_MouseLeave(object sender, EventArgs e)
        {
            panel6.ForeColor = Color.Black;
        }

        private void Panel7_MouseHover(object sender, EventArgs e)
        {
            panel7.ForeColor = Color.FromArgb(190, 0, 0);
        }

        private void Panel7_MouseLeave(object sender, EventArgs e)
        {
            panel7.ForeColor = Color.Black;
        }

        private void Panel8_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void Panel8_MouseLeave(object sender, EventArgs e)
        {
        
        }

        private void Panel11_MouseHover(object sender, EventArgs e)
        {
            panel11.ForeColor = Color.FromArgb(190, 0, 0);
        }

        private void Panel11_MouseLeave(object sender, EventArgs e)
        {
            panel11.ForeColor = Color.Black;
        }


        #endregion

        #region Menu Visibilidad
        private void Panel2_Click(object sender, EventArgs e)
        {
            Inicio.Visible = false;
            Profesores.Visible = false;
            Asignaturas.Visible = false;
        
            Calificaciones.Visible = false;

            Estudiantes.Visible = true;
        }

        private void Panel5_Click(object sender, EventArgs e)
        {
            Profesores.Visible = false;
            Estudiantes.Visible = false;
            Asignaturas.Visible = false;
        
            Calificaciones.Visible = false;

            Inicio.Visible = true;
        }

        private void Panel6_Click(object sender, EventArgs e)
        {
            Inicio.Visible = false;
            Estudiantes.Visible = false;
            Asignaturas.Visible = false;
            
            Calificaciones.Visible = false;

            Profesores.Visible = true;
        }

        private void Panel7_Click(object sender, EventArgs e)
        {
            Inicio.Visible = false;
            Estudiantes.Visible = false;
            Profesores.Visible = false;
      
            Calificaciones.Visible = false;

            Asignaturas.Visible = true;
        }

        private void Panel8_Click(object sender, EventArgs e)
        {
            Inicio.Visible = false;
            Estudiantes.Visible = false;
            Profesores.Visible = false;
            Asignaturas.Visible = false;
            Calificaciones.Visible = false;
;
        }

        private void Panel11_Click(object sender, EventArgs e)
        {
            Inicio.Visible = false;
            Estudiantes.Visible = false;
            Profesores.Visible = false;
            Asignaturas.Visible = false;
        

            Calificaciones.Visible = true;
        }
        #endregion
        #endregion

        private void Button2_Click(object sender, EventArgs e)
        {
            string id = EstudiantesId.Text;
            string nombre = EstudiantesNombre.Text;
            string apellido = EstudiantesApellido.Text;
            string carrera = EstudiantesCarrera.Text;

            if (id == "" || nombre == "")
            {
                MessageBox.Show("Error en datos");
                return;
            }
            Estudiante nuevoEstudiante = new Estudiante(id, nombre, apellido, carrera);
            try
            {

                string[] nuevaFila = nuevoEstudiante.ToString().Split(',');

                tableEstudiantes.Rows.Add(nuevaFila);
                EstudiantesTabla.DataSource = tableEstudiantes;

            }
            catch
            {
                MessageBox.Show("Algo ha salido mal");
                return;
            }

            CrudEst.Crear(nuevoEstudiante);
            EstudiantesTabla.DataSource = CrudEst.CrearGridView();
            RecargarDropdown();


           EstudiantesId.Clear();
           EstudiantesNombre.Clear();
           EstudiantesApellido.Clear();
        
        }

          private void Button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in EstudiantesTabla.SelectedCells)

            {
                if (oneCell.Selected)
                {
                    string codigo = oneCell.OwningRow.Cells[0].Value.ToString();
                    EstudiantesTabla.Rows.RemoveAt(oneCell.RowIndex);

                    CrudEst.Borrar(codigo);
                    CrudCal.BorrarTodasCalificacionesSegunID(codigo);
                }
            }



            EstudiantesTabla.DataSource = CrudEst.CrearGridView();
            dataGridView5.DataSource = CrudCal.CrearGridView();
            RecargarDropdown();
        }

        private void Button5_Click(object sender, EventArgs e)
        {  
            bool v = false;
            if (EstudiantesId.Text == "")
            {
                MessageBox.Show("La casilla del Id esta vacia");
                return;
            }

            else 
            {

                for (int i = 0; i < CrudEst.TotalLines(CrudEst.directorio); i++)
                {
                    string[] n = CrudEst.GetEstudiantesID();

                    if (EstudiantesId.Text == n[i])
                    {

                        v = true;
                        
                        
                        EstudiantesTabla.Rows[i].Selected = true;
                  
                    }
                  

                }
                   
                
                if (v == true)
                    { 
                     MessageBox.Show("Se encontro");
                    }
                else
               {
                    MessageBox.Show("No se encontro");

                }
            
            }
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Archivos.crearArchivos();
            tableEstudiantes = CrudEst.CrearGridView();
            tableProf = CrudProf.CrearGridView();
            tableAsignaturas = AsignaturasCRUD.CrearGridView();
            tableCal = CrudCal.CrearGridView();
            
            EstudiantesTabla.DataSource = tableEstudiantes;
            ProfTab.DataSource = tableProf;
            dataGridView3.DataSource = tableAsignaturas;
            dataGridView5.DataSource = tableCal;
            RecargarDropdown();

            CrudEst.TotalLines(CrudEst.directorio);
            ContEstudiantes.Text = Convert.ToString(CrudEst.TotalLines(CrudEst.directorio));


            CrudProf.TotalLines(CrudProf.directorio);
            ContProfesores.Text = Convert.ToString(CrudProf.TotalLines(CrudProf.directorio));

            AsignaturasCRUD.TotalLines(AsignaturasCRUD.directorio);
            ContAsignaturas.Text = Convert.ToString(AsignaturasCRUD.TotalLines(AsignaturasCRUD.directorio));
        }

        private void EstudiantesEditar_Click(object sender, EventArgs e)
        {
            
        }

        private void ProfesoresAgregar_Click(object sender, EventArgs e)
        {
            string id = ProfesoresId.Text;
            string nombre = ProfesoresNombre.Text;
            string apellido = ProfesoresApellido.Text;


            if (id == "" || nombre == "")
            {
                MessageBox.Show("Error en datos");
                return;
            }

          //  try
          //  {

                Profesor nuevoProfesor = new Profesor(id, nombre, apellido);

               


                string[] nuevaFila = nuevoProfesor.ToString().Split(',');

            try
            {

                tableProf.Rows.Add(nuevaFila);
                ProfTab.DataSource = CrudProf.CrearGridView();
            }
            catch
            {
                MessageBox.Show("ID ya registrado.");
                return;
            }
            CrudProf.Crear(nuevoProfesor);


            RecargarDropdown();
        }

       

        private void ProfesoresBuscar_Click(object sender, EventArgs e)
        {
            bool v = false;
            if (ProfesoresId.Text == "")
            {
                MessageBox.Show("La casilla del Id esta vacia");
                return;
            }

            else
            {

                for (int i = 0; i < CrudProf.TotalLines(CrudProf.directorio); i++)
                {
                    string[] n = CrudProf.GetProfesoresID();

                    if (ProfesoresId.Text == n[i])
                    {

                        v = true;


                        ProfTab.Rows[i].Selected = true;

                    }


                }


                if (v == true)
                {
                    MessageBox.Show("Se encontro");
                }
                else
                {
                    MessageBox.Show("No se encontro");

                }

            }
        
    }

        private void Menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EstudiantesTabla_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = EstudiantesTabla.Rows[e.RowIndex];

            try
            {
                Estudiante estudiante = new Estudiante(fila.Cells[0].Value.ToString(), fila.Cells[1].Value.ToString(),fila.Cells[2].Value.ToString(), fila.Cells[3].Value.ToString());

                CrudEst.Modificar(estudiante);
            }
            catch
            {
                MessageBox.Show("Valores invalidos.");
                EstudiantesTabla.DataSource = CrudEst.CrearGridView();
            }


            RecargarDropdown();
        }

        private void ProfesoresBorrar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in ProfTab.SelectedCells)

            {
                if (oneCell.Selected)
                {
                    string codigo = oneCell.OwningRow.Cells[0].Value.ToString();
                    ProfTab.Rows.RemoveAt(oneCell.RowIndex);

                    CrudProf.Borrar(codigo);
                }
            }



            ProfTab.DataSource = CrudProf.CrearGridView();
            RecargarDropdown();

        }

        private void ProfTab_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = ProfTab.Rows[e.RowIndex];

            try
            {
                Profesor profesor = new Profesor(fila.Cells[0].Value.ToString(), fila.Cells[1].Value.ToString(), fila.Cells[2].Value.ToString());

                CrudProf.Modificar(profesor);
            }
            catch
            {
                MessageBox.Show("Valores invalidos.");
              
            }

            try
            {
                ProfTab.DataSource = CrudProf.CrearGridView();
            }
            catch
            {
                MessageBox.Show("ID ya registrado.");
            }

            RecargarDropdown();
        }
        #region Asignatura


   

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {


            DataGridViewRow fila = dataGridView3.Rows[e.RowIndex];

            try
            {
                Asignatura asignatura = new Asignatura(fila.Cells[0].Value.ToString(), fila.Cells[1].Value.ToString(), byte.Parse(fila.Cells[2].Value.ToString()));

                AsignaturasCRUD.Modificar(asignatura);
            }
            catch
            {
                MessageBox.Show("Valores invalidos.");
               
            }
            try
            {
                dataGridView3.DataSource = AsignaturasCRUD.CrearGridView();
            } catch
            {
                MessageBox.Show("ID registrada");
            }
            RecargarDropdown();
        }



       

        #endregion

        private void AsignaturasAgregar_Click_1(object sender, EventArgs e)
        {


            string clave = AsignaturasClave.Text;
            string nombre = AsignaturasNombre.Text;

            if (clave == "" || nombre == "")
            {
                MessageBox.Show("Error en datos");
                return;
            }

            //try
            //{
            byte creditos = byte.Parse(AsignaturasCreditos.Text);

            if (creditos > 5)
            {
                MessageBox.Show("No mas de 5 creditos");
                return;
            }
            Asignatura nuevaAsignatura = new Asignatura(clave, nombre, creditos);

           


            string[] nuevaFila = nuevaAsignatura.ToString().Split(',');
            try
            {
                tableAsignaturas.Rows.Add(nuevaFila);
                dataGridView3.DataSource = AsignaturasCRUD.CrearGridView();
            }
            catch
            {
                MessageBox.Show("Asignatura repetida(ID ya registrado)");
                return;
            }
            AsignaturasCRUD.Crear(nuevaAsignatura);

        
            RecargarDropdown();

        }

        private void AsignaturasBorrar_Click_1(object sender, EventArgs e)
        {

            foreach (DataGridViewCell oneCell in dataGridView3.SelectedCells)

            {
                if (oneCell.Selected)
                {
                    string codigo = oneCell.OwningRow.Cells[0].Value.ToString();
                    dataGridView3.Rows.RemoveAt(oneCell.RowIndex);

                    AsignaturasCRUD.Borrar(codigo);
                }
            }



            dataGridView3.DataSource = AsignaturasCRUD.CrearGridView();
            RecargarDropdown();

        }

        private void CalificacionesAgregar_Click(object sender, EventArgs e)
        {
            string estudiante = CalificacionesEstudiantes.Text;
            string calificacion = CalificacionesCalificacion.Text;
            string asignatura = CalificacionesAsignaturas.Text;

            try
            {
                int.Parse(calificacion);
            }
            catch
            {
                MessageBox.Show("Debe ser un num 1-100");
                return;
            }




            string letra = Calificacion.RecibirNota(Convert.ToInt32(calificacion));

           


            if (estudiante == "" || calificacion == ""|| asignatura=="")
            {
                MessageBox.Show("Error en datos");
                return;
            }

            //try
            //{
           

            Calificacion nuevaCalificacion = new Calificacion(estudiante, calificacion, asignatura, letra);

            string[] nuevaFila = nuevaCalificacion.ToString().Split(',');

            bool pudoCrearse = CrudCal.Crear(nuevaCalificacion);

            if (!pudoCrearse)
            {
                MessageBox.Show("El estudiante ya pasó esa asignatura.");
                return;
            }
            else
            {
                tableCal.Rows.Add(nuevaFila);
            }

            dataGridView5.DataSource = CrudCal.CrearGridView();

        
            RecargarDropdown();

        }

        private void CalificacionesBorrar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dataGridView5.SelectedCells)

            {
                if (oneCell.Selected)
                {
                    string codigo = oneCell.OwningRow.Cells[0].Value.ToString();
                    dataGridView5.Rows.RemoveAt(oneCell.RowIndex);

                    CrudCal.Borrar(codigo);
                }
            }



            dataGridView5.DataSource = CrudCal.CrearGridView();
            RecargarDropdown();
        }

        private void CalificacionesEditar_Click(object sender, EventArgs e)
        {

        }

        private void Reporte_Click(object sender, EventArgs e)
        {
            ReporteWrite.generarReporte();
        }

        private void Inicio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Inicio_MouseClick(object sender, MouseEventArgs e)
        {
           
            ContEstudiantes.Text = Convert.ToString(CrudEst.TotalLines(CrudEst.directorio));


           
            ContProfesores.Text = Convert.ToString(CrudProf.TotalLines(CrudProf.directorio));

          
            ContAsignaturas.Text = Convert.ToString(AsignaturasCRUD.TotalLines(AsignaturasCRUD.directorio));


        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AsignaturasBuscar_Click(object sender, EventArgs e)
        {
            bool v = false;
            if (AsignaturasClave.Text == "")
            {
                MessageBox.Show("La casilla del Id esta vacia");
                return;
            }

            else
            {

                for (int i = 0; i < AsignaturasCRUD.TotalLines(AsignaturasCRUD.directorio); i++)
                {
                    string[] n = AsignaturasCRUD.GetAsignaturas();

                    if (AsignaturasClave.Text == n[i])
                    {

                        v = true;


                        dataGridView3.Rows[i].Selected = true;

                    }


                }


                if (v == true)
                {
                    MessageBox.Show("Se encontro");
                }
                else
                {
                    MessageBox.Show("No se encontro");

                }

            }
        }
    }




}

