using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCProject
{
    public class Coo
    {
        public double X { get; set; } // X asis
        public double Y { get; set; } // Y asis
        public double Z { get; set; } // Z asis
        public double I { get; set; } // Braizant arka releatyvus nuotolis nuo X asies
        public double J { get; set; } // Braizant arka releatyvus nuotolis nuo Y asies


        public Coo() {
            Z = -9999;
            X = -9999;
            Y = -9999;
            I = -9999;
            J = -9999;
        }
        public Coo(double x, double y)
        {
            X = x;
            Y = y;
            Z = -9999;
            I = -9999;
            J = -9999;
        }

        public Coo(double x, double y, double i, double j)
        {
            X = x;
            Y = y;
            I = i;
            J = j;
            Z = -9999;
        }
        public Coo(double z)
        {
            Z = z;
            X = -9999;
            Y = -9999;
            I = -9999;
            J = -9999;
        }

    }
}
