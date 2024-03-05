namespace HamburgerGame {
    partial class HamburgerGAME {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.Area_Play = new System.Windows.Forms.PictureBox();
            this.Area_Display = new System.Windows.Forms.PictureBox();
            this.Plate = new System.Windows.Forms.PictureBox();
            this.bun_under = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.Area_Play)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Area_Display)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Plate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bun_under)).BeginInit();
            this.SuspendLayout();
            // 
            // Area_Play
            // 
            this.Area_Play.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.Area_Play.Location = new System.Drawing.Point(-3, 1);
            this.Area_Play.Name = "Area_Play";
            this.Area_Play.Size = new System.Drawing.Size(703, 560);
            this.Area_Play.TabIndex = 0;
            this.Area_Play.TabStop = false;
            // 
            // Area_Display
            // 
            this.Area_Display.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Area_Display.BackColor = System.Drawing.Color.Linen;
            this.Area_Display.Location = new System.Drawing.Point(700, 1);
            this.Area_Display.Name = "Area_Display";
            this.Area_Display.Size = new System.Drawing.Size(285, 560);
            this.Area_Display.TabIndex = 1;
            this.Area_Display.TabStop = false;
            // 
            // Plate
            // 
            this.Plate.BackColor = System.Drawing.Color.White;
            this.Plate.Image = global::HamburgerGame.Properties.Resources.dish;
            this.Plate.Location = new System.Drawing.Point(293, 499);
            this.Plate.Name = "Plate";
            this.Plate.Size = new System.Drawing.Size(158, 51);
            this.Plate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Plate.TabIndex = 2;
            this.Plate.TabStop = false;
            // 
            // bun_under
            // 
            this.bun_under.Image = global::HamburgerGame.Properties.Resources.bun_under;
            this.bun_under.Location = new System.Drawing.Point(775, 452);
            this.bun_under.Name = "bun_under";
            this.bun_under.Size = new System.Drawing.Size(156, 59);
            this.bun_under.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bun_under.TabIndex = 3;
            this.bun_under.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(769, 56);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(161, 232);
            this.listBox1.TabIndex = 4;
            // 
            // HamburgerGAME
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.bun_under);
            this.Controls.Add(this.Plate);
            this.Controls.Add(this.Area_Display);
            this.Controls.Add(this.Area_Play);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HamburgerGAME";
            this.Text = "ハンバーガーゲーム";
            ((System.ComponentModel.ISupportInitialize)(this.Area_Play)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Area_Display)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Plate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bun_under)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Area_Play;
        private System.Windows.Forms.PictureBox Area_Display;
        private System.Windows.Forms.PictureBox Plate;
        private System.Windows.Forms.PictureBox bun_under;
        private System.Windows.Forms.ListBox listBox1;
    }
}

