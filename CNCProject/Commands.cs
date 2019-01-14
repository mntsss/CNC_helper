using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace CNCProject
{
    public class Commands
    {
        Settings settings;

        public Commands(Settings s) {
            settings = s;
        }


        public void Move(Coo cord, ref List<GCode> gcode)
        {
            GCode g = new GCode("G0", cord.X, cord.Y);
            gcode.Add(g);
        }

        public void GoHome(ref List<GCode> gcode)
        {
            GoSafe(ref gcode);
            gcode.Add(new GCode("G28"));
        }

        public void SetMM(ref List<GCode> gcode)
        {
            gcode.Add(new GCode("G21"));
        }

        public void GoSafe(ref List<GCode> gcode)
        {
            GCode g = new GCode("G0", settings.SafeHeight);
            gcode.Add(g);
        }

        public void GoworkingHeight(ref List<GCode> gcode)
        {
            GCode g = new GCode("G1", settings.WorkingDepth);
            gcode.Add(g);
        }

        public void MoveNextCenter(ref List<GCode> gcode, int i, int j, double Yoffset)
        {
            gcode.Add(new GCode("(Einama i sekanti centra)"));
            GoSafe(ref gcode);
            Move(new Coo(i * settings.RangeBetweenCenters, j * settings.RangeBetweenCenters + Yoffset), ref gcode);
        }

        public List<GCode> LoadSymbolData(char c, double size = 1)
        {
            size /= 10;
            string dir = Environment.CurrentDirectory + "\\Symbols\\" + c + ".cnc";
            List<GCode> loaded = new List<GCode>();

            if (File.Exists(dir))
            {
                using (StreamReader reader = new StreamReader(dir))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(' ');



                        if (parts[0] == "G0" || parts[0] == "G1" || parts[0] == "G2" || parts[0] == "G3")
                        {
                            GCode g = new GCode();
                            g.Command = parts[0];
                            for (int i = 1; i < parts.Count(); i++)
                            {
                                if (parts[i][0] == 'X')
                                    g.X = Convert.ToDouble(parts[i].Replace("X", "")) * size;
                                if (parts[i][0] == 'Y')
                                    g.Y = Convert.ToDouble(parts[i].Replace("Y", "")) * size;
                                if (parts[i][0] == 'Z')
                                    g.Z = Convert.ToDouble(parts[i].Replace("Z", ""));
                                if (parts[i][0] == 'I')
                                    g.I = Convert.ToDouble(parts[i].Replace("I", "")) * size;
                                if (parts[i][0] == 'J')
                                    g.J = Convert.ToDouble(parts[i].Replace("J", "")) * size;
                            }
                            loaded.Add(g);
                        }
                    }
                }
            }
            else
            {

            }

            return loaded;
        }

        public bool CheckIFSymbolsExists(string text, out char ch)
        {
            foreach (char c in text)
            {
                string dir = Environment.CurrentDirectory + "\\Symbols\\" + c + ".cnc";

                if (!File.Exists(dir))
                {
                    ch = c;
                    return false;
                }
            }
            ch = '\0';
            return true;
        }

        public List<GCode> JoinSymbols(string text)
        {
            List<GCode> joinedSymbols = new List<GCode>();
            double lastXOffset = 0;
            for (int i = 0; i < text.Length; i++)
            {
                List<GCode> loadData = LoadSymbolData(text[i], settings.symbolSettings[text.Length - 1].charSize);

                double currentX = 0;
                double currentY = 0;

                if (i > 0)
                {
                    currentX = lastXOffset + settings.symbolSettings[text.Length-1].symbolsGap;
                }
                lastXOffset = -999;
                foreach (GCode g in loadData)
                {
                    if (g.X > -9999)
                    {
                        g.X += currentX;
                        if (g.X > lastXOffset)
                            lastXOffset = g.X;
                    }
                    if (g.I > -9999)
                    {
                        double radius = Math.Sqrt(Math.Pow(g.I, 2) + Math.Pow(g.J, 2)) / 2;
                        if (g.J == 0)
                        {
                            if (g.X > lastXOffset)
                                lastXOffset = g.X;
                        }
                        else
                            if ((g.X + radius * 2) > lastXOffset)
                                lastXOffset = g.X + radius * 2;

                    }
                }
                if (i < text.Length - 1)
                {
                    GoSafe(ref loadData);
                    loadData.Add(new GCode("G0", currentX, currentY));
                }
                


                joinedSymbols.AddRange(loadData);
            }
            GoSafe(ref joinedSymbols);
            joinedSymbols.Add(new GCode("G0", 0, 0 + settings.symbolSettings[text.Length - 1].underlineOffsetY));
            GoworkingHeight(ref joinedSymbols);
            joinedSymbols.Add(new GCode("G1", 0 + lastXOffset, 0 + settings.symbolSettings[text.Length - 1].underlineOffsetY));
                GoSafe(ref joinedSymbols);

            return joinedSymbols;
        }


        public double findFurthestX(List<GCode> joinedSymbols)
        {
            double x = -999;

            foreach (GCode g in joinedSymbols)
            {
                if (g.X > x)
                    x = g.X;
                if (g.I > -9999)
                {
                    double radius = Math.Sqrt(Math.Pow(g.I, 2) + Math.Pow(g.J, 2)) / 2;
                    if (g.Command == "G2")
                    {
                        if (g.X > x)
                            x = g.X;
                    }
                    if (g.Command == "G3")
                    {
                        if (g.J == 0)
                        {
                            if (g.X > x)
                                x = g.X;
                        }
                        else
                                if ((g.X + radius * 2) > x)
                            x = g.X + radius * 2;
                    }

                }
            }
            return x;
        }
        public void PaintSymbol(ref List<GCode> gcode, string text, double baseYOffset)
        {
            List<GCode> loadData = JoinSymbols(text);

            double xOffset = -findFurthestX(loadData)/2;

            double currentX;
            double currentY;

            if (gcode.Count > 4)
            {
                currentX = gcode.Last().X + xOffset;
                currentY = gcode.Last().Y + settings.symbolSettings[text.Length - 1].startY + baseYOffset;
            }
            else
            {
                currentX = xOffset;
                currentY = settings.symbolSettings[text.Length - 1].startY + baseYOffset;
            }
            

            foreach (GCode g in loadData)
            {
                if (g.X > -9999)
                {
                    g.X += currentX;

                }
                if (g.Y > -9999)
                {
                    g.Y += currentY;
                }
            }

            gcode.AddRange(loadData);
        }

        public void OutputGCode(List<GCode> gcode, string filepath)
        {
            using (StreamWriter writer = new StreamWriter(filepath))
            {
                foreach (GCode g in gcode)
                    writer.WriteLine(g.ToString());
            }
        }

        public void GraveCircle(ref List<GCode> gcode, int x, int y, double Yoffset)
        {
            gcode.Add(new GCode("G0", x * settings.RangeBetweenCenters - 5/settings.COOtoMMratio, y * settings.RangeBetweenCenters + Yoffset));
            GoworkingHeight(ref gcode);
            gcode.Add(new GCode("G3", x * settings.RangeBetweenCenters - 5 / settings.COOtoMMratio, y * settings.RangeBetweenCenters + Yoffset, 5 / settings.COOtoMMratio, 0));
            GoSafe(ref gcode);
            Move(new Coo(x * settings.RangeBetweenCenters, y * settings.RangeBetweenCenters + Yoffset), ref gcode);
        }
    }
}
