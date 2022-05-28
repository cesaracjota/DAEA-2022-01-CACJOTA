using SchoolEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SchoolDAL
{
    public class CPersonDAL
    {
        public List<CPerson> Listar()
        {
            using (SchoolEntities contexto = new SchoolEntities())
            {
                var query = contexto.Person.Select(p => new CPerson
                {
                    PersonID = p.PersonID,
                    LastName = p.LastName,
                    FirstName = p.FirstName
                });
                return query.ToList();
            }
        }
    }
}
