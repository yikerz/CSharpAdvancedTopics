using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    public interface IShape
    {
        // all methods inside interface should be empty
        double CalculateArea();
        double CalculatePerimeter();
    }
}
