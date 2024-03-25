namespace HamburgerGame
{
    partial class MainMenuForm
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
            this.Label = new System.Windows.Forms.Label();
            this.FHamburgerShop = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FHamburgerShop)).BeginInit();
            this.SuspendLayout();
            // 
            // Label
            // 
            this.Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label.BackColor = System.Drawing.Color.Black;
            this.Label.Font = new System.Drawing.Font("MS UI Gothic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(12)));
            this.Label.ForeColor = System.Drawing.Color.White;
            this.Label.Location = new System.Drawing.Point(348, 331);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(307, 215);
            this.Label.TabIndex = 1;
            this.Label.Text = "入店";
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label.Click += new System.EventHandler(this.Label_Click);
            // 
            // FHamburgerShop
            // 
            this.FHamburgerShop.BackColor = System.Drawing.Color.Transparent;
            this.FHamburgerShop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FHamburgerShop.Image = global::HamburgerGame.Properties.Resources.HambugerSHOP;
            this.FHamburgerShop.Location = new System.Drawing.Point(177, 0);
            this.FHamburgerShop.Name = "FHamburgerShop";
            this.FHamburgerShop.Size = new System.Drawing.Size(647, 557);
            this.FHamburgerShop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FHamburgerShop.TabIndex = 0;
            this.FHamburgerShop.TabStop = false;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.FHamburgerShop);
            this.Name = "MainMenuForm";
            this.RightToLeftLayout = true;
            this.Text = "MainMenuForm";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FHamburgerShop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox FHamburgerShop;
        internal System.Windows.Forms.Label Label;
    }
}
