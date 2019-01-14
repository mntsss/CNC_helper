using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCProject
{
    public class GCode : Coo
    {
        public string Command { get; set; }


        public GCode() { }
        public GCode(string c, double x, double y) : base (x, y)
        {
            Command = c;
        }
        public GCode(string c, double x, double y, double i, double j) : base(x, y, i, j)
        {
            Command = c;
        }
        
        public GCode(string c) : base()
        {
            Command = c;
        }
        public GCode(string c, double z) : base(z)
        {
            Command = c;
        }

        public override string ToString()
        {
            if (X > -9999 && Y > -9999 && Z == -9999 && I == -9999 && J == -9999)
                return String.Format("{0} X{1:0.0000000} Y{2:0.0000000}", Command, X, Y);
            else if (X > -9999 && Y > -9999 && I > -9999 && J > -9999)
                return String.Format("{0} X{1:0.0000000} Y{2:0.0000000} I{3:0.0000000} J{4:0.0000000}", Command, X, Y, I, J);
            else if (X > -9999 && Y > -9999 && Z > -9999 && I == -9999 && J == -9999)
                return String.Format("{0} X{1:0.0000000} Y{2:0.0000000} Z{3:0.0000000}", Command, X, Y, Z);
            else if (Z > -9999)
                return String.Format("{0} Z{1:0.0000000}", Command, Z);
            else
                return String.Format("{0}", Command);
        }

    }
}
