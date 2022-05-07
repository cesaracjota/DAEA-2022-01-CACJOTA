using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Negocio
{
    public class clsNEGPerson
    {
        clsDAOPerson daoPerson = new clsDAOPerson();

        public DataTable GetAll()
        {
            return daoPerson.GetAll();
        }

        public DataTable FindByName(string textobuscar)
  
        {
            clsDAOPerson objeto = new clsDAOPerson();
            objeto.txtBuscar = textobuscar;
            return objeto.FindByName(objeto);
        }
    }
}
