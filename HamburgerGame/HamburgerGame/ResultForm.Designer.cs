namespace HamburgerGame
{
    partial class ResultForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FDish = new System.Windows.Forms.PictureBox();
            this.FBunUnder = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FDish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FBunUnder)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 40F);
            this.label1.Location = new System.Drawing.Point(406, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 57);
            this.label1.TabIndex = 1;
            this.label1.Text = "完成 !!";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.label2.Location = new System.Drawing.Point(365, 491);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "MainMenuFormに戻る [Enter]";
            // 
            // FDish
            // 
            this.FDish.BackColor = System.Drawing.Color.Transparent;
            this.FDish.Image = global::HamburgerGame.Properties.Resources.dish;
            this.FDish.Location = new System.Drawing.Point(281, 307);
            this.FDish.Name = "FDish";
            this.FDish.Size = new System.Drawing.Size(423, 164);
            this.FDish.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FDish.TabIndex = 0;
            this.FDish.TabStop = false;
            this.FDish.Visible = false;
            // 
            // FBunUnder
            // 
            this.FBunUnder.BackColor = System.Drawing.Color.Transparent;
            this.FBunUnder.Image = global::HamburgerGame.Properties.Resources.bun_under;
            this.FBunUnder.Location = new System.Drawing.Point(354, 255);
            this.FBunUnder.Name = "FBunUnder";
            this.FBunUnder.Size = new System.Drawing.Size(277, 146);
            this.FBunUnder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FBunUnder.TabIndex = 3;
            this.FBunUnder.TabStop = false;
            this.FBunUnder.Visible = false;
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.FBunUnder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FDish);
            this.Name = "ResultForm";
            this.Text = "ResultForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ResultForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.FDish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FBunUnder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox FDish;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox FBunUnder;
    }
}