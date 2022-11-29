using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WF
{
    public partial class Form1 : Form
    {


        public Form1()
        {

            InitializeComponent();
            //RefreshGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Views.Formulario tabla = new Views.Formulario();
            tabla.ShowDialog();

            Refrescar();
        }

        //Obtener Id
        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }


        //Mostrar formulario para editar o agregar
        private void button2_Click(object sender, EventArgs e)
        {
            int? IdEmpleado = GetId();
            if (IdEmpleado != null)
            {
                Views.Formulario tabla = new Views.Formulario(IdEmpleado);
                tabla.ShowDialog();
                Refrescar();
            }
        }

        //Eliminar
        private void button3_Click(object sender, EventArgs e)
        {
            int? IdEmpleado = GetId();
            if (MessageBox.Show("¿Desea eliminar el registro?", "Eliminar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (IdEmpleado != null)
                {
                    ML.Result result = BL.Empleado.DeleteEF(IdEmpleado);
                    MessageBox.Show("Registro eliminado con exito");
                    Refrescar();
                }
                //MessageBox.Show("Pago realizado");

            }

            else
            {

                MessageBox.Show("Registro no eliminado");

            }
        }

        private void Refrescar2()
        {
            dataGridView1.ClearSelection();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            Refrescar();
        }


        #region HELPER
        public void Refrescar()
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Area = new ML.Area();
            ML.Result result = BL.Empleado.GetAll();
            empleado.Empleados = result.Objects;
            dataGridView1.DataSource = empleado.Empleados;  //AGREGAR SIN FOREACH
            dataGridView1.Columns[4].Visible = false;
        }
        #endregion

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        //private void button2_Click_1(object sender, EventArgs e)
        //{
        //    dataGridView1.Columns.Clear();
        //    Refrescar();
        //}

    }
}
