using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class clsDAOPerson : clsDAO
    {
        public string txtBuscar;

        public DataTable GetAll()
        {
            DataTable dt = new DataTable();

            con.Open();
            String sql = "select * from Person";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            con.Close();
            return dt;
        }
       
        public DataTable FindByName(clsDAOPerson nombre)
        {
            DataTable dt = new DataTable();

            con.Open();
            String sp = "BuscarPersonaNombre";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter ParTextBuscar = new SqlParameter();
            ParTextBuscar.ParameterName = "@FirstName";
            ParTextBuscar.SqlDbType = SqlDbType.NVarChar;
            ParTextBuscar.Size = 50;
            ParTextBuscar.Value = nombre.txtBuscar;
            cmd.Parameters.Add(ParTextBuscar);


            SqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            con.Close();

            return dt;
        }
        
    }
}
