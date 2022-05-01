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

namespace Lab06
{
    public partial class manPerson : Form
    {
        SqlConnection con;
        DataSet ds = new DataSet();
        DataTable tablePerson = new DataTable();
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
            String sql = "SELECT * FROM Person";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            adapter.Fill(ds, "Person");

            tablePerson = ds.Tables["Person"];

            dvgListado.DataSource = tablePerson;
            dvgListado.Update();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("InsertPerson", con);

            cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50, "LastName");
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50, "FirstName");
            cmd.Parameters.Add("@HireDate", SqlDbType.Date).SourceColumn = "HireDate";
            cmd.Parameters.Add("@EnrollmentDate", SqlDbType.Date).SourceColumn = "EnrollmentDate";

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = cmd;
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

            DataRow fila = tablePerson.NewRow();
            fila["LastName"] = txtLastName.Text;

            fila["FirstName"] = txtFirstName.Text;

            //Condicionamos si el campo txtHireDatechecked es false y continuamente igualamos
            if (txtHireDate.Checked == false)
            {
                fila["HireDate"] = DBNull.Value;
            }
            else
            {
                fila["HireDate"] = txtHireDate.Value;
            }

            if (txtEnrollmentDate.Checked == false)
            {
                fila["EnrollmentDate"] = DBNull.Value;
            }
            else
            {
                fila["EnrollmentDate"] = txtEnrollmentDate.Value;
            }


            tablePerson.Rows.Add(fila);
            adapter.Update(tablePerson);
            MessageBox.Show("Data Insertada Correctamente");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UpdatePerson", con);

            cmd.Parameters.Add("@PersonID", SqlDbType.VarChar).SourceColumn = "PersonID";
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar).SourceColumn = "LastName";
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).SourceColumn = "FirstName";
            cmd.Parameters.Add("@HireDate", SqlDbType.Date).SourceColumn = "HireDate";
            cmd.Parameters.Add("@EnrollmentDate", SqlDbType.Date).SourceColumn = "EnrollmentDate";

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.UpdateCommand = cmd;
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;

            DataRow[] fila = tablePerson.Select("PersonID = '"+ txtPersonID.Text+ "'");
            fila[0]["LastName"] = txtLastName.Text;
            fila[0]["FirstName"] = txtFirstName.Text;
            fila[0]["HireDate"] = txtHireDate.Value;
            fila[0]["EnrollmentDate"] = txtEnrollmentDate.Value;

            adapter.Update(tablePerson);

            MessageBox.Show("Se actualizo los datos correctamente");

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DeletePerson", con);
            cmd.Parameters.Add("@PersonID", SqlDbType.VarChar).SourceColumn = "PersonID";

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.DeleteCommand = cmd;
            adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;

            DataRow[] fila = tablePerson.Select("PersonID = '" + txtPersonID.Text + "'");

            fila[0].Delete();
            adapter.Update(tablePerson);
            MessageBox.Show("Se eliminó el dato correctamente");
        }

        private void dvgListado_SelectionChanged(object sender, EventArgs e)
        {
            if (dvgListado.SelectedRows.Count > 0)
            {
                txtPersonID.Text = dvgListado.SelectedRows[0].Cells[0].Value.ToString();
                txtLastName.Text = dvgListado.SelectedRows[0].Cells[1].Value.ToString();
                txtFirstName.Text = dvgListado.SelectedRows[0].Cells[2].Value.ToString();
                string hireDate = dvgListado.SelectedRows[0].Cells[3].Value.ToString();
                if (String.IsNullOrEmpty(hireDate))
                    txtHireDate.Checked = false;
                else
                    txtHireDate.Text = hireDate;

                string enrollmentDate = dvgListado.SelectedRows[0].Cells[4].Value.ToString();
                if (String.IsNullOrEmpty(enrollmentDate))
                    txtEnrollmentDate.Checked = false;
                else
                    txtEnrollmentDate.Text = enrollmentDate;

            }
        }

        private void btnOrdenarApellido_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(tablePerson);
            dv.Sort = "LastName ASC";
            dvgListado.DataSource = dv;
        }
        private void btnOrdenarNombre_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(tablePerson);
            dv.Sort = "FirstName ASC";
            dvgListado.DataSource = dv;
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(tablePerson);
            dv.RowFilter = "PersonID = '" + txtPersonID.Text + "'";
            dvgListado.DataSource = dv;
        }

        private void btnBuscarNombre_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(tablePerson);
            dv.RowFilter = "FirstName = '" + txtFirstName.Text + "'";
            dvgListado.DataSource = dv;
        }

        private void btnBuscarApellido_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(tablePerson);
            dv.RowFilter = "LastName = '" + txtLastName.Text + "'";
            dvgListado.DataSource = dv;
        }
    }
}
