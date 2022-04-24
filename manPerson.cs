using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab05
{
    public partial class manPerson : Form
    {
        SqlConnection con;
        public manPerson()
        {
            InitializeComponent();
        }

        private void manPerson_Load(object sender, EventArgs e)
        {
            String str = "Server=DESKTOP-JP8L9C3\\LOCAL;DataBase=School;Integrated Security=true;";
            con = new SqlConnection(str);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sql = "SELECT * FROM Person";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            dvgListado.DataSource = dt;
            dvgListado.Refresh();
            con.Close();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sp = "InsertPerson";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@HireDate", txtHireDate.Value);
            cmd.Parameters.AddWithValue("@EnrollmentDate", txtEnrollmentDate.Value);

            int codigo = Convert.ToInt32(cmd.ExecuteScalar());
            MessageBox.Show("Se ha registrado nueva persona con el codigo: " + codigo);
            con.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sp = "UpdatePerson";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", txtPersonID.Text);
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@HireDate", txtHireDate.Value);
            cmd.Parameters.AddWithValue("@EnrollmentDate", txtEnrollmentDate.Value);

            int resultado = cmd.ExecuteNonQuery();
            if (resultado > 0)
            {
                MessageBox.Show("Se ha modificado el registro correctamente");
            }
            con.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sp = "DeletePerson";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", txtPersonID.Text);

            int resultado = cmd.ExecuteNonQuery();

            if (resultado > 0)
            {
                MessageBox.Show("Se ha eliminado el registro correctamente");
            }
            con.Close();
        }

        private void dvgListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dvgListado_SelectionChanged
        }

        private void dvgListado_SelectionChanged(object sender, EventArgs e)
        {
            if(dvgListado.SelectedRows.Count > 0)
            {
                txtPersonID.Text = dvgListado.SelectedRows[0].Cells[0].Value.ToString();
                txtLastName.Text = dvgListado.SelectedRows[0].Cells[1].Value.ToString();
                txtFirstName.Text = dvgListado.SelectedRows[0].Cells[2].Value.ToString();

                if (dvgListado.SelectedRows[0].Cells[3].Value.ToString() == string.Empty)
                {
                    txtHireDate.Format = DateTimePickerFormat.Custom;
                    txtHireDate.CustomFormat = " ";
                }
                else
                {
                    txtHireDate.Format = DateTimePickerFormat.Short;
                }
               if (dvgListado.SelectedRows[0].Cells[4].Value.ToString() == string.Empty)
                {
                    txtEnrollmentDate.Format = DateTimePickerFormat.Custom;
                    txtEnrollmentDate.CustomFormat = " ";
                }
                else
                {
                    txtEnrollmentDate.Format = DateTimePickerFormat.Short;
                }
                txtHireDate.Text = dvgListado.SelectedRows[0].Cells[3].Value.ToString();
                txtEnrollmentDate.Text = dvgListado.SelectedRows[0].Cells[4].Value.ToString();

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sp = "BuscarPersonaNombre";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@PersonID", txtPersonID.Text);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            dvgListado.DataSource = dt;
            dvgListado.Refresh();
            con.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPersonID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
        }
    }
}
