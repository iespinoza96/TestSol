using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            ML.Result result = BL.Empleado.GetAll();
            empleado.Empleados = result.Objects;

            return View(empleado);
        }

        [HttpGet]
        public ActionResult Form(int? IdEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();



            if (IdEmpleado == null)
            {
                ViewBag.Titulo = "Registrar Empleado";
                ViewBag.Accion = "Guardar";

                empleado.Area = new ML.Area();

                ML.Result resultArea = BL.Area.GetAll();
                empleado.Area = new ML.Area();
                empleado.Area.Areas = resultArea.Objects;
                return View(empleado);
            }
            else
            {
                ViewBag.Titulo = "Registrar Empleado";
                ViewBag.Accion = "Actualizar";




                empleado.IdEmpleao = IdEmpleado.Value;

                var result = BL.Empleado.GetById(IdEmpleado);


                if (result.Object != null)
                {

                    empleado.Area = new ML.Area();
                    empleado.IdEmpleao = ((ML.Empleado)result.Object).IdEmpleao;
                    empleado.Nombre = ((ML.Empleado)result.Object).Nombre;
                    empleado.ApellidoPaterno = ((ML.Empleado)result.Object).ApellidoPaterno;
                    empleado.ApellidoMaterno = ((ML.Empleado)result.Object).ApellidoMaterno;
                    empleado.Area.Nombre = ((ML.Empleado)result.Object).Area.Nombre;
                    empleado.FechaDeNacimiento = ((ML.Empleado)result.Object).FechaDeNacimiento;
                    empleado.Sueldo = ((ML.Empleado)result.Object).Sueldo;


                    ML.Result resultArea = BL.Area.GetAll();
                    empleado.Area = new ML.Area();
                    empleado.Area.Areas = resultArea.Objects;


                    return View(empleado);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return View("ValidationModal");
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            if (empleado.IdEmpleao == 0)
            {
                //ServiceReference3.Service1Client service = new ServiceReference3.Service1Client();
                //service.Add(empleado);

                result = BL.Empleado.AddEF(empleado);

                if (result.Correct == true)
                {
                    ViewBag.Message = "Se agrego el empleado correctamente";
                    return View("ValidationModal");
                }
                else
                {
                    ViewBag.Message = "Ocurrió un error al agregar el empleado.  Error: " + result.ErrorMessage;
                    return View("ValidationModal");
                }
            }
            else
            {
                //ServiceReference3.Service1Client service = new ServiceReference3.Service1Client();
                //service.Update(empleado);
                result = BL.Empleado.UpdateEF(empleado);

                if (result.Correct == true)
                {
                    ViewBag.Message = "Se actualizo correctamente el empleado ";
                    return View("ValidationModal");
                }
                else
                {
                    ViewBag.Message = "Ocurrió un error al actualizar el empleado.  Error: " + result.ErrorMessage;
                    return View("ValidationModal");
                }
            }

        }

        public ActionResult Delete(int? IdEmpleado)
        {
            //ML.Empleado empleado= new ML.Empleado();
            //ServiceReference3.Service1Client service = new ServiceReference3.Service1Client();
            //service.Delete(empleado);

            ML.Result result = BL.Empleado.DeleteEF(IdEmpleado);

            if (result.Correct == true)
            {
                ViewBag.Message = "Se elimino el empleado correctamente";
                return View("ValidationModal");
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al eliminar el empleado. Error: " + result.ErrorMessage;
            }
            return View("ValidationModal");
        }
    }
}