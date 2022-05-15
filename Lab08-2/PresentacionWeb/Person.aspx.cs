using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Data;

namespace PresentacionWeb
{
    public partial class Person : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            clsNEGPerson np = new clsNEGPerson();
            dt = np.GetAll();

            gvDatos.DataSource = dt;
            gvDatos.DataBind();
        }
    }
}