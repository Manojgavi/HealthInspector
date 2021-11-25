using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthInspector.IControllerServices;

namespace HealthInspector.ControllerServices
{
    public class BmiServices : IBmiServices
    {

      


        public double Calculator(double height, double weight)
        {

                double bmi = weight / (height * height);

                return bmi;

            }
    }
}
