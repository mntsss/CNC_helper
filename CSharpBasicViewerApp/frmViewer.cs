using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using MacGen;
using System.IO;
namespace CSharpBasicViewerApp
{
public partial class frmViewer : Form 
{ 
    private string mCncFile; 
    private clsProcessor mProcessor = clsProcessor.Instance(); 
    private clsSettings mSetup = clsSettings.Instance(); 
    private MG_CS_BasicViewer mViewer; 
    
    public frmViewer(){
        InitializeComponent();
        mViewer = this.MG_Viewer1; 

        MG_CS_BasicViewer.OnStatus += new MG_CS_BasicViewer.OnStatusEventHandler(mViewer_OnStatus);
        
        mSetup.LoadAllMachines(System.IO.Directory.GetCurrentDirectory() + "\\Data");
        mProcessor.Init(mSetup.Machine);
    }

    private void frmViewer_Load(object sender, System.EventArgs e) 
    { 

        if (CSharpBasicViewerApp.Properties.Settings.Default.Virgin == true) { 
            this.StartPosition = FormStartPosition.CenterScreen; 
        } 
        else { 
            this.Location = CSharpBasicViewerApp.Properties.Settings.Default.ViewFormLocation; 
        } 

        OpenFile(System.IO.Directory.GetCurrentDirectory() + "\\Code.cnc");
        this.tblScreens.RowStyles[1].Height = 0;
        this.tblScreens.ColumnStyles[1].Width = 0;
        MG_Viewer2.Visible = false;
        MG_Viewer3.Visible = false;
        MG_Viewer4.Visible = false;

        } 
    
    private void frmViewer_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e) 
    {
            this.Dispose();
    } 
    
     private void OpenFile(string fileName) 
    { 
        long[] ticks = new long[2]; 
        mCncFile = fileName; 
        mSetup.MatchMachineToFile(mCncFile); 
        
        ProcessFile(mCncFile); 
        mViewer.BreakPoint = MG_CS_BasicViewer.MotionBlocks.Count - 1; 
        
        mViewer.Pitch = mSetup.Machine.ViewAngles[0]; 
        mViewer.Roll = mSetup.Machine.ViewAngles[1]; 
        mViewer.Yaw = mSetup.Machine.ViewAngles[2]; 
        mViewer.Init(); 
        
        ticks[0] = DateTime.Now.Ticks; 
        MG_Viewer1.FindExtents(); 
        ticks[1] = DateTime.Now.Ticks; 
        MG_Viewer1.DynamicViewManipulation = (ticks[1] - ticks[0]) < 2000000; 
        MG_Viewer2.FindExtents(); 
        MG_Viewer3.FindExtents(); 
        MG_Viewer4.FindExtents(); 
        mViewer.Redraw(true); 
    } 
    
    
    private void ProcessFile(string fileName) 
    { 
        if (fileName == null) { 
            return; 
        } 
        MG_CS_BasicViewer.MotionBlocks.Clear(); 
        mProcessor.Init(mSetup.Machine); 
        mProcessor.ProcessFile(fileName, MG_CS_BasicViewer.MotionBlocks); 
        
        if (mViewer.BreakPoint > MG_CS_BasicViewer.MotionBlocks.Count - 1) { 
            mViewer.BreakPoint = MG_CS_BasicViewer.MotionBlocks.Count - 1; 
        } 
        mViewer.GatherTools(); 
        
    } 

     
    private void ViewportActivated(object sender, System.EventArgs e) 
    { 
        mViewer = (MG_CS_BasicViewer)sender; 
    } 
    
    private void SetDefaultViews() 
    { 
        //Case "Top" 
        MG_Viewer1.Pitch = 0f; 
        MG_Viewer1.Roll = 0f; 
        MG_Viewer1.Yaw = 0f; 
        MG_Viewer1.FindExtents(); 
        //Case "Front" 
        MG_Viewer3.Pitch = 270f; 
        MG_Viewer3.Roll = 0f; 
        MG_Viewer3.Yaw = 360f; 
        MG_Viewer3.FindExtents(); 
        
        //Case "Right" 
        MG_Viewer4.Pitch = 270f; 
        MG_Viewer4.Roll = 0f; 
        MG_Viewer4.Yaw = 270f; 
        MG_Viewer4.FindExtents(); 
        
        //Case "ISO" 
        MG_Viewer2.Pitch = 315f; 
        MG_Viewer2.Roll = 0f; 
        MG_Viewer2.Yaw = 315f; 
        MG_Viewer2.FindExtents(); 
        mViewer.Redraw(true); 
    } 
        
    private void mViewer_OnStatus(string msg, int index, int max) 
    { 

    } 
      
    private void mSetup_MachineActivated(clsMachine m) 
    { 
        { 
            MG_Viewer1.RotaryDirection = (RotaryDirection)m.RotaryDir; 
            MG_Viewer1.RotaryPlane = (Axis)m.RotaryAxis; 
            MG_Viewer1.RotaryType = (RotaryMotionType)m.RotaryType; 
            MG_Viewer1.ViewManipMode = MG_CS_BasicViewer.ManipMode.SELECTION;
            
            MG_Viewer1.FindExtents();
            MG_Viewer2.FindExtents();
            MG_Viewer3.FindExtents();
            MG_Viewer4.FindExtents();
            mViewer.Redraw(true);

        } 
    } 
    
 
   /* private void ScreensClicked(object sender, EventArgs e)
    {

        {
            switch (((ToolStripMenuItem)sender).Tag.ToString())
            {
                case "1":
                    this.tblScreens.RowStyles[1].Height = 0;
                    this.tblScreens.ColumnStyles[1].Width = 0;
                    MG_Viewer2.Visible = false;
                    MG_Viewer3.Visible = false;
                    MG_Viewer4.Visible = false;
                    break;
                case "2":
                    this.tblScreens.RowStyles[1].Height = 0;
                    this.tblScreens.ColumnStyles[1].Width = 50;
                    MG_Viewer2.Visible = true;
                    MG_Viewer3.Visible = false;
                    MG_Viewer4.Visible = false;
                    break;
                case "4":
                    this.tblScreens.RowStyles[1].Height = 50;
                    this.tblScreens.ColumnStyles[1].Width = 50;
                    MG_Viewer2.Visible = true;
                    MG_Viewer3.Visible = true;
                    MG_Viewer4.Visible = true;
                    break;
            }
            SetDefaultViews();
        } 
    }*/
   } 
}