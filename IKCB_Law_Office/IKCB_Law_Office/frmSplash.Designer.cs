
namespace IKCB_Law_Office
{
    partial class frmSplash
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
            CodeArtEng.Gauge.Themes.ThemeColors themeColors1 = new CodeArtEng.Gauge.Themes.ThemeColors();
            CodeArtEng.Gauge.Themes.ThemeColors themeColors2 = new CodeArtEng.Gauge.Themes.ThemeColors();
            CodeArtEng.Gauge.Themes.ThemeColors themeColors3 = new CodeArtEng.Gauge.Themes.ThemeColors();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar = new CodeArtEng.Gauge.LinearGauge();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.CadetBlue;
            this.label1.Location = new System.Drawing.Point(338, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "GİRİŞ YAPILIYOR...";
            // 
            // progressBar
            // 
            this.progressBar.AnimationEnabled = false;
            this.progressBar.BottomBarHeight = 8;
            this.progressBar.EndGuardWidth = 15;
            this.progressBar.ErrorLimit = 100D;
            this.progressBar.InfoMode = CodeArtEng.Gauge.GaugeInfoMode.NONE;
            this.progressBar.LabelWidth = 50;
            this.progressBar.Location = new System.Drawing.Point(2, 326);
            this.progressBar.Maximum = 100D;
            this.progressBar.Name = "progressBar";
            this.progressBar.ScaleFactor = 1D;
            this.progressBar.SegmentGap = 2;
            this.progressBar.SegmentSize = 2;
            this.progressBar.Size = new System.Drawing.Size(790, 21);
            this.progressBar.TabIndex = 2;
            this.progressBar.Theme = CodeArtEng.Gauge.GaugeTheme.DarkBlue;
            this.progressBar.Title = "";
            this.progressBar.Unit = "%";
            this.progressBar.UserDefinedColors.Base = themeColors1;
            themeColors2.PointerColor = System.Drawing.Color.Red;
            this.progressBar.UserDefinedColors.Error = themeColors2;
            themeColors3.PointerColor = System.Drawing.Color.Orange;
            this.progressBar.UserDefinedColors.Warning = themeColors3;
            this.progressBar.Value = 50D;
            this.progressBar.WarningLimit = 100D;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::IKCB_Law_Office.Properties.Resources.hukuklaw2;
            this.pictureBox10.Location = new System.Drawing.Point(209, 43);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(397, 257);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 3;
            this.pictureBox10.TabStop = false;
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(793, 352);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSplash";
            this.Load += new System.EventHandler(this.frmSplash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private CodeArtEng.Gauge.LinearGauge progressBar;
        private System.Windows.Forms.PictureBox pictureBox10;
    }
}