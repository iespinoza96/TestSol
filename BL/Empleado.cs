using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.TestSolEntities context = new DL.TestSolEntities())
                {

                    var query = context.EmpleadoGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.IdEmpleao = obj.IdEmpleado;
                            empleado.Nombre = obj.Nombre;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;
                            empleado.Area = new ML.Area();
                            empleado.Area.IdArea = Convert.ToInt32(obj.IdArea);
                            empleado.Area.Nombre = obj.NombreArea;
                            empleado.AreaNombre = obj.NombreArea;
                            empleado.FechaDeNacimiento = Convert.ToDateTime(obj.FechaDeNacimiento);
                            empleado.Sueldo = Convert.ToInt32(obj.Sueldo);

                            result.Objects.Add(empleado);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result AddEF(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();


            try
            {
                using (DL.TestSolEntities context = new DL.TestSolEntities())
                {
                    var query = context.EmpleadoAdd(empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Area.IdArea,
                        empleado.FechaDeNacimiento, empleado.Sueldo);


                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result UpdateEF(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL.TestSolEntities context = new DL.TestSolEntities())
                {
                    var updateResult = context.EmpleadoUpdate(empleado.IdEmpleao, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno,
                        empleado.Area.IdArea, empleado.FechaDeNacimiento, empleado.Sueldo);

                    if (updateResult >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó el status de la credencial";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result GetById(int? IdEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.TestSolEntities context = new DL.TestSolEntities())
                {
                    var query = context.EmpleadoGetById(IdEmpleado).FirstOrDefault();

                    if (query != null)
                    {

                        ML.Empleado empleados = new ML.Empleado();
                        empleados.IdEmpleao = query.IdEmpleado;
                        empleados.Nombre = query.Nombre;
                        empleados.ApellidoPaterno = query.ApellidoPaterno;
                        empleados.ApellidoMaterno = query.ApellidoMaterno;
                        empleados.Area = new ML.Area();
                        empleados.Area.IdArea = Convert.ToInt32(query.IdArea);
                        empleados.Area.Nombre = query.NombreArea;
                        empleados.FechaDeNacimiento = Convert.ToDateTime(query.FechaDeNacimiento);
                        empleados.Sueldo = Convert.ToInt32(query.Sueldo);

                        result.Object = empleados;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }

        public static ML.Result DeleteEF(int? IdEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.TestSolEntities context = new DL.TestSolEntities())
                {

                    var query = context.EmpleadoDelete(IdEmpleado);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se eliminó el registro";
                    }

                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}
