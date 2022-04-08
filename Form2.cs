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

namespace Lab03
{
    public partial class Persona : Form
    {
        SqlConnection conn;
        public Persona(SqlConnection conn)
        {
            this.conn = conn;
            InitializeComponent();
        }

        private void Persona_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                String sql = "SELECT * FROM tbl_usuario";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                dgvListado.DataSource = dt;
                dgvListado.Refresh();
            }
            else
            {
                MessageBox.Show("La conexion esta cerrada");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                string name = txtNombre.Text;
                string sql = "select * from tbl_usuario where usuario_nombre='" + name + "'";
                SqlDataAdapter adaptador = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                dgvListado.DataSource = dt;
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                dgvListado.Refresh();
                reader.Close();
                //if (reader.Read())
                //{
                //   SqlDataAdapter adaptador = new SqlDataAdapter(sql, conn);
                //  DataTable dt = new DataTable();

                //  dgvListado.DataSource = dt;
                //   dgvListado.Refresh();
                // }
                // else
                // {
                //    MessageBox.Show("No existe el usuario buscado");
                //}

                //DataTable dt = new DataTable();
                //dt.Load(reader);
                //dgvListado.DataSource = dt;
                //dgvListado.Refresh();
            }
            else
            {
                MessageBox.Show("La conexion esta cerrada");
            }
        }

        private void Persona_Load_1(object sender, EventArgs e)
        {

        }
    }
}
