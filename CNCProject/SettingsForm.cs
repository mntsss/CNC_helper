using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CNCProject
{
    public partial class SettingsForm : Form
    {
        Settings settings { get; set; }

        public SettingsForm(Settings s)
        {
            settings = s;
            InitializeComponent();
            numericUpDownAbsoluteX.Value = Convert.ToDecimal(s.startX);
            numericUpDownAbsoluteY.Value = Convert.ToDecimal(s.startY);
            numericUpDownCentersGap.Value = Convert.ToDecimal(s.centersGap);
            numericUpDownCooToMM.Value = Convert.ToDecimal(s.COOtoMMratio);
            numericUpDownSafe.Value = Convert.ToDecimal(s.SafeHeight);
            numericUpDownWorking.Value = Convert.ToDecimal(s.WorkingDepth);
            numericUpDownLoops.Value = Convert.ToDecimal(s.Loops);
            numericUpDownSpaceBases.Value = Convert.ToDecimal(s.BasesSpace);

            numericUpDown1LineY.Value = Convert.ToDecimal(s.symbolSettings[0].underlineOffsetY);
            numericUpDown1Size.Value = Convert.ToDecimal(s.symbolSettings[0].charSize);
            numericUpDown1SymbY.Value = Convert.ToDecimal(s.symbolSettings[0].startY);
            numericUpDown1Space.Value = Convert.ToDecimal(s.symbolSettings[0].symbolsGap);

            numericUpDown2LineY.Value = Convert.ToDecimal(s.symbolSettings[1].underlineOffsetY);
            numericUpDown2Size.Value = Convert.ToDecimal(s.symbolSettings[1].charSize);
            numericUpDown2SymbY.Value = Convert.ToDecimal(s.symbolSettings[1].startY);
            numericUpDown2Space.Value = Convert.ToDecimal(s.symbolSettings[1].symbolsGap);

            numericUpDown3LineY.Value = Convert.ToDecimal(s.symbolSettings[2].underlineOffsetY);
            numericUpDown3Size.Value = Convert.ToDecimal(s.symbolSettings[2].charSize);
            numericUpDown3SymbY.Value = Convert.ToDecimal(s.symbolSettings[2].startY);
            numericUpDown3Space.Value = Convert.ToDecimal(s.symbolSettings[2].symbolsGap);

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("settings.ini"))
            {
                writer.WriteLine("AbsoluteStartX = " + numericUpDownAbsoluteX.Value);
                writer.WriteLine("AbsoluteStartY = " + numericUpDownAbsoluteY.Value);
                writer.WriteLine("CoordinatesToMMRatio = " + numericUpDownCooToMM.Value);
                writer.WriteLine("CentersGapinMM = " + numericUpDownCentersGap.Value);
                writer.WriteLine("SafeHeight = " + numericUpDownSafe.Value);
                writer.WriteLine("WorkingDepth = " + numericUpDownWorking.Value);
                writer.WriteLine("Loops = " + numericUpDownLoops.Value);
                writer.WriteLine("SpaceBetweenBases = " + numericUpDownSpaceBases.Value);
                writer.WriteLine("FinishYOffset = " + settings.FinishY);

                writer.WriteLine("OneSymbolSize = " + numericUpDown1Size.Value);
                writer.WriteLine("OneSymbolUnderlineOffsetY = " + numericUpDown1LineY.Value);
                writer.WriteLine("OneSymbolStartY = " + numericUpDown1SymbY.Value);
                writer.WriteLine("OneSymbolGap = " + numericUpDown1Space.Value);

                writer.WriteLine("TwoSymbolsSize = " + numericUpDown2Size.Value);
                writer.WriteLine("TwoSymbolsUnderlineOffsetY = " + numericUpDown2LineY.Value);
                writer.WriteLine("TwoSymbolsStartY = " + numericUpDown2SymbY.Value);
                writer.WriteLine("TwoSymbolsGap = " + numericUpDown2Space.Value);

                writer.WriteLine("ThreeSymbolsSize = " + numericUpDown3Size.Value);
                writer.WriteLine("ThreeSymbolsUnderlineOffsetY = " + numericUpDown3LineY.Value);
                writer.WriteLine("ThreeSymbolsStartY = " + numericUpDown3SymbY.Value);
                writer.WriteLine("ThreeSymbolsGap = " + numericUpDown3Space.Value);

                MessageBox.Show("Nustatymai išsaugoti sėkmingai. Pakeitimams suaktyvinti įjunkite programą iš naujo.");
                Application.Exit();

            }
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
