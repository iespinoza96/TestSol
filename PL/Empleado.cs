using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_Console
{
    public class Empleado
    {
        public static void GetAll()
        {
            ML.Result result = BL.Empleado.GetAll();
            ML.Empleado empleados = new ML.Empleado();

            if (result.Correct)
            {
                foreach (ML.Empleado empleado in result.Objects)
                {
                    Console.WriteLine("IdEmpleado: " + empleado.IdEmpleao);
                    Console.WriteLine("Nombre: " + empleado.Nombre);
                    Console.WriteLine("ApellidoPaterno: " + empleado.ApellidoPaterno);
                    Console.WriteLine();

                }
                //ServiceReference.Service1Client obj = new ServiceReference.Service1Client();
                //var result1 = obj.GetAll(empleados);
                Console.WriteLine("La colsuta fue ejecutada correctamente ");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al ejeutar la consulta " + result.ErrorMessage);
            }
        }

    }
}
