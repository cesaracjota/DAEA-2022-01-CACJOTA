using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab012.Models;

namespace Lab012.Controllers
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
            List<Persona> personas = new List<Persona>();
            personas.Add(new Persona
            {
                PersonaID = 1,
                Nombre = "Cesar",
                Apellido = "Acjota Merma",
                Direccion = "Av Mi Perú",
                FechaNac = Convert.ToDateTime("2001-08-21"),
                Email = "cesar.acjota@gmail.com"
            });
            personas.Add(new Persona
            {
                PersonaID = 2,
                Nombre = "User 2",
                Apellido = "Apellido 2",
                Direccion = "Av Mi Perú",
                FechaNac = Convert.ToDateTime("2001-08-21"),
                Email = "user2@gmail.com"
            });
            personas.Add(new Persona
            {
                PersonaID = 3,
                Nombre = "User 3",
                Apellido = "Apellidos 3",
                Direccion = "Av Mi Perú",
                FechaNac = Convert.ToDateTime("2001-08-21"),
                Email = "user3@gmail.com"
            });
            return View(personas);
        }
    }
}