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
            this.FAreaPlay = new System.Windows.Forms.PictureBox();
            this.FAreaDisplay = new System.Windows.Forms.PictureBox();
            this.FPlate = new System.Windows.Forms.PictureBox();
            this.FBunUnder = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FAreaPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FAreaDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FPlate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FBunUnder)).BeginInit();
            this.SuspendLayout();
            // 
            // FAreaPlay
            // 
            this.FAreaPlay.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.FAreaPlay.BackColor = System.Drawing.Color.White;
            this.FAreaPlay.Location = new System.Drawing.Point(-3, 1);
            this.FAreaPlay.Name = "FAreaPlay";
            this.FAreaPlay.Size = new System.Drawing.Size(703, 560);
            this.FAreaPlay.TabIndex = 0;
            this.FAreaPlay.TabStop = false;
            // 
            // FAreaDisplay
            // 
            this.FAreaDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FAreaDisplay.BackColor = System.Drawing.Color.Linen;
            this.FAreaDisplay.Location = new System.Drawing.Point(700, 1);
            this.FAreaDisplay.Name = "FAreaDisplay";
            this.FAreaDisplay.Size = new System.Drawing.Size(285, 560);
            this.FAreaDisplay.TabIndex = 1;
            this.FAreaDisplay.TabStop = false;
            // 
            // FPlate
            // 
            this.FPlate.BackColor = System.Drawing.Color.Transparent;
            this.FPlate.Image = global::HamburgerGame.Properties.Resources.dish;
            this.FPlate.Location = new System.Drawing.Point(293, 499);
            this.FPlate.Name = "FPlate";
            this.FPlate.Size = new System.Drawing.Size(158, 51);
            this.FPlate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FPlate.TabIndex = 2;
            this.FPlate.TabStop = false;
            // 
            // FBunUnder
            // 
            this.FBunUnder.Image = global::HamburgerGame.Properties.Resources.bun_under;
            this.FBunUnder.Location = new System.Drawing.Point(775, 452);
            this.FBunUnder.Name = "FBunUnder";
            this.FBunUnder.Size = new System.Drawing.Size(156, 59);
            this.FBunUnder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FBunUnder.TabIndex = 3;
            this.FBunUnder.TabStop = false;
            // 
            // HamburgerGAME
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.FBunUnder);
            this.Controls.Add(this.FPlate);
            this.Controls.Add(this.FAreaDisplay);
            this.Controls.Add(this.FAreaPlay);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HamburgerGAME";
            this.Text = "ハンバーガーゲーム";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HamburgerGAME_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.FAreaPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FAreaDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FPlate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FBunUnder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox FAreaPlay;
        private System.Windows.Forms.PictureBox FAreaDisplay;
        private System.Windows.Forms.PictureBox FPlate;
        private System.Windows.Forms.PictureBox FBunUnder;
    }
}

