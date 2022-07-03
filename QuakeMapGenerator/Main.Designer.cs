namespace QuakeMapGenerator
{
    partial class Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.P2P = new System.Windows.Forms.Timer(this.components);
            this.Back = new System.Windows.Forms.Label();
            this.NowTime = new System.Windows.Forms.Label();
            this.UpdateTime = new System.Windows.Forms.Label();
            this.NowTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.RightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MapLoc = new System.Windows.Forms.ToolStripMenuItem();
            this.MapUp = new System.Windows.Forms.ToolStripMenuItem();
            this.MapDown = new System.Windows.Forms.ToolStripMenuItem();
            this.MapRight = new System.Windows.Forms.ToolStripMenuItem();
            this.MapLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.Setting = new System.Windows.Forms.ToolStripMenuItem();
            this.Bar2 = new System.Windows.Forms.ToolStripSeparator();
            this.RebootAndExit = new System.Windows.Forms.ToolStripMenuItem();
            this.Reboot = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Bar3 = new System.Windows.Forms.ToolStripSeparator();
            this.ReportBug = new System.Windows.Forms.ToolStripMenuItem();
            this.BugReportTwitter = new System.Windows.Forms.ToolStripMenuItem();
            this.AreaTextBox = new System.Windows.Forms.TextBox();
            this.Gratime = new System.Windows.Forms.Label();
            this.Info1 = new System.Windows.Forms.Label();
            this.Info3 = new System.Windows.Forms.Label();
            this.Info4 = new System.Windows.Forms.Label();
            this.Info0 = new System.Windows.Forms.Label();
            this.SaveImage = new System.Windows.Forms.Button();
            this.Info2 = new System.Windows.Forms.PictureBox();
            this.Map = new System.Windows.Forms.PictureBox();
            this.Test = new System.Windows.Forms.Label();
            this.Info3Wid = new System.Windows.Forms.Label();
            this.FileOpen = new System.Windows.Forms.Timer(this.components);
            this.Zoom = new System.Windows.Forms.ToolStripMenuItem();
            this.Bar1 = new System.Windows.Forms.ToolStripSeparator();
            this.Zoomx125 = new System.Windows.Forms.ToolStripMenuItem();
            this.Zoomx075 = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Info2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Map)).BeginInit();
            this.SuspendLayout();
            // 
            // P2P
            // 
            this.P2P.Enabled = true;
            this.P2P.Interval = 1000;
            this.P2P.Tick += new System.EventHandler(this.P2P_Tick);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.Back.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Back.Font = new System.Drawing.Font("Koruri Regular", 9F);
            this.Back.ForeColor = System.Drawing.Color.White;
            this.Back.Location = new System.Drawing.Point(961, 0);
            this.Back.Margin = new System.Windows.Forms.Padding(0);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(266, 600);
            this.Back.TabIndex = 1;
            this.Back.Text = "地図データ:気象庁";
            this.Back.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // NowTime
            // 
            this.NowTime.AutoSize = true;
            this.NowTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.NowTime.Font = new System.Drawing.Font("Roboto", 18F);
            this.NowTime.ForeColor = System.Drawing.Color.White;
            this.NowTime.Location = new System.Drawing.Point(963, 1);
            this.NowTime.Margin = new System.Windows.Forms.Padding(0);
            this.NowTime.Name = "NowTime";
            this.NowTime.Size = new System.Drawing.Size(249, 37);
            this.NowTime.TabIndex = 11;
            this.NowTime.Text = "現在時刻: -- : -- : --";
            // 
            // UpdateTime
            // 
            this.UpdateTime.AutoSize = true;
            this.UpdateTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.UpdateTime.Font = new System.Drawing.Font("Roboto", 18F);
            this.UpdateTime.ForeColor = System.Drawing.Color.White;
            this.UpdateTime.Location = new System.Drawing.Point(963, 38);
            this.UpdateTime.Margin = new System.Windows.Forms.Padding(0);
            this.UpdateTime.Name = "UpdateTime";
            this.UpdateTime.Size = new System.Drawing.Size(249, 37);
            this.UpdateTime.TabIndex = 12;
            this.UpdateTime.Text = "更新時刻: -- : -- : --";
            // 
            // NowTimeTimer
            // 
            this.NowTimeTimer.Enabled = true;
            this.NowTimeTimer.Interval = 1000;
            this.NowTimeTimer.Tick += new System.EventHandler(this.NowTime_Tick);
            // 
            // RightClick
            // 
            this.RightClick.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.RightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MapLoc,
            this.Zoom,
            this.Bar1,
            this.Setting,
            this.Bar2,
            this.RebootAndExit,
            this.Bar3,
            this.ReportBug});
            this.RightClick.Name = "RightClick";
            this.RightClick.Size = new System.Drawing.Size(211, 170);
            this.RightClick.Text = "メニュー";
            // 
            // MapLoc
            // 
            this.MapLoc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MapUp,
            this.MapDown,
            this.MapRight,
            this.MapLeft});
            this.MapLoc.Name = "MapLoc";
            this.MapLoc.Size = new System.Drawing.Size(210, 24);
            this.MapLoc.Text = "地図移動";
            // 
            // MapUp
            // 
            this.MapUp.Name = "MapUp";
            this.MapUp.Size = new System.Drawing.Size(224, 26);
            this.MapUp.Text = "上へ";
            this.MapUp.Click += new System.EventHandler(this.MapUp_Click);
            // 
            // MapDown
            // 
            this.MapDown.Name = "MapDown";
            this.MapDown.Size = new System.Drawing.Size(224, 26);
            this.MapDown.Text = "下へ";
            this.MapDown.Click += new System.EventHandler(this.MapDown_Click);
            // 
            // MapRight
            // 
            this.MapRight.Name = "MapRight";
            this.MapRight.Size = new System.Drawing.Size(224, 26);
            this.MapRight.Text = "右へ";
            this.MapRight.Click += new System.EventHandler(this.MapRight_Click);
            // 
            // MapLeft
            // 
            this.MapLeft.Name = "MapLeft";
            this.MapLeft.Size = new System.Drawing.Size(224, 26);
            this.MapLeft.Text = "左へ";
            this.MapLeft.Click += new System.EventHandler(this.MapLeft_Click);
            // 
            // Setting
            // 
            this.Setting.Name = "Setting";
            this.Setting.Size = new System.Drawing.Size(210, 24);
            this.Setting.Text = "設定";
            this.Setting.Click += new System.EventHandler(this.Setting_Click);
            // 
            // Bar2
            // 
            this.Bar2.Name = "Bar2";
            this.Bar2.Size = new System.Drawing.Size(207, 6);
            // 
            // RebootAndExit
            // 
            this.RebootAndExit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Reboot,
            this.Exit});
            this.RebootAndExit.Name = "RebootAndExit";
            this.RebootAndExit.Size = new System.Drawing.Size(210, 24);
            this.RebootAndExit.Text = "再起動・終了";
            // 
            // Reboot
            // 
            this.Reboot.Name = "Reboot";
            this.Reboot.Size = new System.Drawing.Size(224, 26);
            this.Reboot.Text = "再起動";
            this.Reboot.Click += new System.EventHandler(this.Reboot_Click);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(224, 26);
            this.Exit.Text = "終了";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Bar3
            // 
            this.Bar3.Name = "Bar3";
            this.Bar3.Size = new System.Drawing.Size(207, 6);
            // 
            // ReportBug
            // 
            this.ReportBug.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BugReportTwitter});
            this.ReportBug.Name = "ReportBug";
            this.ReportBug.Size = new System.Drawing.Size(210, 24);
            this.ReportBug.Text = "バグ報告";
            // 
            // BugReportTwitter
            // 
            this.BugReportTwitter.Name = "BugReportTwitter";
            this.BugReportTwitter.Size = new System.Drawing.Size(224, 26);
            this.BugReportTwitter.Text = "Twitter@Project-S";
            this.BugReportTwitter.Click += new System.EventHandler(this.BugReportTwitter_Click);
            // 
            // AreaTextBox
            // 
            this.AreaTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.AreaTextBox.Font = new System.Drawing.Font("Koruri Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.AreaTextBox.ForeColor = System.Drawing.Color.White;
            this.AreaTextBox.Location = new System.Drawing.Point(963, 75);
            this.AreaTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.AreaTextBox.Multiline = true;
            this.AreaTextBox.Name = "AreaTextBox";
            this.AreaTextBox.ReadOnly = true;
            this.AreaTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AreaTextBox.Size = new System.Drawing.Size(264, 474);
            this.AreaTextBox.TabIndex = 14;
            // 
            // Gratime
            // 
            this.Gratime.AutoSize = true;
            this.Gratime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.Gratime.Font = new System.Drawing.Font("Koruri Regular", 15F);
            this.Gratime.ForeColor = System.Drawing.Color.White;
            this.Gratime.Location = new System.Drawing.Point(963, 545);
            this.Gratime.Margin = new System.Windows.Forms.Padding(0);
            this.Gratime.Name = "Gratime";
            this.Gratime.Size = new System.Drawing.Size(122, 35);
            this.Gratime.TabIndex = 13;
            this.Gratime.Text = "描画時間:";
            // 
            // Info1
            // 
            this.Info1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(30)))));
            this.Info1.Font = new System.Drawing.Font("Koruri Regular", 13.8F);
            this.Info1.ForeColor = System.Drawing.Color.White;
            this.Info1.Location = new System.Drawing.Point(0, 0);
            this.Info1.Margin = new System.Windows.Forms.Padding(0);
            this.Info1.Name = "Info1";
            this.Info1.Size = new System.Drawing.Size(389, 164);
            this.Info1.TabIndex = 15;
            this.Info1.Text = "地震情報\r\n\r\n\r\n\r\n";
            // 
            // Info3
            // 
            this.Info3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.Info3.Font = new System.Drawing.Font("Koruri Regular", 16F);
            this.Info3.ForeColor = System.Drawing.Color.White;
            this.Info3.Location = new System.Drawing.Point(3, 34);
            this.Info3.Margin = new System.Windows.Forms.Padding(0);
            this.Info3.Name = "Info3";
            this.Info3.Size = new System.Drawing.Size(384, 92);
            this.Info3.TabIndex = 16;
            this.Info3.Text = "         ";
            // 
            // Info4
            // 
            this.Info4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.Info4.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Info4.ForeColor = System.Drawing.Color.White;
            this.Info4.Location = new System.Drawing.Point(216, 108);
            this.Info4.Name = "Info4";
            this.Info4.Size = new System.Drawing.Size(167, 19);
            this.Info4.TabIndex = 17;
            this.Info4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Info0
            // 
            this.Info0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.Info0.Font = new System.Drawing.Font("Koruri Regular", 8F);
            this.Info0.ForeColor = System.Drawing.Color.White;
            this.Info0.Location = new System.Drawing.Point(7, 38);
            this.Info0.Margin = new System.Windows.Forms.Padding(0);
            this.Info0.Name = "Info0";
            this.Info0.Size = new System.Drawing.Size(72, 85);
            this.Info0.TabIndex = 18;
            this.Info0.Text = "最大震度";
            this.Info0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SaveImage
            // 
            this.SaveImage.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.SaveImage.Location = new System.Drawing.Point(963, 578);
            this.SaveImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveImage.Name = "SaveImage";
            this.SaveImage.Size = new System.Drawing.Size(76, 22);
            this.SaveImage.TabIndex = 20;
            this.SaveImage.Text = "画像保存";
            this.SaveImage.UseVisualStyleBackColor = true;
            this.SaveImage.Click += new System.EventHandler(this.SaveImage_Click);
            // 
            // Info2
            // 
            this.Info2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.Info2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Info2.Location = new System.Drawing.Point(11, 59);
            this.Info2.Margin = new System.Windows.Forms.Padding(4);
            this.Info2.Name = "Info2";
            this.Info2.Size = new System.Drawing.Size(64, 60);
            this.Info2.TabIndex = 21;
            this.Info2.TabStop = false;
            // 
            // Map
            // 
            this.Map.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Map.BackgroundImage")));
            this.Map.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Map.Location = new System.Drawing.Point(0, 0);
            this.Map.Margin = new System.Windows.Forms.Padding(0);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(4000, 3104);
            this.Map.TabIndex = 0;
            this.Map.TabStop = false;
            this.Map.Click += new System.EventHandler(this.Main_Click);
            // 
            // Test
            // 
            this.Test.AutoSize = true;
            this.Test.Font = new System.Drawing.Font("MS UI Gothic", 30F);
            this.Test.ForeColor = System.Drawing.Color.White;
            this.Test.Location = new System.Drawing.Point(300, 250);
            this.Test.Name = "Test";
            this.Test.Size = new System.Drawing.Size(0, 50);
            this.Test.TabIndex = 22;
            // 
            // Info3Wid
            // 
            this.Info3Wid.AutoSize = true;
            this.Info3Wid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.Info3Wid.Font = new System.Drawing.Font("Koruri Regular", 16F);
            this.Info3Wid.ForeColor = System.Drawing.Color.White;
            this.Info3Wid.Location = new System.Drawing.Point(-133, -125);
            this.Info3Wid.Margin = new System.Windows.Forms.Padding(0);
            this.Info3Wid.Name = "Info3Wid";
            this.Info3Wid.Size = new System.Drawing.Size(80, 38);
            this.Info3Wid.TabIndex = 23;
            this.Info3Wid.Text = "         ";
            // 
            // FileOpen
            // 
            this.FileOpen.Interval = 180000;
            this.FileOpen.Tick += new System.EventHandler(this.FileOpen_Tick);
            // 
            // Zoom
            // 
            this.Zoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Zoomx125,
            this.Zoomx075});
            this.Zoom.Name = "Zoom";
            this.Zoom.Size = new System.Drawing.Size(210, 24);
            this.Zoom.Text = "拡大率調整";
            // 
            // Bar1
            // 
            this.Bar1.Name = "Bar1";
            this.Bar1.Size = new System.Drawing.Size(207, 6);
            // 
            // Zoomx125
            // 
            this.Zoomx125.Name = "Zoomx125";
            this.Zoomx125.Size = new System.Drawing.Size(224, 26);
            this.Zoomx125.Text = "x1.25";
            this.Zoomx125.Click += new System.EventHandler(this.Zoom25UP_Click);
            // 
            // Zoomx075
            // 
            this.Zoomx075.Name = "Zoomx075";
            this.Zoomx075.Size = new System.Drawing.Size(224, 26);
            this.Zoomx075.Text = "x0.75";
            this.Zoomx075.Click += new System.EventHandler(this.Zoomx075_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(1227, 600);
            this.ContextMenuStrip = this.RightClick;
            this.Controls.Add(this.Info3Wid);
            this.Controls.Add(this.Test);
            this.Controls.Add(this.Info2);
            this.Controls.Add(this.SaveImage);
            this.Controls.Add(this.Info0);
            this.Controls.Add(this.Info4);
            this.Controls.Add(this.Info3);
            this.Controls.Add(this.Info1);
            this.Controls.Add(this.AreaTextBox);
            this.Controls.Add(this.Gratime);
            this.Controls.Add(this.UpdateTime);
            this.Controls.Add(this.NowTime);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Map);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "QuakeMapGenerator";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.RightClick.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Info2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Map)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Map;
        private System.Windows.Forms.Timer P2P;
        private System.Windows.Forms.Label Back;
        private System.Windows.Forms.Label NowTime;
        private System.Windows.Forms.Label UpdateTime;
        private System.Windows.Forms.Timer NowTimeTimer;
        private System.Windows.Forms.ContextMenuStrip RightClick;
        private System.Windows.Forms.ToolStripMenuItem MapLoc;
        private System.Windows.Forms.ToolStripMenuItem MapUp;
        private System.Windows.Forms.ToolStripMenuItem MapDown;
        private System.Windows.Forms.ToolStripMenuItem MapRight;
        private System.Windows.Forms.ToolStripMenuItem MapLeft;
        private System.Windows.Forms.ToolStripMenuItem Setting;
        private System.Windows.Forms.ToolStripSeparator Bar2;
        private System.Windows.Forms.ToolStripMenuItem RebootAndExit;
        private System.Windows.Forms.ToolStripMenuItem Reboot;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripSeparator Bar3;
        private System.Windows.Forms.ToolStripMenuItem ReportBug;
        private System.Windows.Forms.ToolStripMenuItem BugReportTwitter;
        private System.Windows.Forms.TextBox AreaTextBox;
        private System.Windows.Forms.Label Gratime;
        private System.Windows.Forms.Label Info1;
        private System.Windows.Forms.Label Info4;
        private System.Windows.Forms.Label Info0;
        private System.Windows.Forms.Label Info3;
        private System.Windows.Forms.Button SaveImage;
        private System.Windows.Forms.PictureBox Info2;
        private System.Windows.Forms.Label Test;
        private System.Windows.Forms.Label Info3Wid;
        private System.Windows.Forms.Timer FileOpen;
        private System.Windows.Forms.ToolStripMenuItem Zoom;
        private System.Windows.Forms.ToolStripSeparator Bar1;
        private System.Windows.Forms.ToolStripMenuItem Zoomx125;
        private System.Windows.Forms.ToolStripMenuItem Zoomx075;
    }
}

