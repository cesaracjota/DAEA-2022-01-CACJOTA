using System;

namespace persons.Models
{
    public class Person
    {
        public int? PersonID { get; set; }

        public string? LastName { get; set; }

        public string? FirstName { get; set; }
        public DateTime? HireDate { get; set; }

        public DateTime? EnrollmentDate { get; set; }

    }
}
