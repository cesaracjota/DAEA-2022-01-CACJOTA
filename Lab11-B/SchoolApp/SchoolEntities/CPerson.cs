using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolEntities
{
    public class CPerson
    {
        public int PersonID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
