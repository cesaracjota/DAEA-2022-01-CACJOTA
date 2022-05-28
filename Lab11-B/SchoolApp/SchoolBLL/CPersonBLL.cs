using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolEntities;
using SchoolDAL;

namespace SchoolBLL
{
    public class CPersonBLL
    {
        CPersonDAL personDAL = new CPersonDAL();
        public List<CPerson> ListarBLL()
        {
            return personDAL.Listar();
        }
    }
}
