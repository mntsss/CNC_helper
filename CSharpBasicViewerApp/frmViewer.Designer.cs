namespace CSharpBasicViewerApp
{
    partial class frmViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CodeTip = new System.Windows.Forms.ToolTip(this.components);
            this.rmbView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuFit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFence = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRotate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tblScreens = new System.Windows.Forms.TableLayoutPanel();
            this.MG_Viewer4 = new MacGen.MG_CS_BasicViewer();
            this.MG_Viewer3 = new MacGen.MG_CS_BasicViewer();
            this.MG_Viewer2 = new MacGen.MG_CS_BasicViewer();
            this.MG_Viewer1 = new MacGen.MG_CS_BasicViewer();
            this.rmbView.SuspendLayout();
            this.tblScreens.SuspendLayout();
            this.SuspendLayout();
            // 
            // CodeTip
            // 
            this.CodeTip.AutoPopDelay = 3000;
            this.CodeTip.InitialDelay = 0;
            this.CodeTip.IsBalloon = true;
            this.CodeTip.OwnerDraw = true;
            this.CodeTip.ReshowDelay = 100;
            this.CodeTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.CodeTip.ToolTipTitle = "G-code source";
            // 
            // rmbView
            // 
            this.rmbView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFit,
            this.mnuFence,
            this.mnuPan,
            this.mnuRotate,
            this.mnuZoom,
            this.mnuSelect});
            this.rmbView.Name = "rmbView";
            this.rmbView.Size = new System.Drawing.Size(109, 136);
            // 
            // mnuFit
            // 
            this.mnuFit.Image = global::CSharpBasicViewerApp.Properties.Resources.ViewFit;
            this.mnuFit.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.mnuFit.Name = "mnuFit";
            this.mnuFit.Size = new System.Drawing.Size(108, 22);
            this.mnuFit.Tag = "Fit";
            this.mnuFit.Text = "Fit";
            // 
            // mnuFence
            // 
            this.mnuFence.Image = global::CSharpBasicViewerApp.Properties.Resources.ViewFence;
            this.mnuFence.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.mnuFence.Name = "mnuFence";
            this.mnuFence.Size = new System.Drawing.Size(108, 22);
            this.mnuFence.Tag = "Fence";
            this.mnuFence.Text = "Fence";
            // 
            // mnuPan
            // 
            this.mnuPan.Image = global::CSharpBasicViewerApp.Properties.Resources.ViewPan;
            this.mnuPan.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.mnuPan.Name = "mnuPan";
            this.mnuPan.Size = new System.Drawing.Size(108, 22);
            this.mnuPan.Tag = "Pan";
            this.mnuPan.Text = "Pan";
            // 
            // mnuRotate
            // 
            this.mnuRotate.Image = global::CSharpBasicViewerApp.Properties.Resources.ViewRotate;
            this.mnuRotate.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.mnuRotate.Name = "mnuRotate";
            this.mnuRotate.Size = new System.Drawing.Size(108, 22);
            this.mnuRotate.Tag = "Rotate";
            this.mnuRotate.Text = "Rotate";
            // 
            // mnuZoom
            // 
            this.mnuZoom.Image = global::CSharpBasicViewerApp.Properties.Resources.ViewZoom;
            this.mnuZoom.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.mnuZoom.Name = "mnuZoom";
            this.mnuZoom.Size = new System.Drawing.Size(108, 22);
            this.mnuZoom.Tag = "Zoom";
            this.mnuZoom.Text = "Zoom";
            // 
            // mnuSelect
            // 
            this.mnuSelect.Image = global::CSharpBasicViewerApp.Properties.Resources._Select;
            this.mnuSelect.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.mnuSelect.Name = "mnuSelect";
            this.mnuSelect.Size = new System.Drawing.Size(108, 22);
            this.mnuSelect.Tag = "Select";
            this.mnuSelect.Text = "Select";
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.Title = "Open File";
            // 
            // tblScreens
            // 
            this.tblScreens.BackColor = System.Drawing.Color.Black;
            this.tblScreens.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblScreens.ColumnCount = 2;
            this.tblScreens.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblScreens.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblScreens.Controls.Add(this.MG_Viewer4, 1, 1);
            this.tblScreens.Controls.Add(this.MG_Viewer3, 0, 1);
            this.tblScreens.Controls.Add(this.MG_Viewer2, 1, 0);
            this.tblScreens.Controls.Add(this.MG_Viewer1, 0, 0);
            this.tblScreens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblScreens.Location = new System.Drawing.Point(0, 0);
            this.tblScreens.Margin = new System.Windows.Forms.Padding(0);
            this.tblScreens.Name = "tblScreens";
            this.tblScreens.RowCount = 2;
            this.tblScreens.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblScreens.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblScreens.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblScreens.Size = new System.Drawing.Size(480, 467);
            this.tblScreens.TabIndex = 8;
            // 
            // MG_Viewer4
            // 
            this.MG_Viewer4.AxisIndicatorScale = 0.75F;
            this.MG_Viewer4.BackColor = System.Drawing.Color.Black;
            this.MG_Viewer4.BreakPoint = -1;
            this.MG_Viewer4.ContextMenuStrip = this.rmbView;
            this.MG_Viewer4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MG_Viewer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MG_Viewer4.DynamicViewManipulation = true;
            this.MG_Viewer4.FourthAxis = 0F;
            this.MG_Viewer4.Location = new System.Drawing.Point(240, 234);
            this.MG_Viewer4.Margin = new System.Windows.Forms.Padding(0);
            this.MG_Viewer4.Name = "MG_Viewer4";
            this.MG_Viewer4.Pitch = 0F;
            this.MG_Viewer4.Roll = 0F;
            this.MG_Viewer4.RotaryType = MacGen.RotaryMotionType.BMC;
            this.MG_Viewer4.Size = new System.Drawing.Size(239, 232);
            this.MG_Viewer4.TabIndex = 3;
            this.MG_Viewer4.ViewManipMode = MacGen.MG_CS_BasicViewer.ManipMode.SELECTION;
            this.MG_Viewer4.Yaw = 0F;
            this.MG_Viewer4.Enter += new System.EventHandler(this.ViewportActivated);
            // 
            // MG_Viewer3
            // 
            this.MG_Viewer3.AxisIndicatorScale = 0.75F;
            this.MG_Viewer3.BackColor = System.Drawing.Color.Black;
            this.MG_Viewer3.BreakPoint = -1;
            this.MG_Viewer3.ContextMenuStrip = this.rmbView;
            this.MG_Viewer3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MG_Viewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MG_Viewer3.DynamicViewManipulation = true;
            this.MG_Viewer3.FourthAxis = 0F;
            this.MG_Viewer3.Location = new System.Drawing.Point(1, 234);
            this.MG_Viewer3.Margin = new System.Windows.Forms.Padding(0);
            this.MG_Viewer3.Name = "MG_Viewer3";
            this.MG_Viewer3.Pitch = 0F;
            this.MG_Viewer3.Roll = 0F;
            this.MG_Viewer3.RotaryType = MacGen.RotaryMotionType.BMC;
            this.MG_Viewer3.Size = new System.Drawing.Size(238, 232);
            this.MG_Viewer3.TabIndex = 2;
            this.MG_Viewer3.ViewManipMode = MacGen.MG_CS_BasicViewer.ManipMode.SELECTION;
            this.MG_Viewer3.Yaw = 0F;
            this.MG_Viewer3.Enter += new System.EventHandler(this.ViewportActivated);
            // 
            // MG_Viewer2
            // 
            this.MG_Viewer2.AxisIndicatorScale = 0.75F;
            this.MG_Viewer2.BackColor = System.Drawing.Color.Black;
            this.MG_Viewer2.BreakPoint = -1;
            this.MG_Viewer2.ContextMenuStrip = this.rmbView;
            this.MG_Viewer2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MG_Viewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MG_Viewer2.DynamicViewManipulation = true;
            this.MG_Viewer2.FourthAxis = 0F;
            this.MG_Viewer2.Location = new System.Drawing.Point(240, 1);
            this.MG_Viewer2.Margin = new System.Windows.Forms.Padding(0);
            this.MG_Viewer2.Name = "MG_Viewer2";
            this.MG_Viewer2.Pitch = 0F;
            this.MG_Viewer2.Roll = 0F;
            this.MG_Viewer2.RotaryType = MacGen.RotaryMotionType.BMC;
            this.MG_Viewer2.Size = new System.Drawing.Size(239, 232);
            this.MG_Viewer2.TabIndex = 1;
            this.MG_Viewer2.ViewManipMode = MacGen.MG_CS_BasicViewer.ManipMode.SELECTION;
            this.MG_Viewer2.Yaw = 0F;
            this.MG_Viewer2.Enter += new System.EventHandler(this.ViewportActivated);
            // 
            // MG_Viewer1
            // 
            this.MG_Viewer1.AxisIndicatorScale = 0.75F;
            this.MG_Viewer1.BackColor = System.Drawing.Color.Black;
            this.MG_Viewer1.BreakPoint = -1;
            this.MG_Viewer1.ContextMenuStrip = this.rmbView;
            this.MG_Viewer1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MG_Viewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MG_Viewer1.DynamicViewManipulation = true;
            this.MG_Viewer1.FourthAxis = 0F;
            this.MG_Viewer1.Location = new System.Drawing.Point(1, 1);
            this.MG_Viewer1.Margin = new System.Windows.Forms.Padding(0);
            this.MG_Viewer1.Name = "MG_Viewer1";
            this.MG_Viewer1.Pitch = 0F;
            this.MG_Viewer1.Roll = 0F;
            this.MG_Viewer1.RotaryType = MacGen.RotaryMotionType.BMC;
            this.MG_Viewer1.Size = new System.Drawing.Size(238, 232);
            this.MG_Viewer1.TabIndex = 0;
            this.MG_Viewer1.ViewManipMode = MacGen.MG_CS_BasicViewer.ManipMode.SELECTION;
            this.MG_Viewer1.Yaw = 0F;
            this.MG_Viewer1.Enter += new System.EventHandler(this.ViewportActivated);
            // 
            // frmViewer
            // 
            this.ClientSize = new System.Drawing.Size(680, 667);
            this.Controls.Add(this.tblScreens);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(68, 66);
            this.MinimumSize = new System.Drawing.Size(425, 225);
            this.Name = "frmViewer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.Tag = "";
            this.Text = "Graviravimo peržiūra";
            this.Load += new System.EventHandler(this.frmViewer_Load);
            this.rmbView.ResumeLayout(false);
            this.tblScreens.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ToolTip CodeTip;
        internal System.Windows.Forms.ContextMenuStrip rmbView;
        internal System.Windows.Forms.ToolStripMenuItem mnuFit;
        internal System.Windows.Forms.ToolStripMenuItem mnuFence;
        internal System.Windows.Forms.ToolStripMenuItem mnuPan;
        internal System.Windows.Forms.ToolStripMenuItem mnuRotate;
        internal System.Windows.Forms.ToolStripMenuItem mnuZoom;
        internal System.Windows.Forms.ToolStripMenuItem mnuSelect;
        internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        internal System.Windows.Forms.TableLayoutPanel tblScreens;
        internal MacGen.MG_CS_BasicViewer MG_Viewer4;
        internal MacGen.MG_CS_BasicViewer MG_Viewer3;
        internal MacGen.MG_CS_BasicViewer MG_Viewer2;
        internal MacGen.MG_CS_BasicViewer MG_Viewer1;
        
    }
}

