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
    public partial class Login : Form
    {
        SqlConnection conn;
        public Login(SqlConnection conn)
        {
            this.conn = conn;
            InitializeComponent();
        }

        private void btnInciar_Click(object sender, EventArgs e)
        {
            String UserName = txtUsuario.Text;
            String UserPassword = txtPassword.Text;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "InicioSesionUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            SqlParameter paramUsuario = new SqlParameter();
            paramUsuario.ParameterName = "@usuario_nombre";
            paramUsuario.SqlDbType = SqlDbType.NVarChar;
            paramUsuario.Value = UserName;
            cmd.Parameters.Add(paramUsuario);

            SqlParameter paramPassword = new SqlParameter();
            paramPassword.ParameterName = "@usuario_password";
            paramPassword.SqlDbType = SqlDbType.NVarChar;
            paramPassword.Value = UserPassword;
            cmd.Parameters.Add(paramPassword);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            if (dt.Rows.Count > 0)
            {
                Person person = new Person(conn);
                person.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error de Inicio de Sesion");
            }
        }
    }
}
