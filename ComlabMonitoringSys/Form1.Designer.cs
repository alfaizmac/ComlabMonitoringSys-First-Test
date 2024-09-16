namespace ComlabMonitoringSys
{
    partial class Form1
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.rjButton2 = new Button_round_corner.RJButton();
            this.rjButton3 = new Button_round_corner.RJButton();
            this.rjTextBox1 = new Roundtextbox.RJTextBox();
            this.PassCharTimer = new System.Windows.Forms.Timer(this.components);
            this.AutoShutdownTimer = new System.Windows.Forms.Timer(this.components);
            this.CloseOtherAppTimer = new System.Windows.Forms.Timer(this.components);
            this.WelcomePanel = new System.Windows.Forms.Panel();
            this.UserEye = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.UserLoginButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.UserTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonSpecAny2 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.PassTextBox2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonSpecAny1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.PassTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.WelcomePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 200;
            this.toolTip1.IsBalloon = true;
            // 
            // rjButton2
            // 
            this.rjButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rjButton2.BackColor = System.Drawing.Color.Transparent;
            this.rjButton2.FlatAppearance.BorderSize = 0;
            this.rjButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton2.ForeColor = System.Drawing.Color.White;
            this.rjButton2.Image = global::ComlabMonitoringSys.Properties.Resources.power__1_;
            this.rjButton2.Location = new System.Drawing.Point(1833, 970);
            this.rjButton2.Name = "rjButton2";
            this.rjButton2.Size = new System.Drawing.Size(58, 56);
            this.rjButton2.TabIndex = 7;
            this.toolTip1.SetToolTip(this.rjButton2, "Shut down");
            this.rjButton2.UseVisualStyleBackColor = false;
            this.rjButton2.Click += new System.EventHandler(this.rjButton2_Click);
            // 
            // rjButton3
            // 
            this.rjButton3.BackColor = System.Drawing.Color.Transparent;
            this.rjButton3.FlatAppearance.BorderSize = 0;
            this.rjButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton3.ForeColor = System.Drawing.Color.Transparent;
            this.rjButton3.Image = global::ComlabMonitoringSys.Properties.Resources.admin__1_;
            this.rjButton3.Location = new System.Drawing.Point(1845, 12);
            this.rjButton3.Name = "rjButton3";
            this.rjButton3.Size = new System.Drawing.Size(47, 46);
            this.rjButton3.TabIndex = 5;
            this.toolTip1.SetToolTip(this.rjButton3, "Login as an Admin.");
            this.rjButton3.UseVisualStyleBackColor = false;
            this.rjButton3.Click += new System.EventHandler(this.rjButton3_Click);
            // 
            // rjTextBox1
            // 
            this.rjTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.rjTextBox1.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.rjTextBox1.BorderFocusColor = System.Drawing.Color.Red;
            this.rjTextBox1.BorderRadius = 0;
            this.rjTextBox1.BorderSize = 2;
            this.rjTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjTextBox1.Location = new System.Drawing.Point(0, 0);
            this.rjTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.rjTextBox1.Multiline = false;
            this.rjTextBox1.Name = "rjTextBox1";
            this.rjTextBox1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.rjTextBox1.PasswordChar = false;
            this.rjTextBox1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.rjTextBox1.PlaceholderText = "";
            this.rjTextBox1.Size = new System.Drawing.Size(250, 30);
            this.rjTextBox1.TabIndex = 0;
            this.rjTextBox1.Texts = "";
            this.rjTextBox1.UnderlinedSty1e = false;
            // 
            // PassCharTimer
            // 
            this.PassCharTimer.Enabled = true;
            this.PassCharTimer.Interval = 500;
            this.PassCharTimer.Tick += new System.EventHandler(this.PassCharTImer_Tick);
            // 
            // AutoShutdownTimer
            // 
            this.AutoShutdownTimer.Interval = 300000;
            this.AutoShutdownTimer.Tick += new System.EventHandler(this.AutoShutdownTimer_Tick);
            // 
            // CloseOtherAppTimer
            // 
            this.CloseOtherAppTimer.Interval = 5000;
            this.CloseOtherAppTimer.Tick += new System.EventHandler(this.CloseOtherAppTimer_Tick);
            // 
            // WelcomePanel
            // 
            this.WelcomePanel.AutoScroll = true;
            this.WelcomePanel.AutoScrollMinSize = new System.Drawing.Size(10, 10);
            this.WelcomePanel.BackColor = System.Drawing.Color.Transparent;
            this.WelcomePanel.BackgroundImage = global::ComlabMonitoringSys.Properties.Resources.LoginUser;
            this.WelcomePanel.Controls.Add(this.label3);
            this.WelcomePanel.Controls.Add(this.label2);
            this.WelcomePanel.Controls.Add(this.UserEye);
            this.WelcomePanel.Controls.Add(this.UserLoginButton);
            this.WelcomePanel.Controls.Add(this.UserTextBox);
            this.WelcomePanel.Controls.Add(this.label1);
            this.WelcomePanel.Controls.Add(this.rjButton2);
            this.WelcomePanel.Controls.Add(this.rjButton3);
            this.WelcomePanel.Controls.Add(this.pictureBox2);
            this.WelcomePanel.Controls.Add(this.linkLabel1);
            this.WelcomePanel.Controls.Add(this.pictureBox3);
            this.WelcomePanel.Controls.Add(this.PassTextBox2);
            this.WelcomePanel.Controls.Add(this.PassTextBox1);
            this.WelcomePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WelcomePanel.Location = new System.Drawing.Point(0, 0);
            this.WelcomePanel.Name = "WelcomePanel";
            this.WelcomePanel.Size = new System.Drawing.Size(1904, 1041);
            this.WelcomePanel.TabIndex = 0;
            // 
            // UserEye
            // 
            this.UserEye.Location = new System.Drawing.Point(1548, 602);
            this.UserEye.Name = "UserEye";
            this.UserEye.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.UserEye.OverrideDefault.Back.Color2 = System.Drawing.Color.Gainsboro;
            this.UserEye.OverrideDefault.Back.ColorAngle = 0F;
            this.UserEye.OverrideDefault.Border.Color1 = System.Drawing.Color.Gainsboro;
            this.UserEye.OverrideDefault.Border.Color2 = System.Drawing.Color.Gainsboro;
            this.UserEye.OverrideDefault.Border.ColorAngle = 0F;
            this.UserEye.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.UserEye.OverrideDefault.Border.Rounding = 0;
            this.UserEye.OverrideDefault.Content.Padding = new System.Windows.Forms.Padding(1);
            this.UserEye.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.UserEye.OverrideFocus.Back.Color2 = System.Drawing.Color.Gainsboro;
            this.UserEye.OverrideFocus.Back.ColorAngle = 0F;
            this.UserEye.OverrideFocus.Border.Color1 = System.Drawing.Color.Gainsboro;
            this.UserEye.OverrideFocus.Border.Color2 = System.Drawing.Color.Gainsboro;
            this.UserEye.OverrideFocus.Border.ColorAngle = 0F;
            this.UserEye.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.UserEye.OverrideFocus.Border.Rounding = 0;
            this.UserEye.Size = new System.Drawing.Size(20, 16);
            this.UserEye.StateCommon.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.UserEye.StateCommon.Back.Color2 = System.Drawing.Color.Gainsboro;
            this.UserEye.StateCommon.Back.ColorAngle = 0F;
            this.UserEye.StateCommon.Back.Image = global::ComlabMonitoringSys.Properties.Resources.eye__1_;
            this.UserEye.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.UserEye.StateCommon.Border.Color1 = System.Drawing.Color.Gainsboro;
            this.UserEye.StateCommon.Border.Color2 = System.Drawing.Color.LightGray;
            this.UserEye.StateCommon.Border.ColorAngle = 0F;
            this.UserEye.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.UserEye.StateCommon.Border.Rounding = 0;
            this.UserEye.StateCommon.Border.Width = 0;
            this.UserEye.StateNormal.Border.Color1 = System.Drawing.Color.Gainsboro;
            this.UserEye.StateNormal.Border.Color2 = System.Drawing.Color.Gainsboro;
            this.UserEye.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.UserEye.StateNormal.Border.Rounding = 0;
            this.UserEye.StatePressed.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.UserEye.StatePressed.Back.Color2 = System.Drawing.Color.Gainsboro;
            this.UserEye.StatePressed.Border.Color1 = System.Drawing.Color.Gainsboro;
            this.UserEye.StatePressed.Border.Color2 = System.Drawing.Color.Gainsboro;
            this.UserEye.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.UserEye.StatePressed.Border.Rounding = 0;
            this.UserEye.StateTracking.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.UserEye.StateTracking.Back.Color2 = System.Drawing.Color.Gainsboro;
            this.UserEye.StateTracking.Back.ColorAngle = 0F;
            this.UserEye.StateTracking.Border.Color1 = System.Drawing.Color.Gainsboro;
            this.UserEye.StateTracking.Border.Color2 = System.Drawing.Color.Gainsboro;
            this.UserEye.StateTracking.Border.ColorAngle = 0F;
            this.UserEye.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.UserEye.StateTracking.Border.Rounding = 0;
            this.UserEye.StateTracking.Border.Width = -3;
            this.UserEye.TabIndex = 27;
            this.UserEye.TabStop = false;
            this.UserEye.Values.Text = "";
            this.UserEye.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kryptonButton2_MouseDown);
            this.UserEye.MouseUp += new System.Windows.Forms.MouseEventHandler(this.kryptonButton2_MouseUp);
            // 
            // UserLoginButton
            // 
            this.UserLoginButton.Location = new System.Drawing.Point(1366, 695);
            this.UserLoginButton.Name = "UserLoginButton";
            this.UserLoginButton.OverrideDefault.Back.Color1 = System.Drawing.Color.Maroon;
            this.UserLoginButton.OverrideDefault.Back.Color2 = System.Drawing.Color.Maroon;
            this.UserLoginButton.OverrideDefault.Border.Color1 = System.Drawing.Color.Red;
            this.UserLoginButton.OverrideDefault.Border.Color2 = System.Drawing.Color.Red;
            this.UserLoginButton.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.UserLoginButton.OverrideDefault.Border.Rounding = 15;
            this.UserLoginButton.OverrideDefault.Border.Width = 3;
            this.UserLoginButton.OverrideFocus.Border.Color1 = System.Drawing.Color.Red;
            this.UserLoginButton.OverrideFocus.Border.Color2 = System.Drawing.Color.Red;
            this.UserLoginButton.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.UserLoginButton.OverrideFocus.Border.Width = 3;
            this.UserLoginButton.Size = new System.Drawing.Size(150, 40);
            this.UserLoginButton.StateCommon.Back.Color1 = System.Drawing.Color.Maroon;
            this.UserLoginButton.StateCommon.Back.Color2 = System.Drawing.Color.Maroon;
            this.UserLoginButton.StateCommon.Border.Color1 = System.Drawing.Color.Maroon;
            this.UserLoginButton.StateCommon.Border.Color2 = System.Drawing.Color.Maroon;
            this.UserLoginButton.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.UserLoginButton.StateCommon.Border.Rounding = 15;
            this.UserLoginButton.StateCommon.Border.Width = 2;
            this.UserLoginButton.StateCommon.Content.LongText.Color1 = System.Drawing.Color.Transparent;
            this.UserLoginButton.StateCommon.Content.LongText.Color2 = System.Drawing.Color.Transparent;
            this.UserLoginButton.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.UserLoginButton.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.WhiteSmoke;
            this.UserLoginButton.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserLoginButton.StatePressed.Back.Color1 = System.Drawing.Color.Red;
            this.UserLoginButton.StatePressed.Back.Color2 = System.Drawing.Color.Red;
            this.UserLoginButton.StatePressed.Border.Color1 = System.Drawing.Color.Red;
            this.UserLoginButton.StatePressed.Border.Color2 = System.Drawing.Color.Red;
            this.UserLoginButton.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.UserLoginButton.StateTracking.Border.Color1 = System.Drawing.Color.Red;
            this.UserLoginButton.StateTracking.Border.Color2 = System.Drawing.Color.Red;
            this.UserLoginButton.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.UserLoginButton.StateTracking.Border.Rounding = 15;
            this.UserLoginButton.TabIndex = 3;
            this.UserLoginButton.Values.Text = "Login";
            this.UserLoginButton.Click += new System.EventHandler(this.UserLoginButton_Click);
            // 
            // UserTextBox
            // 
            this.UserTextBox.AlwaysActive = false;
            this.UserTextBox.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny2});
            this.UserTextBox.Location = new System.Drawing.Point(1310, 499);
            this.UserTextBox.Name = "UserTextBox";
            this.UserTextBox.Size = new System.Drawing.Size(269, 40);
            this.UserTextBox.StateActive.Border.Color1 = System.Drawing.Color.Red;
            this.UserTextBox.StateActive.Border.Color2 = System.Drawing.Color.Red;
            this.UserTextBox.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.UserTextBox.StateActive.Content.Color1 = System.Drawing.SystemColors.ControlText;
            this.UserTextBox.StateCommon.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.UserTextBox.StateCommon.Border.Color1 = System.Drawing.Color.Maroon;
            this.UserTextBox.StateCommon.Border.Color2 = System.Drawing.Color.Maroon;
            this.UserTextBox.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.UserTextBox.StateCommon.Border.Rounding = 15;
            this.UserTextBox.StateCommon.Border.Width = 2;
            this.UserTextBox.StateCommon.Content.Color1 = System.Drawing.SystemColors.ControlText;
            this.UserTextBox.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserTextBox.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.UserTextBox.TabIndex = 1;
            this.UserTextBox.Enter += new System.EventHandler(this.UserTextBox_Enter);
            this.UserTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserTextBox_KeyDown);
            this.UserTextBox.Leave += new System.EventHandler(this.UserTextBox_Leave);
            // 
            // buttonSpecAny2
            // 
            this.buttonSpecAny2.UniqueName = "97F522A16BEC47F144BF65ED3DFB12B1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(391, 672);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 86);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::ComlabMonitoringSys.Properties.Resources.lock__1_1;
            this.pictureBox2.Location = new System.Drawing.Point(1281, 589);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.linkLabel1.LinkColor = System.Drawing.Color.Maroon;
            this.linkLabel1.Location = new System.Drawing.Point(1485, 635);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(73, 15);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Need Help?";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Red;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::ComlabMonitoringSys.Properties.Resources.person__3_;
            this.pictureBox3.Location = new System.Drawing.Point(1281, 497);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(27, 43);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // PassTextBox2
            // 
            this.PassTextBox2.AlwaysActive = false;
            this.PassTextBox2.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny1});
            this.PassTextBox2.Location = new System.Drawing.Point(1310, 590);
            this.PassTextBox2.Name = "PassTextBox2";
            this.PassTextBox2.Size = new System.Drawing.Size(269, 40);
            this.PassTextBox2.StateActive.Border.Color1 = System.Drawing.Color.Red;
            this.PassTextBox2.StateActive.Border.Color2 = System.Drawing.Color.Gainsboro;
            this.PassTextBox2.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.PassTextBox2.StateActive.Content.Color1 = System.Drawing.SystemColors.ControlText;
            this.PassTextBox2.StateCommon.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.PassTextBox2.StateCommon.Border.Color1 = System.Drawing.Color.Maroon;
            this.PassTextBox2.StateCommon.Border.Color2 = System.Drawing.Color.Maroon;
            this.PassTextBox2.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.PassTextBox2.StateCommon.Border.Rounding = 15;
            this.PassTextBox2.StateCommon.Border.Width = 2;
            this.PassTextBox2.StateCommon.Content.Color1 = System.Drawing.SystemColors.ControlText;
            this.PassTextBox2.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassTextBox2.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.PassTextBox2.TabIndex = 2;
            this.PassTextBox2.Enter += new System.EventHandler(this.PassTextBox2_Enter);
            this.PassTextBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PassTextBox1_KeyDown);
            this.PassTextBox2.Leave += new System.EventHandler(this.PassTextBox2_Leave);
            // 
            // buttonSpecAny1
            // 
            this.buttonSpecAny1.UniqueName = "97F522A16BEC47F144BF65ED3DFB12B1";
            // 
            // PassTextBox1
            // 
            this.PassTextBox1.Location = new System.Drawing.Point(1310, 590);
            this.PassTextBox1.Name = "PassTextBox1";
            this.PassTextBox1.Size = new System.Drawing.Size(269, 40);
            this.PassTextBox1.StateActive.Border.Color1 = System.Drawing.Color.Red;
            this.PassTextBox1.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.PassTextBox1.StateCommon.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.PassTextBox1.StateCommon.Border.Color1 = System.Drawing.Color.Gainsboro;
            this.PassTextBox1.StateCommon.Border.Color2 = System.Drawing.Color.Gainsboro;
            this.PassTextBox1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.PassTextBox1.StateCommon.Border.Rounding = 15;
            this.PassTextBox1.StateCommon.Border.Width = 2;
            this.PassTextBox1.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassTextBox1.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.PassTextBox1.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1319, 475);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 21);
            this.label2.TabIndex = 28;
            this.label2.Text = "Student ID :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1319, 566);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 21);
            this.label3.TabIndex = 29;
            this.label3.Text = "Password :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.WelcomePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.WelcomePanel.ResumeLayout(false);
            this.WelcomePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel WelcomePanel;
        private System.Windows.Forms.ToolTip toolTip1;
        private Roundtextbox.RJTextBox rjTextBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Button_round_corner.RJButton rjButton2;
        private System.Windows.Forms.Label label1;
        private Button_round_corner.RJButton rjButton3;
        private System.Windows.Forms.Timer PassCharTimer;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox PassTextBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox PassTextBox1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox UserTextBox;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton UserLoginButton;
        private ComponentFactory.Krypton.Toolkit.KryptonButton UserEye;
        private System.Windows.Forms.Timer AutoShutdownTimer;
        private System.Windows.Forms.Timer CloseOtherAppTimer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

