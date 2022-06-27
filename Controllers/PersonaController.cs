using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab13.Models;

namespace Lab13.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {
            List<Persona> personas = new List<Persona>
            {
                new Persona
                {
                    PersonaID = 1,
                    Nombre = "Juan",
                    Apellido = "Perez",
                    Direccion = "Av. Cultura 123",
                    FechaNac = Convert.ToDateTime("1997-11-07"),
                    Email = "juan@gmail.com"
                },

                new Persona
                {
                    PersonaID = 2,
                    Nombre = "Maria",
                    Apellido = "Salas",
                    Direccion = "Av. arequipa 123",
                    FechaNac = Convert.ToDateTime("1999-11-07"),
                    Email = "maria@gmail.com"
                },

                new Persona
                {
                    PersonaID = 3,
                    Nombre = "Cesar",
                    Apellido = "Acjota",
                    Direccion = "Av. pizarro 123",
                    FechaNac = Convert.ToDateTime("2001-11-07"),
                    Email = "cesar@gmail.com"
                }
            };

            return View(personas);
        }
        public ActionResult Mostrar(int id)
        {
            List<Persona> personas = new List<Persona>();

            personas.Add(new Persona
            {
                PersonaID = 1,
                Nombre = "Juan",
                Apellido = "Perez",
                Direccion = "Av. Evergen 123",
                FechaNac = Convert.ToDateTime("1997-11-07"),
                Email = "juan@gmail.com"
            });
            personas.Add(new Persona
            {
                PersonaID = 2,
                Nombre = "Maria",
                Apellido = "Salas",
                Direccion = "Av. arequipa 123",
                FechaNac = Convert.ToDateTime("1999-11-07"),
                Email = "maria@gmail.com"
            });
            personas.Add(new Persona
            {
                PersonaID = 3,
                Nombre = "Cesar",
                Apellido = "Acjota",
                Direccion = "Av. pizarro 123",
                FechaNac = Convert.ToDateTime("2001-11-07"),
                Email = "cesar@gmail.com"
            });
            Persona persona = (from p in personas
                               where p.PersonaID == id
                               select p).FirstOrDefault();
            return View(persona);
        }

        public ActionResult Buscar(string search)
        {
            List<Persona> personas = new List<Persona>();

            return View(personas.Where(x => x.Nombre.Contains(search)).ToList());
        }
    }
}