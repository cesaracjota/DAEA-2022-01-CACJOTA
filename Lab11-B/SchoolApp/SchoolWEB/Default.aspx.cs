using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolEntities;
using SchoolBLL;

namespace SchoolWEB
{
    public partial class _Default : Page
    {
        CPersonBLL personB = new CPersonBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            gvListado.DataSource = personB.ListarBLL();
            gvListado.DataBind();

        }
    }
}