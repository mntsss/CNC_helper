using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace CNCProject
{
    public partial class Main : Form
    {
        public Commands commands;
        public Settings settings;

        public Main()
        {
            InitializeComponent();

            settings = new Settings();
            commands = new Commands(settings);
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            int tabIndex = 0;

            List<GCode> gcode = new List<GCode>();

            commands.GoHome(ref gcode);
            for (int x = 0; x <= 9; x++)
            {
                for (int y = 0; y <= 3; y++)
                {
                    
                    //Textboxo tekstas
                    string text = Controls.GetElementTextByTabIndex(tabIndex);
                    text = text.ToUpper();

                    if (checkBoxCircles.Checked)
                        commands.GraveCircle(ref gcode, x, y, 0);
                    if (text.Length > 0)
                    {
                        commands.MoveNextCenter(ref gcode, x, y, 0);
                        char c;
                        if (!commands.CheckIFSymbolsExists(text, out c))
                        {
                            MessageBox.Show("Klaida: simbolis " + c + " nėra graviravimo simbolių sąraše ir negali būti graviruojamas.");
                            return;
                        }
                        for(int i = 0; i<settings.Loops; i++)
                        {
                            commands.PaintSymbol(ref gcode, text, 0);
                            commands.MoveNextCenter(ref gcode, x, y, 0);
                        }
                    }

                    

                    tabIndex++;
                }
            }
            for (int x = 0; x <= 9; x++)
            {
                for (int y = 0; y <= 3; y++)
                {

                    //Textboxo tekstas
                    string text = Controls.GetElementTextByTabIndex(tabIndex);
                    text = text.ToUpper();

                    if (checkBoxCircles.Checked)
                        commands.GraveCircle(ref gcode, x, y, settings.SecondBaseStart);
                    if (text.Length > 0)
                    {
                        commands.MoveNextCenter(ref gcode, x, y, settings.SecondBaseStart);
                        char c;
                        if (!commands.CheckIFSymbolsExists(text, out c))
                        {
                            MessageBox.Show("Klaida: simbolis " + c + " nėra graviravimo simbolių sąraše ir negali būti graviruojamas.");
                            return;
                        }
                        for (int i = 0; i < settings.Loops; i++)
                        {
                            commands.PaintSymbol(ref gcode, text, 0);
                            commands.MoveNextCenter(ref gcode, x, y, settings.SecondBaseStart);
                        }
                    }



                    tabIndex++;
                }
            }
            commands.GoSafe(ref gcode);
            commands.Move(new Coo(settings.startX, settings.FinishY), ref gcode);
            commands.OutputGCode(gcode, "Code.cnc");
            MessageBox.Show("Kodas išsaugotas į failą Code.cnc .");

            System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\Code.cnc");

        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Green, 2);
            for (int x = 0; x <= 9; x++)
            {
                for (int y = 0; y <= 7; y++)
                {
                    if (Controls.ContainsKey("textBox" + x.ToString() + "x" + y.ToString() + "y"))
                    {
                        TextBox tBox = (TextBox)Controls["textBox" + x.ToString() + "x" + y.ToString() + "y"];
                        int tbX = tBox.Location.X;
                        int tbY = tBox.Location.Y;
                        
                        
                        g.DrawCircle(p, tbX+ tBox.Size.Width / 2, tbY+ tBox.Size.Height / 2, 4+tBox.Size.Width/2);

                    }
                }
            }
            
        }

        private void nustatymaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm(settings);
            form.ShowDialog();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

    }

    public static class MyExtensions
    {
        public static string GetElementTextByTabIndex(this Control.ControlCollection controls, int index)
        {
            return controls.OfType<Control>()
                           .Where(c => c.TabIndex == index)
                           .Select(c => c.Text).First();
        }
    }

    public static class GraphicsExtensions
    {
        public static void DrawCircle(this Graphics g, Pen pen,
                                      float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }

        public static void FillCircle(this Graphics g, Brush brush,
                                      float centerX, float centerY, float radius)
        {
            g.FillEllipse(brush, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }
    }
}
