using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
       //public SL.Result Add(ML.Empleado empleado)
       //{
       //    var result= BL.Empleado.AddEF(empleado);

       //    return new SL.Result{ Correct=result.Correct, ErrorMessage=result.ErrorMessage, Ex=result.Ex};
       //}

        public string Saludar(string nombre)
        {
            return nombre;
        }

        public Result Add(ML.Empleado empleado)
        {

            ML.Result result = BL.Empleado.AddEF(empleado);

            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };
        }

        public Result Update(ML.Empleado empleado)
        {

            ML.Result result = BL.Empleado.UpdateEF(empleado);

            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };
        }


        public Result Delete(ML.Empleado empleado)
        {

            ML.Result result = BL.Empleado.DeleteEF(empleado.IdEmpleao);

            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };
        }
    }
}
