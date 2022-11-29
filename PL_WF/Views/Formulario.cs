using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WF.Views
{
    public partial class Formulario : Form
    {
        public int? IdEmpleado;

        public Formulario(int? IdEmpleado = null)
        {
            InitializeComponent();

            this.IdEmpleado = IdEmpleado;
            if (IdEmpleado != null)
            {
                CargaDatos();
            }
        }
        //GetById
        private void CargaDatos()
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Area = new ML.Area();
            ML.Result result = BL.Empleado.GetById(IdEmpleado);

            empleado.IdEmpleao = ((ML.Empleado)result.Object).IdEmpleao;
            empleado.Nombre = ((ML.Empleado)result.Object).Nombre;
            empleado.ApellidoPaterno = ((ML.Empleado)result.Object).ApellidoPaterno;
            empleado.ApellidoMaterno = ((ML.Empleado)result.Object).ApellidoMaterno;
            empleado.Area.Nombre = ((ML.Empleado)result.Object).Area.Nombre;
            empleado.FechaDeNacimiento = ((ML.Empleado)result.Object).FechaDeNacimiento;
            empleado.Sueldo = ((ML.Empleado)result.Object).Sueldo;
            empleado.Area.IdArea = ((ML.Empleado)result.Object).Area.IdArea;

            Id.Text = Convert.ToString(empleado.IdEmpleao);
            Nombre.Text = empleado.Nombre;
            ApellidoPaterno.Text = empleado.ApellidoPaterno;
            ApellidoMaterno.Text = empleado.ApellidoMaterno;
            FechaDeNacimiento.Value = empleado.FechaDeNacimiento;
            Sueldo.Text = empleado.Sueldo.ToString();
            //comboBox1.Text = empleado.Area.Nombre;

            ML.Area area = new ML.Area();
            ML.Result resultArea = BL.Area.GetAll();
            area.Areas = resultArea.Objects;
            comboBox1.DataSource = area.Areas;
            comboBox1.ValueMember = "IdArea";
            comboBox1.DisplayMember = "Nombre";
            comboBox1.Text = ((ML.Empleado)result.Object).Area.Nombre;
            // comboBox1.Text = ("Seleccionar área");
            comboBox1.SelectedItem = ((ML.Empleado)result.Object).Area.IdArea;
            //  comboBox1.SelectedIndex = comboBox1.Items.IndexOf(((ML.Empleado)result.Object).Area.Nombre); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Area = new ML.Area();
            if (IdEmpleado == null)
            {

                empleado.Nombre = Nombre.Text;
                empleado.ApellidoPaterno = ApellidoPaterno.Text;
                empleado.ApellidoMaterno = ApellidoMaterno.Text;
                empleado.FechaDeNacimiento = FechaDeNacimiento.Value;
                empleado.Sueldo = Convert.ToInt32(Sueldo.Text);
                var obj = comboBox1.SelectedItem;

                empleado.Area.IdArea = ((ML.Area)obj).IdArea;
                //empleado.Area.Nombre = obj.ToString();

                ML.Result result = BL.Empleado.AddEF(empleado);

                if (result.Correct == true)
                {

                    MessageBox.Show("Registro agregado correctamente");

                }
                else
                {
                    MessageBox.Show("El registro no se agrego ");
                }

                this.Close();
            }
            else
            {

                empleado.IdEmpleao = Convert.ToInt32(Id.Text);
                empleado.Nombre = Nombre.Text;
                empleado.ApellidoPaterno = ApellidoPaterno.Text;
                empleado.ApellidoMaterno = ApellidoMaterno.Text;
                var obj = comboBox1.SelectedItem;
                empleado.Area.IdArea = ((ML.Area)obj).IdArea;
                empleado.FechaDeNacimiento = FechaDeNacimiento.Value;
                empleado.Sueldo = Convert.ToInt32(Sueldo.Text);

                ML.Result result = BL.Empleado.UpdateEF(empleado);
                if (result.Correct == true)
                {
                    MessageBox.Show("Registro actualizado correctamente");
                }
                else
                {
                    MessageBox.Show("El registro no se actualizo ");
                }
                this.Close();
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Formulario_Load(object sender, EventArgs e)
        {
            ML.Area empleado = new ML.Area();
            ML.Result result = BL.Area.GetAll();
            empleado.Areas = result.Objects;
            comboBox1.DataSource = empleado.Areas;
            comboBox1.ValueMember = "IdArea";
            comboBox1.DisplayMember = "Nombre";

            comboBox1.Text = ("Seleccionar área");
            comboBox1.SelectedIndex = 0;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox2.Items.Clear();
            //llenardatos();

        }

   



        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Area = new ML.Area();
            if (IdEmpleado == null)
            {

                empleado.Nombre = Nombre.Text;
                empleado.ApellidoPaterno = ApellidoPaterno.Text;
                empleado.ApellidoMaterno = ApellidoMaterno.Text;
                empleado.FechaDeNacimiento = FechaDeNacimiento.Value;
                empleado.Sueldo = Convert.ToInt32(Sueldo.Text);
                var obj = comboBox1.SelectedItem;

                empleado.Area.IdArea = ((ML.Area)obj).IdArea;
                //empleado.Area.Nombre = obj.ToString();

                ML.Result result = BL.Empleado.AddEF(empleado);

                if (result.Correct == true)
                {

                    MessageBox.Show("Registro agregado correctamente, refresca la tabla para ver los cambios");

                }
                else
                {
                    MessageBox.Show("El registro no se agrego ");
                }

                this.Close();
            }
            else
            {

                empleado.IdEmpleao = Convert.ToInt32(Id.Text);
                empleado.Nombre = Nombre.Text;
                empleado.ApellidoPaterno = ApellidoPaterno.Text;
                empleado.ApellidoMaterno = ApellidoMaterno.Text;
                var obj = comboBox1.SelectedItem;
                empleado.Area.IdArea = ((ML.Area)obj).IdArea;
                empleado.FechaDeNacimiento = FechaDeNacimiento.Value;
                empleado.Sueldo = Convert.ToInt32(Sueldo.Text);

                ML.Result result = BL.Empleado.UpdateEF(empleado);
                if (result.Correct == true)
                {
                    MessageBox.Show("Registro actualizado correctamente, refresca la tabla para ver los cambios");
                }
                else
                {
                    MessageBox.Show("El registro no se actualizo ");
                }
                this.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    
        //Cargar datos al ComboBox al iniciar el formulario
        private void Formulario_Load_1(object sender, EventArgs e)
        {
            ML.Area empleado = new ML.Area();
            ML.Result result = BL.Area.GetAll();
            empleado.Areas = result.Objects;
            comboBox1.DataSource = empleado.Areas;
            comboBox1.ValueMember = "IdArea";
            comboBox1.DisplayMember = "Nombre";

            comboBox1.Text = ("Seleccionar área");
            comboBox1.SelectedIndex = 0;
            
        }

        private void Id_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
