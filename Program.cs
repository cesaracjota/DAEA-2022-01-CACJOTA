using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            //origen de datos

            NorthwndDataContext context = new NorthwndDataContext();
            //ejercicio #1
            //Creacion de consulta
            var query1 = from p in context.Products
                         select p;

            Console.WriteLine("************* EJERCICIO #1 *************");

            foreach (var prod in query1)
            {
                Console.WriteLine("ID={0} \t Name={1}", prod.ProductID, prod.ProductName);

            }

            //Ejercicio #2
            var query2 = from p in context.Products
                         where p.Categories.CategoryName == "Beverages"
                         select p;

            Console.WriteLine("************* EJERCICIO #2 *************");

            foreach (var prod in query2)
            {
                Console.WriteLine("ID={0} \t Name={1}", prod.ProductID, prod.ProductName);

            }

            //Ejercicio #3
            var query3 = from p in context.Products
                         where p.UnitPrice < 20
                         select p;

            Console.WriteLine("************* EJERCICIO #3 *************");

            foreach (var prod in query3)
            {
                Console.WriteLine("ID={0} \t Price={1} \t Name={2}", prod.ProductID, prod.UnitPrice, prod.ProductName);

            }

            //Ejercicio #4
            var query4 = from p in context.Products
                             //FirstName like '%'+@FirstName+'%'
                         where p.ProductName.Contains("Queso")
                         select p;

            Console.WriteLine("************* EJERCICIO #4 *************");
            foreach (var prod in query4)
            {
                Console.WriteLine("ID={0} \t Name={1}", prod.ProductID, prod.ProductName);

            }

            //Ejercicio #5
            var query5 = from p in context.Products
                             //FirstName like '%'+@FirstName+'%'
                         where p.QuantityPerUnit.Contains("pkgs") || p.QuantityPerUnit.Contains("pkg")
                         select p;

            Console.WriteLine("************* EJERCICIO #5 *************");
            foreach (var prod in query5)
            {
                Console.WriteLine("ID={0} \t Name={1} \t Presentation={2}", prod.ProductID, prod.ProductName, prod.QuantityPerUnit);

            }

            //Ejercicio #6
            var query6 = from p in context.Products
                             //FirstName like '%'+@FirstName+'%'
                         where p.ProductName.StartsWith("a")
                         select p;

            Console.WriteLine("************* EJERCICIO #6 *************");
            foreach (var prod in query6)
            {
                Console.WriteLine("ID={0} \t Name={1} \t Precio={2}", prod.ProductID, prod.ProductName, prod.UnitPrice);

            }

            //Ejercicio #7
            var query7 = from p in context.Products
                             //FirstName like '%'+@FirstName+'%'
                         where p.UnitsInStock <= 0
                         select p;

            Console.WriteLine("************* EJERCICIO #7 *************");
            foreach (var prod in query7)
            {
                Console.WriteLine("ID={0} \t Name={1} \t Stock={2}", prod.ProductID, prod.ProductName, prod.UnitsInStock);

            }

            //Ejercicio #8
            var query8 = from p in context.Products
                             //FirstName like '%'+@FirstName+'%'
                         where p.Discontinued == true
                         select p;

            Console.WriteLine("************* EJERCICIO #8 *************");
            foreach (var prod in query8)
            {
                Console.WriteLine("ID={0} \t Name={1} \t Discontiuned={2}", prod.ProductID, prod.ProductName, prod.Discontinued);

            }

            Console.ReadKey();


            //INSERTAR REGISTROS

            //Creacion de consulta
            Products np = new Products();
            np.ProductName = "Agyl Code Products";
            np.SupplierID = 20;
            np.CategoryID = 1;
            np.QuantityPerUnit = "10 pkgs";
            np.UnitPrice = 25;

            //Ejecucion de la consulta

            context.Products.InsertOnSubmit(np);
            context.SubmitChanges();
            Console.WriteLine("Nuevo registro en BD : " + np.ProductID);
            Console.ReadKey();


            //INSERTAR REGISTROS DE CATEGORIAS

            Categories nc = new Categories();
            nc.CategoryName = "Agyl Category";
            nc.Description = "Agyl Category Description";

            //Ejecucion de la consulta

            context.Categories.InsertOnSubmit(nc);
            context.SubmitChanges();
            Console.WriteLine("Nuevo registro de Categoria en BD : " + nc.CategoryID);
            Console.ReadKey();


            //MODIFICAR REGISTROS
            var product = (from p in context.Products
                           where p.ProductName == "Agyl Code Products"
                           select p).FirstOrDefault();

            product.ProductName = "Agyl Code Products Actualizado";
            product.UnitPrice = 100;
            product.UnitsInStock = 15;
            product.Discontinued = true;

            //ejecucion de consulta
            context.SubmitChanges();
            Console.WriteLine("Registro actualizado en BD : " + product.ProductID);
            Console.ReadKey();


            //ELIMINAR UN PRODUCTO
            var productDel = (from p in context.Products
                              where p.ProductID == 78
                              select p).FirstOrDefault();

            //Ejecucion de consulta
            context.Products.DeleteOnSubmit(productDel);
            context.SubmitChanges();
            Console.WriteLine("Registro eliminado en BD : " + productDel.ProductID);
            Console.ReadKey();


            // ACTIVIDADES ADICIONALES

            // Creacion de consulta  a la tabla Suppliers

            var queryPS = from ps in context.Products
                         select ps;

            Console.WriteLine("************* ACTIVIDADES ADICIONALES #1 *************");

            foreach (var sup in queryPS)
            {
                Console.WriteLine("ID={0} \t Name={1} \t Proveedor={2}", sup.ProductID, sup.ProductName, sup.Suppliers.CompanyName);
            }

            // Listar los productos de los proveedores ubicados en USA

            var queryPS1 = from ps in context.Products
                           where ps.Suppliers.Country == "USA"
                          select ps;

            Console.WriteLine("************* ACTIVIDADES ADICIONALES #2 *************");

            foreach (var sup in queryPS1)
            {
                Console.WriteLine("ID={0} \t Name={1} \t Country={2}", sup.ProductID, sup.ProductName, sup.Suppliers.Country);
            }

            Console.ReadKey();

        }
    }
}
