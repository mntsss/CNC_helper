using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CNCProject
{
    public class Settings
    {
        public double startX;
        public double startY;

        public double COOtoMMratio;
        public double centersGap;
        public double RangeBetweenCenters;

        public double SafeHeight;
        public double WorkingDepth;

        public int Loops;

        public double BasesSpace;

        public double SecondBaseStart;

        public double FinishY;

        public SymbolSettings [] symbolSettings = { new SymbolSettings(), new SymbolSettings(), new SymbolSettings()};

        public Settings()
        {
            ReadParameters();
            RangeBetweenCenters = centersGap / COOtoMMratio;
            SecondBaseStart = BasesSpace;
        }


        public void ReadParameters()
        {
            string line;
            using (StreamReader reader = new StreamReader("settings.ini"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(' ');

                    if (data[0] == "AbsoluteStartX")
                    {
                        startX = Convert.ToDouble(data[2]);
                    }
                    if (data[0] == "AbsoluteStartY")
                    {
                        startY = Convert.ToDouble(data[2]);
                    }
                    if (data[0] == "CoordinatesToMMRatio")
                    {
                        COOtoMMratio = Convert.ToDouble(data[2]);
                    }
                    if (data[0] == "CentersGapinMM")
                    {
                        centersGap = Convert.ToDouble(data[2]);
                    }
                    if (data[0] == "SafeHeight")
                    {
                        SafeHeight = Convert.ToDouble(data[2]);
                    }
                    if (data[0] == "WorkingDepth")
                    {
                        WorkingDepth = Convert.ToDouble(data[2]);
                    }
                    if (data[0] == "Loops")
                    {
                        Loops = Convert.ToInt32(data[2]);
                    }
                    if (data[0] == "SpaceBetweenBases")
                    {
                        BasesSpace = Convert.ToDouble(data[2]);
                    }
                    if (data[0] == "FinishYOffset")
                    {
                        FinishY = Convert.ToDouble(data[2]);
                    }
                    if (data[0] == "OneSymbolSize")
                    {
                        symbolSettings[0].charSize = Convert.ToDouble(data[2]);
                    }
                    if (data[0] == "OneSymbolUnderlineOffsetY")
                    {
                        symbolSettings[0].underlineOffsetY = Convert.ToDouble(data[2]);
                    }
                    if (data[0] == "OneSymbolStartY")
                    {
                        symbolSettings[0].startY = Convert.ToDouble(data[2]);
                    }
                    if (data[0] == "OneSymbolGap")
                    {
                        symbolSettings[0].symbolsGap = Convert.ToDouble(data[2]);
                    }
                    if (data[0] == "TwoSymbolsSize")
                    {
                        symbolSettings[1].charSize = Convert.ToDouble(data[2]);
                    }
                        if (data[0] == "TwoSymbolsUnderlineOffsetY")
                    {
                        symbolSettings[1].underlineOffsetY = Convert.ToDouble(data[2]);
                    }
                    if (data[0] == "TwoSymbolsStartY")
                    {
                        symbolSettings[1].startY = Convert.ToDouble(data[2]);
                    }
                    if (data[0] == "TwoSymbolsGap")
                    {
                        symbolSettings[1].symbolsGap = Convert.ToDouble(data[2]);
                    }
                    if (data[0] == "ThreeSymbolsSize")
                    {
                        symbolSettings[2].charSize = Convert.ToDouble(data[2]);
                    }
                    if (data[0] == "ThreeSymbolsUnderlineOffsetY")
                    {
                        symbolSettings[2].underlineOffsetY = Convert.ToDouble(data[2]);
                    }
                    if (data[0] == "ThreeSymbolsStartY")
                    {
                        symbolSettings[2].startY = Convert.ToDouble(data[2]);
                    }
                    if (data[0] == "ThreeSymbolsGap")
                    {
                        symbolSettings[2].symbolsGap = Convert.ToDouble(data[2]);
                    }
                }
            }
        }

        public class SymbolSettings
        {
            public double underlineOffsetY;

            public double charSize;
            public double startY;

            public double symbolsGap;
        }
    }
}
